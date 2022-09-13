using Buran.Core.Library.Http;
using Buran.Core.Library.LogUtil;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Buran.Core.Library.Notification.Sms
{
    public class MobilDevSmsResponse
    {
        public string Id { get; set; }
        public string Err { get; set; }
    }

    public class MobilDevSms
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private readonly string _from;

        public MobilDevSms(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
        }

        public MobilDevSmsResponse SendSms(string toPhone, string msg)
        {
            try
            {
                var xmlData = $@"<MainmsgBody>
    <UserName>{_apiKey}</UserName>
    <PassWord>{_apiSecret}</PassWord>
    <Action>0</Action>
    <Mesgbody>{msg}</Mesgbody>
    <Numbers>{toPhone}</Numbers>
    <AccountId></AccountId>
    <Originator></Originator>
    <Blacklist>1</Blacklist>
    <SDate></SDate>
    <EDate></EDate>
    <Encoding>0</Encoding>
    <MessageType>N</MessageType>
    <RecipientType></RecipientType>
</MainmsgBody>
";
                var client = new WebRequest2();
                var response = client.PostString("https://xmlapi.mobildev.com", xmlData);

                var ss = response.Split(' ');
                var res = new MobilDevSmsResponse();
                if (ss.Length <= 2)
                {
                    int.TryParse(ss[0], out int i);
                    if (i == 0)
                    {
                        res.Id = ss[1];
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                return new MobilDevSmsResponse { Err = Logger.GetErrorMessage(ex) };
            }
        }
    }
}
