using System;
using System.Linq;

namespace LinqXml.Control
{
   public class AfterCloseFileEventArgs : System.EventArgs
   {
      public BeforeCloseFileEventArgs args;

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

      public AfterCloseFileEventArgs( BeforeCloseFileEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
