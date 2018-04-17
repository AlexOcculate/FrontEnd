using DataPhilosophiae.Exceptions.AppCS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
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
      public bool wasCanceled
      {
         get
         {
            return this.Cancel;
         }
      }

      public bool hasException
      {
         get
         {
            return this.Exception != null;
         }
      }

      public bool isOk
      {
         get
         {
            return !this.wasCanceled && !this.hasException;
         }
      }
   }
}
