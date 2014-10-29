using SharpSerializerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSK.Models
{
    public class Config : Object, ICloneable
    {
        public bool IsEnabled { get; set; }
        public string ShortKeysFolder { get; set; }
        public List<App> ShortKeys { get; set; }

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
