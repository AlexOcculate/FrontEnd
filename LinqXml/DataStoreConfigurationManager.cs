using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml
{
   public partial class DataStoreConfigurationManager : Component
   {
      public DataStoreConfigurationManager()
      {
         InitializeComponent( );
      }

      public DataStoreConfigurationManager( IContainer container )
      {
         container.Add( this );

         InitializeComponent( );
      }
// ----------------------------------------------------------------------------

   }
}
