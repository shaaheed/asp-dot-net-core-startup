using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartOfAccountCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccountCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code2 = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    LongName = table.Column<string>(nullable: true),
                    NativeName = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    Latitude = table.Column<float>(nullable: true),
                    Longitude = table.Column<float>(nullable: true),
                    Capital = table.Column<string>(nullable: true),
                    CallingCode = table.Column<string>(nullable: true),
                    NumericCode = table.Column<string>(nullable: true),
                    IDD = table.Column<string>(nullable: true),
                    NDD = table.Column<string>(nullable: true),
                    Flag = table.Column<string>(nullable: true),
                    IsIndependent = table.Column<bool>(nullable: false),
                    IsBillingEnabled = table.Column<bool>(nullable: false),
                    IsShippingEnabled = table.Column<bool>(nullable: false),
                    IsCityEnabled = table.Column<bool>(nullable: false),
                    IsZipCodeEnabled = table.Column<bool>(nullable: false),
                    IsDistrictEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Plural = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Code2 = table.Column<string>(nullable: true),
                    Code3 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NativeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    FileSize = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    MediaType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationEntity",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentProvider",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Group = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    IsFeatured = table.Column<bool>(nullable: false),
                    IsCallForPricing = table.Column<bool>(nullable: false),
                    StockQuantity = table.Column<int>(nullable: false),
                    IsSale = table.Column<bool>(nullable: false),
                    IsBuy = table.Column<bool>(nullable: false),
                    IsInventory = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tax",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Rate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tax", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccountType",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    UseOf = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccountType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartOfAccountType_ChartOfAccountCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ChartOfAccountCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateOrProvince",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    CountryId = table.Column<string>(nullable: true),
                    CountryId1 = table.Column<long>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOrProvince", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateOrProvince_Country_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<long>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsFavourite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryLanguage",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: false),
                    LanguageId = table.Column<long>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsFavourite = table.Column<bool>(nullable: false),
                    IsOfficial = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    IsEnable = table.Column<bool>(nullable: false),
                    PaymentProviderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_PaymentProvider_PaymentProviderId",
                        column: x => x.PaymentProviderId,
                        principalTable: "PaymentProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    TotalTaxAmount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(nullable: false),
                    PermissionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTax",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    TaxId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTax_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTax_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsEditable = table.Column<bool>(nullable: false),
                    IsDeletable = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    TypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_ChartOfAccountCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ChartOfAccountCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChartOfAccount_ChartOfAccountType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "ChartOfAccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Reference = table.Column<string>(nullable: true),
                    PaymentMethodId = table.Column<long>(nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    Memo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItemTax",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    LineItemId = table.Column<long>(nullable: false),
                    TaxId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItemTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItemTax_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItemTax_Tax_TaxId",
                        column: x => x.TaxId,
                        principalTable: "Tax",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    IsReviewed = table.Column<bool>(nullable: false),
                    AccountId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_ChartOfAccount_AccountId",
                        column: x => x.AccountId,
                        principalTable: "ChartOfAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressLine4 = table.Column<string>(nullable: true),
                    AddressLine5 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    DistrictId = table.Column<long>(nullable: true),
                    StateOrProvinceId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_StateOrProvince_StateOrProvinceId",
                        column: x => x.StateOrProvinceId,
                        principalTable: "StateOrProvince",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: true),
                    TypeId1 = table.Column<long>(nullable: true),
                    CountryId = table.Column<long>(nullable: true),
                    CountryId1 = table.Column<long>(nullable: true),
                    CurrencyId = table.Column<long>(nullable: true),
                    CurrencyId1 = table.Column<long>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    AddressId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Address_AddressId1",
                        column: x => x.AddressId1,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_Country_CountryId1",
                        column: x => x.CountryId1,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_Currency_CurrencyId1",
                        column: x => x.CurrencyId1,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organization_OrganizationType_TypeId1",
                        column: x => x.TypeId1,
                        principalTable: "OrganizationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    AddressId = table.Column<long>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<long>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VendorId = table.Column<long>(nullable: true),
                    AddressId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: true),
                    Subtotal = table.Column<decimal>(nullable: false),
                    GrandTotal = table.Column<decimal>(nullable: false),
                    TotalTaxAmount = table.Column<decimal>(nullable: false),
                    AmountDue = table.Column<decimal>(nullable: false),
                    IssueDate = table.Column<DateTimeOffset>(nullable: false),
                    PaymentDueDate = table.Column<DateTimeOffset>(nullable: false),
                    Pinned = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    CustomerId = table.Column<long>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    CurrencyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Qoute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    CustomerId = table.Column<long>(nullable: true),
                    IssueDate = table.Column<DateTimeOffset>(nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(nullable: false),
                    CurrencyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qoute_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qoute_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: false),
                    WarehouseId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ReservedQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLineItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    InvoiceId = table.Column<long>(nullable: false),
                    LineItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLineItem_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePayment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    InvoiceId = table.Column<long>(nullable: false),
                    PaymentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePayment_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoicePayment_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLineItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    LineItemId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLineItem_LineItem_LineItemId",
                        column: x => x.LineItemId,
                        principalTable: "LineItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLineItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChartOfAccountCategory",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "Name", "OrganizationId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, null, null, 0L, null, "Assets", null, null, 0L },
                    { 2L, null, null, 0L, null, "Liabilities & Credit Cards", null, null, 0L },
                    { 3L, null, null, 0L, null, "Income", null, null, 0L },
                    { 4L, null, null, 0L, null, "Expenses", null, null, 0L },
                    { 5L, null, null, 0L, null, "Equity", null, null, 0L }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "Name", "OrganizationId", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 104L, "NOK", null, 0L, "Norwegian krone", null, "Norwegian kroner", "kr", null, 0L },
                    { 105L, "NPR", null, 0L, "Nepalese rupee", null, "Nepalese rupees", "₨", null, 0L },
                    { 106L, "NZD", null, 0L, "New Zealand dollar", null, "New Zealand dollars", "$", null, 0L },
                    { 107L, "OMR", null, 0L, "Omani rial", null, "Omani rials", "﷼", null, 0L },
                    { 108L, "PAB", null, 0L, "Balboa", null, "Balboas", "B/.", null, 0L },
                    { 109L, "PEN", null, 0L, "Nuevo Sol", null, "Nuevo Soles", "S/.", null, 0L },
                    { 110L, "PGK", null, 0L, "Kina", null, "Kinas", "K", null, 0L },
                    { 111L, "PHP", null, 0L, "Philippine peso", null, "Philippine pesos", "Php", null, 0L },
                    { 113L, "PLN", null, 0L, "Zloty", null, "Zloty", "zł", null, 0L },
                    { 103L, "NIO", null, 0L, "Cordoba Oro", null, "Cordobas Oro", "C$", null, 0L },
                    { 114L, "PYG", null, 0L, "Guarani", null, "Guaranis", "Gs", null, 0L },
                    { 115L, "QAR", null, 0L, "Qatari riyal", null, "Qatari riyals", "﷼", null, 0L },
                    { 116L, "RON", null, 0L, "New Leu", null, "New Lei", "lei", null, 0L },
                    { 117L, "RSD", null, 0L, "Serbian dinar", null, "Serbian dinars", "Дин.", null, 0L },
                    { 118L, "RUB", null, 0L, "Russian rouble", null, "Russian roubles", "руб", null, 0L },
                    { 119L, "RWF", null, 0L, "Rwanda franc", null, "Rwanda francs", "R₣", null, 0L },
                    { 112L, "PKR", null, 0L, "Pakistani rupee", null, "Pakistani rupees", "₨", null, 0L },
                    { 102L, "NGN", null, 0L, "Naira", null, "Naira", "₦", null, 0L },
                    { 99L, "MYR", null, 0L, "Malaysian ringgit", null, "Malaysian ringgit", "RM", null, 0L },
                    { 100L, "MZN", null, 0L, "Metical", null, "Meticais", "MT", null, 0L },
                    { 83L, "LTL", null, 0L, "Lithuanian litus", null, "Lithuanian litai", "Lt", null, 0L },
                    { 84L, "LVL", null, 0L, "Latvian lats", null, "Latvian lats", "Ls", null, 0L },
                    { 85L, "LYD", null, 0L, "Libyan dinar", null, "Libyan dinar", "ل.د", null, 0L },
                    { 86L, "MAD", null, 0L, "Moroccan dirham", null, "Moroccan dirhams", "د.م", null, 0L },
                    { 87L, "MDL", null, 0L, "Moldovan leu", null, "Moldovan lei", "L", null, 0L },
                    { 88L, "MGA", null, 0L, "Malagasy Ariary", null, "Malagasy Ariaries", "Ar", null, 0L },
                    { 89L, "MKD", null, 0L, "Denar", null, "Denari", "ден", null, 0L },
                    { 90L, "MMK", null, 0L, "Kyat", null, "Kyats", "K", null, 0L },
                    { 91L, "MNT", null, 0L, "Tugrik", null, "Tugriks", "₮", null, 0L },
                    { 92L, "MOP", null, 0L, "Pataca", null, "Patacas", "MOP$", null, 0L },
                    { 93L, "MRO", null, 0L, "Ouguiya", null, "Ouguiyas", "UM", null, 0L },
                    { 94L, "MRU", null, 0L, "Ouguiya", null, "Ouguiyas", "UM", null, 0L },
                    { 95L, "MUR", null, 0L, "Mauritian rupee", null, "Mauritian rupees", "₨", null, 0L },
                    { 96L, "MVR", null, 0L, "Rufiyaa", null, "Rufiyaas", "Rf", null, 0L },
                    { 97L, "MWK", null, 0L, "Kwacha", null, "Kwacha", "MK", null, 0L },
                    { 98L, "MXN", null, 0L, "Mexican peso", null, "Mexican pesos", "$", null, 0L },
                    { 120L, "SAR", null, 0L, "Saudi riyal", null, "Saudi riyals", "﷼", null, 0L },
                    { 101L, "NAD", null, 0L, "Namibian dollar", null, "Namibian dollar", "N$", null, 0L },
                    { 122L, "SCR", null, 0L, "Seychelles rupee", null, "Seychelles rupees", "₨", null, 0L },
                    { 124L, "SEK", null, 0L, "Swedish krona", null, "Swedish kronur", "kr", null, 0L },
                    { 82L, "LSL", null, 0L, "Loti", null, "Maloti", "M", null, 0L },
                    { 146L, "USD", null, 0L, "U.S. dollar", null, "U.S. dollars", "$", null, 0L },
                    { 147L, "UYU", null, 0L, "Uruguayo peso", null, "Uruguayo pesos", "$U", null, 0L },
                    { 148L, "UZS", null, 0L, "Uzbekistan sum", null, "Uzbekistan sum", "лв", null, 0L },
                    { 149L, "VEF", null, 0L, "Bolivar Fuerte", null, "Bolivares Fuerte", "Bs", null, 0L },
                    { 150L, "VND", null, 0L, "Dong", null, "Dongs", "₫", null, 0L },
                    { 151L, "VUV", null, 0L, "Vatu", null, "Vatu", "VT", null, 0L },
                    { 152L, "WST", null, 0L, "Samoan Tala", null, "Samoan Talas", "$", null, 0L },
                    { 145L, "UGX", null, 0L, "Ugandan shilling", null, "Ugandan shillings", "UGX", null, 0L },
                    { 153L, "XAF", null, 0L, "CFA Franc - BEAC", null, "CFA Francs - BEAC", "Fr", null, 0L },
                    { 155L, "XOF", null, 0L, "CFA franc - BCEAO", null, "CFA francs - BCEAO", "CFA", null, 0L },
                    { 156L, "XPF", null, 0L, "Comptoirs Francais du Pacifique Francs", null, "Comptoirs Francais du Pacifique Francs", "₣", null, 0L },
                    { 157L, "YER", null, 0L, "Yemeni rial", null, "Yemeni rials", "﷼", null, 0L },
                    { 158L, "ZAR", null, 0L, "Rand", null, "Rand", "R", null, 0L },
                    { 159L, "ZMK", null, 0L, "Kwacha", null, "Kwachas", "ZK", null, 0L },
                    { 160L, "ZMW", null, 0L, "Kwacha", null, "Kwachas", "ZK", null, 0L },
                    { 161L, "ZWD", null, 0L, "Zimbabwean dollar", null, "Zimbabwean dollars", "Z$", null, 0L },
                    { 154L, "XCD", null, 0L, "Eastern Caribbean dollar", null, "Eastern Caribbean dollars", "$", null, 0L },
                    { 144L, "UAH", null, 0L, "Hryvnia", null, "Hryvni", "₴", null, 0L },
                    { 143L, "TZS", null, 0L, "Tanzanian shilling", null, "Tanzanian shillings", "Sh", null, 0L },
                    { 142L, "TWD", null, 0L, "New Taiwan dollar", null, "New Taiwan dollars", "NT$", null, 0L },
                    { 125L, "SGD", null, 0L, "Singapore dollar", null, "Singapore dollars", "$", null, 0L },
                    { 126L, "SHP", null, 0L, "Saint Helena pound", null, "Saint Helena pounds", "£", null, 0L },
                    { 127L, "SLL", null, 0L, "Leone", null, "Leones", "Le", null, 0L },
                    { 128L, "SOS", null, 0L, "Somali shilling", null, "Somali shillings", "S", null, 0L },
                    { 129L, "SRD", null, 0L, "Surinam dollar", null, "Surinam dollars", "$", null, 0L },
                    { 130L, "SSP", null, 0L, "South Sudanese pound", null, "South Sudanese pounds", "£", null, 0L },
                    { 131L, "STD", null, 0L, "Dobra", null, "Dobras", "Db", null, 0L },
                    { 132L, "SVC", null, 0L, "El Salvador colon", null, "El Salvador colones", "$", null, 0L },
                    { 133L, "SYP", null, 0L, "Syrian pound", null, "Syrian pounds", "£S", null, 0L },
                    { 134L, "SZL", null, 0L, "Lilangeni", null, "Emalangeni", "E", null, 0L },
                    { 135L, "THB", null, 0L, "Baht", null, "Baht", "฿", null, 0L },
                    { 136L, "TJS", null, 0L, "Somoni", null, "Somonis", "SM", null, 0L },
                    { 137L, "TMM", null, 0L, "Manat", null, "Manat", "m", null, 0L },
                    { 138L, "TND", null, 0L, "Tunisian dinar", null, "Tunisian dinars", "TND", null, 0L },
                    { 139L, "TOP", null, 0L, "Pa'anga", null, "Pa'anga", "$", null, 0L },
                    { 140L, "TRY", null, 0L, "Turkish lira", null, "Turkish liras", "TL", null, 0L },
                    { 141L, "TTD", null, 0L, "Trinidad and Tobago dollar", null, "Trinidad and Tobago dollars", "TT$", null, 0L },
                    { 123L, "SDG", null, 0L, "Sudanese pound", null, "Sudanese pounds", "£", null, 0L },
                    { 81L, "LRD", null, 0L, "Liberian dollar", null, "Liberian dollars", "$", null, 0L },
                    { 121L, "SBD", null, 0L, "Solomon Islands dollar", null, "Solomon Islands dollars", "SI$", null, 0L },
                    { 79L, "LBP", null, 0L, "Lebanese pound", null, "Lebanese pounds", "LBP", null, 0L },
                    { 22L, "BTN", null, 0L, "Ngultrum", null, "Ngultrums", "Nu.", null, 0L },
                    { 23L, "BWP", null, 0L, "Pula", null, "Pula", "P", null, 0L },
                    { 24L, "BYR", null, 0L, "Belarussian rouble", null, "Belarussian roubles", "p.", null, 0L },
                    { 25L, "BZD", null, 0L, "Belize dollar", null, "Belize dollars", "BZ$", null, 0L },
                    { 26L, "CAD", null, 0L, "Canadian dollar", null, "Canadian dollars", "$", null, 0L },
                    { 27L, "CDF", null, 0L, "Franc congolais", null, "Francs congolais", "₣", null, 0L },
                    { 28L, "CHF", null, 0L, "Swiss franc", null, "Swiss francs", "CHF", null, 0L },
                    { 21L, "BSD", null, 0L, "Bahamian dollar", null, "Bahamian dollars", "$", null, 0L },
                    { 29L, "CLP", null, 0L, "Chilean peso", null, "Chilean pesos", "$", null, 0L },
                    { 31L, "COP", null, 0L, "Colombian peso", null, "Colombian pesos", "$", null, 0L },
                    { 32L, "CRC", null, 0L, "Costa Rican colon", null, "Costa Rican colones", "₡", null, 0L },
                    { 33L, "CUP", null, 0L, "Cuban peso", null, "Cuban pesos", "₱", null, 0L },
                    { 34L, "CVE", null, 0L, "Cape Verde escudo", null, "Cape Verde escudos", "Esc", null, 0L },
                    { 35L, "CZK", null, 0L, "Czech koruna", null, "Czech korun", "Kč", null, 0L },
                    { 36L, "DJF", null, 0L, "Djibouti franc", null, "Djibouti francs", "₣", null, 0L },
                    { 37L, "DKK", null, 0L, "Danish krone", null, "Danish kroner", "kr", null, 0L },
                    { 30L, "CNY", null, 0L, "Ren-Min-Bi yuan", null, "Ren-Min-Bi yuan", "¥", null, 0L },
                    { 20L, "BRL", null, 0L, "Real", null, "Reales", "R$", null, 0L },
                    { 19L, "BOB", null, 0L, "Boliviano", null, "Bolivianos", "$b", null, 0L },
                    { 18L, "BND", null, 0L, "Brunei dollar", null, "Brunei dollars", "$", null, 0L },
                    { 1L, "AED", null, 0L, "UAE dirham", null, "UAE dirhams", "AED", null, 0L },
                    { 2L, "AFN", null, 0L, "Afghani", null, "Afganis", "؋", null, 0L },
                    { 3L, "ALL", null, 0L, "Lek", null, "Lekë", "Lek", null, 0L },
                    { 4L, "AMD", null, 0L, "Armenian dram", null, "Armenian drams", "֏", null, 0L },
                    { 5L, "ANG", null, 0L, "Netherlands Antillean guilder", null, "Netherlands Antillean guilders", "ƒ", null, 0L },
                    { 6L, "AOA", null, 0L, "Kwanza", null, "Kwanzas", "Kz", null, 0L },
                    { 7L, "ARS", null, 0L, "Argentinian peso", null, "Argentinian pesos", "$", null, 0L },
                    { 8L, "AUD", null, 0L, "Australian dollar", null, "Australian dollars", "$", null, 0L },
                    { 9L, "AWG", null, 0L, "Aruban florin", null, "Aruban florin", "ƒ", null, 0L },
                    { 10L, "AZN", null, 0L, "New Manat", null, "New Manat", "ман", null, 0L },
                    { 11L, "BAM", null, 0L, "Convertible Marks", null, "Convertible Marks", "KM", null, 0L },
                    { 12L, "BBD", null, 0L, "Barbados dollar", null, "Barbados dollars", "$", null, 0L },
                    { 13L, "BDT", null, 0L, "Taka", null, "Takas", "৳", null, 0L },
                    { 14L, "BGN", null, 0L, "Lev", null, "Leva", "лв", null, 0L },
                    { 15L, "BHD", null, 0L, "Bahraini dinar", null, "Bahraini dinars", "BD", null, 0L },
                    { 16L, "BIF", null, 0L, "Burundi franc", null, "Burundi francs", "FBu", null, 0L },
                    { 17L, "BMD", null, 0L, "Bermuda dollar", null, "Bermuda dollars", "$", null, 0L },
                    { 38L, "DOP", null, 0L, "Dominican peso", null, "Dominican pesos", "RD$", null, 0L },
                    { 39L, "DZD", null, 0L, "Algerian dinar", null, "Algerian dinars", "د.ج", null, 0L },
                    { 40L, "EEK", null, 0L, "Estonian kroon", null, "Estonian krooni", "kr", null, 0L },
                    { 60L, "HUF", null, 0L, "Forint", null, "Forints", "Ft", null, 0L },
                    { 63L, "INR", null, 0L, "Indian rupee", null, "Indian rupees", "₹", null, 0L },
                    { 64L, "IQD", null, 0L, "Iraqi dinar", null, "Iraqi dinars", "د.ع", null, 0L },
                    { 65L, "IRR", null, 0L, "Iranian rial", null, "Iranian rials", "﷼", null, 0L },
                    { 66L, "ISK", null, 0L, "Icelandic króna", null, "Icelandic krónur", "kr", null, 0L },
                    { 67L, "JMD", null, 0L, "Jamaican dollar", null, "Jamaican dollars", "J$", null, 0L },
                    { 68L, "JOD", null, 0L, "Jordanian dinar", null, "Jordanian dinars", "د.ا", null, 0L },
                    { 69L, "JPY", null, 0L, "Yen", null, "Yen", "¥", null, 0L },
                    { 62L, "ILS", null, 0L, "New Israeli sheqel", null, "New Israeli sheqels", "₪", null, 0L },
                    { 70L, "KES", null, 0L, "Kenyan shilling", null, "Kenyan shillings", "SH", null, 0L },
                    { 72L, "KHR", null, 0L, "Riel", null, "Riels", "៛", null, 0L },
                    { 73L, "KMF", null, 0L, "Comoro franc", null, "Comoro francs", "₣", null, 0L },
                    { 74L, "KRW", null, 0L, "Won", null, "Won", "₩", null, 0L },
                    { 75L, "KWD", null, 0L, "Kuwaiti dinar", null, "Kuwaiti dinars", "د.ك", null, 0L },
                    { 76L, "KYD", null, 0L, "Cayman Islands dollar", null, "Cayman Islands dollars", "$", null, 0L },
                    { 77L, "KZT", null, 0L, "Tenge", null, "Tenge", "лв", null, 0L },
                    { 78L, "LAK", null, 0L, "Kip", null, "Kips", "₭", null, 0L },
                    { 71L, "KGS", null, 0L, "Kyrgyz Som", null, "Kyrgyz Soms", "лв", null, 0L },
                    { 61L, "IDR", null, 0L, "Rupiah", null, "Rupiahs", "Rp", null, 0L },
                    { 80L, "LKR", null, 0L, "Sri Lankan rupee", null, "Sri Lankan rupees", "₨", null, 0L },
                    { 49L, "GHS", null, 0L, "Ghana cedi", null, "Ghana cedis", "GH¢", null, 0L },
                    { 43L, "ETB", null, 0L, "Ethiopian birr", null, "Ethiopian birrs", "Br", null, 0L },
                    { 44L, "EUR", null, 0L, "Euro", null, "Euros", "€", null, 0L },
                    { 45L, "FJD", null, 0L, "Fiji dollar", null, "Fiji dollars", "$", null, 0L },
                    { 46L, "FKP", null, 0L, "Falkland Islands (Malvinas) pound", null, "Falkland Islands (Malvinas) pounds", "£", null, 0L },
                    { 47L, "GBP", null, 0L, "Pound sterling", null, "Pounds sterling", "£", null, 0L },
                    { 48L, "GEL", null, 0L, "Lari", null, "Lari", "ლ", null, 0L },
                    { 59L, "HTG", null, 0L, "Haitian gourde", null, "Haitian gourdes", "G", null, 0L },
                    { 42L, "ERN", null, 0L, "Nakfa", null, "Nakfas", "Nfk", null, 0L },
                    { 50L, "GIP", null, 0L, "Gibraltar pound", null, "Gibraltar pounds", "£", null, 0L },
                    { 52L, "GNF", null, 0L, "Guinean franc", null, "Guinean francs", "₣", null, 0L },
                    { 53L, "GTQ", null, 0L, "Quetzal", null, "Quetzales", "Q", null, 0L },
                    { 54L, "GWP", null, 0L, "Guinea-Bissau peso", null, "Guinea-Bissau pesos", "$", null, 0L },
                    { 55L, "GYD", null, 0L, "Guyana dollar", null, "Guyana dollars", "$", null, 0L },
                    { 56L, "HKD", null, 0L, "Hong Kong dollar", null, "Hong Kong dollars", "$", null, 0L },
                    { 57L, "HNL", null, 0L, "Lempira", null, "Lempiras", "L", null, 0L },
                    { 58L, "HRK", null, 0L, "Kuna", null, "Kunas", "kn", null, 0L },
                    { 51L, "GMD", null, 0L, "Dalasi", null, "Dalasi", "D", null, 0L },
                    { 41L, "EGP", null, 0L, "Egyptian pound", null, "Egyptian pounds", "E £", null, 0L }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "AddressId", "AddressId1", "CountryId", "CountryId1", "CreatedAt", "CreatedBy", "CurrencyId", "CurrencyId1", "Name", "OrganizationId", "TypeId", "TypeId1", "UpdatedAt", "UpdatedBy" },
                values: new object[] { 1L, null, null, null, null, null, 0L, 13L, null, "Default", null, null, null, null, 0L });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "IsEnable", "Name", "OrganizationId", "PaymentProviderId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 3L, "cheque", null, 0L, true, "Cheque", null, null, null, 0L },
                    { 2L, "cash", null, 0L, true, "Cash", null, null, null, 0L },
                    { 1L, "bank_payment", null, 0L, true, "Bank payment", null, null, null, 0L }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Group", "Name", "OrganizationId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "sales.product.list", null, 0L, null, "Product", "List", null, null, 0L },
                    { "sales.product.view", null, 0L, null, "Product", "View", null, null, 0L },
                    { "sales.product.update", null, 0L, null, "Product", "Update", null, null, 0L },
                    { "sales.product.create", null, 0L, null, "Product", "Create", null, null, 0L },
                    { "sales.invoice.manage", null, 0L, null, "Invoice", "Manage", null, null, 0L },
                    { "sales.invoice.delete", null, 0L, null, "Invoice", "Delete", null, null, 0L },
                    { "sales.invoice.list", null, 0L, null, "Invoice", "List", null, null, 0L },
                    { "sales.product.delete", null, 0L, null, "Product", "Delete", null, null, 0L },
                    { "sales.invoice.view", null, 0L, null, "Invoice", "View", null, null, 0L },
                    { "sales.invoice.create", null, 0L, null, "Invoice", "Create", null, null, 0L },
                    { "sales.customer.manage", null, 0L, null, "Customer", "Manage", null, null, 0L },
                    { "sales.customer.delete", null, 0L, null, "Customer", "Delete", null, null, 0L },
                    { "sales.customer.list", null, 0L, null, "Customer", "List", null, null, 0L },
                    { "sales.customer.view", null, 0L, null, "Customer", "View", null, null, 0L },
                    { "sales.customer.update", null, 0L, null, "Customer", "Update", null, null, 0L },
                    { "sales.customer.create", null, 0L, null, "Customer", "Create", null, null, 0L },
                    { "sales.invoice.update", null, 0L, null, "Invoice", "Update", null, null, 0L },
                    { "permissions.delete", null, 0L, null, "Permission", "Delete", null, null, 0L },
                    { "sales.product.manage", null, 0L, null, "Product", "Manage", null, null, 0L },
                    { "sales.invoice.payment.update", null, 0L, null, "Invoice Payment", "Update", null, null, 0L },
                    { "users.manage", null, 0L, null, "User", "Manage", null, null, 0L },
                    { "users.delete", null, 0L, null, "User", "Delete", null, null, 0L },
                    { "users.list", null, 0L, null, "User", "List", null, null, 0L },
                    { "users.view", null, 0L, null, "User", "View", null, null, 0L },
                    { "users.update", null, 0L, null, "User", "Update", null, null, 0L },
                    { "users.create", null, 0L, null, "User", "Create", null, null, 0L },
                    { "sales.vendor.manage", null, 0L, null, "Vendor", "Manage", null, null, 0L },
                    { "sales.invoice.payment.create", null, 0L, null, "Invoice Payment", "Create", null, null, 0L },
                    { "sales.vendor.delete", null, 0L, null, "Vendor", "Delete", null, null, 0L },
                    { "sales.vendor.view", null, 0L, null, "Vendor", "View", null, null, 0L },
                    { "sales.vendor.update", null, 0L, null, "Vendor", "Update", null, null, 0L },
                    { "sales.vendor.create", null, 0L, null, "Vendor", "Create", null, null, 0L },
                    { "sales.invoice.payment.manage", null, 0L, null, "Invoice Payment", "Manage", null, null, 0L },
                    { "sales.invoice.payment.delete", null, 0L, null, "Invoice Payment", "Delete", null, null, 0L },
                    { "sales.invoice.payment.list", null, 0L, null, "Invoice Payment", "List", null, null, 0L },
                    { "sales.invoice.payment.view", null, 0L, null, "Invoice Payment", "View", null, null, 0L },
                    { "sales.vendor.list", null, 0L, null, "Vendor", "List", null, null, 0L },
                    { "permissions.view", null, 0L, null, "Permission", "View", null, null, 0L },
                    { "orgapermissionsnizations.list", null, 0L, null, "Permission", "List", null, null, 0L },
                    { "accounting.transaction.manage", null, 0L, null, "Transaction", "Manage", null, null, 0L },
                    { "accounting.transaction.delete", null, 0L, null, "Transaction", "Delete", null, null, 0L },
                    { "accounting.transaction.list", null, 0L, null, "Transaction", "List", null, null, 0L },
                    { "accounting.transaction.view", null, 0L, null, "Transaction", "View", null, null, 0L },
                    { "accounting.transaction.update", null, 0L, null, "Transaction", "Update", null, null, 0L }
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Group", "Name", "OrganizationId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "accounting.transaction.create", null, 0L, null, "Transaction", "Create", null, null, 0L },
                    { "accounting.chartofaccount.category.manage", null, 0L, null, "Chart Of Account Category", "Manage", null, null, 0L },
                    { "accounting.chartofaccount.category.delete", null, 0L, null, "Chart Of Account Category", "Delete", null, null, 0L },
                    { "accounting.chartofaccount.category.list", null, 0L, null, "Chart Of Account Category", "List", null, null, 0L },
                    { "accounting.chartofaccount.category.view", null, 0L, null, "Chart Of Account Category", "View", null, null, 0L },
                    { "accounting.chartofaccount.category.update", null, 0L, null, "Chart Of Account Category", "Update", null, null, 0L },
                    { "accounting.chartofaccount.category.create", null, 0L, null, "Chart Of Account Category", "Create", null, null, 0L },
                    { "accounting.chartofaccount.manage", null, 0L, null, "Chart Of Account", "Manage", null, null, 0L },
                    { "accounting.chartofaccount.delete", null, 0L, null, "Chart Of Account", "Delete", null, null, 0L },
                    { "accounting.chartofaccount.list", null, 0L, null, "Chart Of Account", "List", null, null, 0L },
                    { "accounting.chartofaccount.view", null, 0L, null, "Chart Of Account", "View", null, null, 0L },
                    { "permissions.update", null, 0L, null, "Permission", "Update", null, null, 0L },
                    { "core.currency.create", null, 0L, null, "Customer", "Create", null, null, 0L },
                    { "core.currency.update", null, 0L, null, "Customer", "Update", null, null, 0L },
                    { "core.currency.view", null, 0L, null, "Customer", "View", null, null, 0L },
                    { "permissions.create", null, 0L, null, "Permission", "Create", null, null, 0L },
                    { "payments.manage", null, 0L, null, "Payment", "Manage", null, null, 0L },
                    { "payments.delete", null, 0L, null, "Payment", "Delete", null, null, 0L },
                    { "payments.list", null, 0L, null, "Payment", "List", null, null, 0L },
                    { "payments.view", null, 0L, null, "Payment", "View", null, null, 0L },
                    { "payments.update", null, 0L, null, "Payment", "Update", null, null, 0L },
                    { "payments.create", null, 0L, null, "Payment", "Create", null, null, 0L },
                    { "accounting.chartofaccount.update", null, 0L, null, "Chart Of Account", "Update", null, null, 0L },
                    { "organizations.manage", null, 0L, null, "Organization", "Manage", null, null, 0L },
                    { "organizations.list", null, 0L, null, "Organization", "List", null, null, 0L },
                    { "organizations.view", null, 0L, null, "Organization", "View", null, null, 0L },
                    { "organizations.update", null, 0L, null, "Organization", "Update", null, null, 0L },
                    { "organizations.create", null, 0L, null, "Organization", "Create", null, null, 0L },
                    { "core.currency.manage", null, 0L, null, "Customer", "Manage", null, null, 0L },
                    { "core.currency.delete", null, 0L, null, "Customer", "Delete", null, null, 0L },
                    { "core.currency.list", null, 0L, null, "Customer", "List", null, null, 0L },
                    { "organizations.delete", null, 0L, null, "Organization", "Delete", null, null, 0L },
                    { "accounting.chartofaccount.create", null, 0L, null, "Chart Of Account", "Create", null, null, 0L }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Code", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2L, "customer", "b9d804c1-1032-4e5c-a06c-c97275965887", null, "Customer", null },
                    { 1L, "administrator", "acec435f-c965-478a-bba2-c32ec8a9651d", null, "Administrator", null },
                    { 3L, "vendor", "4e3c47bb-b168-4da1-8327-f2d07b32be51", null, "Vendor", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "Contact", "CreatedAt", "CreatedBy", "CurrencyId", "DateOfBirth", "Email", "EmailConfirmed", "Fax", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Mobile", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UpdatedBy", "UserName", "Website" },
                values: new object[] { 1L, 0, null, "f5bf7eed-f135-49b4-a9a0-79934fd61cb6", null, null, 0L, null, null, "admin@gmail.com", false, null, null, null, true, null, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", null, "AQAAAAEAACcQAAAAEMEK4zlmpB7ANy3V5gBLV8UTrLSTyZDx1Ri4KQRuJthXUIQCmpZePOogrBu/orB0TA==", null, null, false, "afb26da4-f076-4609-8f8b-c942f234ec61", false, null, 0L, "admin@gmail.com", null });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { -1L, 1L, 1L });

            migrationBuilder.InsertData(
                table: "ChartOfAccountType",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedAt", "CreatedBy", "Name", "OrganizationId", "UpdatedAt", "UpdatedBy", "UseOf" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, 0L, "Cash and Bank", null, null, 0L, "Use this to track the balance of cash that is immediately available for use. Examples of this are bank accounts, cash boxes in a register, money boxes, or electronic accounts such as PayPal." },
                    { 30L, 5L, null, null, 0L, "Retained Earnings: Profit", null, null, 0L, "Use this to track money that you have taken out of the business." },
                    { 29L, 5L, null, null, 0L, "Business Owner Contribution and Drawing", null, null, 0L, "Use this to track money you or others have invested into the business. For example, when you first start a business you usually invest start-up money into it." },
                    { 28L, 4L, null, null, 0L, "Loss On Foreign Exchange", null, null, 0L, "This account is used to track losses due to exchange rate differences on foreign currency invoices, bills, and transfers." },
                    { 27L, 4L, null, null, 0L, "Uncategorized Expense", null, null, 0L, "This account is used as the default category for new withdrawal transactions." },
                    { 26L, 4L, null, null, 0L, "Payroll Expense", null, null, 0L, "Use this to track expenses related to running and approving a payroll for salaried and hourly employees. Do not use these categories to track payments to yourself, unless you are an employee of the business." },
                    { 25L, 4L, null, null, 0L, "Payment Processing Fee", null, null, 0L, "Use this to track the fees charged when your customer makes a credit card payment. Even though this is usually deducted from the transfer or deposit into your bank account, you should still be recording this type of expense." },
                    { 24L, 4L, null, null, 0L, "Cost of Goods Sold", null, null, 0L, "Use this to track expenses that are directly attributable to the product or service you are selling. If there is a type of expense that cannot be attributable to sales, then you should create an Operating Expense category instead." },
                    { 23L, 4L, null, null, 0L, "Operating Expense", null, null, 0L, "Use this to track most of your business expenses. Each type of office, insurance, rent, utilities, and subscription fees can have a category." },
                    { 21L, 3L, null, null, 0L, "Uncategorized Income", null, null, 0L, "This account is used as the default category for new deposit transactions." },
                    { 20L, 3L, null, null, 0L, "Other Income", null, null, 0L, "Use this to track all other income that is outside of your regular business operations of selling to your customers. For example, if your main business is as a photographer, but you rented your camera to a friend as a one-off shoot, that could be other income." },
                    { 19L, 3L, null, null, 0L, "Discount", null, null, 0L, "Use this to track discounts you've given to customers so that you can determine if you are giving too many discounts. Discounts reduce your income, which is why it will be shown as a negative on the Profit and Loss report." },
                    { 18L, 3L, null, null, 0L, "Income", null, null, 0L, "Use this to track all your sales to customers, whether your customer has made a payment or not. These are the categories used when you create an Invoice in Wave. Any sales taxes charged to customers will not be tracked using a Sales category, but will be tracked using a Sales Taxes on Sales or Purchases category." },
                    { 17L, 2L, null, null, 0L, "Other Long-Term Liability", null, null, 0L, "Use this to track amounts that you owe after this year when none of the other liability account types apply. Other Short-Term Liability accounts are used to track amounts that you owe this year. These accounts will appear in the Long-term Liabilities section of the balance sheet." },
                    { 16L, 2L, null, null, 0L, "Other Short-Term Liability", null, null, 0L, "Use this to track amounts that you owe this year when none of the other liability account types apply. Other Long-Term Liability accounts are used to track amounts that you owe after this year. These accounts will appear in the Current Liabilities section of the balance sheet." },
                    { 22L, 3L, null, null, 0L, "Gain On Foreign Exchange", null, null, 0L, "This account is used to track gains due to exchange rate differences on foreign currency invoices, bills, and transfers." },
                    { 14L, 2L, null, null, 0L, "Due to You and Other Business Owners", null, null, 0L, "Use this to track the balance of what you (or your partners) have personally loaned to the business, but expect to be paid back for. The same category can also be used to track loans the business has given you (or your partners), in which case the balance would be less than zero (negative)." },
                    { 15L, 2L, null, null, 0L, "Customer Prepayments and Customer Credits", null, null, 0L, "Use this to track the value of the product or service that you still need to provide to a customer because they made upfront payments to you. An example is when a customer gives you a deposit or a retainer, or when you give a customer a credit note. The balance of the category will decrease over time as you provide the product or service to the customer." },
                    { 3L, 1L, null, null, 0L, "Expected Payments from Customers", null, null, 0L, "Use this to track the balance of what customers owe you after you have made a sale. Invoices in Wave are already tracked in the Accounts Receivable category." },
                    { 4L, 1L, null, null, 0L, "Inventory", null, null, 0L, "Use this to track the value of physical items you have in storage or in a retail store that are waiting to be sold/completed." },
                    { 5L, 1L, null, null, 0L, "Property, Plant, Equipment", null, null, 0L, "Things you own but you do not sell to customers as part of your normal business operations." },
                    { 6L, 1L, null, null, 0L, "Depreciation and Amortization", null, null, 0L, "Use this to track the decrease in value of things you own. For example, when you purchase equipment for business, it loses its value as time goes on. These categories always have a balance less than zero (negative)." },
                    { 7L, 1L, null, null, 0L, "Vendor Prepayments and Vendor Credits", null, null, 0L, "Use this to track the value of the product or service that a vendor still needs to provide to you because you have made upfront payments to them. Examples of this are when you make upfront payments for insurance in the beginning of the year or for multiple years, or when a vendor gives you a credit note. The balance of the category will decrease over time as the vendor needs to provide less and less product or service to you." },
                    { 2L, 1L, null, null, 0L, "Money in Transit", null, null, 0L, "Use this to track the balance of money that is expected to deposited or withdrawn into or from a Cash and Bank account at a future date, usually within days. Examples of this are credit card sales that have been processed but have not yet been deposited into your bank, or checks (written or received) that have not been deposited into or withdrawn from your bank account yet." },
                    { 9L, 1L, null, null, 0L, "Other Long-Term Asset", null, null, 0L, "Use this to track amounts that you are owed after this year when none of the other asset account types apply. Other Short-Term Asset accounts are used to track amounts that you are owed this year. These accounts will appear in the Long-term Assets section of the balance sheet." },
                    { 10L, 2L, null, null, 0L, "Credit Card", null, null, 0L, "Use this to track purchases made using a credit card. Create an account for each credit card you use in your business. Purchases using your credit card, and payments to your credit card, should be recorded in the relevant credit card category." },
                    { 11L, 2L, null, null, 0L, "Loan and Line of Credit", null, null, 0L, "Use this to track the balance of outstanding loans or withdrawals you've made using a line of credit. The cash you receive as a result of a loan or line of credit is deposited into a Cash and Bank category." },
                    { 12L, 2L, null, null, 0L, "Expected Payments to Vendors", null, null, 0L, "Use this to track the balance of what you owe vendors (i.e. suppliers, online subscriptions providers) after you accepted their service or receive items for which you have not yet paid. Bills in Wave are already tracked in the Accounts Payable category." },
                    { 13L, 2L, null, null, 0L, "Sales Taxes", null, null, 0L, "Use this to track the sales taxes you have charged to customers during a sale, and sales tax amounts you have remitted to the government. The balance of this category indicates how much you have to remit to the government. This category can also be used to track sales taxes you been charged on purchases, so that you can reduce how much sales taxes you have to remit to the government. If you create a sales tax in Wave, a category here is created for you automatically." },
                    { 8L, 1L, null, null, 0L, "Other Short-Term Asset", null, null, 0L, "Use this to track amounts that you are owed this year when none of the other asset account types apply. Other Long-Term Asset accounts are used to track amounts that you are owed after this year. These accounts will appear in the Other Current Assets section of the balance sheet." }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 603L, "sales.invoice.payment.manage", 1L },
                    { 602L, "sales.product.manage", 1L },
                    { 601L, "sales.invoice.manage", 1L },
                    { 600L, "sales.customer.manage", 1L },
                    { 500L, "permissions.manage", 1L },
                    { 200L, "core.currency.manage", 1L },
                    { 300L, "organizations.manage", 1L },
                    { 102L, "accounting.transaction.manage", 1L },
                    { 101L, "accounting.chartofaccount.category.manage", 1L },
                    { 100L, "accounting.chartofaccount.manage", 1L },
                    { 604L, "sales.vendor.manage", 1L },
                    { 400L, "payments.manage", 1L },
                    { 700L, "users.manage", 1L }
                });

            migrationBuilder.InsertData(
                table: "ChartOfAccount",
                columns: new[] { "Id", "CategoryId", "Code", "CreatedAt", "CreatedBy", "Description", "IsDeletable", "IsEditable", "Name", "OrganizationId", "TypeId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 1L, null, null, 0L, "Cash you haven’t deposited in the bank. Add your bank and credit card accounts to accurately categorize transactions that aren't cash.", false, false, "Cash on Hand", null, 1L, null, 0L },
                    { 31L, 4L, null, null, 0L, "Foreign exchange losses happen when the exchange rate between your business's home currency and a foreign currency transaction changes and results in a loss. This can happen in the time between a transaction being entered in Wave and being settled, for example, between when you send an invoice and when your customer pays it. This can affect foreign currency invoice payments, bill payments, or foreign currency held in your bank account.", false, false, "Loss on Foreign Exchange", null, 28L, null, 0L },
                    { 30L, 4L, null, null, 0L, "A business cost you haven't categorized yet. Categorize it now to keep your records accurate.", false, false, "Uncategorized Expense", null, 27L, null, 0L },
                    { 29L, 4L, null, null, 0L, "Wages and salaries paid to your employees.", false, false, "Payroll – Salary & Wages", null, 26L, null, 0L },
                    { 28L, 4L, null, null, 0L, "The portion of federal and provincial/state obligations your business is responsible for paying as an employer.", false, false, "Payroll – Employer's Share of Benefits", null, 26L, null, 0L },
                    { 27L, 4L, null, null, 0L, "Federal and provincial/state deductions taken from an employee's pay, like employment insurance. These are usually described as line deductions on the pay stub.", false, false, "Payroll – Employee Benefits", null, 26L, null, 0L },
                    { 26L, 4L, null, null, 0L, "Repairs and preventative maitenance of the vehicle you drive for business.", false, false, "Vehicle – Repairs & Maintenance", null, 23L, null, 0L },
                    { 25L, 4L, null, null, 0L, "Gas and fuel costs when driving for business.", false, false, "Vehicle – Fuel", null, 23L, null, 0L },
                    { 24L, 4L, null, null, 0L, "Utilities (electricity, water, etc.) for your business office. Does not include phone use.", false, false, "Utilities", null, 23L, null, 0L },
                    { 23L, 4L, null, null, 0L, "Transportation and travel costs while traveling for business. Does not include daily commute costs.", false, false, "Travel Expense", null, 23L, null, 0L },
                    { 22L, 4L, null, null, 0L, "Mobile phone services for your business.", false, false, "Telephone – Wireless", null, 23L, null, 0L },
                    { 21L, 4L, null, null, 0L, "Land line phone services for your business.", false, false, "Telephone – Land Line", null, 23L, null, 0L },
                    { 20L, 4L, null, null, 0L, "Repair and upkeep of property or equipment, as long as the repair doesn't add value to the property. Does not include replacements or upgrades.", false, false, "Repairs & Maintenance", null, 23L, null, 0L },
                    { 19L, 4L, null, null, 0L, "Costs to rent or lease property or furniture for your business office space. Does not include equipment rentals.", false, false, "Rent Expense", null, 23L, null, 0L },
                    { 18L, 4L, null, null, 0L, "Fees you pay to consultants or trained professionals for advice or services related to your business.", false, false, "Professional Fees", null, 23L, null, 0L },
                    { 32L, 5L, null, null, 0L, "Owner investment represents the amount of money or assets you put into your business, either to start the business or keep it running. An owner's draw is a direct withdrawal from business cash or assets for your personal use.", false, false, "Owner Investment / Drawings", null, 29L, null, 0L },
                    { 17L, 4L, null, null, 0L, "Office supplies and services for your business office or space.", false, false, "Office Supplies", null, 23L, null, 0L },
                    { 15L, 4L, null, null, 0L, null, false, false, "Depreciation Expense", null, 23L, null, 0L },
                    { 14L, 4L, null, null, 0L, "Apps, software, and web or cloud services you use for business on your mobile phone or computer. Includes one-time purchases and subscriptions.", false, false, "Computer – Software", null, 23L, null, 0L },
                    { 13L, 4L, null, null, 0L, "Internet services for your business. Does not include data access for mobile devices.", false, false, "Computer – Internet", null, 23L, null, 0L },
                    { 12L, 4L, null, null, 0L, "Fees for web storage and access, like hosting your business website or app.", false, false, "Computer – Hosting", null, 23L, null, 0L },
                    { 11L, 4L, null, null, 0L, "Desktop or laptop computers, mobile phones, tablets, and accessories used for your business.", false, false, "Computer – Hardware", null, 23L, null, 0L },
                    { 10L, 4L, null, null, 0L, "Fees you pay to your bank like transaction charges, monthly charges, and overdraft charges.", false, false, "Bank Service Charges", null, 23L, null, 0L },
                    { 9L, 4L, null, null, 0L, "Advertising or other costs to promote your business. Includes web or social media promotion.", false, false, "Advertising & Promotion", null, 23L, null, 0L },
                    { 8L, 4L, null, null, 0L, "Accounting or bookkeeping services for your business.", false, false, "Accounting Fees", null, 23L, null, 0L },
                    { 7L, 3L, null, null, 0L, null, false, false, "Foreign exchange gains happen when the exchange rate between your business's home currency and a foreign currency transaction changes and results in a gain. This can happen in the time between a transaction being entered in Wave and being settled, for example, between when you send an invoice and when your customer pays it. This can affect foreign currency invoice payments, bill payments, or foreign currency held in your bank account.", null, 22L, null, 0L },
                    { 6L, 3L, null, null, 0L, "Income you haven't categorized yet. Categorize it now to keep your records accurate.", false, false, "Uncategorized Income", null, 21L, null, 0L },
                    { 5L, 3L, null, null, 0L, "Payments from your customers for products and services that your business sold.", false, false, "Sales", null, 18L, null, 0L },
                    { 4L, 2L, null, null, 0L, null, false, false, "Tax", null, 13L, null, 0L },
                    { 3L, 2L, null, null, 0L, null, false, false, "Accounts Payable", null, 12L, null, 0L },
                    { 2L, 1L, null, null, 0L, null, false, false, "Accounts Receivable", null, 3L, null, 0L },
                    { 16L, 4L, null, null, 0L, "Food and beverages you consume while conducting business, with clients and vendors, or entertaining customers.", false, false, "Meals and Entertainment", null, 23L, null, 0L },
                    { 33L, 5L, null, null, 0L, "Owner's equity is what remains after you subtract business liabilities from business assets. In other words, it's what's left over for you if you sell all your assets and pay all your debts.", false, false, "Owner's Equity", null, 30L, null, 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_DistrictId",
                table: "Address",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StateOrProvinceId",
                table: "Address",
                column: "StateOrProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_CategoryId",
                table: "ChartOfAccount",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccount_TypeId",
                table: "ChartOfAccount",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccountType_CategoryId",
                table: "ChartOfAccountType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CountryId",
                table: "CountryCurrency",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrencyId",
                table: "CountryCurrency",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguage_CountryId",
                table: "CountryLanguage",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguage_LanguageId",
                table: "CountryLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_District_StateOrProvinceId",
                table: "District",
                column: "StateOrProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerId",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_InvoiceId",
                table: "InvoiceLineItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLineItem_LineItemId",
                table: "InvoiceLineItem",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayment_InvoiceId",
                table: "InvoicePayment",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePayment_PaymentId",
                table: "InvoicePayment",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProductId",
                table: "LineItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItemTax_LineItemId",
                table: "LineItemTax",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItemTax_TaxId",
                table: "LineItemTax",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CurrencyId",
                table: "Order",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_LineItemId",
                table: "OrderLineItem",
                column: "LineItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLineItem_OrderId",
                table: "OrderLineItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_AddressId1",
                table: "Organization",
                column: "AddressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_CountryId1",
                table: "Organization",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_CurrencyId1",
                table: "Organization",
                column: "CurrencyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_TypeId1",
                table: "Organization",
                column: "TypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodId",
                table: "Payment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_PaymentProviderId",
                table: "PaymentMethod",
                column: "PaymentProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTax_ProductId",
                table: "ProductTax",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTax_TaxId",
                table: "ProductTax",
                column: "TaxId");

            migrationBuilder.CreateIndex(
                name: "IX_Qoute_CurrencyId",
                table: "Qoute",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Qoute_CustomerId",
                table: "Qoute",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StateOrProvince_CountryId1",
                table: "StateOrProvince",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_WarehouseId",
                table: "Stock",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CurrencyId",
                table: "User",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_AddressId",
                table: "Warehouse",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLanguage");

            migrationBuilder.DropTable(
                name: "InvoiceLineItem");

            migrationBuilder.DropTable(
                name: "InvoicePayment");

            migrationBuilder.DropTable(
                name: "LineItemTax");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "OrderLineItem");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationEntity");

            migrationBuilder.DropTable(
                name: "ProductTax");

            migrationBuilder.DropTable(
                name: "Qoute");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrganizationType");

            migrationBuilder.DropTable(
                name: "Tax");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "ChartOfAccount");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ChartOfAccountType");

            migrationBuilder.DropTable(
                name: "PaymentProvider");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "ChartOfAccountCategory");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "StateOrProvince");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
