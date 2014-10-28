using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public class Cmds
    {
        /// <summary>
        /// 新建命令文件
        /// </summary>
        /// <param name="cmd">命令（文件）名称，快捷键</param>
        /// <param name="appPath">命令指向应用路径</param>
        /// <param name="cmdsFolder">命令文件保存路径</param>
        /// <returns></returns>
        public bool CreateCmd(string cmd, string appPath, string cmdsFolder)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除命令文件
        /// </summary>
        /// <param name="cmd">命令（文件）名称，快捷键</param>
        /// <param name="cmdsFolder">命令文件保存路径</param>
        /// <returns></returns>
        public bool RemoveCmd(string cmd, string cmdsFolder)
        {
            throw new NotImplementedException();
        }
    }
}
