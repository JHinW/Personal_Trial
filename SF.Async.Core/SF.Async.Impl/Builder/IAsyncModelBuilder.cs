using SF.Async.Cross;
using SF.Async.EasyDI;
using SF.Async.Org.Builder;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF.Async.Impl.Builder
{
    using FollowingConfigureDelegate = Action<IFollowingBuilder>;
    using EasyDIConfigureDelegate = Action<IContainer>;

    public interface IAsyncModelBuilder
    {
        IAsyncModelBuilder ConfigureServices(EasyDIConfigureDelegate easyDIConfigureDelegate);

        IAsyncModelBuilder ConfigureFollowingDelegate(FollowingConfigureDelegate followingConfigureDelegate);

        TModel Build<TModel>() where TModel : ITransferer;
    }
}
