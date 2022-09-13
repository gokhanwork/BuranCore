using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using Buran.Core.Library.Http;
using System.Xml.Linq;

namespace Buran.Core.Library.Notification.Sms
{
    public class VatanSmsService
    {
        private readonly string _userName;
        private readonly string _password;
        private readonly string _from;
        private readonly string _musteriNo;

        public VatanSmsService(string userName, string password, string from, string musteriNo)
        {
            _userName = userName;
            _password = password;
            _from = from;
            _musteriNo = musteriNo;
        }

        public void Send(string to, string description)
        {
            string sms1N = "data=<sms><kno>" + _musteriNo + "</kno><kulad>" + _userName + "</kulad><sifre>" + _password + "</sifre>" +
                "<gonderen>" + _from + "</gonderen>" +
                "<mesaj>" + description + "</mesaj>" +
                "<numaralar>" + to + "</numaralar>" +
                "<tur>Normal</tur></sms>";

            var client = new WebRequest2();
            var response = client.PostString("http://panel.vatansms.com/panel/smsgonder1Npost.php", sms1N);
        }
    }
}
