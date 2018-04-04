using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class AfterOpenFileEventArgs : System.EventArgs
   {
      public BeforeOpenFileEventArgs args;

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

      public AfterOpenFileEventArgs( BeforeOpenFileEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
