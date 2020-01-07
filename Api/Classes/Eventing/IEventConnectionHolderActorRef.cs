using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Classes.Eventing
{
    public interface IEventConnectionHolderActorRef
    {
        IActorRef GetActorRef();
    }
}
