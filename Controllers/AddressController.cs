using ClientManagementService.Model;
using ClientManagementService;
using Microsoft.AspNetCore.Mvc;

namespace MyClientsInfo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        // Get all addresses for a client
        [HttpGet("GetAddresses/{clientId}")]
        public IEnumerable<Address> GetAddresses(int clientId)
        {
            var addresses = _addressRepository.GetAddressesByClientId(clientId);
            if (addresses == null || !addresses.Any())
            {
                return null;
            }
            return addresses;
        }

        // Add a new address
        [HttpPost("AddAddress")]
        public IActionResult AddAddress(List<Address> addresses)
        {
            foreach(var address in addresses)
            {
                _addressRepository.AddAddress(address);
            }
            
            return Ok("Address added successfully.");
        }

        // Update an existing address
        [HttpPut("UpdateAddress/{addressId}")]
        public IActionResult UpdateAddress(int addressId,Address address)
        {
            var existingAddress = _addressRepository.GetAddressesByClientId(address.Id).FirstOrDefault(a => a.Id == addressId);
            if (existingAddress == null)
            {
                return NotFound("No address found.");
            }

            address.Id = addressId;
            _addressRepository.UpdateAddress(address);
            return Ok("Address updated successfully.");
        }

        // Delete an address
        [HttpDelete("DeleteAddress/{addressId}")]
        public IActionResult DeleteAddress(int addressId)
        {
            var existingAddress = _addressRepository.GetAddressesByClientId(addressId).FirstOrDefault();
            if (existingAddress == null)
            {
                return NotFound("No address found.");
            }

            _addressRepository.DeleteAddress(addressId);
            return Ok("Address deleted successfully.");
        }
    }
}
