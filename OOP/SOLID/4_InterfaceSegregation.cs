// 1 interface segregation principle
// 2 принцип разделения интерфейсов
// 3 клиенты не должны вынужденно зависеть от методов, которыми не пользуются
// 4 относится к тем случаям когда классы имеют "жирный" интерфнйс т.е. слишком раздуый интерфейс, 
// не все методы и свойства которого используются и могут быть востребованы

using System;

namespace OOP.SOLID._4_InterfaceSegregation
{
    public class Example00
    {
        private static Example00 _instance;
        private static readonly object _synchrObj = new object();

        private Example00()
        {

        }

        public static Example00 Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(_synchrObj)
                    {
                        if (_instance == null)
                            _instance = new Example00();
                    }
                }
                return _instance;
            }
        }

        public string Main(ISendingMessage sendingMessage)
        {
            return sendingMessage.Send();
        }
    }

    public interface ISendingMessage
    {
        string Send();
    }

    public interface IMessage : ISendingMessage
    {
        string ToAddress { get; set; }
        string FromAddress { get; set; }
    }

    public interface ITextMessage : IMessage
    {
        string Text { get; set; }
    }

    public interface IEmailMessage : ITextMessage
    {
        string Subject { get; set; }
    }

    public interface IVoiceMessage : IMessage
    {
        byte[] Voice { get; set; }
    }

    public class EmailMessage : IEmailMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }

        public string Send()
        {
            return string.Format("SendEmail{0}To:{1}{0}From:{2}{0}Subject:{3}{0}Text:{4}", Environment.NewLine, ToAddress, FromAddress, Subject, Text);
        }
    }

    public class SmsMessage : ITextMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Text { get; set; }

        public string Send()
        {
            return string.Format("SendSms{0}To:{1}{0}From:{2}{0}Text:{3}", Environment.NewLine, ToAddress, FromAddress, Text);
        }
    }

    public class VoiceMessage : IVoiceMessage
    {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public byte[] Voice { get; set; }

        public string Send()
        {
            return string.Format("SendVoice{0}To:{1}{0}From:{2}{0}Voice:{3}", Environment.NewLine, ToAddress, FromAddress, Voice);
        }
    }
}


