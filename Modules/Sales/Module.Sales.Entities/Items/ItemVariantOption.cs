﻿using Msi.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Sales.Entities
{
    public class ItemVariantOption : OrganizationEntity
    {
        public Guid? ItemVariantId { get; set; }
        [ForeignKey(nameof(ItemVariantId))]
        public virtual ItemVariant ItemVariant { get; set; }

        public Guid? VariantOptionId { get; set; }
        [ForeignKey(nameof(VariantOptionId))]
        public virtual VariantOption VariantOption { get; set; }

        public Guid? SaleDetailsId { get; set; }
        public virtual SaleDetails SaleDetails { get; set; }

        public Guid? PurchaseDetailsId { get; set; }
        public virtual PurchaseDetails PurchaseDetails { get; set; }
    }
}
