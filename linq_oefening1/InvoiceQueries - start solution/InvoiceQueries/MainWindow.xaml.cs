using InvoiceQueries.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace InvoiceQueries
{
    public partial class MainWindow : Window
    {
        private IList<Invoice> _allInvoices;
        private IList<Invoice> AllInvoices
        {
            get
            {
                if (_allInvoices == null)
                {
                    _allInvoices = InvoiceRepository.GetAll();
                }
                return _allInvoices;
            }
        }

        private IList<Vendor> _allVendors;
        private IList<Vendor> AllVendors
        {
            get
            {
                if (_allVendors == null)
                {
                    _allVendors = VendorRepository.GetAll();
                }
                return _allVendors;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowInvoicesSumButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Define the query expression
            var invoiceQuery = from invoice in AllInvoices select invoice;
            //TODO: write Linq query

            //Execute the query
            decimal sum = 0;
            foreach (var invoice in invoiceQuery) //triggers query execution
            {
                sum += invoice.InvoiceTotal;
            }
            MessageBox.Show(sum.ToString("C"), "Sum of invoices");
        }

        private void ShowBigInvoicesButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Define the query expression
            var bigInvoiceQuery = AllInvoices.Where(inv => inv.InvoiceTotal >= 20000);

            //Execute the query
            var resultBuilder = new StringBuilder("Invoice No.\tInvoice Total");
            resultBuilder.AppendLine();
            foreach (var invoice in bigInvoiceQuery) //triggers query execution
            {
                resultBuilder.AppendLine($"{invoice.InvoiceNumber}\t\t{invoice.InvoiceTotal:C}");
            }
            MessageBox.Show(resultBuilder.ToString());
        }

        private void ShowInvoicesDueButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Define the query expression
            var invoicesDueQuery = AllInvoices.Where(inv => inv.BalanceDue > 0).OrderByDescending(inv => inv.BalanceDue);

            //Execute the query
            var resultBuilder = new StringBuilder("Invoice No.\tBalance due");
            resultBuilder.AppendLine();
            foreach (var invoice in invoicesDueQuery) //triggers query execution
            {
                resultBuilder.AppendLine($"{invoice.InvoiceNumber.PadRight(15)}\t{invoice.BalanceDue:C}");
            }
            MessageBox.Show(resultBuilder.ToString());
        }

        private void ShowGroupedInvoicesButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Define the query expression
            var groupedInvoicesQuery =
                from invoice in AllInvoices
                where invoice.InvoiceTotal > 20000
                group invoice by invoice.VendorId into venderGroup
                select new
                {
                    VendorId = venderGroup.Key,
                    InvoiceCount = venderGroup.Count(),
                    Invoices = venderGroup
                };

            //TODO write Linq query

            //Execute the query
            var resultBuilder = new StringBuilder("Vendor Id (#invoices)\t\tInvoice No.\tInvoice Total");
            resultBuilder.AppendLine();
            foreach (var vendorInfo in groupedInvoicesQuery) //triggers query execution
            {
                resultBuilder.AppendLine($"{vendorInfo.VendorId} ({vendorInfo.InvoiceCount})");
                foreach (var invoice in vendorInfo.Invoices)
                {
                    resultBuilder.AppendLine($"\t\t\t{invoice.InvoiceNumber.PadRight(15)}\t{invoice.InvoiceTotal:C}");
                }
            }
            MessageBox.Show(resultBuilder.ToString());
        }
    }
}
