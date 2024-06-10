﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_API.Models;
using MongoDB_API.Services;

namespace MongoDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressesController(AddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpGet]
        public ActionResult<List<Address>> Get()
        {
            return _addressService.Get();
        }
        [HttpGet("{id:length(24)}", Name = "GetAddress")]
        public ActionResult<Address> Get(string id)
        {
            return _addressService.Get(id);
        }

        [HttpGet("{cep:length(8)}")]
        public async Task<ActionResult<AddressDTO>> GetPostOffice(string cep)
        {
            return await PostOfficeServices.GetAddress(cep);
        }

        [HttpPost]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);
            return CreatedAtRoute("GetAddress", new { id = address.Id }, address);
        }
    }
}
