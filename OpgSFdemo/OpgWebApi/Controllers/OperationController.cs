using Common.Interface.Actor;
using Common.Model.Responese;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using OpgWebApi.Src.Factory;
using OpgWebApi.Src.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace OpgWebApi.Controllers
{
    [ServiceRequestActionFilter]
    public class OperationController : ApiController
    {

        //[HttpGet]
        public async Task<ResponseModel> Get([FromUri]string type, [FromUri]int value)
        {
            var actorService = FactoryBase.GetActorService<CommandGetter, ICommandActor>("10");
            var ret = await actorService.InputOperation(type, value, CancellationToken.None);

            // for simply access actor proxy
            /*
            ActorId actorclient0 = new ActorId("actorclient0");
            var proxy2 = ActorProxy.Create<ICommandActor>(actorclient0, "fabric:/OpgSFdemo/CommandActorService");
            var ret2 = await proxy2.InputOperation(type, value, CancellationToken.None);
            */

            return new ResponseModel
            {
                Type = type,
                Value = ret
            };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }

    }
}
