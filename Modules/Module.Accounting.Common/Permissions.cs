namespace Module.Accounting.Common
{
    public static class Permissions
    {
        public const string ChartOfAccountCreate = "accounting.chartofaccount.create";
        public const string ChartOfAccountUpdate = "accounting.chartofaccount.update";
        public const string ChartOfAccountView = "accounting.chartofaccount.view";
        public const string ChartOfAccountDelete = "accounting.chartofaccount.delete";
        public const string ChartOfAccountList = "accounting.chartofaccount.list";
        public const string ChartOfAccountManage = "accounting.chartofaccount.manage";

        public const string ChartOfAccountCategoryCreate = "accounting.chartofaccount.category.create";
        public const string ChartOfAccountCategoryUpdate = "accounting.chartofaccount.category.update";
        public const string ChartOfAccountCategoryView = "accounting.chartofaccount.category.view";
        public const string ChartOfAccountCategoryDelete = "accounting.chartofaccount.category.delete";
        public const string ChartOfAccountCategoryList = "accounting.chartofaccount.category.list";
        public const string ChartOfAccountCategoryManage = "accounting.chartofaccount.category.manage";

        public const string TransactionCreate = "accounting.transaction.create";
        public const string TransactionUpdate = "accounting.transaction.update";
        public const string TransactionView = "accounting.transaction.view";
        public const string TransactionDelete = "accounting.transaction.delete";
        public const string TransactionList = "accounting.transaction.list";
        public const string TransactionManage = "accounting.transaction.manage";

        public static class Group
        {
            public const string ChartOfAccount = "Chart Of Account";
            public const string ChartOfAccountCategory = "Chart Of Account Category";
            public const string Transaction = "Transaction";
        }
    }
}
