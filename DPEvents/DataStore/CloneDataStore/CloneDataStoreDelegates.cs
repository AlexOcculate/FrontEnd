using DataPhilosophiae.Events.DS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.DS
{
   public delegate void AllowedToCloneDataStoreEventHandler(object sender);
   public delegate void NotAllowedToCloneDataStoreEventHandler(object sender);
   //
   public delegate void BeforeCloneDataStoreEventHandler(object sender, BeforeCloneDataStoreEventArgs ea);
   public delegate void AfterCloneDataStoreEventHandler(object sender, AfterCloneDataStoreEventArgs ea);
}
