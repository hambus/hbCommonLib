using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMaster.Model
{
  public enum BusType { BusMaster, RigBus, VirtualRigBus, LogBus, RotoBus, ClusterBus}
  public class BusMasterGroups
  {
    public readonly string UI = "ui";
    public readonly string Radio = "radio";
    public readonly string Logging = "logging";
    public readonly string DxCluster = "dxcluster";
    public readonly string Rotor  = "rotor";
  }
}
