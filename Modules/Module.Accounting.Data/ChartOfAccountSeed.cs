using Core.Interfaces.Data;
using System.Collections.Generic;

namespace Module.Accounting.Entities
{
    public class ChartOfAccountSeed : ISeed<ChartOfAccount>
    {
        public int Order => 1;
        public IEnumerable<ChartOfAccount> GetSeeds()
        {
            return new List<ChartOfAccount>
            {
                new ChartOfAccount { Id = 1, Name = "Cash on Hand", Description = "Cash you haven’t deposited in the bank. Add your bank and credit card accounts to accurately categorize transactions that aren't cash.", CategoryId = 1, TypeId = 1 },

                new ChartOfAccount { Id = 2, Name = "Accounts Receivable", CategoryId = 1, TypeId = 3 },

                new ChartOfAccount { Id = 3, Name = "Accounts Payable", CategoryId = 2, TypeId = 12 },

                new ChartOfAccount { Id = 4, Name = "Tax", CategoryId = 2, TypeId = 13 },

                new ChartOfAccount { Id = 5, Name = "Sales", Description = "Payments from your customers for products and services that your business sold.", CategoryId = 3, TypeId = 18 },

                new ChartOfAccount { Id = 6, Name = "Uncategorized Income", Description = "Income you haven't categorized yet. Categorize it now to keep your records accurate.", CategoryId = 3, TypeId = 21 },

                new ChartOfAccount { Id = 7, Name = "Foreign exchange gains happen when the exchange rate between your business's home currency and a foreign currency transaction changes and results in a gain. This can happen in the time between a transaction being entered in Wave and being settled, for example, between when you send an invoice and when your customer pays it. This can affect foreign currency invoice payments, bill payments, or foreign currency held in your bank account.", CategoryId = 3, TypeId = 22 },

                new ChartOfAccount { Id = 8, Name = "Accounting Fees", Description = "Accounting or bookkeeping services for your business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 9, Name = "Advertising & Promotion", Description = "Advertising or other costs to promote your business. Includes web or social media promotion.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 10, Name = "Bank Service Charges", Description = "Fees you pay to your bank like transaction charges, monthly charges, and overdraft charges.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 11, Name = "Computer – Hardware", Description = "Desktop or laptop computers, mobile phones, tablets, and accessories used for your business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 12, Name = "Computer – Hosting", Description = "Fees for web storage and access, like hosting your business website or app.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 13, Name = "Computer – Internet", Description = "Internet services for your business. Does not include data access for mobile devices.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 14, Name = "Computer – Software", Description = "Apps, software, and web or cloud services you use for business on your mobile phone or computer. Includes one-time purchases and subscriptions.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 15, Name = "Depreciation Expense", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 16, Name = "Meals and Entertainment", Description = "Food and beverages you consume while conducting business, with clients and vendors, or entertaining customers.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 17, Name = "Office Supplies", Description = "Office supplies and services for your business office or space.", CategoryId = 4, TypeId = 23 },


                new ChartOfAccount { Id = 18, Name = "Professional Fees", Description = "Fees you pay to consultants or trained professionals for advice or services related to your business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 19, Name = "Rent Expense", Description = "Costs to rent or lease property or furniture for your business office space. Does not include equipment rentals.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 20, Name = "Repairs & Maintenance", Description = "Repair and upkeep of property or equipment, as long as the repair doesn't add value to the property. Does not include replacements or upgrades.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 21, Name = "Telephone – Land Line", Description = "Land line phone services for your business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 22, Name = "Telephone – Wireless", Description = "Mobile phone services for your business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 23, Name = "Travel Expense", Description = "Transportation and travel costs while traveling for business. Does not include daily commute costs.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 24, Name = "Utilities", Description = "Utilities (electricity, water, etc.) for your business office. Does not include phone use.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 25, Name = "Vehicle – Fuel", Description = "Gas and fuel costs when driving for business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 26, Name = "Vehicle – Repairs & Maintenance", Description = "Repairs and preventative maitenance of the vehicle you drive for business.", CategoryId = 4, TypeId = 23 },

                new ChartOfAccount { Id = 27, Name = "Payroll – Employee Benefits", Description = "Federal and provincial/state deductions taken from an employee's pay, like employment insurance. These are usually described as line deductions on the pay stub.", CategoryId = 4, TypeId = 26 },

                new ChartOfAccount { Id = 28, Name = "Payroll – Employer's Share of Benefits", Description = "The portion of federal and provincial/state obligations your business is responsible for paying as an employer.", CategoryId = 4, TypeId = 26 },

                new ChartOfAccount { Id = 29, Name = "Payroll – Salary & Wages", Description = "Wages and salaries paid to your employees.", CategoryId = 4, TypeId = 26 },

                new ChartOfAccount { Id = 30, Name = "Uncategorized Expense", Description = "A business cost you haven't categorized yet. Categorize it now to keep your records accurate.", CategoryId = 4, TypeId = 27 },

                new ChartOfAccount { Id = 31, Name = "Loss on Foreign Exchange", Description = "Foreign exchange losses happen when the exchange rate between your business's home currency and a foreign currency transaction changes and results in a loss. This can happen in the time between a transaction being entered in Wave and being settled, for example, between when you send an invoice and when your customer pays it. This can affect foreign currency invoice payments, bill payments, or foreign currency held in your bank account.", CategoryId = 4, TypeId = 28 },

                new ChartOfAccount { Id = 32, Name = "Owner Investment / Drawings", Description = "Owner investment represents the amount of money or assets you put into your business, either to start the business or keep it running. An owner's draw is a direct withdrawal from business cash or assets for your personal use.", CategoryId = 5, TypeId = 29 },

                new ChartOfAccount { Id = 33, Name = "Owner's Equity", Description = "Owner's equity is what remains after you subtract business liabilities from business assets. In other words, it's what's left over for you if you sell all your assets and pay all your debts.", CategoryId = 5, TypeId = 30 }

            };
        }
    }
}
