using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_ManagerCar
{
    class function
    {
        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = COMPUTER\\SQLEXPRESS;database=CarRentralWinform;integrated security =True";
            return con;
        }

        public DataSet getData(String query)  //Lay data tu database
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public string getString(String query)  //Lay data tu database
        {
            
            SqlConnection con = getConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.Direction = ParameterDirection.ReturnValue;

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = query;
            //cmd.Parameters.AddWithValue(@userID);
            cmd.ExecuteNonQuery();
            con.Close();
            if(Convert.ToString(sqlParameter.Value) != null)
            {
                return Convert.ToString(sqlParameter.Value);
            }
            return "";
        }

        public void setData(String query,String message) // cap nhat, chinh sua, xoa 
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'"+message+ "'","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
