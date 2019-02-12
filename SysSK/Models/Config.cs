using SharpSerializerLibrary;
using System;
using System.Collections.Generic;
using System.IO;

namespace EnjoyCodes.SysSK.Models
{
    public class Config : Object, ICloneable
    {
        public bool IsEnabled { get; set; }
        /// <summary>
        /// 是否可以从系统环境变量中移除当前添加的路径
        /// 其他应用添加的路径，不能移除
        /// </summary>
        public bool CanRemoveCurrentFolder { get; set; }
        public string ShortKeysFolder { get; set; }
        /// <summary>
        /// 以管理员权限运行应用的软件路径
        /// </summary>
        public string RunAsAministratorAppPath { get; } = Path.Combine(Environment.CurrentDirectory, "RunAsAministrator.exe");
        public List<Cmd> ShortKeys { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public static Config Load(string path)
        {
            Config config = null;
            try
            {
                var serializer = new SharpSerializer();
                config = serializer.Deserialize(path) as Config;
            }
            catch { }
            return config;
        }

        public bool Save(string path)
        {
            try
            {
                var serializer = new SharpSerializer();
                serializer.Serialize(this, path);
            }
            catch { return false; }
            return true;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
