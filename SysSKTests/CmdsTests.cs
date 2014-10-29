using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysSK.Models;
using System.IO;

namespace SysSKTests
{
    [TestClass]
    public class CmdsTests
    {
        [TestMethod]
        public void TestCreateCmd()
        {
            Cmds cmd = new Cmds();
            cmd.CreateCmd("xunl", @"D:\Thunder\Program\Thunder.exe", Path.Combine(Environment.CurrentDirectory, "bat"));
        }

        [TestMethod]
        public void TestRemoveCmd()
        {
            string path = @"E:\qizl的文件夹\Practise\SysSK\SysSKTests\bin\Debug\bat\";
            Cmds cmd = new Cmds();
            cmd.RemoveCmd("xunl", path);
        }
    }
}
