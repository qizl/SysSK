using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysSK.Models;

namespace SysSKTests
{
    [TestClass]
    public class RegeditTests
    {
        [TestMethod]
        public void TestReadApps()
        {
            Regedit regedit = new Regedit();
            regedit.ReadApps();
        }
    }
}
