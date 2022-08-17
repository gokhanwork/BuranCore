using Buran.Core.Library.Http;
using Buran.Core.Library.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Buran.Core.MvcLibrary.Utils
{
    public class IpTools
    {
        public string GetIp(HttpRequest request)
        {
            var result = string.Empty;
            if (request.Headers != null)
            {
                var forwardedHeader = request.Headers["X-Forwarded-For"];
                if (!StringValues.IsNullOrEmpty(forwardedHeader))
                    result = forwardedHeader.FirstOrDefault();
            }
            if (result.IsEmpty() && request.HttpContext.Connection.RemoteIpAddress != null)
                result = request.HttpContext.Connection.RemoteIpAddress.ToString();
            return result;
            //var ip = request.HttpContext.Connection.RemoteIpAddress;
            //return ip.ToString();
        }

        public string GetRealIp(HttpRequest request)
        {
            try
            {
                var client = new WebRequest2();
                var response = client.GetUrl("http://checkip.dyndns.org", null);
                var a = response.Split(':');
                var a2 = a[1].Substring(1);
                var a3 = a2.Split('<');
                var a4 = a3[0];
                return a4; // + " (" + GetIp(request) + ")";
            }
            catch (Exception)
            {

            }
            var ip = request.HttpContext.Connection.RemoteIpAddress;
            return ip.ToString();
        }

        public string GetAgent(HttpRequest request)
        {
            var agent = request.Headers["User-Agent"].ToString();
            return agent;
        }
    }
}
