using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIRS_api.Classes.Eventing
{
    /// <summary>
    /// Wrapper class to pass a dedicated actorRef into a controller,
    /// with the dotnet mvc dependency injection.
    /// </summary>
    public class EventConnectionHolderActorRef : IEventConnectionHolderActorRef
    {
        private readonly IActorRef EventConnectionHolderActorWrapper;

        public EventConnectionHolderActorRef(IActorRef pEventConnectionHolderActorWrapper) =>
                EventConnectionHolderActorWrapper = pEventConnectionHolderActorWrapper;

        public IActorRef GetActorRef() => EventConnectionHolderActorWrapper;
    }
}
