using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArcaneClinic.Models
{
    public class CaptchaCodeManager
    {
        public string CaptchaCode()
        {
            char ch1, ch2, ch3, ch4, ch5, ch6;
            Random r = new Random();
            ch1 = (char)(r.Next(65, 92));//A-Z
            ch2 = (char)(r.Next(97, 122));//a-z
            ch3 = (char)(r.Next(50, 55));//1,6
            ch4 = (char)(r.Next(78, 92));//A-Z
            ch5 = (char)(r.Next(100, 122));//a-z
            ch6 = (char)(r.Next(50, 55));//1,6
            string cph = ch1 + "" + ch2 + "" + ch3 + "" + ch4 + "" + ch5 + "" + ch6;
            return cph;
        }

    }
}