using System;
using System.Linq;

namespace LinqXml.Control
{
   //
   public class AfterCloneAppCSEventArgs : System.EventArgs
   {
      public BeforeCloneAppCSEventArgs args;
      public bool wasCanceled { get { return this.args == null ? false : this.args.Cancel; } }
      public bool hasException { get { return this.args.Exception != null; } }
      public bool isOk { get { return !this.wasCanceled && !this.hasException; } }
      public AfterCloneAppCSEventArgs( BeforeCloneAppCSEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
