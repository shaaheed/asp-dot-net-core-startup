namespace Module.Systems.Shared
{
    public static class Permissions
    {
        public const string CurrencyCreate = "core.currency.create";
        public const string CurrencyUpdate = "core.currency.update";
        public const string CurrencyView = "core.currency.view";
        public const string CurrencyDelete = "core.currency.delete";
        public const string CurrencyList = "core.currency.list";
        public const string CurrencyManage = "core.currency.manage";

        public static class Group
        {
            public const string Currency = "Customer";
        }
    }
}
