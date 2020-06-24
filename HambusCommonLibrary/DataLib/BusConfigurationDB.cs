
using BusMaster.Model;

namespace CoreHambusCommonLibrary.DataLib
{
  public class BusConfigurationDB
  {
    public int? Id { get; set; }
    public string Name { get; set; } = "";
    public int Version { get; set; }
    public BusType BusType { get; set; }

    public string Configuration { get; set; } = "{}";
  }
}
