using System.Threading.Tasks;

namespace SimpleActor.Core.Actors
{
    public interface IAggregateActor<T>
    {
        void Apply(T @event);
    }
}
