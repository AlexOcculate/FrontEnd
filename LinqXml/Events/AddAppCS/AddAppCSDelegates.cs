using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Control.Configuration.AddAppCS
{
   public delegate void AllowedAddAppCSEventHandler( object sender );
   public delegate void NotAllowedAddAppCSEventHandler( object sender );
   //
   public delegate void BeforeAddAppCSEventHandler( object sender, BeforeAddAppCSEventArgs ea );
   public delegate void AfterAddAppCSEventHandler( object sender, AfterAddAppCSEventArgs ea );
}
