using DataPhilosophiae.Exceptions.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class BeforeSaveFileEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string SavedFilename
      {
         get; set;
      }

      public SaveFileException Exception
      {
         get; set;
      }
   }
}
