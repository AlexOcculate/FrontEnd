using DataPhilosophiae.Exceptions.AppCS;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
   public class BeforeAddAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public AddAppCSException Exception
      {
         get; set;
      }
   }
}
