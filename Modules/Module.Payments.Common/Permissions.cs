namespace Module.Payments.Common
{
    public static class Permissions
    {
        public const string PaymentCreate = "payments.create";
        public const string PaymentUpdate = "payments.update";
        public const string PaymentView = "payments.view";
        public const string PaymentDelete = "payments.delete";
        public const string PaymentList = "payments.list";
        public const string PaymentManage = "payments.manage";

        public static class Group
        {
            public const string Payment = "Payment";
        }
    }
}
