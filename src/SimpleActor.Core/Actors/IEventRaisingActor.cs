﻿using System.Threading.Tasks;

namespace SimpleActor.Core.Actors
{
    public interface IEventRaisingActor<in T>
    {
        void ApplyChange(T @event);
    }
}
