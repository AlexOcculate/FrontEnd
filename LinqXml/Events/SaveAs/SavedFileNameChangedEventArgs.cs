using System;
using System.Linq;

namespace LinqXml.Control
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
