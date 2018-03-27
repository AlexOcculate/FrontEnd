using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Events.ExpandCollapseNode
{
   public delegate void AllowedToExpandAllEventHandler( object sender );
   public delegate void NotAllowedToExpandAllEventHandler( object sender );
   //
   public delegate void AllowedToExpandNodeEventHandler( object sender );
   public delegate void NotAllowedToExpandNodeEventHandler( object sender );
   //
   public delegate void AllowedToExpandChildrenEventHandler( object sender );
   public delegate void NotAllowedToExpandChildrenEventHandler( object sender );
   //
   public delegate void AllowedToCollapseAllEventHandler( object sender );
   public delegate void NotAllowedToCollapseAllEventHandler( object sender );
   //
   public delegate void AllowedToCollapseNodeEventHandler( object sender );
   public delegate void NotAllowedToCollapseNodeEventHandler( object sender );
}
