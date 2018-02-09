using SF.Async.Org.Abstractions;
using SF.Async.Org.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Org.Extensions
{
    public static class FollowingBuilderExtensionForFollower
    {
        public static IFollowingBuilder UseFollower<Tfollower>(this IFollowingBuilder builder)
            where Tfollower : FollowerBase
        {
            var constructor = typeof(Tfollower)
                .GetTypeInfo()
                .DeclaredConstructors
                .SingleOrDefault();

            var paras = constructor.GetParameters();

            var dependencyParas = paras.Select(para =>
            {
                return builder.GetService(para.ParameterType);
            }).ToArray();

            var instance = (Tfollower)Activator.CreateInstance(typeof(Tfollower), dependencyParas);

            builder.UseFollowerEx((context, next) =>
            {
                instance.Next = next;
                return instance.Process(context);
            });
            return builder;
        }
    }
}
