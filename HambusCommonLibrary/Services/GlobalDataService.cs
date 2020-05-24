using CoreHambusCommonLibrary.DataLib;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreHambusCommonLibrary.Services
{
  public class GlobalDataService : IGlobalDataService
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
      var source = busInit.DataFolder + "\\hambus.db";
      var connString = $"data source={source}";
      try
      {
        using (var conn = new SqliteConnection(connString))
        {
          conn.Open();

          var command = conn.CreateCommand();
          command.CommandText = @"SELECT name FROM user WHERE id = $id";
          command.Parameters.AddWithValue("$id", 1);

          using (var reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              var name = reader.GetString(0);

              Console.WriteLine($"Hello, {name}!");
            }
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);

      }
    }
  }
}
