using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HifApplication",
                columns: table => new
                {
                    ApplicationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnnualHeatCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    BackupHeatCost = table.Column<bool>(type: "bit", nullable: false),
                    CostMonthly = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    DurationMonth = table.Column<int>(type: "int", nullable: true),
                    DurationYears = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatSources = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HifJsonData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseholdIncome = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    HousingStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HousingType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LiveCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LiveState = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LiveStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveZipCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MailingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MailingState = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MailingZipCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MessagePhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumberBedrooms = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TargetGroup1 = table.Column<bool>(type: "bit", nullable: false),
                    TargetGroup2 = table.Column<bool>(type: "bit", nullable: false),
                    TotalAnnualElectricCosts = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalEnergyCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    TotalPeople = table.Column<int>(type: "int", nullable: false),
                    UniqueAppId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsedSurrogate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HifApplication", x => x.ApplicationID);
                });

            migrationBuilder.CreateTable(
                name: "IncomeRules",
                columns: table => new
                {
                    RowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HouseholdAdjust = table.Column<decimal>(type: "decimal(4, 2)", nullable: false),
                    HouseholdSize = table.Column<int>(type: "int", nullable: false),
                    MaxIncome = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeRules", x => x.RowID);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdMembers",
                columns: table => new
                {
                    PersonID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Disability = table.Column<bool>(type: "bit", nullable: false),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ethnicity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HealthInsurance = table.Column<bool>(type: "bit", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    MilitaryVeteran = table.Column<bool>(type: "bit", nullable: false),
                    PaidAdult = table.Column<bool>(type: "bit", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationToPrimary = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdMembers", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Hif_Household_AppId",
                        column: x => x.ApplicationID,
                        principalTable: "HifApplication",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantGUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationID = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UniqueImageId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Hif_Images_AppID",
                        column: x => x.ApplicationID,
                        principalTable: "HifApplication",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeTypes",
                columns: table => new
                {
                    RowID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationID = table.Column<long>(type: "bigint", nullable: false),
                    ChildSupport = table.Column<bool>(type: "bit", nullable: false),
                    EarnedIncome = table.Column<bool>(type: "bit", nullable: false),
                    GA = table.Column<bool>(type: "bit", nullable: false),
                    Military = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<bool>(type: "bit", nullable: false),
                    Pension = table.Column<bool>(type: "bit", nullable: false),
                    PersonID = table.Column<long>(type: "bigint", nullable: false),
                    SelfEmployed = table.Column<bool>(type: "bit", nullable: false),
                    SocialSecurity = table.Column<bool>(type: "bit", nullable: false),
                    SSI = table.Column<bool>(type: "bit", nullable: false),
                    TANF = table.Column<bool>(type: "bit", nullable: false),
                    Unemployment = table.Column<bool>(type: "bit", nullable: false),
                    VA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeTypes", x => x.RowID);
                    table.ForeignKey(
                        name: "FK_Income_Hif_AppID",
                        column: x => x.ApplicationID,
                        principalTable: "HifApplication",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCOME_Household_Person",
                        column: x => x.PersonID,
                        principalTable: "HouseholdMembers",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoredImages",
                columns: table => new
                {
                    RowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageData = table.Column<byte[]>(type: "varbinary(1)", maxLength: 1, nullable: false),
                    ImageID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredImages", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_Images_StoredImages_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseholdMembers_ApplicationID",
                table: "HouseholdMembers",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ApplicationID",
                table: "Images",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTypes_ApplicationID",
                table: "IncomeTypes",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeTypes_PersonID",
                table: "IncomeTypes",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_StoredImages_ImageID",
                table: "StoredImages",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeRules");

            migrationBuilder.DropTable(
                name: "IncomeTypes");

            migrationBuilder.DropTable(
                name: "StoredImages");

            migrationBuilder.DropTable(
                name: "HouseholdMembers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "HifApplication");
        }
    }
}
