using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace Scope.HookConsumer.Controllers
{
    public class HandlesController : ApiController
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

            var mail = new MailMessage("test@scopetechnology.com", ConfigurationManager.AppSettings["Receiver"], "Call Summary " + DateTime.UtcNow.ToString(), result);

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
