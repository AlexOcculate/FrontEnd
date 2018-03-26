using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Control.Configuration.AddDataStore
{
   public delegate void AllowedAddDataStoreEventHandler( object sender );
   public delegate void NotAllowedAddDataStoreEventHandler( object sender );
   //
   public delegate void BeforeAddDataStoreEventHandler( object sender, BeforeAddDataStoreEventArgs ea );
   public delegate void AfterAddDataStoreEventHandler( object sender, AfterAddDataStoreEventArgs ea );
}
