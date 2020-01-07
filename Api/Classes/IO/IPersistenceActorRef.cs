using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Classes.IO
{
    public interface IPersistenceActorRef
    {
        IActorRef GetActorRef();
    }
}
