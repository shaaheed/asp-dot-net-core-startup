//using Core.Interfaces.Data;
//using Module.Accounting.Entities;
//using System.Collections.Generic;

//namespace Module.Accounting.Data
//{
//    public class ChartOfAccountTypeSeed : ISeed<ChartOfAccountType>
//    {
//        public int Order => 1;
//        public IEnumerable<ChartOfAccountType> GetSeeds()
//        {
//            return new List<ChartOfAccountType>
//            {
//                // Assets
//                new ChartOfAccountType {
//                    Id = 1, Name = "Cash and Bank", UseOf = "Use this to track the balance of cash that is immediately available for use. Examples of this are bank accounts, cash boxes in a register, money boxes, or electronic accounts such as PayPal.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 2, Name = "Money in Transit", UseOf = "Use this to track the balance of money that is expected to deposited or withdrawn into or from a Cash and Bank account at a future date, usually within days. Examples of this are credit card sales that have been processed but have not yet been deposited into your bank, or checks (written or received) that have not been deposited into or withdrawn from your bank account yet.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 3, Name = "Expected Payments from Customers", UseOf = "Use this to track the balance of what customers owe you after you have made a sale. Invoices in Wave are already tracked in the Accounts Receivable category.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 4, Name = "Inventory", UseOf = "Use this to track the value of physical items you have in storage or in a retail store that are waiting to be sold/completed.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 5, Name = "Property, Plant, Equipment", UseOf = "Things you own but you do not sell to customers as part of your normal business operations.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 6, Name = "Depreciation and Amortization", UseOf = "Use this to track the decrease in value of things you own. For example, when you purchase equipment for business, it loses its value as time goes on. These categories always have a balance less than zero (negative).", CategoryId = 1 },

//                new ChartOfAccountType { Id = 7, Name = "Vendor Prepayments and Vendor Credits", UseOf = "Use this to track the value of the product or service that a vendor still needs to provide to you because you have made upfront payments to them. Examples of this are when you make upfront payments for insurance in the beginning of the year or for multiple years, or when a vendor gives you a credit note. The balance of the category will decrease over time as the vendor needs to provide less and less product or service to you.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 8, Name = "Other Short-Term Asset", UseOf = "Use this to track amounts that you are owed this year when none of the other asset account types apply. Other Long-Term Asset accounts are used to track amounts that you are owed after this year. These accounts will appear in the Other Current Assets section of the balance sheet.", CategoryId = 1 },

//                new ChartOfAccountType { Id = 9, Name = "Other Long-Term Asset", UseOf = "Use this to track amounts that you are owed after this year when none of the other asset account types apply. Other Short-Term Asset accounts are used to track amounts that you are owed this year. These accounts will appear in the Long-term Assets section of the balance sheet.", CategoryId = 1 },

//                // Liabilities & Credit Cards
//                new ChartOfAccountType { Id = 10, Name = "Credit Card", UseOf = "Use this to track purchases made using a credit card. Create an account for each credit card you use in your business. Purchases using your credit card, and payments to your credit card, should be recorded in the relevant credit card category.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 11, Name = "Loan and Line of Credit", UseOf = "Use this to track the balance of outstanding loans or withdrawals you've made using a line of credit. The cash you receive as a result of a loan or line of credit is deposited into a Cash and Bank category.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 12, Name = "Expected Payments to Vendors", UseOf = "Use this to track the balance of what you owe vendors (i.e. suppliers, online subscriptions providers) after you accepted their service or receive items for which you have not yet paid. Bills in Wave are already tracked in the Accounts Payable category.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 13, Name = "Sales Taxes", UseOf = "Use this to track the sales taxes you have charged to customers during a sale, and sales tax amounts you have remitted to the government. The balance of this category indicates how much you have to remit to the government. This category can also be used to track sales taxes you been charged on purchases, so that you can reduce how much sales taxes you have to remit to the government. If you create a sales tax in Wave, a category here is created for you automatically.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 14, Name = "Due to You and Other Business Owners", UseOf = "Use this to track the balance of what you (or your partners) have personally loaned to the business, but expect to be paid back for. The same category can also be used to track loans the business has given you (or your partners), in which case the balance would be less than zero (negative).", CategoryId = 2 },

//                new ChartOfAccountType { Id = 15, Name = "Customer Prepayments and Customer Credits", UseOf = "Use this to track the value of the product or service that you still need to provide to a customer because they made upfront payments to you. An example is when a customer gives you a deposit or a retainer, or when you give a customer a credit note. The balance of the category will decrease over time as you provide the product or service to the customer.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 16, Name = "Other Short-Term Liability", UseOf = "Use this to track amounts that you owe this year when none of the other liability account types apply. Other Long-Term Liability accounts are used to track amounts that you owe after this year. These accounts will appear in the Current Liabilities section of the balance sheet.", CategoryId = 2 },

//                new ChartOfAccountType { Id = 17, Name = "Other Long-Term Liability", UseOf = "Use this to track amounts that you owe after this year when none of the other liability account types apply. Other Short-Term Liability accounts are used to track amounts that you owe this year. These accounts will appear in the Long-term Liabilities section of the balance sheet.", CategoryId = 2 },

//                // Income
//                new ChartOfAccountType { Id = 18, Name = "Income", UseOf = "Use this to track all your sales to customers, whether your customer has made a payment or not. These are the categories used when you create an Invoice in Wave. Any sales taxes charged to customers will not be tracked using a Sales category, but will be tracked using a Sales Taxes on Sales or Purchases category.", CategoryId = 3 },

//                new ChartOfAccountType { Id = 19, Name = "Discount", UseOf = "Use this to track discounts you've given to customers so that you can determine if you are giving too many discounts. Discounts reduce your income, which is why it will be shown as a negative on the Profit and Loss report.", CategoryId = 3 },

//                new ChartOfAccountType { Id = 20, Name = "Other Income", UseOf = "Use this to track all other income that is outside of your regular business operations of selling to your customers. For example, if your main business is as a photographer, but you rented your camera to a friend as a one-off shoot, that could be other income.", CategoryId = 3 },

//                new ChartOfAccountType { Id = 21, Name = "Uncategorized Income", UseOf = "This account is used as the default category for new deposit transactions.", CategoryId = 3 },

//                new ChartOfAccountType { Id = 22, Name = "Gain On Foreign Exchange", UseOf = "This account is used to track gains due to exchange rate differences on foreign currency invoices, bills, and transfers.", CategoryId = 3 },

//                // Expenses
//                new ChartOfAccountType { Id = 23, Name = "Operating Expense", UseOf = "Use this to track most of your business expenses. Each type of office, insurance, rent, utilities, and subscription fees can have a category.", CategoryId = 4 },

//                new ChartOfAccountType { Id = 24, Name = "Cost of Goods Sold", UseOf = "Use this to track expenses that are directly attributable to the product or service you are selling. If there is a type of expense that cannot be attributable to sales, then you should create an Operating Expense category instead.", CategoryId = 4 },

//                new ChartOfAccountType { Id = 25, Name = "Payment Processing Fee", UseOf = "Use this to track the fees charged when your customer makes a credit card payment. Even though this is usually deducted from the transfer or deposit into your bank account, you should still be recording this type of expense.", CategoryId = 4 },

//                new ChartOfAccountType { Id = 26, Name = "Payroll Expense", UseOf = "Use this to track expenses related to running and approving a payroll for salaried and hourly employees. Do not use these categories to track payments to yourself, unless you are an employee of the business.", CategoryId = 4 },

//                new ChartOfAccountType { Id = 27, Name = "Uncategorized Expense", UseOf = "This account is used as the default category for new withdrawal transactions.", CategoryId = 4 },
//                new ChartOfAccountType { Id = 28, Name = "Loss On Foreign Exchange", UseOf = "This account is used to track losses due to exchange rate differences on foreign currency invoices, bills, and transfers.", CategoryId = 4 },

//                // Equity
//                new ChartOfAccountType { Id = 29, Name = "Business Owner Contribution and Drawing", UseOf = "Use this to track money you or others have invested into the business. For example, when you first start a business you usually invest start-up money into it.", CategoryId = 5 },

//                new ChartOfAccountType { Id = 30, Name = "Retained Earnings: Profit", UseOf = "Use this to track money that you have taken out of the business.", CategoryId = 5 }
//            };
//        }
//    }
//}
