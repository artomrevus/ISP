using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISP.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    candidate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.candidate_id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatus",
                columns: table => new
                {
                    client_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatus", x => x.client_status_id);
                });

            migrationBuilder.CreateTable(
                name: "ConnectionTariff",
                columns: table => new
                {
                    connection_tariff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionTariff", x => x.connection_tariff_id);
                });

            migrationBuilder.CreateTable(
                name: "ContractStatus",
                columns: table => new
                {
                    contract_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contract_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractStatus", x => x.contract_status_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    employee_position_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_position = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.employee_position_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    employee_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.employee_status_id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    equipment_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipment_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.equipment_type_id);
                });

            migrationBuilder.CreateTable(
                name: "InternetConnectionRequestStatus",
                columns: table => new
                {
                    internet_connection_request_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_connection_request_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetConnectionRequestStatus", x => x.internet_connection_request_status_id);
                });

            migrationBuilder.CreateTable(
                name: "InternetTariffStatus",
                columns: table => new
                {
                    internet_tariff_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_tariff_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetTariffStatus", x => x.internet_tariff_status_id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewRequestStatus",
                columns: table => new
                {
                    interview_request_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interview_request_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRequestStatus", x => x.interview_request_status_id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewResult",
                columns: table => new
                {
                    interview_result_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interview_result = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewResult", x => x.interview_result_id);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    location_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_type = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.location_type_id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseStatus",
                columns: table => new
                {
                    purchase_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchase_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseStatus", x => x.purchase_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    supplier_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.supplier_id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyStatus",
                columns: table => new
                {
                    vacancy_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyStatus", x => x.vacancy_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    office_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.office_id);
                    table.ForeignKey(
                        name: "FK_Office_City_city_id",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    street_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.street_id);
                    table.ForeignKey(
                        name: "FK_Street_City_city_id",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipment_type_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.equipment_id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentType_equipment_type_id",
                        column: x => x.equipment_type_id,
                        principalTable: "EquipmentType",
                        principalColumn: "equipment_type_id");
                });

            migrationBuilder.CreateTable(
                name: "InternetTariff",
                columns: table => new
                {
                    internet_tariff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_tariff_status_id = table.Column<int>(type: "int", nullable: false),
                    location_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    internet_speed_mbits = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetTariff", x => x.internet_tariff_id);
                    table.ForeignKey(
                        name: "FK_InternetTariff_InternetTariffStatus_internet_tariff_status_id",
                        column: x => x.internet_tariff_status_id,
                        principalTable: "InternetTariffStatus",
                        principalColumn: "internet_tariff_status_id");
                    table.ForeignKey(
                        name: "FK_InternetTariff_LocationType_location_type_id",
                        column: x => x.location_type_id,
                        principalTable: "LocationType",
                        principalColumn: "location_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    vacancy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_status_id = table.Column<int>(type: "int", nullable: false),
                    employee_position_id = table.Column<int>(type: "int", nullable: false),
                    month_rate = table.Column<decimal>(type: "money", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    appearance_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.vacancy_id);
                    table.ForeignKey(
                        name: "FK_Vacancy_EmployeePosition_employee_position_id",
                        column: x => x.employee_position_id,
                        principalTable: "EmployeePosition",
                        principalColumn: "employee_position_id");
                    table.ForeignKey(
                        name: "FK_Vacancy_VacancyStatus_vacancy_status_id",
                        column: x => x.vacancy_status_id,
                        principalTable: "VacancyStatus",
                        principalColumn: "vacancy_status_id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_position_id = table.Column<int>(type: "int", nullable: false),
                    employee_status_id = table.Column<int>(type: "int", nullable: false),
                    office_id = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeePosition_employee_position_id",
                        column: x => x.employee_position_id,
                        principalTable: "EmployeePosition",
                        principalColumn: "employee_position_id");
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeStatus_employee_status_id",
                        column: x => x.employee_status_id,
                        principalTable: "EmployeeStatus",
                        principalColumn: "employee_status_id");
                    table.ForeignKey(
                        name: "FK_Employee_Office_office_id",
                        column: x => x.office_id,
                        principalTable: "Office",
                        principalColumn: "office_id");
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    house_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street_id = table.Column<int>(type: "int", nullable: false),
                    house_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.house_id);
                    table.ForeignKey(
                        name: "FK_House_Street_street_id",
                        column: x => x.street_id,
                        principalTable: "Street",
                        principalColumn: "street_id");
                });

            migrationBuilder.CreateTable(
                name: "OfficeEquipment",
                columns: table => new
                {
                    office_equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    office_id = table.Column<int>(type: "int", nullable: false),
                    equipment_id = table.Column<int>(type: "int", nullable: false),
                    office_equipment_amount = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeEquipment", x => x.office_equipment_id);
                    table.ForeignKey(
                        name: "FK_OfficeEquipment_Equipment_equipment_id",
                        column: x => x.equipment_id,
                        principalTable: "Equipment",
                        principalColumn: "equipment_id");
                    table.ForeignKey(
                        name: "FK_OfficeEquipment_Office_office_id",
                        column: x => x.office_id,
                        principalTable: "Office",
                        principalColumn: "office_id");
                });

            migrationBuilder.CreateTable(
                name: "InterviewRequest",
                columns: table => new
                {
                    interview_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vacancy_id = table.Column<int>(type: "int", nullable: false),
                    candidate_id = table.Column<int>(type: "int", nullable: false),
                    interview_request_status_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    application_date = table.Column<DateOnly>(type: "date", nullable: false),
                    consideration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewRequest", x => x.interview_request_id);
                    table.ForeignKey(
                        name: "FK_InterviewRequest_Candidate_candidate_id",
                        column: x => x.candidate_id,
                        principalTable: "Candidate",
                        principalColumn: "candidate_id");
                    table.ForeignKey(
                        name: "FK_InterviewRequest_InterviewRequestStatus_interview_request_status_id",
                        column: x => x.interview_request_status_id,
                        principalTable: "InterviewRequestStatus",
                        principalColumn: "interview_request_status_id");
                    table.ForeignKey(
                        name: "FK_InterviewRequest_Vacancy_vacancy_id",
                        column: x => x.vacancy_id,
                        principalTable: "Vacancy",
                        principalColumn: "vacancy_id");
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    purchase_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchase_status_id = table.Column<int>(type: "int", nullable: false),
                    supplier_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    total_price = table.Column<decimal>(type: "money", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.purchase_id);
                    table.ForeignKey(
                        name: "FK_Purchase_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_Purchase_PurchaseStatus_purchase_status_id",
                        column: x => x.purchase_status_id,
                        principalTable: "PurchaseStatus",
                        principalColumn: "purchase_status_id");
                    table.ForeignKey(
                        name: "FK_Purchase_Supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "Supplier",
                        principalColumn: "supplier_id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    location_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_type_id = table.Column<int>(type: "int", nullable: false),
                    house_id = table.Column<int>(type: "int", nullable: false),
                    apartment_number = table.Column<int>(type: "int", nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.location_id);
                    table.ForeignKey(
                        name: "FK_Location_House_house_id",
                        column: x => x.house_id,
                        principalTable: "House",
                        principalColumn: "house_id");
                    table.ForeignKey(
                        name: "FK_Location_LocationType_location_type_id",
                        column: x => x.location_type_id,
                        principalTable: "LocationType",
                        principalColumn: "location_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Interview",
                columns: table => new
                {
                    interview_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    interview_request_id = table.Column<int>(type: "int", nullable: false),
                    interview_result_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interview", x => x.interview_id);
                    table.ForeignKey(
                        name: "FK_Interview_InterviewRequest_interview_request_id",
                        column: x => x.interview_request_id,
                        principalTable: "InterviewRequest",
                        principalColumn: "interview_request_id");
                    table.ForeignKey(
                        name: "FK_Interview_InterviewResult_interview_result_id",
                        column: x => x.interview_result_id,
                        principalTable: "InterviewResult",
                        principalColumn: "interview_result_id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseEquipment",
                columns: table => new
                {
                    purchase_equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    purchase_id = table.Column<int>(type: "int", nullable: false),
                    equipment_id = table.Column<int>(type: "int", nullable: false),
                    purchase_equipment_amount = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseEquipment", x => x.purchase_equipment_id);
                    table.ForeignKey(
                        name: "FK_PurchaseEquipment_Equipment_equipment_id",
                        column: x => x.equipment_id,
                        principalTable: "Equipment",
                        principalColumn: "equipment_id");
                    table.ForeignKey(
                        name: "FK_PurchaseEquipment_Purchase_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "Purchase",
                        principalColumn: "purchase_id");
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    client_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_status_id = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    registration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.client_id);
                    table.ForeignKey(
                        name: "FK_Client_ClientStatus_client_status_id",
                        column: x => x.client_status_id,
                        principalTable: "ClientStatus",
                        principalColumn: "client_status_id");
                    table.ForeignKey(
                        name: "FK_Client_Location_location_id",
                        column: x => x.location_id,
                        principalTable: "Location",
                        principalColumn: "location_id");
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    contract_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contract_status_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    month_rate = table.Column<decimal>(type: "money", nullable: false),
                    conclusion_date = table.Column<DateOnly>(type: "date", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    interview_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.contract_id);
                    table.ForeignKey(
                        name: "FK_Contract_ContractStatus_contract_status_id",
                        column: x => x.contract_status_id,
                        principalTable: "ContractStatus",
                        principalColumn: "contract_status_id");
                    table.ForeignKey(
                        name: "FK_Contract_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_Contract_Interview_interview_id",
                        column: x => x.interview_id,
                        principalTable: "Interview",
                        principalColumn: "interview_id");
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacement",
                columns: table => new
                {
                    equipment_placement_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    purchase_equipment_id = table.Column<int>(type: "int", nullable: false),
                    office_equipment_id = table.Column<int>(type: "int", nullable: false),
                    equipment_placement_amount = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacement", x => x.equipment_placement_id);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacement_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_EquipmentPlacement_OfficeEquipment_office_equipment_id",
                        column: x => x.office_equipment_id,
                        principalTable: "OfficeEquipment",
                        principalColumn: "office_equipment_id");
                    table.ForeignKey(
                        name: "FK_EquipmentPlacement_PurchaseEquipment_purchase_equipment_id",
                        column: x => x.purchase_equipment_id,
                        principalTable: "PurchaseEquipment",
                        principalColumn: "purchase_equipment_id");
                });

            migrationBuilder.CreateTable(
                name: "InternetConnectionRequest",
                columns: table => new
                {
                    internet_connection_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    internet_tariff_id = table.Column<int>(type: "int", nullable: false),
                    internet_connection_request_status_id = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    request_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetConnectionRequest", x => x.internet_connection_request_id);
                    table.ForeignKey(
                        name: "FK_InternetConnectionRequest_Client_client_id",
                        column: x => x.client_id,
                        principalTable: "Client",
                        principalColumn: "client_id");
                    table.ForeignKey(
                        name: "FK_InternetConnectionRequest_InternetConnectionRequestStatus_internet_connection_request_status_id",
                        column: x => x.internet_connection_request_status_id,
                        principalTable: "InternetConnectionRequestStatus",
                        principalColumn: "internet_connection_request_status_id");
                    table.ForeignKey(
                        name: "FK_InternetConnectionRequest_InternetTariff_internet_tariff_id",
                        column: x => x.internet_tariff_id,
                        principalTable: "InternetTariff",
                        principalColumn: "internet_tariff_id");
                });

            migrationBuilder.CreateTable(
                name: "Connection_",
                columns: table => new
                {
                    connection_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    internet_connection_request_id = table.Column<int>(type: "int", nullable: false),
                    connection_tariff_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    total_price = table.Column<decimal>(type: "money", nullable: false),
                    connection_date = table.Column<DateOnly>(type: "date", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection_", x => x.connection_id);
                    table.ForeignKey(
                        name: "FK_Connection__ConnectionTariff_connection_tariff_id",
                        column: x => x.connection_tariff_id,
                        principalTable: "ConnectionTariff",
                        principalColumn: "connection_tariff_id");
                    table.ForeignKey(
                        name: "FK_Connection__Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_Connection__InternetConnectionRequest_internet_connection_request_id",
                        column: x => x.internet_connection_request_id,
                        principalTable: "InternetConnectionRequest",
                        principalColumn: "internet_connection_request_id");
                });

            migrationBuilder.CreateTable(
                name: "ConnectionEquipment",
                columns: table => new
                {
                    connection_equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    connection_id = table.Column<int>(type: "int", nullable: false),
                    office_equipment_id = table.Column<int>(type: "int", nullable: false),
                    connection_equipment_amount = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionEquipment", x => x.connection_equipment_id);
                    table.ForeignKey(
                        name: "FK_ConnectionEquipment_Connection__connection_id",
                        column: x => x.connection_id,
                        principalTable: "Connection_",
                        principalColumn: "connection_id");
                    table.ForeignKey(
                        name: "FK_ConnectionEquipment_OfficeEquipment_office_equipment_id",
                        column: x => x.office_equipment_id,
                        principalTable: "OfficeEquipment",
                        principalColumn: "office_equipment_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_email",
                table: "Candidate",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_phone_number",
                table: "Candidate",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_client_status_id",
                table: "Client",
                column: "client_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_email",
                table: "Client",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_location_id",
                table: "Client",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "IX_Client_phone_number",
                table: "Client",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connection__connection_tariff_id",
                table: "Connection_",
                column: "connection_tariff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection__employee_id",
                table: "Connection_",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Connection__internet_connection_request_id",
                table: "Connection_",
                column: "internet_connection_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionEquipment_connection_id",
                table: "ConnectionEquipment",
                column: "connection_id");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionEquipment_office_equipment_id",
                table: "ConnectionEquipment",
                column: "office_equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_contract_status_id",
                table: "Contract",
                column: "contract_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_employee_id",
                table: "Contract",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_interview_id",
                table: "Contract",
                column: "interview_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_number",
                table: "Contract",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_employee_position_id",
                table: "Employee",
                column: "employee_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_employee_status_id",
                table: "Employee",
                column: "employee_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_office_id",
                table: "Employee",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_equipment_type_id",
                table: "Equipment",
                column: "equipment_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacement_employee_id",
                table: "EquipmentPlacement",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacement_office_equipment_id",
                table: "EquipmentPlacement",
                column: "office_equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacement_purchase_equipment_id",
                table: "EquipmentPlacement",
                column: "purchase_equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_House_street_id",
                table: "House",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_client_id",
                table: "InternetConnectionRequest",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_internet_connection_request_status_id",
                table: "InternetConnectionRequest",
                column: "internet_connection_request_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_internet_tariff_id",
                table: "InternetConnectionRequest",
                column: "internet_tariff_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetConnectionRequest_number",
                table: "InternetConnectionRequest",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InternetTariff_internet_tariff_status_id",
                table: "InternetTariff",
                column: "internet_tariff_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_InternetTariff_location_type_id",
                table: "InternetTariff",
                column: "location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Interview_interview_request_id",
                table: "Interview",
                column: "interview_request_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interview_interview_result_id",
                table: "Interview",
                column: "interview_result_id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequest_candidate_id",
                table: "InterviewRequest",
                column: "candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequest_interview_request_status_id",
                table: "InterviewRequest",
                column: "interview_request_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequest_number",
                table: "InterviewRequest",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterviewRequest_vacancy_id",
                table: "InterviewRequest",
                column: "vacancy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Location_house_id",
                table: "Location",
                column: "house_id");

            migrationBuilder.CreateIndex(
                name: "IX_Location_location_type_id",
                table: "Location",
                column: "location_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Office_city_id",
                table: "Office",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Office_email",
                table: "Office",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Office_phone_number",
                table: "Office",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEquipment_equipment_id",
                table: "OfficeEquipment",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeEquipment_office_id",
                table: "OfficeEquipment",
                column: "office_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_employee_id",
                table: "Purchase",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_number",
                table: "Purchase",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_purchase_status_id",
                table: "Purchase",
                column: "purchase_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_supplier_id",
                table: "Purchase",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEquipment_equipment_id",
                table: "PurchaseEquipment",
                column: "equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseEquipment_purchase_id",
                table: "PurchaseEquipment",
                column: "purchase_id");

            migrationBuilder.CreateIndex(
                name: "IX_Street_city_id",
                table: "Street",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_email",
                table: "Supplier",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_phone_number",
                table: "Supplier",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_employee_position_id",
                table: "Vacancy",
                column: "employee_position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_number",
                table: "Vacancy",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_vacancy_status_id",
                table: "Vacancy",
                column: "vacancy_status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionEquipment");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "EquipmentPlacement");

            migrationBuilder.DropTable(
                name: "Connection_");

            migrationBuilder.DropTable(
                name: "ContractStatus");

            migrationBuilder.DropTable(
                name: "Interview");

            migrationBuilder.DropTable(
                name: "OfficeEquipment");

            migrationBuilder.DropTable(
                name: "PurchaseEquipment");

            migrationBuilder.DropTable(
                name: "ConnectionTariff");

            migrationBuilder.DropTable(
                name: "InternetConnectionRequest");

            migrationBuilder.DropTable(
                name: "InterviewRequest");

            migrationBuilder.DropTable(
                name: "InterviewResult");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "InternetConnectionRequestStatus");

            migrationBuilder.DropTable(
                name: "InternetTariff");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "InterviewRequestStatus");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PurchaseStatus");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "ClientStatus");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "InternetTariffStatus");

            migrationBuilder.DropTable(
                name: "VacancyStatus");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
