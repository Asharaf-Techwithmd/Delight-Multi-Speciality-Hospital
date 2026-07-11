using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcaneClinic.Models;
using System.Data;
using System.Data.SqlClient;

namespace ArcaneClinic.Controllers
{
    public class PatientController : Controller
    {
        //
        // GET: /Patient/

        public ActionResult Index()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult MyProfile()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
                string query = "select * from Register where email='" + id + "'";
                DataTable dt = DatabaseManager.Display_All_Records(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.name = dt.Rows[0]["name"];
                    ViewBag.email = dt.Rows[0]["email"];
                    ViewBag.mobile = dt.Rows[0]["mobile"];
                    ViewBag.img = dt.Rows[0]["picture"];
                }
            }
            else

                Response.Redirect("/Home/Login");
                
            return View();
        }

        

        public ActionResult Appointment()
        {
            string uid = Convert.ToString(Session["uid"]);
            if (uid != null && uid != "")
            {
                string query = "select * from Register where email='" + uid + "'";
                DataTable dt = DatabaseManager.Display_All_Records(query);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.email = uid;
                    ViewBag.name = dt.Rows[0]["name"].ToString();
                    ViewBag.mob = dt.Rows[0]["mobile"].ToString();
                }
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            // for doctor display from database
            string cmd = "select * from addoctor where status='yes'";
            DataTable dtl = DatabaseManager.Display_All_Records(cmd);
               var doctorList = new List<SelectListItem>();
               for (int i = 0; i < dtl.Rows.Count; i++)
               {
                   doctorList.Add(new SelectListItem
        {
            Text = dtl.Rows[i]["name"] + " (" + dtl.Rows[i]["specialist"] + ")",
            Value = dtl.Rows[i]["name"] + " (" + dtl.Rows[i]["specialist"] + ")"
        });
    }
    // Create Appointment object
         var Ap = new Appointment
       {
        DoctorList = doctorList
         };

              return View(Ap);
        }

        [HttpPost]
        public ActionResult Appointment(Appointment Ap,string txtname,string txtemail,string txtnum)
        {
            if (ModelState.IsValid)
            {
            string cmd = "select * from addoctor where status='yes'";
            DataTable dtl = DatabaseManager.Display_All_Records(cmd);
            var doctorList = new List<SelectListItem>();
            for (int i = 0; i < dtl.Rows.Count; i++)
            {
                doctorList.Add(new SelectListItem
                {
                    Text = dtl.Rows[i]["name"] + " (" + dtl.Rows[i]["specialist"] + ")",
                    Value = dtl.Rows[i]["name"] + " (" + dtl.Rows[i]["specialist"] + ")"
                });
            }
            // Create Appointment object
            Ap.DoctorList = doctorList;
           
            
                string query = "insert into Appointment values('" + Ap.SelectedDoctor + "','" + txtname + "','" + txtemail + "','" + Ap.Age + "','" + txtnum + "','" + Ap.Date + "','" + Ap.Time + "','yes','" + DateTime.Now.ToString() + "')";
                if (DatabaseManager.Insert_Update_Delete(query))
                {
                    ViewBag.ShowPopup = true;
                    ModelState.Clear();
                }
                else
                {
                    Response.Write("<script>alert('Unable to book ! Try Again')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Check Model')</script>");
            }
            return View(Ap);
        }

        public ActionResult ViewAppointment()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");      
            return View();
        }

        public ActionResult ChangePassword()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword( string txtoldpass,string txtnewpass,string txtcpass)
        {
            string id = Session["uid"] + "";
            if (id != null && id != "")
            {
                if (txtnewpass == txtcpass)
                {
                  string  Query = "update Login set password='" + txtnewpass + "' where userid='" + id + "' and password='" + txtoldpass + "'";
                  string Query1 = "update Register set password='" + txtnewpass + "',cpassword='" + txtcpass + "' where email='" + id + "' and password='" + txtoldpass + "'";
                  if (DatabaseManager.Insert_Update_Delete(Query) && DatabaseManager.Insert_Update_Delete(Query1))
                    {
                        Response.Write("<script>alert('password changed');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No change')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('New password and confirm password not match')</script>");
                }
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }

        public ActionResult ViewNotification()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult ViewResponse()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult Feedback()
        {
            //string uid = Convert.ToString(Session["uid"]);
            //if(uid!=null && uid!="")
            //{

            //}
            //else
            //{
            //    Response.Redirect("/Home/Login");
            //}
            return View();
        }
        [HttpPost]

        public ActionResult Feedback(string txtrate,string txtmessage)
        {
            try
            {
                string uid=Session["uid"].ToString();
                if(uid!=null && uid!="")
                {
                    ViewBag.msg = User_Feedback.Upload_Feedback(txtrate, txtmessage, uid);
                }
                else
                {
                 Response.Redirect("/Home/Login");
                }
            }
            catch(Exception ex)
            {
                ViewBag.msg="Server Error";
            }
            return View();
        }
        public ActionResult LogOut()
        {
            String id = Session["uid"] + "";
            if (id != null && id != "")
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("/Home/Login");
            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }

        public ActionResult EditProfile()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
                string query = "select * from Register where email='" + id + "'";
                SqlConnection con = new SqlConnection("Data source=AKSAHU\\SQLEXPRESS01;Initial Catalog=ArcaneClinic;Integrated security=true");
                DataTable dt = new DataTable();
                SqlDataAdapter sa = new SqlDataAdapter(query, con);
                sa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ViewBag.name = dt.Rows[0]["name"];
                    ViewBag.email = dt.Rows[0]["email"];
                    ViewBag.mobile = dt.Rows[0]["mobile"];
                    ViewBag.img = dt.Rows[0]["picture"];
                }
            }
            else

                Response.Redirect("/Home/Login");
                
         
            return View();
        }

        [HttpPost]

        public ActionResult EditProfile(string txtname,string txtmobile ,string txtemail)
        {
             string query = "update Register set name='" + txtname + "',mobile='" + txtmobile + "' where email='" + txtemail + "'";
             if (DatabaseManager.Insert_Update_Delete(query))
             {
                 Response.Write("<script>alert('Update Successfully');window.location.href='/Patient/MyProfile';</script>");
             }
             else
                 Response.Write("<script>alert('Unable to Update');window.location.href='/Patient/MyProfile';</script>");

            return View();
        }
        public ActionResult Complain()
        {
            string uid = Convert.ToString(Session["uid"]);
            if (uid != null && uid != "")
            {

            }
            else
            {
                Response.Redirect("/Home/Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Complain(string txtmsg)
        {
            
                string uid = Session["uid"].ToString();
                if (uid != null && uid != "")
                {
                    string query = "insert into complain values('" + uid + "','" + txtmsg + "',getDate())";
                    if (DatabaseManager.Insert_Update_Delete(query))
                    {
                        Response.Write("<script>alert('Complain Registered Successfully')</script>");
                    }
                    else
                        Response.Write("<script>alert('Complain Not Register')</script>");
                }
                else
                {
                    Response.Redirect("/Home/Login");
                }            
           
            return View();
        }
    }
}
