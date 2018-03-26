using System;
using System.Linq;

namespace LinqXml.Control
{
   public class BeforeAddAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public AddAppCSException Exception
      {
         get; set;
      }
   }
}
