using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace ArcaneClinic.Models
{
    public class User_Feedback
    {
        public static string Upload_Feedback(string rate,string msg,string id)
        {
            try
            {
                string query = "insert into feedback values('" + id + "','" + rate + "','" + msg + "',getDate())";
                if (DatabaseManager.Insert_Update_Delete(query))
                    return "Feedback Submit Successfully";
                else
                    return "unable to save";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        



        // code for set feedback id and userid

        //public static string Feedback_id_and_userid(string fid)
        //{
        //    string userid = "";
        //    string query = "select * from feedback where fid='" + fid + "'";
        //    DataTable dt = DatabaseManager.Display_All_Records(query);
        //    if(dt.Rows.Count>0)
        //    {
        //        userid = dt.Rows[0]["userid"].ToString();
        //    }
        //    return userid;
        //}

    }
}