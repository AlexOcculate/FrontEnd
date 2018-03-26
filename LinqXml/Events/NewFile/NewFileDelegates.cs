using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Control.Configuration.NewFile
{
   public delegate void AllowedNewFileEventHandler( object sender );
   public delegate void NotAllowedNewFileEventHandler( object sender );
   //
   public delegate void BeforeNewFileEventHandler( object sender, BeforeNewFileEventArgs ea );
   public delegate void AfterNewFileEventHandler( object sender, AfterNewFileEventArgs ea );
}
