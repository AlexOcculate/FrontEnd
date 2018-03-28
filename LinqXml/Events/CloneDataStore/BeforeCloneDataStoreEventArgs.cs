using System;
using System.Linq;

namespace LinqXml.Control
{
   public class BeforeCloneDataStoreEventArgs : System.EventArgs
   {
      public bool Cancel { get; set; }
      public DataStore OrigDS { get; set; }
      public DataStore NewDS { get; set; }
      public CloneDataStoreException Exception { get; set; }
   }
}
