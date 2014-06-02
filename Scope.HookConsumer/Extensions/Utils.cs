using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Http;
using System.ServiceModel.Channels;

namespace Scope.HookConsumer.Extensions
{
    public static class Utils
    {
        public static void AddRecipients(this MailMessage mail, string recipients)
        {
            if (!string.IsNullOrEmpty(recipients))
            {
                var recipientParts = recipients.Split(';');

                foreach (var r in recipientParts)
                {
                    var current = r.Trim();
                    if (!string.IsNullOrEmpty(current))
                    {
                        mail.To.Add(current);
                    }
                }
            }
        }


        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else
            {
                return null;
            }
        }
    }
}