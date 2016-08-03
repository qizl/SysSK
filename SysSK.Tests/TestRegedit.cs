using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysSK.Models;

namespace SysSK.Tests
{
    [TestClass]
    public class TestRegedit
    {
        [TestMethod]
        public void AddSystemEnvironmentVariable_Path()
        {
            return;
            string[] vars = new string[] { @"D:\PL\Cygwin\bin", @"D:\PL\Cygwin\sbin" };

            Regedit regedit = new Regedit();
            bool b = true;
            foreach (var item in vars)
                b &= regedit.AddSystemEnvironmentVariable_Path(item);
            Assert.IsTrue(b);
        }
    }
}
