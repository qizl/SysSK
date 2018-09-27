﻿using SharpSerializerLibrary;
using System;
using System.Collections.Generic;

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
        public List<Cmd> ShortKeys { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }

        public static Config Load(string path)
        {
            Config config = null;
            try
            {
                SharpSerializer serializer = new SharpSerializer();
                config = serializer.Deserialize(path) as Config;
            }
            catch { }
            return config;
        }

        public bool Save(string path)
        {
            try
            {
                SharpSerializer serializer = new SharpSerializer();
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
