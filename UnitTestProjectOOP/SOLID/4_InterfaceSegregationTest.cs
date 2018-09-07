using System;
using OOP.SOLID._4_InterfaceSegregation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace UnitTestProjectOOP.SOLID
{
    [TestClass]
    public class InterfaceSegregationTest
    {
        [TestMethod]
        public void EmailToAddressIsNotModified()
        {
            string result = "test";
            EmailMessage emailMessage = new EmailMessage();

            emailMessage.ToAddress = result;

            Assert.AreEqual(result, emailMessage.ToAddress);
        }

        [TestMethod]
        public void EmailFromAddressIsNotModified()
        {
            string result = "test";
            EmailMessage emailMessage = new EmailMessage();

            emailMessage.FromAddress = result;

            Assert.AreEqual(result, emailMessage.FromAddress);
        }

        [TestMethod]
        public void EmailSubjectIsNotModified()
        {
            string result = "test";
            EmailMessage emailMessage = new EmailMessage();

            emailMessage.Subject = result;

            Assert.AreEqual(result, emailMessage.Subject);
        }

        [TestMethod]
        public void EmailTextIsNotModified()
        {
            string result = "test";
            EmailMessage emailMessage = new EmailMessage();

            emailMessage.Text = result;

            Assert.AreEqual(result, emailMessage.Text);
        }

        [TestMethod]
        public void EmailSendingAreEqual()
        {
            string toAddress = "test1";
            string fromAddress = "test2";
            string subject = "test3";
            string text = "test4";
            string result = string.Format("SendEmail{0}To:{1}{0}From:{2}{0}Subject:{3}{0}Text:{4}", Environment.NewLine, toAddress, fromAddress, subject, text);

            EmailMessage emailMessage = new EmailMessage();
            emailMessage.ToAddress = toAddress;
            emailMessage.FromAddress = fromAddress;
            emailMessage.Subject = subject;
            emailMessage.Text = text;

            string sendingResult;

            sendingResult = Example00.Instance.Main(emailMessage);

            Assert.AreEqual(result, sendingResult);
        }

        [TestMethod]
        public void SmsToAddressIsNotModified()
        {
            string result = "test";
            SmsMessage smsMessage = new SmsMessage();

            smsMessage.ToAddress = result;

            Assert.AreEqual(result, smsMessage.ToAddress);
        }

        [TestMethod]
        public void SmsFromAddressIsNotModified()
        {
            string result = "test";
            SmsMessage smsMessage = new SmsMessage();

            smsMessage.FromAddress = result;

            Assert.AreEqual(result, smsMessage.FromAddress);
        }

        [TestMethod]
        public void SmsTextIsNotModified()
        {
            string result = "test";
            SmsMessage smsMessage = new SmsMessage();

            smsMessage.Text = result;

            Assert.AreEqual(result, smsMessage.Text);
        }

        [TestMethod]
        public void SmsSendingAreEqual()
        {
            string toAddress = "test1";
            string fromAddress = "test2";
            string text = "test3";
            string result = string.Format("SendSms{0}To:{1}{0}From:{2}{0}Text:{3}", Environment.NewLine, toAddress, fromAddress, text);

            SmsMessage smsMessage = new SmsMessage();
            smsMessage.ToAddress = toAddress;
            smsMessage.FromAddress = fromAddress;
            smsMessage.Text = text;

            string sendingResult;

            sendingResult = Example00.Instance.Main(smsMessage);

            Assert.AreEqual(result, sendingResult);
        }

        [TestMethod]
        public void VoiceToAddressIsNotModified()
        {
            string result = "test";
            VoiceMessage voiceMessage = new VoiceMessage();

            voiceMessage.ToAddress = result;

            Assert.AreEqual(result, voiceMessage.ToAddress);
        }

        [TestMethod]
        public void VoiceFromAddressIsNotModified()
        {
            string result = "test";
            VoiceMessage voiceMessage = new VoiceMessage();

            voiceMessage.FromAddress = result;

            Assert.AreEqual(result, voiceMessage.FromAddress);
        }

        [TestMethod]
        public void VoiceVoiceIsNotModified()
        {
            string stringParam = "test";
            byte[] result = Encoding.ASCII.GetBytes(stringParam);
            VoiceMessage voiceMessage = new VoiceMessage();

            voiceMessage.Voice = result;

            Assert.AreEqual(result, voiceMessage.Voice);
        }

        [TestMethod]
        public void VoiceSendingAreEqual()
        {
            string toAddress = "test1";
            string fromAddress = "test2";
            string stringParam = "test3";
            byte[] voice = Encoding.ASCII.GetBytes(stringParam);
            string result = string.Format("SendVoice{0}To:{1}{0}From:{2}{0}Voice:{3}", Environment.NewLine, toAddress, fromAddress, voice);

            VoiceMessage voiceMessage = new VoiceMessage();
            voiceMessage.ToAddress = toAddress;
            voiceMessage.FromAddress = fromAddress;
            voiceMessage.Voice = voice;

            string sendingResult;

            sendingResult = Example00.Instance.Main(voiceMessage);

            Assert.AreEqual(result, sendingResult);
        }
    }
}
