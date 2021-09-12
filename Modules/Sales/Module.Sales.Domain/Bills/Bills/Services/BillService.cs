using Module.Sales.Entities;
using Msi.Data.Abstractions;
using System;
using System.Linq;

namespace Module.Sales.Domain
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bill> _billRepo;
        private readonly IRepository<LineItem> _lineItemRepo;

        public BillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _billRepo = _unitOfWork.GetRepository<Bill>();
            _lineItemRepo = _unitOfWork.GetRepository<LineItem>();
        }

        public void AddPayment(Guid billId)
        {
            var bill = _billRepo
                .Where(x => x.Id == billId && !x.IsDeleted)
                .FirstOrDefault();
            AddPayment(bill);
        }

        public void Calculate(Bill bill)
        {
            if (bill != null)
            {
                decimal grandTotal = 0;
                decimal subtotal = 0;
                var lineItems = _lineItemRepo
                    .WhereAsReadOnly(x => x.ReferenceId == bill.Id && x.Type == LineItemType.Purchase)
                    .Select(x => new
                    {
                        Total = x.Total,
                        Subtotal = x.Subtotal
                    });
                foreach (var item in lineItems)
                {
                    grandTotal += item.Total;
                    subtotal += item.Subtotal;
                }
                grandTotal += bill.AdjustmentAmount;
                bill.GrandTotal = grandTotal;
                bill.Subtotal = subtotal;
            }
        }

        public void AddPayment(Bill bill)
        {
            if (bill != null)
            {
                var paymentsAmount = GetBillPaymentsAmount(bill.Id);
                if (bill.GrandTotal == paymentsAmount)
                {
                    // Full payment
                    bill.Status = Status.Paid;
                    bill.AmountDue = 0;
                }
                else if (bill.GrandTotal > paymentsAmount)
                {
                    bill.Status = Status.Due;
                }

                if (paymentsAmount <= bill.GrandTotal)
                {
                    bill.AmountDue = bill.GrandTotal - paymentsAmount;
                }
            }
        }

        public decimal GetBillPaymentsAmount(Guid billId)
        {
            var paymentAmount = _unitOfWork.GetRepository<BillPayment>()
                .WhereAsReadOnly(x => x.BillId == billId && !x.Bill.IsDeleted)
                .Select(x => x.Payment.Amount)
                .Sum();
            return paymentAmount;
        }

        public string GetNextBillNumber()
        {
            var count = _billRepo
                .WhereAsReadOnly(x => !x.IsDeleted)
                .Select(x => x.Id)
                .LongCount();

            return $"BILL-{count + 1}";
        }

        public decimal GetPayablesAmount(Guid? supplierId)
        {
            if (supplierId == null) return 0;
            decimal amount = _billRepo
                .WhereAsReadOnly(x => x.SupplierId == supplierId && x.AmountDue > 0 && !x.IsDeleted)
                .Select(x => x.AmountDue)
                .Sum();
            return amount;
        }

        public Guid? GetSupplierId(Guid billId)
        {
            return _billRepo
                .WhereAsReadOnly(x => x.Id == billId && !x.IsDeleted)
                .Select(x => x.SupplierId)
                .FirstOrDefault();
        }
    }
}
