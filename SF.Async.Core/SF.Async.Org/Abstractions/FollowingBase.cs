using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF.Async.Core.Definitions;
using static SF.Async.Org.Delegates;
using System.Threading;

namespace SF.Async.Org.Abstractions
{
    public abstract class FollowingBase : IFollowing
    {
        private MesageContextDelegate _mesageContextDelegate;

        private SemaphoreSlim _metex = new SemaphoreSlim(10);

        public FollowingBase(MesageContextDelegate mesageContextDelegate)
        {
            _mesageContextDelegate = mesageContextDelegate;
        }

        public Task CatchAsync(MessageDefinition message)
        {
            if(message == null)
            {
                throw new ArgumentNullException("Exception: message is null.");
            }

            return Task.Factory.StartNew(async () =>
            {
                if (_mesageContextDelegate != null)
                {
                    try
                    {
                        await _metex.WaitAsync();
                        await _mesageContextDelegate(message);
                    }

                    catch (Exception e)
                    {
                        throw new InvalidOperationException(e.Message);
                    }
                    finally
                    {
                        _metex.Release();
                    }

                }
            }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
        }
    }
}
