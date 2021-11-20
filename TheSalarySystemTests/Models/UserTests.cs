using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSalarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSalarySystem.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        //[DataRow("samwon", "123abc", false)]
        [DataRow("farzanezafar", "password1", true)]
        public void DeleteTest_DeleteOnesOwnAccount_ShouldReturnTrue(string userName, string passWord, bool expected)
        {
            var user = new User("Farzane", "Zafar", "farzanezafar", "password1", 54000, "manager", false);
            var actual = user.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("davidberg", "david123", false)]
        public void DeleteTest_DeleteOthersAccount_ShouldReturnFalse(string userName, string passWord, bool expected)
        {
            var user = new User("Farzane", "Zafar", "farzanezafar", "password1", 54000, "manager", false);
            var actual = user.Delete(userName, passWord);
            Assert.AreEqual(expected, actual);
        }
    }
}