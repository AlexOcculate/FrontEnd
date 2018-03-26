using System;
using System.Linq;

namespace LinqXml.Control
{
   public class AfterAddAppCSEventArgs : System.EventArgs
   {
      private BeforeAddAppCSEventArgs args;

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

      public AfterAddAppCSEventArgs( BeforeAddAppCSEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
