using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqXml.Control;

namespace LinqXml.Events.CloneDataStore
{
   public delegate void AllowedToCloneDataStoreEventHandler( object sender );
   public delegate void NotAllowedToCloneDataStoreEventHandler( object sender );
   //
   public delegate void BeforeCloneDataStoreEventHandler( object sender, BeforeCloneDataStoreEventArgs ea );
   public delegate void AfterCloneDataStoreEventHandler( object sender, AfterCloneDataStoreEventArgs ea );
}
