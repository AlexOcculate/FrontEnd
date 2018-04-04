using DataPhilosophiae.Exceptions.DS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
   public class BeforeCloneDataStoreEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public DataStore OrigDS
      {
         get; set;
      }

      public DataStore NewDS
      {
         get; set;
      }

      public CloneDataStoreException Exception
      {
         get; set;
      }
   }
}
