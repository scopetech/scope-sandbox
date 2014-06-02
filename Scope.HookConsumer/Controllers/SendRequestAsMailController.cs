using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using Scope.HookConsumer.Extensions;

namespace Scope.HookConsumer.Controllers
{
    public class SendRequestAsMailController : ApiController
    {

        public string Get()
        {
            return Process();
        }

        public string Post()
        {
            return Process();
        }
        
        private string Process()
        {
            var dateStr = DateTime.UtcNow.ToString("yyyy.MM.dd HH.mm.ss"); 
            string result = "Request at " + DateTime.UtcNow.ToString() + "\r\n";

            var queryValues = Request.RequestUri.ParseQueryString();

            result += "GET params: \r\n";

            foreach (var key in queryValues.AllKeys)
            { 
                var value =  queryValues[key];
                result += key + "=" + (value ?? "NULL") + "\r\n";
            }

            if(Request.Content != null)
            {
                var buffer = Request.Content.ReadAsByteArrayAsync().Result;
                object postData = Encoding.UTF8.GetString(buffer);
                if (postData != null)
                {
                    result += "\r\nPOST data: \r\n" + postData;
                }
            }

            var mail = new MailMessage();
            mail.Subject = "Call Summary " + dateStr;
            mail.AddRecipients(ConfigurationManager.AppSettings["Receivers"]);
            mail.Body = result;

            try
            {
                new SmtpClient().Send(mail);
            }
            catch (Exception ex)
            {
                result += "\r\n Error sending mail: \r\n" + ex.ToString();
            }

            return result;
        }


    }
}
