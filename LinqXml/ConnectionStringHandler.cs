using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml
{
   public partial class ConnectionStringHandler : Component
   {
      public ConnectionStringHandler()
      {
         InitializeComponent( );
      }

      public ConnectionStringHandler( IContainer container )
      {
         container.Add( this );

         InitializeComponent( );
      }
   }
}
