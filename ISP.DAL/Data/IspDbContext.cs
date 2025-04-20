using ISP.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISP.DAL.Data;

public partial class IspDbContext(DbContextOptions<IspDbContext> options) : DbContext(options)
{
    public virtual DbSet<Candidate> Candidates { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientStatus> ClientStatuses { get; set; }

    public virtual DbSet<Connection> Connections { get; set; }

    public virtual DbSet<ConnectionEquipment> ConnectionEquipments { get; set; }

    public virtual DbSet<ConnectionTariff> ConnectionTariffs { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractStatus> ContractStatuses { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }

    public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentPlacement> EquipmentPlacements { get; set; }

    public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

    public virtual DbSet<House> Houses { get; set; }

    public virtual DbSet<InternetConnectionRequest> InternetConnectionRequests { get; set; }

    public virtual DbSet<InternetConnectionRequestStatus> InternetConnectionRequestStatuses { get; set; }

    public virtual DbSet<InternetTariff> InternetTariffs { get; set; }

    public virtual DbSet<InternetTariffStatus> InternetTariffStatuses { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<InterviewRequest> InterviewRequests { get; set; }

    public virtual DbSet<InterviewRequestStatus> InterviewRequestStatuses { get; set; }

    public virtual DbSet<InterviewResult> InterviewResults { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationType> LocationTypes { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<OfficeEquipment> OfficeEquipments { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<PurchaseEquipment> PurchaseEquipments { get; set; }

    public virtual DbSet<PurchaseStatus> PurchaseStatuses { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    public virtual DbSet<VacancyStatus> VacancyStatuses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Candidate");

            entity.HasIndex(e => e.PhoneNumber).IsUnique();

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id).HasColumnName("candidate_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("City");

            entity.Property(e => e.Id).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Client");

            entity.HasIndex(e => e.PhoneNumber).IsUnique();

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id).HasColumnName("client_id");
            entity.Property(e => e.ClientStatusId).HasColumnName("client_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.ClientStatus).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Location).WithMany(p => p.Clients)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ClientStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ClientStatus");

            entity.Property(e => e.Id).HasColumnName("client_status_id");
            entity.Property(e => e.ClientStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("client_status");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Connection_");

            entity.HasIndex(e => e.InternetConnectionRequestId).IsUnique();

            entity.Property(e => e.Id).HasColumnName("connection_id");
            entity.Property(e => e.ConnectionDate).HasColumnName("connection_date");
            entity.Property(e => e.ConnectionTariffId).HasColumnName("connection_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.InternetConnectionRequestId).HasColumnName("internet_connection_request_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.ConnectionTariff).WithMany(p => p.Connections)
                .HasForeignKey(d => d.ConnectionTariffId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.Connections)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InternetConnectionRequest).WithOne(p => p.Connection)
                .HasForeignKey<Connection>(d => d.InternetConnectionRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ConnectionEquipment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ConnectionEquipment", x => x.HasTrigger("ConnectionEquipmentTrigger"));

            entity.Property(e => e.Id).HasColumnName("connection_equipment_id");
            entity.Property(e => e.ConnectionEquipmentAmount).HasColumnName("connection_equipment_amount");
            entity.Property(e => e.ConnectionId).HasColumnName("connection_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.OfficeEquipmentId).HasColumnName("office_equipment_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Connection).WithMany(p => p.ConnectionEquipments)
                .HasForeignKey(d => d.ConnectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OfficeEquipment).WithMany(p => p.ConnectionEquipments)
                .HasForeignKey(d => d.OfficeEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ConnectionTariff>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ConnectionTariff");

            entity.Property(e => e.Id).HasColumnName("connection_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Contract");

            entity.HasIndex(e => e.InterviewId).IsUnique();

            entity.HasIndex(e => e.Number).IsUnique();

            entity.Property(e => e.Id).HasColumnName("contract_id");
            entity.Property(e => e.ConclusionDate).HasColumnName("conclusion_date");
            entity.Property(e => e.ContractStatusId).HasColumnName("contract_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.InterviewId).HasColumnName("interview_id");
            entity.Property(e => e.MonthRate)
                .HasColumnType("money")
                .HasColumnName("month_rate");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.ContractStatus).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ContractStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Employee).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Interview).WithOne(p => p.Contract)
                .HasForeignKey<Contract>(d => d.InterviewId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ContractStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("ContractStatus");

            entity.Property(e => e.Id).HasColumnName("contract_status_id");
            entity.Property(e => e.ContractStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contract_status");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("employee_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeePositionId).HasColumnName("employee_position_id");
            entity.Property(e => e.EmployeeStatusId).HasColumnName("employee_status_id");
            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EmployeeStatus).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Office).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EmployeePosition>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("EmployeePosition");

            entity.Property(e => e.Id).HasColumnName("employee_position_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeePositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_position");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<EmployeeStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("EmployeeStatus");

            entity.Property(e => e.Id).HasColumnName("employee_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EmployeeStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("employee_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("equipment_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentTypeId).HasColumnName("equipment_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.EquipmentType).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EquipmentPlacement>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("EquipmentPlacement");

            entity.Property(e => e.Id).HasColumnName("equipment_placement_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EquipmentPlacementAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_placement_amount");
            entity.Property(e => e.OfficeEquipmentId).HasColumnName("office_equipment_id");
            entity.Property(e => e.PurchaseEquipmentId).HasColumnName("purchase_equipment_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Employee).WithMany(p => p.EquipmentPlacements)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OfficeEquipment).WithMany(p => p.EquipmentPlacements)
                .HasForeignKey(d => d.OfficeEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PurchaseEquipment).WithMany(p => p.EquipmentPlacements)
                .HasForeignKey(d => d.PurchaseEquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("EquipmentType");

            entity.Property(e => e.Id).HasColumnName("equipment_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("equipment_type");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<House>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("House");

            entity.Property(e => e.Id).HasColumnName("house_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("house_number");
            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Street).WithMany(p => p.Houses)
                .HasForeignKey(d => d.StreetId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InternetConnectionRequest>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InternetConnectionRequest");

            entity.HasIndex(e => e.Number).IsUnique();

            entity.Property(e => e.Id).HasColumnName("internet_connection_request_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetConnectionRequestStatusId).HasColumnName("internet_connection_request_status_id");
            entity.Property(e => e.InternetTariffId).HasColumnName("internet_tariff_id");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.RequestDate).HasColumnName("request_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Client).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InternetConnectionRequestStatus).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.InternetConnectionRequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InternetTariff).WithMany(p => p.InternetConnectionRequests)
                .HasForeignKey(d => d.InternetTariffId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InternetConnectionRequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InternetConnectionRequestStatus");

            entity.Property(e => e.Id).HasColumnName("internet_connection_request_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetConnectionRequestStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("internet_connection_request_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<InternetTariff>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InternetTariff");

            entity.Property(e => e.Id).HasColumnName("internet_tariff_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.InternetSpeedMbits).HasColumnName("internet_speed_mbits");
            entity.Property(e => e.InternetTariffStatusId).HasColumnName("internet_tariff_status_id");
            entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.InternetTariffStatus).WithMany(p => p.InternetTariffs)
                .HasForeignKey(d => d.InternetTariffStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.LocationType).WithMany(p => p.InternetTariffs)
                .HasForeignKey(d => d.LocationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InternetTariffStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InternetTariffStatus");

            entity.Property(e => e.Id).HasColumnName("internet_tariff_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InternetTariffStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("internet_tariff_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Interview");

            entity.HasIndex(e => e.InterviewRequestId).IsUnique();

            entity.Property(e => e.Id).HasColumnName("interview_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.InterviewRequestId).HasColumnName("interview_request_id");
            entity.Property(e => e.InterviewResultId).HasColumnName("interview_result_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.InterviewRequest).WithOne(p => p.Interview)
                .HasForeignKey<Interview>(d => d.InterviewRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InterviewResult).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.InterviewResultId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InterviewRequest>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InterviewRequest");

            entity.HasIndex(e => e.Number).IsUnique();

            entity.Property(e => e.Id).HasColumnName("interview_request_id");
            entity.Property(e => e.ApplicationDate).HasColumnName("application_date");
            entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
            entity.Property(e => e.ConsiderationDate).HasColumnName("consideration_date");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InterviewRequestStatusId).HasColumnName("interview_request_status_id");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.VacancyId).HasColumnName("vacancy_id");

            entity.HasOne(d => d.Candidate).WithMany(p => p.InterviewRequests)
                .HasForeignKey(d => d.CandidateId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.InterviewRequestStatus).WithMany(p => p.InterviewRequests)
                .HasForeignKey(d => d.InterviewRequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Vacancy).WithMany(p => p.InterviewRequests)
                .HasForeignKey(d => d.VacancyId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InterviewRequestStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InterviewRequestStatus");

            entity.Property(e => e.Id).HasColumnName("interview_request_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InterviewRequestStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("interview_request_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<InterviewResult>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("InterviewResult");

            entity.Property(e => e.Id).HasColumnName("interview_result_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.InterviewResultName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("interview_result");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasColumnName("location_id");
            entity.Property(e => e.ApartmentNumber).HasColumnName("apartment_number");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.HouseId).HasColumnName("house_id");
            entity.Property(e => e.LocationTypeId).HasColumnName("location_type_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.House).WithMany(p => p.Locations)
                .HasForeignKey(d => d.HouseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.LocationType).WithMany(p => p.Locations)
                .HasForeignKey(d => d.LocationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<LocationType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("LocationType");

            entity.Property(e => e.Id).HasColumnName("location_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.LocationTypeName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location_type");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Office");

            entity.HasIndex(e => e.PhoneNumber).IsUnique();

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id).HasColumnName("office_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.City).WithMany(p => p.Offices)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OfficeEquipment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("OfficeEquipment");

            entity.Property(e => e.Id).HasColumnName("office_equipment_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.OfficeEquipmentAmount).HasColumnName("office_equipment_amount");
            entity.Property(e => e.OfficeId).HasColumnName("office_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Equipment).WithMany(p => p.OfficeEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Office).WithMany(p => p.OfficeEquipments)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Purchase");

            entity.HasIndex(e => e.Number).IsUnique();

            entity.Property(e => e.Id).HasColumnName("purchase_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.PurchaseStatusId).HasColumnName("purchase_status_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("money")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Employee).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PurchaseStatus).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.PurchaseStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Supplier).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseEquipment>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("PurchaseEquipment");

            entity.Property(e => e.Id).HasColumnName("purchase_equipment_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PurchaseEquipmentAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("purchase_equipment_amount");
            entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Equipment).WithMany(p => p.PurchaseEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseEquipments)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PurchaseStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("PurchaseStatus");

            entity.Property(e => e.Id).HasColumnName("purchase_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.PurchaseStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("purchase_status");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Street");

            entity.Property(e => e.Id).HasColumnName("street_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.StreetName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.City).WithMany(p => p.Streets)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.PhoneNumber).IsUnique();

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id).HasColumnName("supplier_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Vacancy");

            entity.HasIndex(e => e.Number).IsUnique();

            entity.Property(e => e.Id).HasColumnName("vacancy_id");
            entity.Property(e => e.AppearanceDate).HasColumnName("appearance_date");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmployeePositionId).HasColumnName("employee_position_id");
            entity.Property(e => e.MonthRate)
                .HasColumnType("money")
                .HasColumnName("month_rate");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.VacancyStatusId).HasColumnName("vacancy_status_id");

            entity.HasOne(d => d.EmployeePosition).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.EmployeePositionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.VacancyStatus).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.VacancyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<VacancyStatus>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("VacancyStatus");

            entity.Property(e => e.Id).HasColumnName("vacancy_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.VacancyStatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("vacancy_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
