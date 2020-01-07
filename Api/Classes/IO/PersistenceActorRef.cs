using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;

namespace Api.Classes.IO
{
    

    /// <summary>
    /// Wrapper class to pass a dedicated actorRef into a controller,
    /// with the dotnet mvc dependency injection.
    /// </summary>
    public class PersistenceActorRef : IPersistenceActorRef
    {
        private readonly IActorRef SharpestChainPersitenceActorWrapper;

        public PersistenceActorRef(IActorRef pSharpestChainPersistenceActorWrapper) =>
                SharpestChainPersitenceActorWrapper = pSharpestChainPersistenceActorWrapper;

        public IActorRef GetActorRef() => SharpestChainPersitenceActorWrapper;
    }
}
