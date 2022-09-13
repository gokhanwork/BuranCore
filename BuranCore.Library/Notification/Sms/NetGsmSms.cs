using Buran.Core.Library.Http;
using Buran.Core.Library.LogUtil;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Buran.Core.Library.Notification.Sms
{
    public class NetgsmResponse
    {
        public int Code { get; set; }
        public string Id { get; set; }
        public string Err { get; set; }
    }

    public class NetGsm
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _from;

        public NetGsm(string userName, string password, string from)
        {
            _userName = userName;
            _password = password;
            _from = from;
        }

        public NetgsmResponse SendSms(string toPhone, string msg)
        {
            try
            {
                var xmlData = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<mainbody>
    <header>
        <company dil=""TR"">Netgsm</company>
        <usercode>{_userName}</usercode>
        <password>{_password}</password>
        <type>1:n</type>
        <msgheader>{_from}</msgheader>
    </header>
    <body>
        <msg><![CDATA[{msg}]]></msg>
        <no>{toPhone}</no>
    </body>
</mainbody>";
                var client = new WebRequest2();
                var response = client.PostString("https://api.netgsm.com.tr/sms/send/xml", xmlData);

                var ss = response.Split(' ');
                var res = new NetgsmResponse();
                if (ss.Length <= 2)
                {
                    int.TryParse(ss[0], out int i);

                    res.Code = i;
                    if (res.Code == 0)
                    {
                        res.Id = ss[1];
                    }
                    else if (res.Code == 20)
                    {
                        res.Err = "Mesaj çok uzun";
                    }
                    else if (res.Code == 30)
                    {
                        res.Err = "IP kısıtlı";
                    }
                    else if (res.Code == 40)
                    {
                        res.Err = "Gönderici adı sorunu";
                    }
                    else if (res.Code == 70)
                    {
                        res.Err = "Genel hata";
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                return new NetgsmResponse { Err = Logger.GetErrorMessage(ex) };
            }
        }
    }
}
