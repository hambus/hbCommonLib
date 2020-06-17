using System.IO.Ports;
using CoreHambusCommonLibrary;

namespace HambusCommonLibrary
{
    public class RigConf : BusConfiguration
    {
        private static RigConf? instance = null;
        public static RigConf Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RigConf();
                }
                return instance;
            }
        }
        private RigConf() { }
        public string? PortName { get; set; }
        public int? BaudRate { get; set; } = 4800;
        public string Parity { get; set; } = "none";
        public int? DataBits { get; set; }
        public string? StopBits { get; set; } = "one";
        public Handshake handShake { get; set; }
        public int? ReadTimeout { get; set; }
        public int? WriteTimeout { get; set; }
        public Handshake Handshake { get; set; }
    }
}
