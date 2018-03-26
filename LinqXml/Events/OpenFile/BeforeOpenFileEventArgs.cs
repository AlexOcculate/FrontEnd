using System;
using System.Linq;

namespace LinqXml.Control
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
