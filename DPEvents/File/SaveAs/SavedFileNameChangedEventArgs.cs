using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class SavedFileNameChangedEventArgs : System.EventArgs
   {
      public string OldFilename
      {
         get; set;
      }

      public string NewFilename
      {
         get; set;
      }
   }
}
