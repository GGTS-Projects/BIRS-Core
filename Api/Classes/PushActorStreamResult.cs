using Akka.Actor;
using Api.Classes.Eventing;
using Api.Classes.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace Api.Classes
{
    public class PushActorStreamResult : IActionResult
    {
        private readonly string _contentType;

        private readonly IEventConnectionHolderActorRef _connectionHolderActorRef;

        private readonly IPersistenceActorRef _persistence;

        public PushActorStreamResult(IEventConnectionHolderActorRef pConnectionHolderActorRef, string pContentType,
                                     IPersistenceActorRef pPersistence)
        {
            _contentType = pContentType;
            _connectionHolderActorRef = pConnectionHolderActorRef;
            _persistence = pPersistence;
        }

        public Task ExecuteResultAsync(ActionContext pContext)
        {
            var stream = pContext.HttpContext.Response.Body;
            pContext.HttpContext.Response.GetTypedHeaders().ContentType = new Microsoft.Net.Http.Headers.MediaTypeHeaderValue(_contentType);

            return _connectionHolderActorRef.GetActorRef()
                                            .Ask(new ConnectionHolder.NewConnection(
                                                         stream, pContext.HttpContext.RequestAborted,
                                                         _persistence.GetActorRef()));
        }
    }
}
