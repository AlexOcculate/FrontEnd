using DataPhilosophiae.Exceptions.DS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.DS
{
   //
   public class BeforeDelDataStoreEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public DataStore DataStore
      {
         get; set;
      }

      public DelDataStoreException Exception
      {
         get; set;
      }
   }
}
