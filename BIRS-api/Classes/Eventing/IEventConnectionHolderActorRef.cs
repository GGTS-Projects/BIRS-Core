using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIRS_api.Classes.Eventing
{
    public interface IEventConnectionHolderActorRef
    {
        IActorRef GetActorRef();
    }
}
