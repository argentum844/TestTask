
using AutoMapper;
using Dadata.Model;

namespace WebApplicationDaData
{
    public class AppMapping:Profile
    {
        public AppMapping()
        {
            CreateMap<Address, UserAddress>();
        }
    }
}
