using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SampleApp.Models;
using SampleApp.Services;

namespace SampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            
            Invoice invoice = new Invoice();
            InvoiceFileService.SaveInvoiceFile(invoice);
            if (!string.IsNullOrEmpty(tbProductName1.Text))
            {
                InvoiceItem invoiceItem = new InvoiceItem()
                {
                    Name = tbProductName1.Text,
                    AmountNet = Convert.ToDouble(tbAmount1.Text)
                };

                invoiceItem.SetAmountNet(Convert.ToDouble(tbNettoPrice1.Text));
                invoiceItem.SetVatRate(Convert.ToInt32(tbVat1.Text));
                invoiceItem.CalculateGrossAmount();
            }
            if (!string.IsNullOrEmpty(tbProductName2.Text))
            {
                InvoiceItem invoiceItem = new InvoiceItem()
                {
                    Name = tbProductName2.Text,
                    AmountNet = Convert.ToDouble(tbAmount2.Text)
                };

                invoiceItem.SetAmountNet(Convert.ToDouble(tbNettoPrice2.Text));
                invoiceItem.SetVatRate(Convert.ToInt32(tbVat2.Text));
                invoiceItem.CalculateGrossAmount();
            }
        }
    }
}
