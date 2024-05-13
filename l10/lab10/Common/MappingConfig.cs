using AutoMapper;
using Laborator10.Models;
using Laborator10.Models.UI;

namespace Laborator10.Common;

public class MappingConfig
{
    internal static IMapper Configure()
    {
        MapperConfiguration automapperConfig = new(cfg => {
            cfg.CreateMap<StireModel, StireModelUI>().ReverseMap();
            cfg.CreateMap<StireModel, StireModelMutation>().ReverseMap();
        });

        // Alternativ putem face mapping pe fiecare directie individual
        /*MapperConfiguration automapperConfig = new(cfg => {
            cfg.CreateMap<StireModel, StireModelUI>(MemberList.Source);
            cfg.CreateMap<StireModelUI, StireModel>(MemberList.Destination);
        });*/

        try
        {
            automapperConfig.AssertConfigurationIsValid();
        }
        catch (Exception ex)
        {
            throw;
        }

        return new Mapper(automapperConfig);
    }
}
