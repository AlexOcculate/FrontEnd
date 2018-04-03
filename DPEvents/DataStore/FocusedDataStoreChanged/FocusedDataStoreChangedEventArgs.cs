using DataPhilosophiae.Exceptions.DS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
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
