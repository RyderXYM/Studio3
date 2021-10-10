using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Studio3.Controllers
{
    public class TheMailController : Controller
    {
        // GET: TheMail
        public ActionResult MailFunction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MailFunction(Models.MailModel objModelMail, HttpPostedFileBase fileUploader)
        {
            if (ModelState.IsValid)
            {
                string from = "yxie0049@student.monash.edu";
                using (MailMessage mail = new MailMessage(from, objModelMail.Receiver))
                {
                    mail.Subject = objModelMail.Subject;
                    mail.Body = objModelMail.Body;
                    if (fileUploader != null)
                    {
                        string fileName = Path.GetFileName(fileUploader.FileName);
                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
                    }
                    mail.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        EnableSsl = true
                    };
                    NetworkCredential networkCredential = new NetworkCredential(from, "****");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    return View("MailFunction", objModelMail);
                }
            }
            else
            {
                return View();
            }
        }
    }

}