using System;
using System.Linq;

namespace LinqXml.Control
{
   public class BeforeCloseFileEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public CloseFileException Exception
      {
         get; set;
      }
   }
}
