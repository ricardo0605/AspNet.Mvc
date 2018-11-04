using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<AddressDto, Address>();
            CreateMap<ClientAddressDto, Client>();
            CreateMap<ClientAddressDto, Address>();
        }
    }
}
