using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Scope.HookConsumer.Extensions;

namespace Scope.HookConsumer.Controllers
{
    public class AppHarborOnBuildController : ApiController
    {
        private const string _bodyFormat = "Application: {0}\t{1}\r\nCommit: {2}\thttps://github.com/scopetech/MLog/commit/{3}\r\nBuild: {4}\t{5}\r\n";

        public string Post()
        {

            var dateStr = DateTime.UtcNow.ToString("yyyy.MM.dd HH.mm.ss"); 

            var result = "Build occurred on AppHarbor.\r\n";
            

            if (Request.Content != null)
            {
                var buffer = Request.Content.ReadAsByteArrayAsync().Result;
                var postStr = Encoding.UTF8.GetString(buffer);
                if (postStr != null)
                {
                    try
                    {
                        dynamic buildInfo = JObject.Parse(postStr);
                        result += string.Format(_bodyFormat, 
                            buildInfo.application.name,
                            buildInfo.application.url,                             
                            buildInfo.build.commit.message,
                            buildInfo.build.commit.id, 
                            buildInfo.build.status,
                            buildInfo.build.url
                            );

                    }
                    catch(Exception ex)
                    {
                        result += "ERROR: Can not parse payload.\r\n" + ex.Message + "\r\n";
                    }               
                }
            }
            else 
            {
                result += "ERROR: No payload sent.\r\n";
            }
            
            result += "Triggered from: " + (Request.GetClientIpAddress() ?? "unknown");

            var mail = new MailMessage();
            mail.Subject = "Build Summary " + DateTime.UtcNow.ToString();
            mail.AddRecipients(ConfigurationManager.AppSettings["Receivers"]);
            mail.Body = result;

            try
            {
                new SmtpClient().Send(mail);
            }
            catch (Exception ex)
            {
                result += "\r\n Error sending mail: \r\n" + ex.Message;
            }

            return result;
        }


    }
}
