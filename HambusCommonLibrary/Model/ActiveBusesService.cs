using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusMaster.Services
{
  public class ActiveBusesService
  {
    public string? Name { get; set; }
    public string? Configuration { get; set; }
    public List<string> Groups { get; set; } = new List<string>();
    public bool IsActive { get; set; }
  }
}
