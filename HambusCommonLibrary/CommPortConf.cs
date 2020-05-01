using System;
using System.Collections.Generic;
using System.Text;

namespace HambusCommonLibrary
{
  class CommPortConf
  {
    public string PortName { get; set; }
    public int BaudRate { get; set; }
    public string Parity { get; set; }
    public int DataBits { get; set; }
    public int stopBits { get; set; }
    public string handShake { get; set; }
    public int ReadTimeout { get; set; }
    public int WriteTimeout { get; set; }
  }
}
