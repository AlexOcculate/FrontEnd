using DataPhilosophiae.Exceptions.AppCS;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
   public class BeforeAddAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public string Filename
      {
         get; set;
      }

      public AddAppCSException Exception
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
