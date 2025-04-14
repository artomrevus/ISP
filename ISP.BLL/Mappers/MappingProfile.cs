using AutoMapper;
using ISP.BLL.DTOs.ISP.City;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.DTOs.Monitoring;
using ISP.DAL.Entities;

namespace ISP.BLL.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserActivity, GetUserActivityDto>();
        
        CreateMap<Client, GetClientDto>();
        CreateMap<AddClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
        
        CreateMap<City, GetCityDto>();
        CreateMap<AddCityDto, City>();
        CreateMap<UpdateCityDto, City>();
        
        CreateMap<ClientStatus, GetClientStatusDto>();
        CreateMap<AddClientStatusDto, ClientStatus>();
        CreateMap<UpdateClientStatusDto, ClientStatus>();
        
        CreateMap<EmployeePosition, GetEmployeePositionDto>();
        CreateMap<AddEmployeePositionDto, EmployeePosition>();
        CreateMap<UpdateEmployeePositionDto, EmployeePosition>();
    }
}