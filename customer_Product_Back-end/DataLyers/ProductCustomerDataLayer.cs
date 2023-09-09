using customer_Product_Back_end.Functions;
using customer_Product_Back_end.Models;
using System.Data;
using System.Data.SqlClient;

namespace customer_Product_Back_end.DataLyers
{
    public class ProductCustomerDataLayer
    {
        DataSet ds = new DataSet();
        DataLeyar ProductCustmerDl = new DataLeyar();
        public string SaveProductCustomer(string connectionName, ProductCustomer ProductCustomer)
        {
            try
            {
                int index = 0;
                SqlParameter[] parameter = new SqlParameter[8];
                parameter[index] = new SqlParameter("@OutMessage", SqlDbType.VarChar, 250);
                parameter[index].Direction = ParameterDirection.Output;
                parameter[index].Value = "";

                index = index + 1;
                parameter[index] = new SqlParameter("@CustomerId", SqlDbType.Int);
                parameter[index].Value = ProductCustomer.CustomerId;

                index = index + 1;
                parameter[index] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 250);
                parameter[index].Value = ProductCustomer.CustomerName;

                index = index + 1;
                parameter[index] = new SqlParameter("@Gender", SqlDbType.VarChar, 250);
                parameter[index].Value = ProductCustomer.Gender;

                index = index + 1;
                parameter[index] = new SqlParameter("@ContactNumber", SqlDbType.VarChar, 250);
                parameter[index].Value = ProductCustomer.ContactNumber;

                index = index + 1;
                parameter[index] = new SqlParameter("@ProductId", SqlDbType.Int);
                parameter[index].Value = ProductCustomer.ProductId;

                index = index + 1;
                parameter[index] = new SqlParameter("@ProductName", SqlDbType.VarChar, 250);
                parameter[index].Value = ProductCustomer.ProductName;

                index = index + 1;
                parameter[index] = new SqlParameter("@Price", SqlDbType.Int);
                parameter[index].Value = ProductCustomer.Price;

                return ProductCustmerDl.SaveData("SaveProductCustomer", ref parameter, connectionName);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataSet GetAllCustomerProduct(string connectionName, int CustomerId)
        {
            try
            {
                int index = 0;
                SqlParameter[] parameter = new SqlParameter[2];
                parameter[index] = new SqlParameter("@OutMessage", SqlDbType.VarChar, 500);
                parameter[index].Direction = ParameterDirection.Output;
                parameter[index].Value = "";

                index = index + 1;
                parameter[index] = new SqlParameter("@CustomerId", SqlDbType.Int);
                parameter[index].Value = CustomerId;

                ds = ProductCustmerDl.GetData("GetProductCustomer", ref parameter, connectionName);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string SaveSaleDate(string connectionName, int CustomerId, string SaleDate)
        {
            try
            {
                int index = 0;
                SqlParameter[] parameter = new SqlParameter[3];
                parameter[index] = new SqlParameter("@OutMessage", SqlDbType.VarChar, 500);
                parameter[index].Direction = ParameterDirection.Output;
                parameter[index].Value = "";

                index = index + 1;
                parameter[index] = new SqlParameter("@CustomerId", SqlDbType.Int);
                parameter[index].Value = CustomerId;

                index = index + 1;
                parameter[index] = new SqlParameter("@SaleDate", SqlDbType.VarChar, 500);
                parameter[index].Value = SaleDate;
                return ProductCustmerDl.SaveData("SaveSaleDate", ref parameter, connectionName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
