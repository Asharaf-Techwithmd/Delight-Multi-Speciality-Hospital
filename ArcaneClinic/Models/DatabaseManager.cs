using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArcaneClinic.Models
{
    public class DatabaseManager
    {
        //code for insert update and delete command
        static SqlConnection con = new SqlConnection("Data source=.;Initial Catalog=ArcaneClinic;Integrated security=true");
        static SqlCommand cmd = null;
        static DataTable dt = null;

        public static bool Insert_Update_Delete(string command)
        {
            try
            {
                cmd = new SqlCommand(command, con);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception x)
            {
                return false;
            }
        }
        // End code for insert update and delete command

        //code for display records

        public static DataTable Display_All_Records(string command)
        {
            try
            {
                cmd=new SqlCommand(command,con);
                SqlDataAdapter sa=new SqlDataAdapter(command,con);
                dt = new DataTable();
                sa.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                return dt;
            }
        }
        // End code for display records
        // code for retrive integer type data

        public static int Get_Single_Data(string command)
        {
            
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                int n;
                cmd=new SqlCommand(command,con);
                n=Convert.ToInt32(cmd.ExecuteScalar());
                return n;
            }
            catch(Exception ex)
            {
                return 1;
            }
        }
    }
}