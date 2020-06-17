using CoreHambusCommonLibrary.DataLib;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CoreHambusCommonLibrary.Services
{
  public class GlobalDataServiceSqlite : IGlobalDataService
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Version { get; set; } = 1.0;
    public string Host { get; set; }
    public int? Port { get; set; }
    public string ConnString { get; set; }
    public string Configuration { get; set; }
    public BusInit busInit { get; set; } = new BusInit();



    #region singleton
    private static readonly object padlock = new object();
    private static GlobalDataServiceSqlite instance = null;
    public static GlobalDataServiceSqlite Instance
    {
      get
      {
        lock (padlock)
        {
          if (instance == null)
          {
            instance = new GlobalDataServiceSqlite();
          }
          return instance;
        }
      }
    }
    #endregion

    public GlobalDataServiceSqlite()
    {
    }

    public void InitDB()
    {

      BuildConnectString();
      try
      {

        using (IDbConnection conn = new SqliteConnection(ConnString))
        {
          try
          {
            conn.Open();
            CreateTable(conn);
            QueryApps(conn);


          }
          catch (Exception ee)
          {
            Console.WriteLine($"InitDB {ee.Message}");
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);

      }
    }

    private void QueryApps(IDbConnection conn)
    {

      var cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT name FROM master_conf";

      var reader = cmd.ExecuteReader();

      if (!reader.Read())
      {
        CreateInitalEntryForMasterBus(cmd, reader);
      }
      else
      {
        UpdateMasterBusEntry(cmd, reader);
      }
    }

    private void UpdateMasterBusEntry(IDbCommand cmd, IDataReader reader)
    {
      throw new NotImplementedException();
    }

    private void CreateInitalEntryForMasterBus(IDbCommand cmd, IDataReader reader)
    {
      //if (Port == null) Port = 7300;
      //var Port = 7300;
      //reader.Close();
      //cmd.CommandText = $"insert into master_conf ( version, port, name) values ( 1.0, {Port}, \"{Name}\")";
      //cmd.ExecuteNonQuery();
    }

    private void CreateTable(IDbConnection conn)
    {
      var createCmd = "CREATE table IF NOT EXISTS [master_conf] (" +
        "[id]  INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
        "[name]  TEXT NOT NULL, " +
        "[Configuration] TEXT" +
        "[version]  NUMERIC NOT NULL DEFAULT 1 " +
         ")";
      Console.WriteLine(createCmd);
      conn.Execute(createCmd);
    }


    private void BuildConnectString()
    {
      var source = busInit.DataFolder + "\\hambus.db";
      ConnString = $"data source={source}";
    }

    private string BuildQuery()
    {
      return null;
    }
  }
}
