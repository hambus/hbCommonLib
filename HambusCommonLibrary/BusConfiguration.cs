using System;

namespace CoreHambusCommonLibrary
{
    public abstract class BusConfiguration
    {
        public string Name { get; set; } = "";
        public string BusType { get; set; } = "";
        public int Port { get; set; } = 7300;
        public string Host { get; set; } = "localhost";
    }
}
