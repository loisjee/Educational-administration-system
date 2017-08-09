using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class DBHelper
    {

        static string connectionString = ConfigurationManager.ConnectionStrings["DBCoon"].ConnectionString;
        /*将连接字符串设计成属性*/
        public static string ConnecttionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        public static int ExecuteCommand(string safeSql)
        {
            return ExecuteCommand(safeSql, null);
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            using (SqlConnection conn = new SqlConnection(ConnecttionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, sql, values);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int GetIntScalar(string safeSql)
        {
            return GetIntScalar(safeSql, null);
        }

        public static int GetIntScalar(string sql, params SqlParameter[] values)
        {
            using (SqlConnection conn = new SqlConnection(ConnecttionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, sql, values);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static SqlDataReader GetReader(string safeSql)
        {
            return GetReader(safeSql, null);
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlConnection conn = new SqlConnection(ConnecttionString);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, sql, values);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        public static DataTable GetDataSet(string safeSql)
        {
            return GetDataSet(safeSql, null);
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            using (SqlConnection conn = new SqlConnection(ConnecttionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, sql, values);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds.Tables[0];
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            cmd.CommandType = CommandType.Text;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
    }
}
