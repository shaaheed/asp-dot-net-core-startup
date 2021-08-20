using Module.Sales.Entities;
using Msi.Core;
using Msi.Data.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Module.Sales.Domain
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Bill> _billRepo;
        private readonly IRepository<BillLineItem> _billLineItemRepo;

        public BillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _billRepo = _unitOfWork.GetRepository<Bill>();
            _billLineItemRepo = _unitOfWork.GetRepository<BillLineItem>();
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
                var lineItems = _billLineItemRepo
                    .WhereAsReadOnly(x => x.BillId == bill.Id)
                    .Select(x => new
                    {
                        Total = x.LineItem.Total,
                        Subtotal = x.LineItem.Subtotal
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

        public async Task<int> CreateOrUpdateBillLineItem(
            BillLineItemRequestDto request,
            Guid billId,
            Guid? lineItemId,
            CancellationToken cancellationToken = default)
        {
            var lineItem = request.Map();
            var billLineItem = new BillLineItem();
            if (request.Id.HasValue)
            {
                var savedInvoiceLineItem = await _billLineItemRepo
                    .FirstOrDefaultAsyncAsReadOnly(x => x.Id == request.Id.Value, x => new
                    {
                        Id = x.Id,
                        LineItemId = x.LineItemId
                    });

                if (savedInvoiceLineItem == null)
                    throw new ValidationException("Line item not found");

                billLineItem.Id = request.Id.Value;
                _billLineItemRepo.Attach(billLineItem);
                if (lineItemId.HasValue)
                {
                    var savedLineItem = await _unitOfWork.GetRepository<LineItem>()
                        .FirstOrDefaultAsyncAsReadOnly(x => x.Id == lineItemId.Value && !x.IsDeleted, x => new { Id = x.Id }, cancellationToken);
                    if (savedLineItem == null)
                        throw new ValidationException("Line item not found.");

                    lineItem.Id = lineItemId.Value;
                    billLineItem.LineItemId = lineItemId.Value;
                    billLineItem.LineItem = lineItem;
                }
            }
            else
            {
                billLineItem.LineItem = lineItem;
                billLineItem.BillId = billId;
                await _billLineItemRepo.AddAsync(billLineItem, cancellationToken);
            }
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result;
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
