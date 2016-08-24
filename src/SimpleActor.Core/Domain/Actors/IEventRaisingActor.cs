using System.Threading.Tasks;
using SimpleActor.Core.Messages;

namespace SimpleActor.Core.Domain.Actors
{
    public interface IEventRaisingActor<in T, TResult> where T : IDomainCommand where TResult : IDomainEvent
    {
        Task<TResult> Handle(T cmd);
    }
}
