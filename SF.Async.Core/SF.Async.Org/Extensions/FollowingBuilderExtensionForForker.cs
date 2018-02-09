using SF.Async.Core;
using SF.Async.Org.Builder;
using SF.Async.Org.Usages;
using System;

namespace SF.Async.Org.Extensions
{
    public static class FollowingBuilderExtensionForForker
    {
        public static IFollowingBuilder UseForker(this IFollowingBuilder builder, MessageStatus forkerStatus, Action<IFollowingBuilder> action)
        {
            var subBuilder = new FollowingBuilder(new ForkerTrackerImpl(type => builder.GetService(type)));
            action(subBuilder);
            var following = subBuilder.FollowingBuild<CommonFollowing>();
            return builder.UseFollowerEx((message, next) => {

                if(forkerStatus == message.MessageStatus)
                {
                    following.CatchAsync(message);
                }

                return next?.Invoke(message);
            });
        }
    }
}
