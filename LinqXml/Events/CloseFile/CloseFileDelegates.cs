using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Control.Configuration.CloseFile
{
   public delegate void AllowedToCloseFileEventHandler( object sender );
   public delegate void NotAllowedToCloseFileEventHandler( object sender );
   //
   public delegate void AfterCloseFileEventHandler( object sender, AfterCloseFileEventArgs ea );
   public delegate void BeforeCloseFileEventHandler( object sender, BeforeCloseFileEventArgs ea );
}
