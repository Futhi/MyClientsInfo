using ClientManagementService;
using ClientManagementService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyClientsInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;

        public ClientController(IClientRepository client, IAddressRepository address, IContactRepository contact)
        {
            _clientRepository = client;
            _addressRepository = address;
            _contactRepository = contact;
        }

        // GET: ClientController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("GetClients")]
        public IEnumerable<Client> GetClients()
        {
            var clients = _clientRepository.GetAllClients();
            if (clients == null || !clients.Any())
            {
                return null;
            }
            return clients;

        }

        [HttpGet("GetClient/{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _clientRepository.GetClient(id);
            if (client == null )
            {
                return NotFound("No client found.");
            } 
            return Ok(client);

        }

        [HttpPost("Create")]
        public IActionResult Create(Client client)
        {
            var clients = _clientRepository.GetAllClients();
            var existingClient = clients.FirstOrDefault(x => x.Name == client.Name );

            if (existingClient == null)
            {
                _clientRepository.AddClient(client);               
            }
            else
            {
                return BadRequest(existingClient.Name + " exists");
            }

            return Ok("Client added successfully.");

        }

        [HttpPut("UpdateClient/{id}")]
        public IActionResult UpdateClient(int id,Client client)
        {
            var existingClient = _clientRepository.GetClient(id);
            if (existingClient == null)
            {
                return NotFound("No client found.");
            }

            client.Id = id;  // just for confirmation
            _clientRepository.UpdateClient(client);
            return Ok("Client updated successfully.");
        }

        [HttpDelete("DeleteClient/{id}")]
        public IActionResult DeleteClient(int id)
        {
            var existingClient = _clientRepository.GetClient(id);
            if (existingClient == null)
            {
                return NotFound("No client found.");
            }
            else
            {
                _addressRepository.DeleteAddressByClient(id);           
                _contactRepository.DeleteContactByClient(id);
                _clientRepository.DeleteClient(id);
            }

            
            return Ok("Client data deleted successfully.");
        }

     
    }
}
