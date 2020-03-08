using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingWebHost.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plural",
                table: "Currency",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Code3", "CreatedAt", "CreatedBy", "Name", "Plural", "Symbol", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, "AED", null, 0L, "UAE dirham", "UAE dirhams", "AED", null, 0L },
                    { 103L, "NIO", null, 0L, "Cordoba Oro", "Cordobas Oro", "C$", null, 0L },
                    { 104L, "NOK", null, 0L, "Norwegian krone", "Norwegian kroner", "kr", null, 0L },
                    { 105L, "NPR", null, 0L, "Nepalese rupee", "Nepalese rupees", "₨", null, 0L },
                    { 106L, "NZD", null, 0L, "New Zealand dollar", "New Zealand dollars", "$", null, 0L },
                    { 107L, "OMR", null, 0L, "Omani rial", "Omani rials", "﷼", null, 0L },
                    { 108L, "PAB", null, 0L, "Balboa", "Balboas", "B/.", null, 0L },
                    { 109L, "PEN", null, 0L, "Nuevo Sol", "Nuevo Soles", "S/.", null, 0L },
                    { 102L, "NGN", null, 0L, "Naira", "Naira", "₦", null, 0L },
                    { 110L, "PGK", null, 0L, "Kina", "Kinas", "K", null, 0L },
                    { 112L, "PKR", null, 0L, "Pakistani rupee", "Pakistani rupees", "₨", null, 0L },
                    { 113L, "PLN", null, 0L, "Zloty", "Zloty", "zł", null, 0L },
                    { 114L, "PYG", null, 0L, "Guarani", "Guaranis", "Gs", null, 0L },
                    { 115L, "QAR", null, 0L, "Qatari riyal", "Qatari riyals", "﷼", null, 0L },
                    { 116L, "RON", null, 0L, "New Leu", "New Lei", "lei", null, 0L },
                    { 117L, "RSD", null, 0L, "Serbian dinar", "Serbian dinars", "Дин.", null, 0L },
                    { 118L, "RUB", null, 0L, "Russian rouble", "Russian roubles", "руб", null, 0L },
                    { 111L, "PHP", null, 0L, "Philippine peso", "Philippine pesos", "Php", null, 0L },
                    { 119L, "RWF", null, 0L, "Rwanda franc", "Rwanda francs", "R₣", null, 0L },
                    { 101L, "NAD", null, 0L, "Namibian dollar", "Namibian dollar", "N$", null, 0L },
                    { 99L, "MYR", null, 0L, "Malaysian ringgit", "Malaysian ringgit", "RM", null, 0L },
                    { 83L, "LTL", null, 0L, "Lithuanian litus", "Lithuanian litai", "Lt", null, 0L },
                    { 84L, "LVL", null, 0L, "Latvian lats", "Latvian lats", "Ls", null, 0L },
                    { 85L, "LYD", null, 0L, "Libyan dinar", "Libyan dinar", "ل.د", null, 0L },
                    { 86L, "MAD", null, 0L, "Moroccan dirham", "Moroccan dirhams", "د.م", null, 0L },
                    { 87L, "MDL", null, 0L, "Moldovan leu", "Moldovan lei", "L", null, 0L },
                    { 88L, "MGA", null, 0L, "Malagasy Ariary", "Malagasy Ariaries", "Ar", null, 0L },
                    { 89L, "MKD", null, 0L, "Denar", "Denari", "ден", null, 0L },
                    { 100L, "MZN", null, 0L, "Metical", "Meticais", "MT", null, 0L },
                    { 90L, "MMK", null, 0L, "Kyat", "Kyats", "K", null, 0L },
                    { 92L, "MOP", null, 0L, "Pataca", "Patacas", "MOP$", null, 0L },
                    { 93L, "MRO", null, 0L, "Ouguiya", "Ouguiyas", "UM", null, 0L },
                    { 94L, "MRU", null, 0L, "Ouguiya", "Ouguiyas", "UM", null, 0L },
                    { 95L, "MUR", null, 0L, "Mauritian rupee", "Mauritian rupees", "₨", null, 0L },
                    { 96L, "MVR", null, 0L, "Rufiyaa", "Rufiyaas", "Rf", null, 0L },
                    { 97L, "MWK", null, 0L, "Kwacha", "Kwacha", "MK", null, 0L },
                    { 98L, "MXN", null, 0L, "Mexican peso", "Mexican pesos", "$", null, 0L },
                    { 91L, "MNT", null, 0L, "Tugrik", "Tugriks", "₮", null, 0L },
                    { 120L, "SAR", null, 0L, "Saudi riyal", "Saudi riyals", "﷼", null, 0L },
                    { 121L, "SBD", null, 0L, "Solomon Islands dollar", "Solomon Islands dollars", "SI$", null, 0L },
                    { 122L, "SCR", null, 0L, "Seychelles rupee", "Seychelles rupees", "₨", null, 0L },
                    { 144L, "UAH", null, 0L, "Hryvnia", "Hryvni", "₴", null, 0L },
                    { 145L, "UGX", null, 0L, "Ugandan shilling", "Ugandan shillings", "UGX", null, 0L },
                    { 146L, "USD", null, 0L, "U.S. dollar", "U.S. dollars", "$", null, 0L },
                    { 147L, "UYU", null, 0L, "Uruguayo peso", "Uruguayo pesos", "$U", null, 0L },
                    { 148L, "UZS", null, 0L, "Uzbekistan sum", "Uzbekistan sum", "лв", null, 0L },
                    { 149L, "VEF", null, 0L, "Bolivar Fuerte", "Bolivares Fuerte", "Bs", null, 0L },
                    { 150L, "VND", null, 0L, "Dong", "Dongs", "₫", null, 0L },
                    { 143L, "TZS", null, 0L, "Tanzanian shilling", "Tanzanian shillings", "Sh", null, 0L },
                    { 151L, "VUV", null, 0L, "Vatu", "Vatu", "VT", null, 0L },
                    { 153L, "XAF", null, 0L, "CFA Franc - BEAC", "CFA Francs - BEAC", "Fr", null, 0L },
                    { 154L, "XCD", null, 0L, "Eastern Caribbean dollar", "Eastern Caribbean dollars", "$", null, 0L },
                    { 155L, "XOF", null, 0L, "CFA franc - BCEAO", "CFA francs - BCEAO", "CFA", null, 0L },
                    { 156L, "XPF", null, 0L, "Comptoirs Francais du Pacifique Francs", "Comptoirs Francais du Pacifique Francs", "₣", null, 0L },
                    { 157L, "YER", null, 0L, "Yemeni rial", "Yemeni rials", "﷼", null, 0L },
                    { 158L, "ZAR", null, 0L, "Rand", "Rand", "R", null, 0L },
                    { 159L, "ZMK", null, 0L, "Kwacha", "Kwachas", "ZK", null, 0L },
                    { 152L, "WST", null, 0L, "Samoan Tala", "Samoan Talas", "$", null, 0L },
                    { 142L, "TWD", null, 0L, "New Taiwan dollar", "New Taiwan dollars", "NT$", null, 0L },
                    { 141L, "TTD", null, 0L, "Trinidad and Tobago dollar", "Trinidad and Tobago dollars", "TT$", null, 0L },
                    { 140L, "TRY", null, 0L, "Turkish lira", "Turkish liras", "TL", null, 0L },
                    { 123L, "SDG", null, 0L, "Sudanese pound", "Sudanese pounds", "£", null, 0L },
                    { 124L, "SEK", null, 0L, "Swedish krona", "Swedish kronur", "kr", null, 0L },
                    { 125L, "SGD", null, 0L, "Singapore dollar", "Singapore dollars", "$", null, 0L },
                    { 126L, "SHP", null, 0L, "Saint Helena pound", "Saint Helena pounds", "£", null, 0L },
                    { 127L, "SLL", null, 0L, "Leone", "Leones", "Le", null, 0L },
                    { 128L, "SOS", null, 0L, "Somali shilling", "Somali shillings", "S", null, 0L },
                    { 129L, "SRD", null, 0L, "Surinam dollar", "Surinam dollars", "$", null, 0L },
                    { 130L, "SSP", null, 0L, "South Sudanese pound", "South Sudanese pounds", "£", null, 0L },
                    { 131L, "STD", null, 0L, "Dobra", "Dobras", "Db", null, 0L },
                    { 132L, "SVC", null, 0L, "El Salvador colon", "El Salvador colones", "$", null, 0L },
                    { 133L, "SYP", null, 0L, "Syrian pound", "Syrian pounds", "£S", null, 0L },
                    { 134L, "SZL", null, 0L, "Lilangeni", "Emalangeni", "E", null, 0L },
                    { 135L, "THB", null, 0L, "Baht", "Baht", "฿", null, 0L },
                    { 136L, "TJS", null, 0L, "Somoni", "Somonis", "SM", null, 0L },
                    { 137L, "TMM", null, 0L, "Manat", "Manat", "m", null, 0L },
                    { 138L, "TND", null, 0L, "Tunisian dinar", "Tunisian dinars", "TND", null, 0L },
                    { 139L, "TOP", null, 0L, "Pa'anga", "Pa'anga", "$", null, 0L },
                    { 82L, "LSL", null, 0L, "Loti", "Maloti", "M", null, 0L },
                    { 160L, "ZMW", null, 0L, "Kwacha", "Kwachas", "ZK", null, 0L },
                    { 81L, "LRD", null, 0L, "Liberian dollar", "Liberian dollars", "$", null, 0L },
                    { 79L, "LBP", null, 0L, "Lebanese pound", "Lebanese pounds", "LBP", null, 0L },
                    { 22L, "BTN", null, 0L, "Ngultrum", "Ngultrums", "Nu.", null, 0L },
                    { 23L, "BWP", null, 0L, "Pula", "Pula", "P", null, 0L },
                    { 24L, "BYR", null, 0L, "Belarussian rouble", "Belarussian roubles", "p.", null, 0L },
                    { 25L, "BZD", null, 0L, "Belize dollar", "Belize dollars", "BZ$", null, 0L },
                    { 26L, "CAD", null, 0L, "Canadian dollar", "Canadian dollars", "$", null, 0L },
                    { 27L, "CDF", null, 0L, "Franc congolais", "Francs congolais", "₣", null, 0L },
                    { 28L, "CHF", null, 0L, "Swiss franc", "Swiss francs", "CHF", null, 0L },
                    { 21L, "BSD", null, 0L, "Bahamian dollar", "Bahamian dollars", "$", null, 0L },
                    { 29L, "CLP", null, 0L, "Chilean peso", "Chilean pesos", "$", null, 0L },
                    { 31L, "COP", null, 0L, "Colombian peso", "Colombian pesos", "$", null, 0L },
                    { 32L, "CRC", null, 0L, "Costa Rican colon", "Costa Rican colones", "₡", null, 0L },
                    { 33L, "CUP", null, 0L, "Cuban peso", "Cuban pesos", "₱", null, 0L },
                    { 34L, "CVE", null, 0L, "Cape Verde escudo", "Cape Verde escudos", "Esc", null, 0L },
                    { 35L, "CZK", null, 0L, "Czech koruna", "Czech korun", "Kč", null, 0L },
                    { 36L, "DJF", null, 0L, "Djibouti franc", "Djibouti francs", "₣", null, 0L },
                    { 37L, "DKK", null, 0L, "Danish krone", "Danish kroner", "kr", null, 0L },
                    { 30L, "CNY", null, 0L, "Ren-Min-Bi yuan", "Ren-Min-Bi yuan", "¥", null, 0L },
                    { 38L, "DOP", null, 0L, "Dominican peso", "Dominican pesos", "RD$", null, 0L },
                    { 20L, "BRL", null, 0L, "Real", "Reales", "R$", null, 0L },
                    { 18L, "BND", null, 0L, "Brunei dollar", "Brunei dollars", "$", null, 0L },
                    { 2L, "AFN", null, 0L, "Afghani", "Afganis", "؋", null, 0L },
                    { 3L, "ALL", null, 0L, "Lek", "Lekë", "Lek", null, 0L },
                    { 4L, "AMD", null, 0L, "Armenian dram", "Armenian drams", "֏", null, 0L },
                    { 5L, "ANG", null, 0L, "Netherlands Antillean guilder", "Netherlands Antillean guilders", "ƒ", null, 0L },
                    { 6L, "AOA", null, 0L, "Kwanza", "Kwanzas", "Kz", null, 0L },
                    { 7L, "ARS", null, 0L, "Argentinian peso", "Argentinian pesos", "$", null, 0L },
                    { 8L, "AUD", null, 0L, "Australian dollar", "Australian dollars", "$", null, 0L },
                    { 19L, "BOB", null, 0L, "Boliviano", "Bolivianos", "$b", null, 0L },
                    { 9L, "AWG", null, 0L, "Aruban florin", "Aruban florin", "ƒ", null, 0L },
                    { 11L, "BAM", null, 0L, "Convertible Marks", "Convertible Marks", "KM", null, 0L },
                    { 12L, "BBD", null, 0L, "Barbados dollar", "Barbados dollars", "$", null, 0L },
                    { 13L, "BDT", null, 0L, "Taka", "Takas", "৳", null, 0L },
                    { 14L, "BGN", null, 0L, "Lev", "Leva", "лв", null, 0L },
                    { 15L, "BHD", null, 0L, "Bahraini dinar", "Bahraini dinars", "BD", null, 0L },
                    { 16L, "BIF", null, 0L, "Burundi franc", "Burundi francs", "FBu", null, 0L },
                    { 17L, "BMD", null, 0L, "Bermuda dollar", "Bermuda dollars", "$", null, 0L },
                    { 10L, "AZN", null, 0L, "New Manat", "New Manat", "ман", null, 0L },
                    { 39L, "DZD", null, 0L, "Algerian dinar", "Algerian dinars", "د.ج", null, 0L },
                    { 40L, "EEK", null, 0L, "Estonian kroon", "Estonian krooni", "kr", null, 0L },
                    { 41L, "EGP", null, 0L, "Egyptian pound", "Egyptian pounds", "E £", null, 0L },
                    { 63L, "INR", null, 0L, "Indian rupee", "Indian rupees", "₹", null, 0L },
                    { 64L, "IQD", null, 0L, "Iraqi dinar", "Iraqi dinars", "د.ع", null, 0L },
                    { 65L, "IRR", null, 0L, "Iranian rial", "Iranian rials", "﷼", null, 0L },
                    { 66L, "ISK", null, 0L, "Icelandic króna", "Icelandic krónur", "kr", null, 0L },
                    { 67L, "JMD", null, 0L, "Jamaican dollar", "Jamaican dollars", "J$", null, 0L },
                    { 68L, "JOD", null, 0L, "Jordanian dinar", "Jordanian dinars", "د.ا", null, 0L },
                    { 69L, "JPY", null, 0L, "Yen", "Yen", "¥", null, 0L },
                    { 62L, "ILS", null, 0L, "New Israeli sheqel", "New Israeli sheqels", "₪", null, 0L },
                    { 70L, "KES", null, 0L, "Kenyan shilling", "Kenyan shillings", "SH", null, 0L },
                    { 72L, "KHR", null, 0L, "Riel", "Riels", "៛", null, 0L },
                    { 73L, "KMF", null, 0L, "Comoro franc", "Comoro francs", "₣", null, 0L },
                    { 74L, "KRW", null, 0L, "Won", "Won", "₩", null, 0L },
                    { 75L, "KWD", null, 0L, "Kuwaiti dinar", "Kuwaiti dinars", "د.ك", null, 0L },
                    { 76L, "KYD", null, 0L, "Cayman Islands dollar", "Cayman Islands dollars", "$", null, 0L },
                    { 77L, "KZT", null, 0L, "Tenge", "Tenge", "лв", null, 0L },
                    { 78L, "LAK", null, 0L, "Kip", "Kips", "₭", null, 0L },
                    { 71L, "KGS", null, 0L, "Kyrgyz Som", "Kyrgyz Soms", "лв", null, 0L },
                    { 61L, "IDR", null, 0L, "Rupiah", "Rupiahs", "Rp", null, 0L },
                    { 60L, "HUF", null, 0L, "Forint", "Forints", "Ft", null, 0L },
                    { 59L, "HTG", null, 0L, "Haitian gourde", "Haitian gourdes", "G", null, 0L },
                    { 42L, "ERN", null, 0L, "Nakfa", "Nakfas", "Nfk", null, 0L },
                    { 43L, "ETB", null, 0L, "Ethiopian birr", "Ethiopian birrs", "Br", null, 0L },
                    { 44L, "EUR", null, 0L, "Euro", "Euros", "€", null, 0L },
                    { 45L, "FJD", null, 0L, "Fiji dollar", "Fiji dollars", "$", null, 0L },
                    { 46L, "FKP", null, 0L, "Falkland Islands (Malvinas) pound", "Falkland Islands (Malvinas) pounds", "£", null, 0L },
                    { 47L, "GBP", null, 0L, "Pound sterling", "Pounds sterling", "£", null, 0L },
                    { 48L, "GEL", null, 0L, "Lari", "Lari", "ლ", null, 0L },
                    { 49L, "GHS", null, 0L, "Ghana cedi", "Ghana cedis", "GH¢", null, 0L },
                    { 50L, "GIP", null, 0L, "Gibraltar pound", "Gibraltar pounds", "£", null, 0L },
                    { 51L, "GMD", null, 0L, "Dalasi", "Dalasi", "D", null, 0L },
                    { 52L, "GNF", null, 0L, "Guinean franc", "Guinean francs", "₣", null, 0L },
                    { 53L, "GTQ", null, 0L, "Quetzal", "Quetzales", "Q", null, 0L },
                    { 54L, "GWP", null, 0L, "Guinea-Bissau peso", "Guinea-Bissau pesos", "$", null, 0L },
                    { 55L, "GYD", null, 0L, "Guyana dollar", "Guyana dollars", "$", null, 0L },
                    { 56L, "HKD", null, 0L, "Hong Kong dollar", "Hong Kong dollars", "$", null, 0L },
                    { 57L, "HNL", null, 0L, "Lempira", "Lempiras", "L", null, 0L },
                    { 58L, "HRK", null, 0L, "Kuna", "Kunas", "kn", null, 0L },
                    { 80L, "LKR", null, 0L, "Sri Lankan rupee", "Sri Lankan rupees", "₨", null, 0L },
                    { 161L, "ZWD", null, 0L, "Zimbabwean dollar", "Zimbabwean dollars", "Z$", null, 0L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 41L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 42L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 43L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 44L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 45L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 46L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 47L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 48L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 49L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 50L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 51L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 52L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 53L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 54L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 55L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 56L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 57L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 58L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 59L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 60L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 61L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 62L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 63L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 64L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 65L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 66L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 67L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 68L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 69L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 70L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 71L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 72L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 73L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 74L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 75L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 76L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 77L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 78L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 79L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 80L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 81L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 82L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 83L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 84L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 85L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 86L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 87L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 88L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 89L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 90L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 91L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 92L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 93L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 94L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 95L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 96L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 97L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 98L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 99L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 100L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 103L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 104L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 105L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 106L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 107L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 108L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 109L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 110L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 111L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 112L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 113L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 114L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 115L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 116L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 117L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 118L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 119L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 120L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 121L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 122L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 123L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 124L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 125L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 126L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 127L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 128L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 129L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 130L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 131L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 132L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 133L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 134L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 135L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 136L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 137L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 138L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 139L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 140L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 141L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 142L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 143L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 144L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 145L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 146L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 147L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 148L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 149L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 150L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 151L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 152L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 153L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 154L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 155L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 156L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 157L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 158L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 159L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 160L);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 161L);

            migrationBuilder.DropColumn(
                name: "Plural",
                table: "Currency");
        }
    }
}
