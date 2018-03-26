using System;
using System.Linq;

namespace LinqXml.Control.Configuration.OpenFile
{
   public delegate void AllowedToOpenFileEventHandler( object sender );
   public delegate void NotAllowedToOpenFileEventHandler( object sender );
   //
   public delegate void BeforeOpenFileEventHandler( object sender, BeforeOpenFileEventArgs ea );
   public delegate void AfterOpenFileEventHandler( object sender, AfterOpenFileEventArgs ea );
}
