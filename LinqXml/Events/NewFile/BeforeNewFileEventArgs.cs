using System;
using System.Linq;

namespace LinqXml.Control
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
