using System;
using System.Collections.Generic;
using System.Text;

namespace l4gof.Model
{
    public class PrototypeRegistry
    {
        private static volatile PrototypeRegistry _instance;
        private static readonly object _lock = new object();
        private Dictionary<string, Computer> _dict;

        private PrototypeRegistry() 
        {
            _dict = new Dictionary<string, Computer>()
            {
                {"gaming", new GamingComputerFactory().Construct() },
                {"office", new OfficeComputerFactory().Construct() },
                {"home", new HomeComputerFactory().Construct() },
            };
        }
        public static PrototypeRegistry Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new PrototypeRegistry();
                    }
                }
                return _instance;
            }
        }
        public Computer GetPrototype(string key)
        {
            if (_dict.ContainsKey(key))
            {
                return _dict[key].DeepCopy();
            }
            return new Computer();
        }
    }
}
