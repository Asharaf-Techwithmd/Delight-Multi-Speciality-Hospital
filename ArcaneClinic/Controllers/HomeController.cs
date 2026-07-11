using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArcaneClinic.Models;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ArcaneClinic.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
       

        public ActionResult Index()
        {           

            return View();
        }

        public ActionResult Complain()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }
        public ActionResult JoinUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult JoinUs(JoinUs j)
        {
            if (ModelState.IsValid)
            {
                // Validate file type
                if (j.Picture != null && j.Picture.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg" }; // Allowed file extensions
                    var fileExtension = Path.GetExtension(j.Picture.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        Response.Write("<script>alert('Only .jpg and .jpeg files are allowed!')</script>");
                        return View();
                    }
                    const int maxFileSize = 2 * 1024 * 1024;//2 Mb in Bytes
                    if (j.Picture.ContentLength > maxFileSize)
                    {
                        Response.Write("<script>alert('File size must not exceed 2 MB!')</script>");
                        return View();
                    }

                    if (j.Password == j.Confirm_Password)
                    {                        
                        string fupic = Path.Combine(Server.MapPath("/Content/register_img"), j.Picture.FileName);
                        j.Picture.SaveAs(fupic);

                        // Insert query for Register
                        string Query = "insert into Register values('" + j.Name + "','" + j.Email + "','" + j.Mobile + "','" + j.Password + "','" + j.Confirm_Password + "','" + j.DOB + "','" + j.Gender + "','" + j.Picture.FileName + "','" + DateTime.Now.ToString() + "','yes')";
                        // Insert query for Login
                        string Query1 = "insert into Login values('" + j.Email + "','" + j.Password + "','user','yes')";

                        if (DatabaseManager.Insert_Update_Delete(Query) && DatabaseManager.Insert_Update_Delete(Query1))
                            {
                                ViewBag.ShowPopup = true;
                                ModelState.Clear();
                            }
                            else
                            {
                                Response.Write("<script>alert('Server Error!')</script>");
                            }
                        }
                    
                    else
                    {
                        Response.Write("<script>alert('Password and Confirm Password do not match!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please upload a valid file!')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please fill valid details!')</script>");
            }

            return View();
        }

        public ActionResult Contact()
        {
            var con = new Contact
            {
                TypeList = new List<SelectListItem>
            {
                new SelectListItem { Text = "For Help", Value = "For Help" },
                new SelectListItem { Text = "For Complain", Value = "For Complain" },
                new SelectListItem { Text = "For Suggestion", Value = "For Suggestion" },
            }
            };
            return View(con);
        }
        [HttpPost]
        public ActionResult Contact(Contact con)
        {
            con.TypeList = new List<SelectListItem>
        {
            new SelectListItem { Text = "For Help", Value = "For Help" },
            new SelectListItem { Text = "For Complain", Value = "For Complain" },
            new SelectListItem { Text = "For Suggestion", Value = "For Suggestion" },
            
        };

            if (ModelState.IsValid)
            {
                string Query = "insert into contact values('" + con.Name + "','" + con.Email + "','" + con.Mobile + "','" + con.SelectedType + "','" + con.Message + "','yes','" + DateTime.Now.ToString() + "')";
                if (DatabaseManager.Insert_Update_Delete(Query))
                {
                    ViewBag.msg = "Enquiry Save Successfully";
                    ModelState.Clear();
                }
                else
                    ViewBag.msg = "Server Error";
            }
            else
            {
                Response.Write("<script>alert('Please fill/check details')</script>");
            }
           
            return View(con);
        }

        public ActionResult OurDoctor()
        {
            return View();
        }

        public ActionResult Login()
        {
            CaptchaCodeManager cg = new CaptchaCodeManager();
            ViewBag.msg = cg.CaptchaCode();
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg, string txtcph, string txtcaptcha)
        {
            if (ModelState.IsValid)
            {
                if (txtcph == txtcaptcha)
                {
                    string type = "";
                    string query = "select * from Login where userid='" + lg.UserId + "'and password='" + lg.Password + "'and status='yes'";
                    DataTable dt = DatabaseManager.Display_All_Records(query);
                    if (dt.Rows.Count > 0)
                    {
                        type = dt.Rows[0]["type"].ToString();
                        if (type == "admin")
                        {
                            Session["aid"] = lg.UserId;
                            Response.Redirect("/Admin/Index");
                        }
                        else if (type == "user")
                        {
                            Session["uid"] = lg.UserId;
                            Response.Redirect("/Patient/Index");
                        }
                        else if (type == "manager")
                        {
                            Session["mid"] = lg.UserId;
                            Response.Redirect("/Manager/Index");
                        }
                        else if (type == "doctor")
                        {
                            Session["did"] = lg.UserId;
                            Response.Redirect("/Doctor/Index");
                        }
                        else
                        {
                            Response.Redirect("/Home/Login");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Server Error')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('invalid Captcha')</script>");
                }
                ModelState.Clear();
            }
            else
            {
                Response.Write("<script>alert('Please Check details')</script>");
            }
            return View();
        }

        public JsonResult Refresh()
        {
            string msg = "";
            CaptchaCodeManager cg = new CaptchaCodeManager();
            msg = cg.CaptchaCode();
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}
