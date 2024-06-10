using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _clientService;
        private readonly AddressService _addressService;
        public ClientsController(ClientService clientsController, AddressService addressService)
        {
            _clientService = clientsController;
            _addressService = addressService;
        }
        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.Get();
        [HttpGet("{id:length(24)}", Name = "GetCustomerById")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
        [HttpPost]
        public ActionResult<Client> Post(Client client)
        {
            var x = _addressService.Create(client.Address);
            client.Address = x;
            var c = _clientService.Create(client);
            if (c == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCustomerById", new { id = client.Id }, c);
        }
    }
}
