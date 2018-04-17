using System;
using System.Linq;

namespace DataPhilosophiae.Model
{
   public class SysConnectionString
   {
      public bool IsSys
      {
         get; private set;
      }

      public string Name
      {
         get; private set;
      }

      public string ProviderName
      {
         get; private set;
      }

      public string ConnectionString
      {
         get; private set;
      }

      public SysConnectionString(string name, string providerName, string connectionString)
      {
         this.Name = name;
         this.ProviderName = providerName;
         this.ConnectionString = connectionString;
         this.IsSys = true;
      }
   }
}
