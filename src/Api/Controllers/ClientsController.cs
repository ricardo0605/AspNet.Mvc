using Application.Dtos;
using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    //[EnableCors(origins: "http://mywebclient.azurewebsites.net, http://mywebclient2.azurewebsites.net", headers: "*", methods: "GET,POST,PUT")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientsController : ApiController
    {
        private readonly IRegistryApplicationService _service;

        public ClientsController(IRegistryApplicationService service)
        {
            _service = service;
        }

        // GET: api/Clients
        public IEnumerable<ClientDto> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Clients/5
        public ClientDto Get(Guid id)
        {
            return _service.GetById(id);
        }

        // POST: api/Clients
        public void Post([FromBody]string value)
        {
            _service.Add(JsonConvert.DeserializeObject<ClientDto>(value));
        }

        // PUT: api/Clients/5
        public void Put(Guid id, [FromBody]string value)
        {
            _service.Update(JsonConvert.DeserializeObject<ClientDto>(value));
        }

        // DELETE: api/Clients/5
        public void Delete(Guid id)
        {
            _service.Remove(id);
        }
    }
}
