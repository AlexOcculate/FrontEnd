using System;
using System.Linq;

namespace DataPhilosophiae.Events.File
{
   public class AfterSaveAsFileEventArgs : System.EventArgs
   {
      public BeforeSaveAsFileEventArgs args;

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

      public string SavedFilename
      {
         get
         {
            return this.args.SavedFilename;
         }
      }

      public AfterSaveAsFileEventArgs( BeforeSaveAsFileEventArgs args1 )
      {
         this.args = args1;
      }
   }
}
