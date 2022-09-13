using Buran.Core.Library.Notification.Sms;



#region MobilDevSMS-Test
var test = new  MobilDevSms("apiKey","apiSecret");
var result = test.SendSms("+90532XXXXXXX", "Deneme Sms VeriPlus");
Console.WriteLine("Sms Gönderildi "+ result.Id);
Console.ReadLine();
#endregion

