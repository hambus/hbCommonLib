using CoreHambusCommonLibrary.DataLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreHambusCommonLibrary.Services
{
  public class GlobalDataService: IGlobalDataService
  {
    public string LocalAppDataPath { get; set; }
    public GlobalDataService()
    {
      Console.WriteLine("in GlobalDataService");
      InitDB();
    }

    private void InitDB()
    {
      var busInit = new BusInit();
      busInit.CreateDataIfNeeded();



      
    }
  }
}
