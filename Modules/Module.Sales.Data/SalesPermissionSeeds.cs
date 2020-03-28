using Core.Interfaces.Data;
using Module.Permissions.Entities;
using System.Collections.Generic;
using static Module.Sales.Common.Permissions;

namespace Module.Sales.Data
{
    public class SalesPermissionSeeds : ISeed<Permission>
    {
        public int Order => 0;
        public IEnumerable<Permission> GetSeeds()
        {
            return new List<Permission>
            {
                #region Customer
                new Permission {
                    Id = CustomerCreate,
                    Name = "Create",
                    Group = Group.Customer
                },
                new Permission {
                    Id = CustomerUpdate,
                    Name = "Update",
                    Group = Group.Customer
                },
                new Permission {
                    Id = CustomerView,
                    Name = "View",
                    Group = Group.Customer
                },
                new Permission {
                    Id = CustomerList,
                    Name = "List",
                    Group = Group.Customer
                },
                new Permission {
                    Id = CustomerDelete,
                    Name = "Delete",
                    Group = Group.Customer
                },
                new Permission {
                    Id = CustomerManage,
                    Name = "Manage",
                    Group = Group.Customer
                },
                #endregion

                #region Invoice
                new Permission {
                    Id = InvoiceCreate,
                    Name = "Create",
                    Group = Group.Invoice
                },
                new Permission {
                    Id = InvoiceUpdate,
                    Name = "Update",
                    Group = Group.Invoice
                },
                new Permission {
                    Id = InvoiceView,
                    Name = "View",
                    Group = Group.Invoice
                },
                new Permission {
                    Id = InvoiceList,
                    Name = "List",
                    Group = Group.Invoice
                },
                new Permission {
                    Id = InvoiceDelete,
                    Name = "Delete",
                    Group = Group.Invoice
                },
                new Permission {
                    Id = InvoiceManage,
                    Name = "Manage",
                    Group = Group.Invoice
                },
                #endregion

                #region Product
                new Permission {
                    Id = ProductCreate,
                    Name = "Create",
                    Group = Group.Product
                },
                new Permission {
                    Id = ProductUpdate,
                    Name = "Update",
                    Group = Group.Product
                },
                new Permission {
                    Id = ProductView,
                    Name = "View",
                    Group = Group.Product
                },
                new Permission {
                    Id = ProductList,
                    Name = "List",
                    Group = Group.Product
                },
                new Permission {
                    Id = ProductDelete,
                    Name = "Delete",
                    Group = Group.Product
                },
                new Permission {
                    Id = ProductManage,
                    Name = "Manage",
                    Group = Group.Product
                },
                #endregion

                #region Invoice Payment
                new Permission {
                    Id = InvoicePaymentCreate,
                    Name = "Create",
                    Group = Group.InvoicePayment
                },
                new Permission {
                    Id = InvoicePaymentUpdate,
                    Name = "Update",
                    Group = Group.InvoicePayment
                },
                new Permission {
                    Id = InvoicePaymentView,
                    Name = "View",
                    Group = Group.InvoicePayment
                },
                new Permission {
                    Id = InvoicePaymentList,
                    Name = "List",
                    Group = Group.InvoicePayment
                },
                new Permission {
                    Id = InvoicePaymentDelete,
                    Name = "Delete",
                    Group = Group.InvoicePayment
                },
                new Permission {
                    Id = InvoicePaymentManage,
                    Name = "Manage",
                    Group = Group.InvoicePayment
                },
                #endregion

                #region Vendor
                new Permission {
                    Id = VendorCreate,
                    Name = "Create",
                    Group = Group.Vendor
                },
                new Permission {
                    Id = VendorUpdate,
                    Name = "Update",
                    Group = Group.Vendor
                },
                new Permission {
                    Id = VendorView,
                    Name = "View",
                    Group = Group.Vendor
                },
                new Permission {
                    Id = VendorList,
                    Name = "List",
                    Group = Group.Vendor
                },
                new Permission {
                    Id = VendorDelete,
                    Name = "Delete",
                    Group = Group.Vendor
                },
                new Permission {
                    Id = VendorManage,
                    Name = "Manage",
                    Group = Group.Vendor
                },
                #endregion

                #region Qoute
                new Permission {
                    Id = QouteCreate,
                    Name = "Create",
                    Group = Group.Qoute
                },
                new Permission {
                    Id = QouteUpdate,
                    Name = "Update",
                    Group = Group.Qoute
                },
                new Permission {
                    Id = QouteView,
                    Name = "View",
                    Group = Group.Qoute
                },
                new Permission {
                    Id = QouteList,
                    Name = "List",
                    Group = Group.Qoute
                },
                new Permission {
                    Id = QouteDelete,
                    Name = "Delete",
                    Group = Group.Qoute
                },
                new Permission {
                    Id = QouteManage,
                    Name = "Manage",
                    Group = Group.Qoute
                },
                #endregion

                #region Bill
                new Permission {
                    Id = BillCreate,
                    Name = "Create",
                    Group = Group.Bill
                },
                new Permission {
                    Id = BillUpdate,
                    Name = "Update",
                    Group = Group.Bill
                },
                new Permission {
                    Id = BillView,
                    Name = "View",
                    Group = Group.Bill
                },
                new Permission {
                    Id = BillList,
                    Name = "List",
                    Group = Group.Bill
                },
                new Permission {
                    Id = BillDelete,
                    Name = "Delete",
                    Group = Group.Bill
                },
                new Permission {
                    Id = BillManage,
                    Name = "Manage",
                    Group = Group.Bill
                }
                #endregion
            };
        }
    }
}
