using System;
using System.Collections.Generic;
using System.Text;

namespace CoreHambusCommonLibrary.DataLib
{
    public class BusConfigurationDB
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Configuration { get; set; } = "{}";
    }
}
