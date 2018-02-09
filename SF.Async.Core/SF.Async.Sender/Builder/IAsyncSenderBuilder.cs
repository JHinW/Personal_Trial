using SF.Async.Cross;
using SF.Async.EasyDI;
using SF.Async.Org.Builder;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Sender.Builder
{
    using FollowingConfigureDelegate = Action<IFollowingBuilder>;
    using EasyDIConfigureDelegate = Action<IContainer>;

    public interface IAsyncSenderBuilder
    {
        IAsyncSenderBuilder ConfigureServices(EasyDIConfigureDelegate easyDIConfigureDelegate);

        IAsyncSenderBuilder ConfigureFollowingDelegate(FollowingConfigureDelegate followingConfigureDelegate);

        TModel Build<TModel>() where TModel : ITransferer;
    }
}
