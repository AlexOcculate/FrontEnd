using DataPhilosophiae.Exceptions.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class BeforeSaveAsFileEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string SuggestedFilename
      {
         get; set;
      }

      public string SavedFilename
      {
         get; set;
      }

      public SaveAsFileException Exception
      {
         get; set;
      }
   }
}
