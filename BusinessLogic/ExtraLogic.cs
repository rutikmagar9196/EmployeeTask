using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using EmployeeTask.Models;

namespace EmployeeTask.BusinessLogic
{

    public class ExtraLogic
    {
        EmployeeTaskDbEntities db;
        public ExtraLogic()
        {
            db = new EmployeeTaskDbEntities();
        }

        public string NextEmployeeCode()
        {
            string code = "E";
            if (db.tblemployees.ToList().Count > 0)
            {

                tblemployee e = db.tblemployees.ToList().OrderByDescending(ep => ep.Emp_Id).First();                
                
               if (e.Emp_Id >= 1 && e.Emp_Id < 10)
               {
                  code = "E000" + (e.Emp_Id + 1);
               }
               else if (e.Emp_Id >= 10 && e.Emp_Id < 100)
               {
                  code = "E00" + (e.Emp_Id + 1);
               }
               else if (e.Emp_Id >= 100 && e.Emp_Id < 1000)
               {
                  code = "E0" + (e.Emp_Id + 1);
               }
               else if (e.Emp_Id >= 1000 && e.Emp_Id < 10000)
               {
                  code = "E" + (e.Emp_Id + 1);
               } 
            }
            else
            {
                code = "E0001"; 
            }
            return code;
        }
        public string GeneratePassword(int size)
        {
            string data = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUWXYZ1234567890@#$";
            string password = "";
            Random random = new Random();
            for (int i = 1; i <= size; i++ ) 
            {
                int p=random.Next(0,data.Length-1);
                password += data[p];

            }
            return password;
            

        }
        public string GenerateOTP(int size)
        {
            string data = "0123456789";
            string OTP = "";
            Random random = new Random();
            for (int i = 1; i <= size; i++)
            {
                int p = random.Next(0, data.Length - 1);
                OTP += data[p];

            }
            return OTP;


        }

        public static void Send_Email(string email, string subject, string discription)
        {
            var fromAddress = new MailAddress("rutikmagar9196@gmail.com", "Montcreast Software Pvt.Ltd");
            var toAddress = new MailAddress(email, email);
            MailMessage meassage = new MailMessage(fromAddress, toAddress);
            meassage.Subject = subject;
            meassage.Body = discription;
            meassage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential networkCred = new NetworkCredential();
            networkCred.UserName = "rutikmagar9196@gmail.com";
            networkCred.Password = "pqad zlzj ovyg kxue";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCred;
            smtp.Port = 587;
            smtp.Send(meassage);

        }
        /*public string Send_Email(string email, string subject, string description)
        {
            try
            {
                var fromAddress = new MailAddress("rutikmagar9196@gmail.com", "Montcreast Software Pvt.Ltd");
                var toAddress = new MailAddress(email, email);
                MailMessage message = new MailMessage(fromAddress, toAddress);
                message.Subject = subject;
                message.Body = description;
                message.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("rutikmagar9196@gmail.com", "pqad zlzj ovyg kxue"),
                    Port = 587
                };

                smtp.Send(message);

                return "Email sent successfully";
            }
            catch (Exception ex)
            {
                return $"Failed to send email: {ex.Message}";
            }
        }*/








    }

}