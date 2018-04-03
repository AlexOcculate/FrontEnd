using DataPhilosophiae.Exceptions.DS;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
   public class BeforeAddDataStoreEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public AddDataStoreException Exception
      {
         get; set;
      }
   }
}
