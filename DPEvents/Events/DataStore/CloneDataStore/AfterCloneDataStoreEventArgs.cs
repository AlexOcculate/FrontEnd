using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
   //
   public class AfterCloneDataStoreEventArgs : System.EventArgs
   {
      public BeforeCloneDataStoreEventArgs args;
      public bool wasCanceled { get { return this.args == null ? false : this.args.Cancel; } }
      public bool hasException { get { return this.args.Exception != null; } }
      public bool isOk { get { return !this.wasCanceled && !this.hasException; } }
      public AfterCloneDataStoreEventArgs( BeforeCloneDataStoreEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
