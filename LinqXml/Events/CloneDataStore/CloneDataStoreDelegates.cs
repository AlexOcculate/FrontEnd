using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Events.CloneDataStore
{
   public delegate void AllowedToCloneDataStoreEventHandler( object sender );
   public delegate void NotAllowedToCloneDataStoreEventHandler( object sender );
}
