using System;
using System.Linq;

namespace LinqXml.Control
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
