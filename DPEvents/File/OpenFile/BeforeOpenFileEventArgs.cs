using DataPhilosophiae.Exceptions.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class BeforeOpenFileEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string SuggestedFilename
      {
         get; set;
      }

      public string OpenedFilename
      {
         get; set;
      }

      public OpenFileException Exception
      {
         get; set;
      }
   }
}
