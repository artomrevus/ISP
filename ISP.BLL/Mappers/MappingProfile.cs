using AutoMapper;
using ISP.BLL.DTOs.ISP.Candidate;
using ISP.BLL.DTOs.ISP.City;
using ISP.BLL.DTOs.ISP.Client;
using ISP.BLL.DTOs.ISP.ClientStatus;
using ISP.BLL.DTOs.ISP.Connection;
using ISP.BLL.DTOs.ISP.ConnectionEquipment;
using ISP.BLL.DTOs.ISP.ConnectionTariff;
using ISP.BLL.DTOs.ISP.Contract;
using ISP.BLL.DTOs.ISP.ContractStatus;
using ISP.BLL.DTOs.ISP.Employee;
using ISP.BLL.DTOs.ISP.EmployeePosition;
using ISP.BLL.DTOs.ISP.EmployeeStatus;
using ISP.BLL.DTOs.ISP.Equipment;
using ISP.BLL.DTOs.ISP.EquipmentType;
using ISP.BLL.DTOs.ISP.House;
using ISP.BLL.DTOs.ISP.InternetConnectionRequest;
using ISP.BLL.DTOs.ISP.InternetConnectionRequestStatus;
using ISP.BLL.DTOs.ISP.InternetTariff;
using ISP.BLL.DTOs.ISP.InternetTariffStatus;
using ISP.BLL.DTOs.ISP.Interview;
using ISP.BLL.DTOs.ISP.InterviewRequest;
using ISP.BLL.DTOs.ISP.InterviewRequestStatus;
using ISP.BLL.DTOs.ISP.InterviewResult;
using ISP.BLL.DTOs.ISP.Location;
using ISP.BLL.DTOs.ISP.LocationType;
using ISP.BLL.DTOs.ISP.Office;
using ISP.BLL.DTOs.ISP.OfficeEquipment;
using ISP.BLL.DTOs.ISP.Street;
using ISP.BLL.DTOs.ISP.Vacancy;
using ISP.BLL.DTOs.ISP.VacancyStatus;
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
        
        CreateMap<InternetTariff, GetInternetTariffDto>();
        CreateMap<AddInternetTariffDto, InternetTariff>();
        CreateMap<UpdateInternetTariffDto, InternetTariff>();
        
        CreateMap<InternetTariffStatus, GetInternetTariffStatusDto>();
        CreateMap<AddInternetTariffStatusDto, InternetTariffStatus>();
        CreateMap<UpdateInternetTariffStatusDto, InternetTariffStatus>();
        
        CreateMap<InternetConnectionRequestStatus, GetInternetConnectionRequestStatusDto>();
        CreateMap<AddInternetConnectionRequestStatusDto, InternetConnectionRequestStatus>();
        CreateMap<UpdateInternetConnectionRequestStatusDto, InternetConnectionRequestStatus>();
        
        CreateMap<ConnectionTariff, GetConnectionTariffDto>();
        CreateMap<AddConnectionTariffDto, ConnectionTariff>();
        CreateMap<UpdateConnectionTariffDto, ConnectionTariff>();
        
        CreateMap<InternetConnectionRequest, GetInternetConnectionRequestDto>();
        CreateMap<AddInternetConnectionRequestDto, InternetConnectionRequest>();
        CreateMap<UpdateInternetConnectionRequestDto, InternetConnectionRequest>();
        
        CreateMap<Connection, GetConnectionDto>();
        CreateMap<AddConnectionDto, Connection>();
        CreateMap<UpdateConnectionDto, Connection>();
        
        CreateMap<ConnectionEquipment, GetConnectionEquipmentDto>();
        CreateMap<AddConnectionEquipmentDto, ConnectionEquipment>();
        CreateMap<UpdateConnectionEquipmentDto, ConnectionEquipment>();
        
        CreateMap<OfficeEquipment, GetOfficeEquipmentDto>();
        CreateMap<AddOfficeEquipmentDto, OfficeEquipment>();
        CreateMap<UpdateOfficeEquipmentDto, OfficeEquipment>();
        
        CreateMap<Equipment, GetEquipmentDto>();
        CreateMap<AddEquipmentDto, Equipment>();
        CreateMap<UpdateEquipmentDto, Equipment>();
        
        CreateMap<EquipmentType, GetEquipmentTypeDto>();
        CreateMap<AddEquipmentTypeDto, EquipmentType>();
        CreateMap<UpdateEquipmentTypeDto, EquipmentType>();
        
        CreateMap<Contract, GetContractDto>();
        CreateMap<AddContractDto, Contract>();
        CreateMap<UpdateContractDto, Contract>();
        
        CreateMap<Interview, GetInterviewDto>();
        CreateMap<AddInterviewDto, Interview>();
        CreateMap<UpdateInterviewDto, Interview>();
        
        CreateMap<InterviewRequest, GetInterviewRequestDto>();
        CreateMap<AddInterviewRequestDto, InterviewRequest>();
        CreateMap<UpdateInterviewRequestDto, InterviewRequest>();
        
        CreateMap<Candidate, GetCandidateDto>();
        CreateMap<AddCandidateDto, Candidate>();
        CreateMap<UpdateCandidateDto, Candidate>();
        
        CreateMap<Vacancy, GetVacancyDto>();
        CreateMap<AddVacancyDto, Vacancy>();
        CreateMap<UpdateVacancyDto, Vacancy>();
        
        CreateMap<VacancyStatus, GetVacancyStatusDto>();
        CreateMap<AddVacancyStatusDto, VacancyStatus>();
        CreateMap<UpdateVacancyStatusDto, VacancyStatus>();
        
        CreateMap<ContractStatus, GetContractStatusDto>();
        CreateMap<AddContractStatusDto, ContractStatus>();
        CreateMap<UpdateContractStatusDto, ContractStatus>();
        
        CreateMap<InterviewRequestStatus, GetInterviewRequestStatusDto>();
        CreateMap<AddInterviewRequestStatusDto, InterviewRequestStatus>();
        CreateMap<UpdateInterviewRequestStatusDto, InterviewRequestStatus>();
        
        CreateMap<InterviewResult, GetInterviewResultDto>();
        CreateMap<AddInterviewResultDto, InterviewResult>();
        CreateMap<UpdateInterviewResultDto, InterviewResult>();
    }
}