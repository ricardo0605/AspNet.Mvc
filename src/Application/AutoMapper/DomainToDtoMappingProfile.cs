using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<Client, ClientAddressDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Address, ClientAddressDto>();
        }
    }
}
