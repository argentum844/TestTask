using AutoMapper;
using Dadata;
using Dadata.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationDaData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleanAddressController : ControllerBase
    {
        // GET: api/<CleanAddressController>
        [HttpGet("{address}")]
        public async Task<UserAddress> Get(string address, IOptions<DaDataConfiguration> options, IMapper mapper)
        {
            DaDataConfiguration configuration = options.Value;
            var api = new CleanClientAsync(configuration.APIKey, configuration.APISecret);
            var result = await api.Clean<Address>(address);
            UserAddress res = mapper.Map<UserAddress>(result);
            return res;
        }
    }
}
