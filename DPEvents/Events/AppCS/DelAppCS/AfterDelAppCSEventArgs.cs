using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
   public class AfterDelAppCSEventArgs : System.EventArgs
   {
      private BeforeDelAppCSEventArgs args;

      public bool wasCanceled
      {
         get
         {
            return this.args == null ? false : this.args.Cancel;
         }
      }

      public bool hasException
      {
         get
         {
            return this.args.Exception != null;
         }
      }

      public bool isOk
      {
         get
         {
            return !this.wasCanceled && !this.hasException;
         }
      }

      public AfterDelAppCSEventArgs( BeforeDelAppCSEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
