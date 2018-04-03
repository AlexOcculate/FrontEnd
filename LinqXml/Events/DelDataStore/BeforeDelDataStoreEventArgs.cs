using System;
using System.Linq;

namespace LinqXml.Control
{
   //
   public class BeforeDelDataStoreEventArgs : System.EventArgs
   {
      public bool Cancel { get; set; }
      public DataStore DataStore { get; set; }
      public DelDataStoreException Exception { get; set; }
   }
}
