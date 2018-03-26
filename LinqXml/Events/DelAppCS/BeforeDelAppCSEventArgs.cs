using System;
using System.Linq;

namespace LinqXml.Control
{
   public class BeforeDelAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public ConnectionString AppCS
      {
         get; set;
      }

      public DelAppCSException Exception
      {
         get; set;
      }
   }
}
