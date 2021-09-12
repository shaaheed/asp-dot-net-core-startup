using Module.Systems.Entities;
using System;

namespace Module.Sales.Entities
{
    public class AccountType : CodeNameEntity
    {
        public string Description { get; set; }
        public string UseOf { get; set; }

        public Guid? ParentAccountTypeId { get; set; }
        public AccountType ParentAccountType { get; set; }

        public readonly static Guid ASSET = Guid.Parse("");
        public readonly static Guid LIABILITIES = Guid.Parse("");
        public readonly static Guid EQUITY = Guid.Parse("");
        public readonly static Guid REVENUES = Guid.Parse("");
        public readonly static Guid EXPENSES = Guid.Parse("");

    }
}
