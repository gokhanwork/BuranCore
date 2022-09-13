using Buran.Core.Library.Notification.Sms;



#region MobilDevSMS-Test
var test = new  MobilDevSms("apiKey","apiSecret");
var result = test.SendSms("+905321632051", "Deneme Sms VeriPlus");
Console.WriteLine("Sms Gönderildi "+ result.Id);
Console.ReadLine();
#endregion

