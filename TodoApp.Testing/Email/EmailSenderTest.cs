using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.EmailService.Services;

namespace TodoApp.Testing.Email
{
    [TestFixture]
    public class EmailSenderTest
    {
        private IEmailSender sender;

        [SetUp]
        public void Init()
        {
            sender = new EmailSender();
        }

        [Test]
        public void SendEmailPassed_Test()
        {
            var res = sender.SendEmail("testmail@test.com", "Error1", "Unable to get task lists");

            Assert.AreEqual(1, res);
        }
    }
}
