using System;
using System.Linq;

namespace LinqXml.Control
{
   public delegate void FocusedAppCSChangedEventHandler( object sender, FocusedAppCSChangedEventArgs ea );

   //
   //         FocusedConnectionStringChangedEventArgs args1 = new FocusedConnectionStringChangedEventArgs( );
   //         args1.Filename = filename;
   //         this.FocusedConnectionStringChangedEvent?.Invoke( this, args2 );
   //
   public class FocusedAppCSChangedEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public ConnectionString ConnectionString
      {
         get; set;
      }

      public FocusedAppCSChangedException Exception
      {
         get; set;
      }
   }
}
