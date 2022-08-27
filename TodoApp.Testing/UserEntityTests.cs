using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using TodoApp.DataVerifier;

namespace TodoApp.Testing
{
    [TestFixture]
    public class UserEntityTests
    {
        private AppUser user;

        [SetUp]
        public void Init()
        {
           // user = new IdentityUser(Guid.NewGuid(), "User1", "user1@example.com", "mYPasswRd33!");
        }

        [TestCase("---aabbcc,", ExpectedResult = false)]
        [TestCase("-1-aabb0c,", ExpectedResult = false)]
        [TestCase(",--aabbcc,", ExpectedResult = false)]
        [TestCase("Ad--cvb", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        [TestCase("aabdsvb32", ExpectedResult = true)]
        [TestCase("jannowak99", ExpectedResult = true)]
        [TestCase("user123", ExpectedResult = true)]
        [TestCase("username222", ExpectedResult = true)]

        public bool UserNameSet_Test(string userName)
        {
            var expected = Verifier.Verify(userName, EntityDataType.USERNAME);
            return expected;
        }

        [TestCase("a1", ExpectedResult = false)]
        [TestCase("-aads222", ExpectedResult = false)]
        [TestCase("AAAAA", ExpectedResult = false)]
        [TestCase("333333", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        [TestCase("#Dddgd9198", ExpectedResult = true)]
        [TestCase("Abcfj#i99", ExpectedResult = true)]
        [TestCase("Fff#33f", ExpectedResult = true)]
        [TestCase("323256###Aaaa99!", ExpectedResult = true)]

        public bool UserPasswordSet_Test(string password)
        {
            var expected = Verifier.Verify(password, EntityDataType.PASSWORD);
            return expected;
        }

        [TestCase("user1@gmail.com", ExpectedResult =true)]
        [TestCase("userno2@wp.pl", ExpectedResult = true)]
        [TestCase("testUser3@gmail.com", ExpectedResult = true)]

        public bool UserEmailSet_Test(string email)
        {
            var expected = Verifier.Verify(email, EntityDataType.EMAIL);
            return expected;
        }

        [Test]
        public void ExampleUserCreatedSuccessfully()
        {
            string username = "myTestUser15";
            string password = "Abcfj#i99";
            string email = "myTestUser15@test.com";
            var id = Guid.NewGuid();

            var newUser = new AppUser();

            Assert.NotNull(newUser);
            Assert.AreEqual(id, newUser.Id);
            Assert.AreEqual(username, newUser.UserName);
            Assert.AreEqual(email, newUser.Email);
            Assert.AreEqual(password, newUser.PasswordHash);
        }
    }
}
