using SF.Async.Core.Definitions;
using SF.Async.Org.Builder;
using System;
using System.Threading.Tasks;
using static SF.Async.Org.Delegates;

namespace SF.Async.Org.Extensions
{
    using FuncLikeCompWihtSinglePare = Func<MessageDefinition, Task>;
    using FuncLikeCompWithTwoParas = Func<MessageDefinition, MesageContextDelegate, Task>;

    public static class FollowingBuilderExtension
    {
        public static IFollowingBuilder UseFollowerEx(this IFollowingBuilder builder, FuncLikeCompWithTwoParas funcLikeCompWithTwoParas)
        {
            builder.UseFollower(next => message => funcLikeCompWithTwoParas(message, next));
            return builder;
        }

        public static IFollowingBuilder UseFollowerEx(this IFollowingBuilder builder, FuncLikeCompWihtSinglePare funcLikeCompWihtSinglePare)
        {
            builder.UseFollower(next => message => funcLikeCompWihtSinglePare(message));
            return builder;
        }

    }
}
