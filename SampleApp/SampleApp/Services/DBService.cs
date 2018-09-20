using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public static class DBService
    {
        public static string ConnectionString;

        public static List<Invoice> GetAllInvoices(string connectionStringParameter)
        {
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                if (connectionStringParameter != string.Empty)
                    connectionString = connectionStringParameter;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Invoice", connection);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice();
                            invoice.Id = (string)reader[0];
                            invoice.IssueDate = (DateTime?)reader[1];
                            invoice.BuyerData = (string)reader[2];
                            invoice.SellerData = (string)reader[3];

                            invoices.Add(invoice);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
            

            return invoices;
        }

        public static List<Invoice> GetInvoiceById(string connectionStringParameter, string invoiceId)
        {
            List<Invoice> invoices = new List<Invoice>();

            try
            {
                string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                if (connectionStringParameter != string.Empty)
                    connectionString = connectionStringParameter;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM Invoice WHERE Id = @InvoiceId", connection);
                    selectCommand.Parameters.Add(new SqlParameter("InvoiceId", invoiceId));

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        // while there is another record present
                        while (reader.Read())
                        {
                            Invoice invoice = new Invoice();
                            invoice.Id = (string)reader[0];
                            invoice.IssueDate = (DateTime?)reader[1];
                            invoice.BuyerData = (string)reader[2];
                            invoice.SellerData = (string)reader[3];

                            invoices.Add(invoice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }


            return invoices;
        }

        public static bool InvoiceExists(string invoiceId)
        {
            bool result = false;
            string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand selectCommand = new SqlCommand("SELECT 1 FROM Invoice WHERE Id = @InvoiceId", connection);
                selectCommand.Parameters.Add(new SqlParameter("InvoiceId", invoiceId));

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        if (reader.FieldCount > 0)
                            result = true;
                    }
                }
            }

            return result;
        }

        public static void InsertInvoice(Invoice invoice)
        {
            if (invoice.IssueDate == null)
                throw new ArgumentNullException();

            string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Invoice (Id, IssueDate, BuyerData, SellerData) VALUES (@Id, @IssueDate, @BuyerData, @SellerData)", connection);
                insertCommand.Parameters.Add(new SqlParameter("Id", invoice.Id));
                insertCommand.Parameters.Add(new SqlParameter("IssueDate", invoice.IssueDate));
                insertCommand.Parameters.Add(new SqlParameter("BuyerData", invoice.BuyerData));
                insertCommand.Parameters.Add(new SqlParameter("SellerData", invoice.SellerData));

                insertCommand.ExecuteNonQuery();
            }
        }

        public static void InsertInvoiceItem(InvoiceItem invoiceItem)
        {
            if (invoiceItem.Amount <= 0
                || invoiceItem.AmountNet <= 0
                || invoiceItem.AmountGross <= 0
                || string.IsNullOrEmpty(invoiceItem.Unit)
                || string.IsNullOrEmpty(invoiceItem.Name)
                || string.IsNullOrEmpty(invoiceItem.InvoiceId))
                throw new ArgumentException();

            string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand insertCommand =
                    new SqlCommand("INSERT INTO InvoiceItem (Id, InvoiceId, Name, VatRate, AmountNet, AmountGross, Amount, Unit) "
                    + "VALUES (@Id, @InvoiceId, @Name, @VatRate, @AmountNet, @AmountGross, @Amount, @Unit)", connection);
                insertCommand.Parameters.Add(new SqlParameter("Id", invoiceItem.Id));
                insertCommand.Parameters.Add(new SqlParameter("InvoiceId", invoiceItem.InvoiceId));
                insertCommand.Parameters.Add(new SqlParameter("Name", invoiceItem.Name));
                insertCommand.Parameters.Add(new SqlParameter("VatRate", invoiceItem.GetVatRate()));
                insertCommand.Parameters.Add(new SqlParameter("AmountNet", invoiceItem.AmountNet));
                insertCommand.Parameters.Add(new SqlParameter("AmountGross", invoiceItem.AmountGross));
                insertCommand.Parameters.Add(new SqlParameter("Amount", invoiceItem.Amount));
                insertCommand.Parameters.Add(new SqlParameter("Unit", invoiceItem.Unit));

                insertCommand.ExecuteNonQuery();
            }
        }

        //public static void InsertInvoiceItem(InvoiceItem invoiceItem)
        //{
        //    if (invoiceItem.Amount <= 0)
        //        throw new ArgumentException();

        //    string connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = SampleAppDB; Integrated Security = True; Connect Timeout = 15; Encrypt = False; TrustServerCertificate = True; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand insertCommand = new SqlCommand("INSERT INTO InvoiceItem (Id, InvoiceId) VALUES (@Id, @InvoiceId)", connection);
        //        insertCommand.Parameters.Add(new SqlParameter("Id", invoiceItem.Id));
        //        insertCommand.Parameters.Add(new SqlParameter("InvoiceId", invoiceItem.InvoiceId));

        //        insertCommand.ExecuteNonQuery();
        //    }
        //}
    }
}
