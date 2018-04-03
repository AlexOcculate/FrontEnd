using DataPhilosophiae.Exceptions.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class BeforeNewFileEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public NewFileException Exception
      {
         get; set;
      }
   }
}
