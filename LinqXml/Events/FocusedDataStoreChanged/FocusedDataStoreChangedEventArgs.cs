using System;
using System.Linq;

namespace LinqXml.Control
{
   public delegate void FocusedDataStoreChangedEventHandler( object sender, FocusedDataStoreChangedEventArgs ea );

   //
   //
   //         FocusedDataStoreChangedEventArgs args1 = new FocusedDataStoreChangedEventArgs( );
   //         args1.Filename = filename;
   //         this.FocusedDataStoreChangedEvent?.Invoke( this, args2 );
   //

   public class FocusedDataStoreChangedEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public DataStore DataStore
      {
         get; set;
      }

      public FocusedDataStoreChangedException Exception
      {
         get; set;
      }
   }
}
