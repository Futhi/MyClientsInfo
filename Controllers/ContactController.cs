using ClientManagementService.Model;
using ClientManagementService;
using Microsoft.AspNetCore.Mvc;

namespace MyClientsInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // Get all contacts for a client
        [HttpGet("GetContacts/{clientId}")]
        public IEnumerable<Contact> GetContacts(int clientId)
        {
            var contacts = _contactRepository.GetContactsByClientId(clientId);
            if (contacts == null || !contacts.Any())
            {
                return null;
            }
            return contacts;
        }

        // Add a new contact
        [HttpPost("AddContact")]
        public IActionResult AddContact([FromBody] Contact contact)
        {
            _contactRepository.AddContact(contact);
            return Ok("Contact added successfully.");
        }

        // Update an existing contact
        [HttpPut("UpdateContact/{contactId}")]
        public IActionResult UpdateContact(int contactId, [FromBody] Contact contact)
        {
            var existingContact = _contactRepository.GetContactsByClientId(contact.Id).FirstOrDefault(c => c.Id == contactId);
            if (existingContact == null)
            {
                return NotFound("No contact found.");
            }

            contact.Id = contactId;
            _contactRepository.UpdateContact(contact);
            return Ok("Contact updated successfully.");
        }

        // Delete a contact
        [HttpDelete("DeleteContact/{contactId}")]
        public IActionResult DeleteContact(int contactId)
        {
            var existingContact = _contactRepository.GetContactsByClientId(contactId).FirstOrDefault();
            if (existingContact == null)
            {
                return NotFound("No contact found.");
            }

            _contactRepository.DeleteContact(contactId);
            return Ok("Contact deleted successfully.");
        }
    }
}
