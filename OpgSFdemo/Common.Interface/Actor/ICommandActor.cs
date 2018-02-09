
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Common.Interface.Actor
{
    public interface ICommandActor : IActor
    {
        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync(CancellationToken cancellationToken);

        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task SetCountAsync(int count, CancellationToken cancellationToken);


        Task<int> GetScore(CancellationToken cancellationToken);

        Task AddScore(int score, CancellationToken cancellationToken);


        Task<int> InputOperation(string type, int value, CancellationToken cancellationToken);

    }
}
