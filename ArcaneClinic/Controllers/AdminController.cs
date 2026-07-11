using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ArcaneClinic.Models;

namespace ArcaneClinic.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
                string cmd = "select count (*) from Appointment where status='yes'";
                string cmd1 = "select count (*) from addoctor where status='yes'";
                string cmd2 = "select count (*) from Register where status='yes'";
                string cmd3 = "select count (*) from feedback";
                string cmd4 = "select count (*) from complain";
                string cmd5 = "select count (*) from notification";
                string cmd6 = "select count (*) from contact where status='For Complain'";
                int count = DatabaseManager.Get_Single_Data(cmd);
                int count1 = DatabaseManager.Get_Single_Data(cmd1);
                int count2 = DatabaseManager.Get_Single_Data(cmd2);
                int count3 = DatabaseManager.Get_Single_Data(cmd3);
                int count4 = DatabaseManager.Get_Single_Data(cmd4);
                int count5 = DatabaseManager.Get_Single_Data(cmd5);
                int count6 = DatabaseManager.Get_Single_Data(cmd6);
                ViewBag.dd = count;
                ViewBag.dd1 = count1;
                ViewBag.dd2 = count2;
                ViewBag.dd3 = count3;
                ViewBag.dd4 = count4;
                ViewBag.dd5 = count5;
                ViewBag.dd6 = count6;
            }
           
            
             else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult ViewDoctors()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        [HttpPost]
        public ActionResult ViewDoctors(string cmd1)
        {
            cmd1 = "truncate table AddSlider";
            if (DatabaseManager.Insert_Update_Delete(cmd1))
                Response.Write("<script>alert('Deleted Successfully');window.location.href='/Admin/AddSlider';</script>");
            else
                Response.Write("<script>alert('Deleted Successfully');window.location.href='/Admin/AddSlider';</script>");
            return View();
        }



        public ActionResult ViewEnquiry()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");

            return View();
        }


        public ActionResult EnquiryResponse()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }
    
        public ActionResult UpDoctors(string ud)
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
           
            string query = "select * from addoctor where did='" + ud + "'";
            DataTable dt = DatabaseManager.Display_All_Records(query);
            if(dt.Rows.Count>0)
            {
                ViewBag.id = dt.Rows[0]["did"];
                ViewBag.name = dt.Rows[0]["name"];
                ViewBag.Qualification = dt.Rows[0]["qualification"];
                ViewBag.Specialist = dt.Rows[0]["specialist"];
                ViewBag.Room = dt.Rows[0]["room_no"];
                ViewBag.exp = dt.Rows[0]["experience"];
                ViewBag.fee = dt.Rows[0]["fee"];
                
            }
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }
        [HttpPost]
        public ActionResult UpDoctors(string txtname,string txtexp,string txtfee,string txtid)
        {
            
            string Query = "update addoctor set name='" + txtname + "',experience='" + txtexp + "',fee='" + txtfee + "' where did='" + txtid + "'";
            if (DatabaseManager.Insert_Update_Delete(Query))
            {
                Response.Write("<script>alert('Update Successfully');window.location.href='/Admin/ViewDoctors';</script>");
            }
            else
            {
                Response.Write("<script>alert('Server Error')</script>");
            }
            return View();
        }

        public ActionResult DelDoctor(string dd)
        {
            string Query = "update addoctor set status='no' where did='" + dd + "'";
            if (DatabaseManager.Insert_Update_Delete(Query))
            {
                Response.Write("<script>alert('Data Deleted Successfully');window.location.href='/Admin/ViewDoctors';</script>");
            }
            else
            {
                Response.Write("<script>alert('Server Error')</script>");
            }
            return View();
        }

        public ActionResult CurrentAppointments()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult AppointmentsRecords()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }


        public ActionResult AddNotification()
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
        public ActionResult AddNotification(string txtnoti, string txtnotification)
        {
            string query = "insert into notification values('" + txtnoti + "','" + txtnotification + "','" + DateTime.Now.ToString() + "')";
            if (DatabaseManager.Insert_Update_Delete(query))
                Response.Write("<script>alert('Add Notification Successfully')</script>");
            else
                Response.Write("<script>alert('unable to add')</script>");
            return View();
        }

        public ActionResult RegisterRecords()
        {
            string id = Session["uid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult ViewFeedback()
        {
            
            return View();
        }

        public ActionResult FeedbackResponse(string fid)
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            string query = "select * from feedback where fid='" + fid + "'";
                DataTable dt = DatabaseManager.Display_All_Records(query);
               if(dt.Rows.Count>0)
               {
                   ViewBag.use = dt.Rows[0]["userid"].ToString();
                   ViewBag.id = fid;
               }}
            else
                Response.Redirect("/Home/Login");
           
            return View();
        }
        [HttpPost]

        public ActionResult FeedbackResponse(string txtid, string txtuid, string txtmsg)
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            try
                    {

                        string query = "insert into feedbackResponse values('" + txtid + "','" + txtuid + "','" + txtmsg + "',getdate())";
                    if (DatabaseManager.Insert_Update_Delete(query))
                        ViewBag.msg = "Submit Successfully";
                    else
                        ViewBag.msg = "Unable to Save";
                }
                
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            }
            else
                Response.Redirect("/Home/Login");
           return View();
        }

        public ActionResult ViewComplain()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult ComplainResponse(string cmp_id)
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            string query = "select * from complain where cmp_id='" + cmp_id + "'";
            DataTable dt = DatabaseManager.Display_All_Records(query);
            if (dt.Rows.Count > 0)
            {
                ViewBag.user = dt.Rows[0]["userid"].ToString();
                ViewBag.id = cmp_id;
            }
             }
            else
                Response.Redirect("/Home/Login");

            return View();
        }
        [HttpPost]

        public ActionResult ComplainResponse(string txtid, string txtuid, string txtmsg)
        {
             string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            try
            {

                string query = "insert into ComplainResponse values('" + txtid + "','" + txtuid + "','" + txtmsg + "',getdate())";
                if (DatabaseManager.Insert_Update_Delete(query))
                    ViewBag.msg = "Submit Successfully";
                else
                    ViewBag.msg = "Unable to Save";
            }

            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }



        public ActionResult AddSlider()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        [HttpPost]
        public ActionResult AddSlider(AddSlider ad)
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            if (ModelState.IsValid)
            {
                string fupic = Path.Combine(Server.MapPath("/Content/Slider_img"), ad.Pic.FileName);
                ad.Pic.SaveAs(fupic);
                string query = "insert into AddSlider values('" + ad.Pid + "','" + ad.Pname + "','" + ad.Pic.FileName + "','" + DateTime.Now.ToString() + "','"+ad.Description+"')";
                if (DatabaseManager.Insert_Update_Delete(query))
                {
                    Response.Write("<script>alert('Inserted successfully');window.location.href='/Admin/AddSlider';</script>");
                    ModelState.Clear();
                }
                else
                    Response.Write("<script>alert('Not Inserted')</script>");

            }
             }
            else
                Response.Redirect("/Home/Login");

            return View();
        }

        public ActionResult AddLogo()
        {
            string id = Session["aid"] + "";
            if (id != "" && id != null)
            {
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        [HttpPost]
        public ActionResult AddLogo(AddLogo al,string cmd)
        {string id = Session["aid"] + "";
            if (id != "" && id != null)
            {

            if (ModelState.IsValid)
            {
                string fupic = Path.Combine(Server.MapPath("/Content/Slider_img"), al.LogoPic.FileName);
                al.LogoPic.SaveAs(fupic);
                string query = "insert into AddLogo values('" + al.LogoName + "','" + al.LogoPic.FileName + "','" + DateTime.Now.ToString() + "')";
                if (DatabaseManager.Insert_Update_Delete(query))
                {
                    Response.Write("<script>alert('Inserted successfully');window.location.href='/Admin/AddLogo';</script>");
                    ModelState.Clear();
                }
                else
                    Response.Write("<script>alert('Not Inserted')</script>");              

            }
            }
            else
                Response.Redirect("/Home/Login");
            return View();
        }

        public ActionResult AddDoctor()
        { 
            var model = new AddDoctor
            {
                QualificationList = new List<SelectListItem>
            {
                new SelectListItem { Text = "MBBS", Value = "MBBS" },
                new SelectListItem { Text = "MD", Value = "MD" },
                new SelectListItem { Text = "DO", Value = "DO" },
                new SelectListItem { Text = "PhD", Value = "PhD" }
            },
                SpecialistList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" },
                new SelectListItem { Text = "Dermatologist", Value = "Dermatologist" },
                new SelectListItem { Text = "Neurologist", Value = "Neurologist" },
                new SelectListItem { Text = "Pediatrician", Value = "Pediatrician" }
            }
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDoctor(AddDoctor model)
        {

            // Repopulate the lists in case of redisplay due to validation errors
            model.QualificationList = new List<SelectListItem>
        {
            new SelectListItem { Text = "MBBS", Value = "MBBS" },
            new SelectListItem { Text = "MD", Value = "MD" },
            new SelectListItem { Text = "DO", Value = "DO" },
            new SelectListItem { Text = "PhD", Value = "PhD" }
        };
            model.SpecialistList = new List<SelectListItem>
        {
            new SelectListItem { Text = "Cardiologist", Value = "Cardiologist" },
            new SelectListItem { Text = "Dermatologist", Value = "Dermatologist" },
            new SelectListItem { Text = "Neurologist", Value = "Neurologist" },
            new SelectListItem { Text = "Pediatrician", Value = "Pediatrician" }
        };
            //for insert data in database
            string id = Session["aid"] + "";
        if (id != "" && id != null)
        {
            if (ModelState.IsValid)
            {
                string fupic = Path.Combine(Server.MapPath("/Content/doctor_img"), model.Image.FileName);
                model.Image.SaveAs(fupic);
                string Query = "insert into addoctor values('" + model.Name + "','" + model.SelectedQualification + "','" + model.SelectedSpecialist + "','" + model.Room_No + "','" + model.Experience + "','" + model.Fee + "','yes','" + model.Image.FileName + "')";
                if (DatabaseManager.Insert_Update_Delete(Query))
                {
                    Response.Write("<script>alert('Add Successfully');window.location.href='/Admin/AddDoctor';</script>");

                }
                else
                {
                    Response.Write("<script>alert('Server Error')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please Check Model')</script>");
            }
        }
        else
        {
            Response.Redirect("/Home/Login");
        }

            return View(model);
        }
       
        public ActionResult AddChairman()
        {
          string id = Session["aid"] + "";
        if (id != "" && id != null)
        {
        }
        else
        {
            Response.Redirect("/Home/Login");
        }
            return View();
        }

        [HttpPost]
        public ActionResult AddChairman(CMan cm)
        {
             string id = Session["aid"] + "";
        if (id != "" && id != null)
        {

            if (ModelState.IsValid)
            {
                string fupic = Path.Combine(Server.MapPath("/Content/Slider_img"), cm.ChairmanPic.FileName);
                cm.ChairmanPic.SaveAs(fupic);
                string cmd = "insert into cman values('" + cm.PicName + "','" + cm.ChairmanPic.FileName + "')";
                if (DatabaseManager.Insert_Update_Delete(cmd))
                {
                    Response.Write("<script>alert('Inserted successfully');window.location.href='/Admin/AddChairman';</script>");
                    ModelState.Clear();
                }
                else
                    Response.Write("<script>alert('Not Inserted')</script>");

            }
        }
        else
        {
            Response.Redirect("/Home/Login");
        }
            return View();
        }

        [HttpPost]
        public ActionResult deleteCMan(string cmd1)
        {
            cmd1 = "truncate table cman";
            if (DatabaseManager.Insert_Update_Delete(cmd1))
                Response.Write("<script>alert('Deleted Successfully');window.location.href='/Admin/AddChairman';</script>");
            else
                Response.Write("<script>alert('Deleted Successfully');window.location.href='/Admin/AddChairman';</script>");
            return View();
        }

        public ActionResult SignOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return View();
        }
    }
}
