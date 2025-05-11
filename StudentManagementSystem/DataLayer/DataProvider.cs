using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cnn;
        public DataProvider() { 
            string cnStr = "Data Source=.;Initial Catalog=QLHocSinh;Integrated Security=True";
            cnn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if(cnn!=null && cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public void DisConnect()
        {
            try
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SqlDataReader MyExecuteReader(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.CommandType = type;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters.ToArray());
            }
            try
            {
                Connect();
                return(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public object MyExecuteScalar(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cd = new SqlCommand(sql, cnn);
            cd.CommandType = type;
            if (parameters != null)
            {
                cd.Parameters.AddRange(parameters.ToArray());
            }
            try
            {
                Connect();
                return (cd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }


        public int MyExecuteNonQuery(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cd = new SqlCommand(sql, cnn);
            cd.CommandType = type;

            if (parameters != null)
            {
                cd.Parameters.AddRange(parameters.ToArray());
            }
            try
            {
                Connect();
                return cd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
