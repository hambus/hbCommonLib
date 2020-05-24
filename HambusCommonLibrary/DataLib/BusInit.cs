﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Authentication;
using System.Text;

namespace CoreHambusCommonLibrary.DataLib
{
  public class BusInit
  {
    public  string DataFolder;
    public  string hamBusDir = "HamBus";
    public BusInit()
    {

    }
    public string GetLocalAppData()
    {
      string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
      return filePath;
    }

    public  void CreateDataIfNeeded()
    {
      try
      {
        var filePath = GetLocalAppData() + "\\" + hamBusDir;

        if (File.Exists(filePath))
          throw new Exception($"{hamBusDir} exist as a file.  Cannot continue");
        if (Directory.Exists(filePath))
          return;
        Directory.CreateDirectory(filePath);
      } 
      catch (Exception e)
      {
        Console.WriteLine($"Create Data Directory Error: {e.Message}");
        throw e;

      }
    }

  }
}