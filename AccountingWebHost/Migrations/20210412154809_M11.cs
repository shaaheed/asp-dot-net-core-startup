using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Organization",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KeyValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValue", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("63f4c8dc-6863-4971-8066-3aca28af142e"), "AED", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "UAE dirham", "UAE dirhams", "AED", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("dede3fec-dfa0-4e23-aa01-3790ad5bdef7"), "NIO", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Cordoba Oro", "Cordobas Oro", "C$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e061cb16-3146-4a3a-948e-92973065ec63"), "NOK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Norwegian krone", "Norwegian kroner", "kr", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("238ea326-d416-459d-aced-895503f3e3c8"), "NPR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Nepalese rupee", "Nepalese rupees", "₨", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6f450580-4010-43fb-b6f9-067c37db0252"), "NZD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "New Zealand dollar", "New Zealand dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b5ee806c-c823-43c3-8c2e-0854637937b9"), "OMR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Omani rial", "Omani rials", "﷼", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9a3f388e-37d4-4627-8a30-3b181173c589"), "PAB", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Balboa", "Balboas", "B/.", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ad804988-fcf6-4ba0-8419-e982f77d6b7e"), "PEN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Nuevo Sol", "Nuevo Soles", "S/.", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0f393913-8795-4ded-be14-b76a721787f5"), "NGN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Naira", "Naira", "₦", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("355f755c-c472-40c4-8d0b-8628dde6414a"), "PGK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kina", "Kinas", "K", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fd642a42-76bd-4566-bd44-ee1c4bfeaee1"), "PKR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Pakistani rupee", "Pakistani rupees", "₨", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b8108219-6534-43c2-9afa-868b77ee6b9d"), "PLN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Zloty", "Zloty", "zł", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("dc23fbf1-28cc-40d8-8dfc-f0c3e6049201"), "PYG", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Guarani", "Guaranis", "Gs", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fe96676a-58bd-4309-8f45-94a4f5362380"), "QAR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Qatari riyal", "Qatari riyals", "﷼", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bb6f58af-6871-4f3b-8e68-16c615b9a7ae"), "RON", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "New Leu", "New Lei", "lei", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("06d20c1b-0cd6-4426-b7a4-a76a27010ef5"), "RSD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Serbian dinar", "Serbian dinars", "Дин.", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("611ffb55-aae8-4cca-923a-7a3c246c14fc"), "RUB", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Russian rouble", "Russian roubles", "руб", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("023197f3-b75d-4028-b65f-d5ce4666ef88"), "PHP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Philippine peso", "Philippine pesos", "Php", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d4487ded-0120-4f47-a4eb-c522b2c1c45b"), "RWF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Rwanda franc", "Rwanda francs", "R₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c3950228-3a3d-4edc-9cef-aff52440d2c0"), "NAD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Namibian dollar", "Namibian dollar", "N$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ee7550f7-965f-4635-b51c-0f2ca03c0169"), "MYR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Malaysian ringgit", "Malaysian ringgit", "RM", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0e4fd2a1-fca2-40c9-bd73-6479a13fb512"), "LTL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lithuanian litus", "Lithuanian litai", "Lt", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9b34e0e1-757c-4e69-b1a2-1f93e25ebe88"), "LVL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Latvian lats", "Latvian lats", "Ls", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("056da660-c2cb-4ac7-9da6-995810ff8e09"), "LYD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Libyan dinar", "Libyan dinar", "ل.د", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f8be9a73-bee0-47e8-952b-d264a8b720b0"), "MAD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Moroccan dirham", "Moroccan dirhams", "د.م", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5fa0d5cc-983c-436d-aada-f3848c7bad5a"), "MDL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Moldovan leu", "Moldovan lei", "L", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9c0e7483-a8d6-4ced-837c-bd2f4bc68b4b"), "MGA", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Malagasy Ariary", "Malagasy Ariaries", "Ar", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d1f581fc-99b1-4564-87b7-2ece82d8570d"), "MKD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Denar", "Denari", "ден", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2720c97a-f434-4f6a-966c-379f24c85d79"), "MZN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Metical", "Meticais", "MT", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("10abba60-de27-4d91-b6b8-9e872485e00d"), "MMK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kyat", "Kyats", "K", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("09347574-cf53-4142-8a3c-4b747d2df1ba"), "MOP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Pataca", "Patacas", "MOP$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cf0418a0-9e22-44e2-85c5-bc0622c762c2"), "MRO", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ouguiya", "Ouguiyas", "UM", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("500c2fc9-93ff-4971-a920-8ef6eb1e07d1"), "MRU", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ouguiya", "Ouguiyas", "UM", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("398e5f1d-6b48-4779-9905-74eaaae15a76"), "MUR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Mauritian rupee", "Mauritian rupees", "₨", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("66837a54-2802-4d0a-b290-e56e23d312de"), "MVR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Rufiyaa", "Rufiyaas", "Rf", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b0566eeb-067f-47a3-8a73-02f3153635ee"), "MWK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kwacha", "Kwacha", "MK", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("89141a33-a8ad-437d-a877-9944568b8172"), "MXN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Mexican peso", "Mexican pesos", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("81be630a-d757-4da5-b4df-81dcc66fa055"), "MNT", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Tugrik", "Tugriks", "₮", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("afe4045d-3d67-4365-94f3-f61e792b25e3"), "SAR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Saudi riyal", "Saudi riyals", "﷼", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2f4dd201-09c7-493d-a188-82c98bde65a7"), "SBD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Solomon Islands dollar", "Solomon Islands dollars", "SI$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0def5ec1-7183-46ec-939a-99ca805013f0"), "SCR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Seychelles rupee", "Seychelles rupees", "₨", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5b543466-6028-4afb-a103-47888f1e6264"), "UAH", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Hryvnia", "Hryvni", "₴", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("5d67e99e-4885-4c18-bd5a-407bf84cfa75"), "UGX", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ugandan shilling", "Ugandan shillings", "UGX", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7ce57a4f-bf49-4c07-8b5a-801f1431fa22"), "USD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "U.S. dollar", "U.S. dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e32a2be7-aa9c-44c0-8155-6d138ad4a950"), "UYU", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Uruguayo peso", "Uruguayo pesos", "$U", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ccc3cfd3-507b-43de-a4cc-9a18e490a9de"), "UZS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Uzbekistan sum", "Uzbekistan sum", "лв", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7f223126-caf8-4bde-9e0d-6e688529e0c3"), "VEF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Bolivar Fuerte", "Bolivares Fuerte", "Bs", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8a959aec-852d-4f6e-863b-ad5db323e78c"), "VND", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Dong", "Dongs", "₫", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cebad91b-0bdf-415c-b7a1-ad38b44915fd"), "TZS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Tanzanian shilling", "Tanzanian shillings", "Sh", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4af1de3a-433a-43b0-a762-37172347207e"), "VUV", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Vatu", "Vatu", "VT", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("369a8041-6d84-4167-97cf-603aa3cf0aef"), "XAF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "CFA Franc - BEAC", "CFA Francs - BEAC", "Fr", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("87887e89-ec57-4448-bd5c-17c38f938bb8"), "XCD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Eastern Caribbean dollar", "Eastern Caribbean dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a933ef62-ee56-43af-ac6f-2b280e28c74a"), "XOF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "CFA franc - BCEAO", "CFA francs - BCEAO", "CFA", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("68584ee5-4962-426b-a3c0-6ec714989089"), "XPF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Comptoirs Francais du Pacifique Francs", "Comptoirs Francais du Pacifique Francs", "₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ac045fb8-e07a-4fcb-9283-cb2bdf00bb5e"), "YER", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Yemeni rial", "Yemeni rials", "﷼", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("97a5a296-96d0-469b-93a0-c9eb89a7bfe7"), "ZAR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Rand", "Rand", "R", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c964646b-e097-47ac-a637-26395905e79b"), "ZMK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kwacha", "Kwachas", "ZK", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9a53163d-85e9-4f99-9ce3-01ecd20ee949"), "WST", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Samoan Tala", "Samoan Talas", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bd587ae1-5ad5-4b23-9dc4-fa73f2d3723f"), "TWD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "New Taiwan dollar", "New Taiwan dollars", "NT$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6cca2984-1bda-4810-a81e-4f9e5e8885fc"), "TTD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Trinidad and Tobago dollar", "Trinidad and Tobago dollars", "TT$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("34a05fff-fb2c-4f05-9c5d-66858efece57"), "TRY", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Turkish lira", "Turkish liras", "TL", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("25c1177b-9e97-45bc-b492-d3e6c764128f"), "SDG", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Sudanese pound", "Sudanese pounds", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a9edd292-de95-4e75-85f8-62556105dc21"), "SEK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Swedish krona", "Swedish kronur", "kr", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c3522cff-7479-4cd1-b8da-1e5021589838"), "SGD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Singapore dollar", "Singapore dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c56f4eb5-daaa-4f4d-a3c1-96199a174048"), "SHP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Saint Helena pound", "Saint Helena pounds", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("41f3e2d8-b465-40ab-8e04-4c3f7a1f4de7"), "SLL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Leone", "Leones", "Le", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c4348c2a-36ba-4dc2-b45d-5085209caf6d"), "SOS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Somali shilling", "Somali shillings", "S", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("aa76b5ba-49f5-4ad5-b9b1-c2fb2adff912"), "SRD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Surinam dollar", "Surinam dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cc8d3722-3e99-4a0f-a2b4-d0c44485f992"), "SSP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "South Sudanese pound", "South Sudanese pounds", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5b80c226-19bd-4054-ab71-a3abe666189b"), "STD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Dobra", "Dobras", "Db", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("14a73aeb-c52b-4e65-98d2-e1fdb3f156a2"), "SVC", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "El Salvador colon", "El Salvador colones", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1eb7326d-d93c-4d6d-933e-829616e6ffda"), "SYP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Syrian pound", "Syrian pounds", "£S", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b94c744c-6939-4fae-bfbc-73be73a0f7a1"), "SZL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lilangeni", "Emalangeni", "E", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d0dd9e8b-1447-4e96-8650-480952ca088d"), "THB", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Baht", "Baht", "฿", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2f5ece9d-c2c1-426a-aa85-6b9c9bc7c6e9"), "TJS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Somoni", "Somonis", "SM", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00cd2a2b-0056-4a0f-a67e-d8253d3f6059"), "TMM", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Manat", "Manat", "m", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ea52cdc6-bee4-4d80-85a3-cd5e9fb068d5"), "TND", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Tunisian dinar", "Tunisian dinars", "TND", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d8b1453b-9112-4b2a-a2bc-254cfca7864e"), "TOP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Pa'anga", "Pa'anga", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0aa7adc6-0016-44ab-9ceb-a3df9d94c6bc"), "LSL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Loti", "Maloti", "M", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4e78ce83-dfdc-4b5d-b5c2-0307036508e8"), "ZMW", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kwacha", "Kwachas", "ZK", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7943d411-fb9b-4268-aef6-e36d598b14bf"), "LRD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Liberian dollar", "Liberian dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0aa7a62a-11b8-47fe-8f02-e90443f5f8ad"), "LBP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lebanese pound", "Lebanese pounds", "LBP", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8ccdf5ed-8166-4a3c-8a9b-69401127f735"), "BTN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ngultrum", "Ngultrums", "Nu.", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1fcb8567-24de-466c-9bdd-c01b46a2caeb"), "BWP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Pula", "Pula", "P", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("9e82904e-840a-42e0-b1f2-b2adb1851c4d"), "BYR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Belarussian rouble", "Belarussian roubles", "p.", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("51089759-519b-474f-9e65-dac86c204769"), "BZD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Belize dollar", "Belize dollars", "BZ$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1af1b8d6-be5d-437d-8bd4-08055203993b"), "CAD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Canadian dollar", "Canadian dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d5af2acd-dc1a-45bd-9517-98e82607e2ff"), "CDF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Franc congolais", "Francs congolais", "₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8712b274-59d3-4e70-bd63-70c95c50b7fc"), "CHF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Swiss franc", "Swiss francs", "CHF", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("aaac99d7-c2d2-418e-95db-53694bcf40c0"), "BSD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Bahamian dollar", "Bahamian dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("73b40d5e-5e36-439f-a6bd-9d09f2852ac3"), "CLP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Chilean peso", "Chilean pesos", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ffc33209-5e2e-4d4a-aeff-46af3944f563"), "COP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Colombian peso", "Colombian pesos", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("64e55e0e-618f-4ab8-b394-00eac916b6ec"), "CRC", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Costa Rican colon", "Costa Rican colones", "₡", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("624366be-fc32-4393-b7f5-e16ddd4fbbcb"), "CUP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Cuban peso", "Cuban pesos", "₱", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("0268c118-585a-4df6-974a-1ba9db038130"), "CVE", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Cape Verde escudo", "Cape Verde escudos", "Esc", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8f4e3de1-300d-4170-af62-b03ff8028d56"), "CZK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Czech koruna", "Czech korun", "Kč", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("86ba8684-3ed5-4afb-b8c3-e069d1def19f"), "DJF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Djibouti franc", "Djibouti francs", "₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3755dd5e-e409-4e2d-a989-16c42cb1c593"), "DKK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Danish krone", "Danish kroner", "kr", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d89f497d-e6c8-43ce-868a-9806af78d207"), "CNY", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ren-Min-Bi yuan", "Ren-Min-Bi yuan", "¥", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e7e33739-6ae0-43ba-9b80-56f6f0eee721"), "DOP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Dominican peso", "Dominican pesos", "RD$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("be88fc3b-4665-4ce6-b0b8-4f76071106d0"), "BRL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Real", "Reales", "R$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2fb32292-c3d6-409e-a9d7-76fdd1d04093"), "BND", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Brunei dollar", "Brunei dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ec56bd2a-a134-495c-9708-bace3aa8e710"), "AFN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Afghani", "Afganis", "؋", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("840cc1e2-269b-482a-becb-a120586b8a33"), "ALL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lek", "Lekë", "Lek", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c5ec4b94-6226-4d48-9ec8-3f87ce3e0d66"), "AMD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Armenian dram", "Armenian drams", "֏", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("20804d96-c11f-4623-9961-6c57cd60597c"), "ANG", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Netherlands Antillean guilder", "Netherlands Antillean guilders", "ƒ", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c0687019-d389-4dd3-84d4-404d305deb10"), "AOA", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kwanza", "Kwanzas", "Kz", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cd9eb67d-7254-47f7-8e1d-168653d04998"), "ARS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Argentinian peso", "Argentinian pesos", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("18e92f5d-82d6-4e41-a413-c113a8a5df2c"), "AUD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Australian dollar", "Australian dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("852810b4-6794-4948-90e0-069f057eca21"), "BOB", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Boliviano", "Bolivianos", "$b", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c583ebda-3db2-46ce-8790-be51280f977c"), "AWG", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Aruban florin", "Aruban florin", "ƒ", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("40dd02af-9799-48a0-a87b-09d6ce16d7cf"), "BAM", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Convertible Marks", "Convertible Marks", "KM", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b6e458a1-b515-435b-8408-125b05ea4e48"), "BBD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Barbados dollar", "Barbados dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6f902863-ba4f-44a5-8b94-c9d7080b8b7c"), "BDT", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Taka", "Takas", "৳", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4b546137-30d9-481f-8290-d933bbcae452"), "BGN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lev", "Leva", "лв", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("eb4931ce-00f1-4cf8-b4b6-971591253a9f"), "BHD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Bahraini dinar", "Bahraini dinars", "BD", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("55033a9e-671c-473d-96b6-67b8ad86f056"), "BIF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Burundi franc", "Burundi francs", "FBu", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5e47fcca-58e1-447e-9896-88c8920e9438"), "BMD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Bermuda dollar", "Bermuda dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cd8b67ab-06e2-4145-adb5-b18f3755cf30"), "AZN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "New Manat", "New Manat", "ман", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cfaac572-0d03-45f9-8d00-bdb7ea4605dd"), "DZD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Algerian dinar", "Algerian dinars", "د.ج", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a3cd1e66-fe13-4a79-b269-f8a9391bc595"), "EEK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Estonian kroon", "Estonian krooni", "kr", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("202bf744-2038-4658-bab4-794962bf7b2e"), "EGP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Egyptian pound", "Egyptian pounds", "E £", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fa568b86-8e82-456c-bd08-5bdcf9ae595b"), "INR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Indian rupee", "Indian rupees", "₹", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("443d3178-c48b-48cc-9693-f02e31996b69"), "IQD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Iraqi dinar", "Iraqi dinars", "د.ع", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d849f6e4-05f2-466b-835f-a20d372f9568"), "IRR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Iranian rial", "Iranian rials", "﷼", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("63f1636d-c5a8-43c3-bae9-1e0892a16d6d"), "ISK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Icelandic króna", "Icelandic krónur", "kr", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "IsDeleted", "Name", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("c080a6ef-a13f-4761-a0ec-2af59e6ca3f8"), "JMD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Jamaican dollar", "Jamaican dollars", "J$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("13719ead-c45e-468c-ad53-2a90de678029"), "JOD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Jordanian dinar", "Jordanian dinars", "د.ا", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("84c642db-8857-49b5-bdfc-a2d655f96428"), "JPY", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Yen", "Yen", "¥", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1d98496b-3583-46f0-b42c-73726bc92360"), "ILS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "New Israeli sheqel", "New Israeli sheqels", "₪", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("630a79bf-7cd4-4f3a-af10-ad182b5bf205"), "KES", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kenyan shilling", "Kenyan shillings", "SH", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("181209f3-34bb-4fc6-82df-710c6ae5625b"), "KHR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Riel", "Riels", "៛", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("07c95d0c-98d0-4be7-808c-b3b529730028"), "KMF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Comoro franc", "Comoro francs", "₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("531a6f53-43f4-4576-9c52-97f6ac74b0e6"), "KRW", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Won", "Won", "₩", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d501ca46-aba2-49ed-9af8-d96fe594456a"), "KWD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kuwaiti dinar", "Kuwaiti dinars", "د.ك", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("08b339d4-b5d4-4b80-964b-d63dc61e81b1"), "KYD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Cayman Islands dollar", "Cayman Islands dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("22e51645-f524-4164-a7bb-2ca25e3f7b66"), "KZT", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Tenge", "Tenge", "лв", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5cf6a865-98dc-4f95-9b1f-e6c4f78f62ee"), "LAK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kip", "Kips", "₭", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("000db371-07c3-4f01-92cd-de94ed140e7d"), "KGS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kyrgyz Som", "Kyrgyz Soms", "лв", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8fd3f2af-3ed8-4b17-abbc-fc9d8aadea4e"), "IDR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Rupiah", "Rupiahs", "Rp", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("63346b08-8e7d-4a39-b1e1-9d85e5121631"), "HUF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Forint", "Forints", "Ft", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("b04aff33-cf3b-45de-8b59-f5cea73caa0a"), "HTG", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Haitian gourde", "Haitian gourdes", "G", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5d88271e-05bb-46fa-b02a-d129d195e86a"), "ERN", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Nakfa", "Nakfas", "Nfk", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("502e3289-427f-4681-a52d-75e6020288ff"), "ETB", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ethiopian birr", "Ethiopian birrs", "Br", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("81a1b960-d26a-4e45-9473-edf0bc2e0f96"), "EUR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Euro", "Euros", "€", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("fc01207f-0299-4191-a21f-3d851d335ad4"), "FJD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Fiji dollar", "Fiji dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("562a2ae9-fd93-4da8-9ef9-726ea8a992c9"), "FKP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Falkland Islands (Malvinas) pound", "Falkland Islands (Malvinas) pounds", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("00f96cc1-93db-4361-b53a-07e93f34c514"), "GBP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Pound sterling", "Pounds sterling", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a28e6f8d-d6c3-4b59-94d5-f7073fb41ef9"), "GEL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lari", "Lari", "ლ", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("eee5778e-a203-4f0c-a0d8-85854b4e1aab"), "GHS", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Ghana cedi", "Ghana cedis", "GH¢", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("526cc251-7274-47b8-9918-50cf6cd93837"), "GIP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Gibraltar pound", "Gibraltar pounds", "£", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("2ad7ceac-fb94-4e69-83f6-546ff53f6dbe"), "GMD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Dalasi", "Dalasi", "D", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("577173ba-078b-4869-97cc-5290334b51f0"), "GNF", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Guinean franc", "Guinean francs", "₣", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("32c947ce-1fe7-4525-9f36-41ca33fcf19e"), "GTQ", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Quetzal", "Quetzales", "Q", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ff8b54b4-4767-40ca-9bd9-385a5f42929e"), "GWP", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Guinea-Bissau peso", "Guinea-Bissau pesos", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c8667ec8-9671-4800-85b7-b16fd7917156"), "GYD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Guyana dollar", "Guyana dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5fbe7960-72b9-4afa-84db-f8cc1473bc9a"), "HKD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Hong Kong dollar", "Hong Kong dollars", "$", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ce40007a-fe85-4035-8e36-a867e104920e"), "HNL", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Lempira", "Lempiras", "L", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bd295809-8418-4342-aa53-8b45a1bec5bb"), "HRK", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Kuna", "Kunas", "kn", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1b93cb56-9061-4a56-b016-af14ac6ee0fd"), "LKR", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Sri Lankan rupee", "Sri Lankan rupees", "₨", null, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("40bae6d1-3f25-4056-97a8-793a32c51efa"), "ZWD", null, new Guid("00000000-0000-0000-0000-000000000000"), false, "Zimbabwean dollar", "Zimbabwean dollars", "Z$", null, new Guid("00000000-0000-0000-0000-000000000000") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyValue");

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("000db371-07c3-4f01-92cd-de94ed140e7d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("00cd2a2b-0056-4a0f-a67e-d8253d3f6059"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("00f96cc1-93db-4361-b53a-07e93f34c514"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("023197f3-b75d-4028-b65f-d5ce4666ef88"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0268c118-585a-4df6-974a-1ba9db038130"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("056da660-c2cb-4ac7-9da6-995810ff8e09"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("06d20c1b-0cd6-4426-b7a4-a76a27010ef5"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("07c95d0c-98d0-4be7-808c-b3b529730028"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("08b339d4-b5d4-4b80-964b-d63dc61e81b1"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("09347574-cf53-4142-8a3c-4b747d2df1ba"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0aa7a62a-11b8-47fe-8f02-e90443f5f8ad"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0aa7adc6-0016-44ab-9ceb-a3df9d94c6bc"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0def5ec1-7183-46ec-939a-99ca805013f0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0e4fd2a1-fca2-40c9-bd73-6479a13fb512"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("0f393913-8795-4ded-be14-b76a721787f5"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("10abba60-de27-4d91-b6b8-9e872485e00d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("13719ead-c45e-468c-ad53-2a90de678029"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("14a73aeb-c52b-4e65-98d2-e1fdb3f156a2"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("181209f3-34bb-4fc6-82df-710c6ae5625b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("18e92f5d-82d6-4e41-a413-c113a8a5df2c"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("1af1b8d6-be5d-437d-8bd4-08055203993b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("1b93cb56-9061-4a56-b016-af14ac6ee0fd"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("1d98496b-3583-46f0-b42c-73726bc92360"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("1eb7326d-d93c-4d6d-933e-829616e6ffda"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("1fcb8567-24de-466c-9bdd-c01b46a2caeb"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("202bf744-2038-4658-bab4-794962bf7b2e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("20804d96-c11f-4623-9961-6c57cd60597c"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("22e51645-f524-4164-a7bb-2ca25e3f7b66"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("238ea326-d416-459d-aced-895503f3e3c8"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("25c1177b-9e97-45bc-b492-d3e6c764128f"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2720c97a-f434-4f6a-966c-379f24c85d79"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2ad7ceac-fb94-4e69-83f6-546ff53f6dbe"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2f4dd201-09c7-493d-a188-82c98bde65a7"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2f5ece9d-c2c1-426a-aa85-6b9c9bc7c6e9"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("2fb32292-c3d6-409e-a9d7-76fdd1d04093"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("32c947ce-1fe7-4525-9f36-41ca33fcf19e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("34a05fff-fb2c-4f05-9c5d-66858efece57"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("355f755c-c472-40c4-8d0b-8628dde6414a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("369a8041-6d84-4167-97cf-603aa3cf0aef"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("3755dd5e-e409-4e2d-a989-16c42cb1c593"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("398e5f1d-6b48-4779-9905-74eaaae15a76"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("40bae6d1-3f25-4056-97a8-793a32c51efa"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("40dd02af-9799-48a0-a87b-09d6ce16d7cf"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("41f3e2d8-b465-40ab-8e04-4c3f7a1f4de7"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("443d3178-c48b-48cc-9693-f02e31996b69"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("4af1de3a-433a-43b0-a762-37172347207e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("4b546137-30d9-481f-8290-d933bbcae452"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("4e78ce83-dfdc-4b5d-b5c2-0307036508e8"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("500c2fc9-93ff-4971-a920-8ef6eb1e07d1"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("502e3289-427f-4681-a52d-75e6020288ff"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("51089759-519b-474f-9e65-dac86c204769"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("526cc251-7274-47b8-9918-50cf6cd93837"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("531a6f53-43f4-4576-9c52-97f6ac74b0e6"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("55033a9e-671c-473d-96b6-67b8ad86f056"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("562a2ae9-fd93-4da8-9ef9-726ea8a992c9"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("577173ba-078b-4869-97cc-5290334b51f0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5b543466-6028-4afb-a103-47888f1e6264"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5b80c226-19bd-4054-ab71-a3abe666189b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5cf6a865-98dc-4f95-9b1f-e6c4f78f62ee"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5d67e99e-4885-4c18-bd5a-407bf84cfa75"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5d88271e-05bb-46fa-b02a-d129d195e86a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5e47fcca-58e1-447e-9896-88c8920e9438"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5fa0d5cc-983c-436d-aada-f3848c7bad5a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("5fbe7960-72b9-4afa-84db-f8cc1473bc9a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("611ffb55-aae8-4cca-923a-7a3c246c14fc"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("624366be-fc32-4393-b7f5-e16ddd4fbbcb"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("630a79bf-7cd4-4f3a-af10-ad182b5bf205"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("63346b08-8e7d-4a39-b1e1-9d85e5121631"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("63f1636d-c5a8-43c3-bae9-1e0892a16d6d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("63f4c8dc-6863-4971-8066-3aca28af142e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("64e55e0e-618f-4ab8-b394-00eac916b6ec"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("66837a54-2802-4d0a-b290-e56e23d312de"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("68584ee5-4962-426b-a3c0-6ec714989089"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("6cca2984-1bda-4810-a81e-4f9e5e8885fc"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("6f450580-4010-43fb-b6f9-067c37db0252"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("6f902863-ba4f-44a5-8b94-c9d7080b8b7c"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("73b40d5e-5e36-439f-a6bd-9d09f2852ac3"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("7943d411-fb9b-4268-aef6-e36d598b14bf"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("7ce57a4f-bf49-4c07-8b5a-801f1431fa22"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("7f223126-caf8-4bde-9e0d-6e688529e0c3"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("81a1b960-d26a-4e45-9473-edf0bc2e0f96"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("81be630a-d757-4da5-b4df-81dcc66fa055"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("840cc1e2-269b-482a-becb-a120586b8a33"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("84c642db-8857-49b5-bdfc-a2d655f96428"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("852810b4-6794-4948-90e0-069f057eca21"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("86ba8684-3ed5-4afb-b8c3-e069d1def19f"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("8712b274-59d3-4e70-bd63-70c95c50b7fc"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("87887e89-ec57-4448-bd5c-17c38f938bb8"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("89141a33-a8ad-437d-a877-9944568b8172"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("8a959aec-852d-4f6e-863b-ad5db323e78c"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("8ccdf5ed-8166-4a3c-8a9b-69401127f735"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("8f4e3de1-300d-4170-af62-b03ff8028d56"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("8fd3f2af-3ed8-4b17-abbc-fc9d8aadea4e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("97a5a296-96d0-469b-93a0-c9eb89a7bfe7"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("9a3f388e-37d4-4627-8a30-3b181173c589"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("9a53163d-85e9-4f99-9ce3-01ecd20ee949"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("9b34e0e1-757c-4e69-b1a2-1f93e25ebe88"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("9c0e7483-a8d6-4ced-837c-bd2f4bc68b4b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("9e82904e-840a-42e0-b1f2-b2adb1851c4d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("a28e6f8d-d6c3-4b59-94d5-f7073fb41ef9"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("a3cd1e66-fe13-4a79-b269-f8a9391bc595"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("a933ef62-ee56-43af-ac6f-2b280e28c74a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("a9edd292-de95-4e75-85f8-62556105dc21"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("aa76b5ba-49f5-4ad5-b9b1-c2fb2adff912"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("aaac99d7-c2d2-418e-95db-53694bcf40c0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ac045fb8-e07a-4fcb-9283-cb2bdf00bb5e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ad804988-fcf6-4ba0-8419-e982f77d6b7e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("afe4045d-3d67-4365-94f3-f61e792b25e3"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b04aff33-cf3b-45de-8b59-f5cea73caa0a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b0566eeb-067f-47a3-8a73-02f3153635ee"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b5ee806c-c823-43c3-8c2e-0854637937b9"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b6e458a1-b515-435b-8408-125b05ea4e48"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b8108219-6534-43c2-9afa-868b77ee6b9d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("b94c744c-6939-4fae-bfbc-73be73a0f7a1"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("bb6f58af-6871-4f3b-8e68-16c615b9a7ae"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("bd295809-8418-4342-aa53-8b45a1bec5bb"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("bd587ae1-5ad5-4b23-9dc4-fa73f2d3723f"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("be88fc3b-4665-4ce6-b0b8-4f76071106d0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c0687019-d389-4dd3-84d4-404d305deb10"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c080a6ef-a13f-4761-a0ec-2af59e6ca3f8"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c3522cff-7479-4cd1-b8da-1e5021589838"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c3950228-3a3d-4edc-9cef-aff52440d2c0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c4348c2a-36ba-4dc2-b45d-5085209caf6d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c56f4eb5-daaa-4f4d-a3c1-96199a174048"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c583ebda-3db2-46ce-8790-be51280f977c"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c5ec4b94-6226-4d48-9ec8-3f87ce3e0d66"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c8667ec8-9671-4800-85b7-b16fd7917156"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("c964646b-e097-47ac-a637-26395905e79b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cc8d3722-3e99-4a0f-a2b4-d0c44485f992"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ccc3cfd3-507b-43de-a4cc-9a18e490a9de"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cd8b67ab-06e2-4145-adb5-b18f3755cf30"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cd9eb67d-7254-47f7-8e1d-168653d04998"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ce40007a-fe85-4035-8e36-a867e104920e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cebad91b-0bdf-415c-b7a1-ad38b44915fd"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cf0418a0-9e22-44e2-85c5-bc0622c762c2"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("cfaac572-0d03-45f9-8d00-bdb7ea4605dd"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d0dd9e8b-1447-4e96-8650-480952ca088d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d1f581fc-99b1-4564-87b7-2ece82d8570d"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d4487ded-0120-4f47-a4eb-c522b2c1c45b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d501ca46-aba2-49ed-9af8-d96fe594456a"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d5af2acd-dc1a-45bd-9517-98e82607e2ff"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d849f6e4-05f2-466b-835f-a20d372f9568"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d89f497d-e6c8-43ce-868a-9806af78d207"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("d8b1453b-9112-4b2a-a2bc-254cfca7864e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("dc23fbf1-28cc-40d8-8dfc-f0c3e6049201"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("dede3fec-dfa0-4e23-aa01-3790ad5bdef7"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("e061cb16-3146-4a3a-948e-92973065ec63"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("e32a2be7-aa9c-44c0-8155-6d138ad4a950"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("e7e33739-6ae0-43ba-9b80-56f6f0eee721"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ea52cdc6-bee4-4d80-85a3-cd5e9fb068d5"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("eb4931ce-00f1-4cf8-b4b6-971591253a9f"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ec56bd2a-a134-495c-9708-bace3aa8e710"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ee7550f7-965f-4635-b51c-0f2ca03c0169"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("eee5778e-a203-4f0c-a0d8-85854b4e1aab"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("f8be9a73-bee0-47e8-952b-d264a8b720b0"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("fa568b86-8e82-456c-bd08-5bdcf9ae595b"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("fc01207f-0299-4191-a21f-3d851d335ad4"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("fd642a42-76bd-4566-bd44-ee1c4bfeaee1"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("fe96676a-58bd-4309-8f45-94a4f5362380"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ff8b54b4-4767-40ca-9bd9-385a5f42929e"));

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: new Guid("ffc33209-5e2e-4d4a-aeff-46af3944f563"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Organization");
        }
    }
}
