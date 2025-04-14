using AutoMapper;
using ISP.BLL.DTOs.ISP.City;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.BLL.DTOs.ISP.Employee;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.BLL.DTOs.ISP.House;
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.BLL.DTOs.ISP.Office;
using ISP.BLL.DTOs.ISP.Street;
using ISP.BLL.DTOs.Monitoring;
using ISP.DAL.Entities;

namespace ISP.BLL.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserActivity, GetUserActivityDto>();
        
        CreateMap<City, GetCityDto>();
        CreateMap<AddCityDto, City>();
        CreateMap<UpdateCityDto, City>();
        
        CreateMap<Client, GetClientDto>();
        CreateMap<AddClientDto, Client>();
        CreateMap<UpdateClientDto, Client>();
        
        CreateMap<ClientStatus, GetClientStatusDto>();
        CreateMap<AddClientStatusDto, ClientStatus>();
        CreateMap<UpdateClientStatusDto, ClientStatus>();
        
        CreateMap<EmployeePosition, GetEmployeePositionDto>();
        CreateMap<AddEmployeePositionDto, EmployeePosition>();
        CreateMap<UpdateEmployeePositionDto, EmployeePosition>();
        
        CreateMap<Employee, GetEmployeeDto>();
        CreateMap<AddEmployeeDto, Employee>();
        CreateMap<UpdateEmployeeDto, Employee>();
        
        CreateMap<EmployeeStatus, GetEmployeeStatusDto>();
        CreateMap<AddEmployeeStatusDto, EmployeeStatus>();
        CreateMap<UpdateEmployeeStatusDto, EmployeeStatus>();
        
        CreateMap<House, GetHouseDto>();
        CreateMap<AddHouseDto, House>();
        CreateMap<UpdateHouseDto, House>();
        
        CreateMap<Location, GetLocationDto>();
        CreateMap<AddLocationDto, Location>();
        CreateMap<UpdateLocationDto, Location>();
        
        CreateMap<LocationType, GetLocationTypeDto>();
        CreateMap<AddLocationTypeDto, LocationType>();
        CreateMap<UpdateLocationTypeDto, LocationType>();
        
        CreateMap<Office, GetOfficeDto>();
        CreateMap<AddOfficeDto, Office>();
        CreateMap<UpdateOfficeDto, Office>();
        
        CreateMap<Street, GetStreetDto>();
        CreateMap<AddStreetDto, Street>();
        CreateMap<UpdateStreetDto, Street>();
    }
}