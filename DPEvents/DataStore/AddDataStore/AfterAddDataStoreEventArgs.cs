using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
   public class AfterAddDataStoreEventArgs : System.EventArgs
   {
      private BeforeAddDataStoreEventArgs args;

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

      public AfterAddDataStoreEventArgs( BeforeAddDataStoreEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
