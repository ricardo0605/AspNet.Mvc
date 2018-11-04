using AutoMapper;

namespace Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToDtoMappingProfile>();
                config.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}
