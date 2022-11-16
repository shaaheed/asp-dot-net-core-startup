using Msi.Data.Entity;

namespace Module.Sales.Entities
{
    public class Term : NameEntity, IOrganizationEntity
    {
        public Guid? OrganizationId { get; set; }

        /// <summary>
        /// Enable the Standard option if this payment term is based on the number of days since the invoice was issued, for example, for customer payments that are due within 30 days of the date the bill is created.
        /// Enable the Date Driven option if the payment term is based on a particular calendar date, for example, for customer payments that are due on or before the 20th of any given month.
        /// </summary>
        public TermOption Option { get; set; } = TermOption.Standard;

        /// <summary>
        /// Enter the number of days until the net amount of the bill becomes due.
        /// For example, if you are creating a term of Net 30, enter 30 in this field.
        /// 
        /// For date driven terms, enter the day of the month when the net amount of the invoice is due.
        /// If you enter a date that does not exist in the month the transaction is due, the last day of the month becomes the due date.
        /// </summary>
        public float Days { get; set; }

        /// <summary>
        /// Enter the percentage discount if the invoice is paid early.
        /// </summary>
        public float? Discount { get; set; }

        /// <summary>
        /// For standard terms, enter the number of days the early payment discount is available.
        /// For example, if the early payment discount is available for 15 days after the bill is issued, enter 15 in this field.
        /// 
        /// If you offer a discount for early payment under date driven terms, enter the last day of the month the early payment discount is available.
        /// For example, if the early payment discount is available through the 20th of each month, enter 20 in this field.
        /// </summary>
        public int? DiscountExpires { get; set; }

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Check this box to make this term or message show by default on sales transactions you create.
        /// Note: Terms set on customer records override terms marked as preferred.
        /// </summary>
        public bool IsPreferred { get; set; }

    }
}
