using DataPhilosophiae.Exceptions.AppCS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
   public class BeforeCloneAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public ConnectionString OrigCS
      {
         get; set;
      }

      public ConnectionString NewCS
      {
         get; set;
      }

      public CloneAppCSException Exception
      {
         get; set;
      }
   }
}
