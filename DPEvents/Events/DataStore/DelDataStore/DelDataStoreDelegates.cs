using DataPhilosophiae.Events.DS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.DS
{
   public delegate void AllowedDelDataStoreEventHandler(object sender);
   public delegate void NotAllowedDelDataStoreEventHandler(object sender);
   //
   public delegate void BeforeDelDataStoreEventHandler(object sender, BeforeDelDataStoreEventArgs ea);
   public delegate void AfterDelDataStoreEventHandler(object sender, AfterDelDataStoreEventArgs ea);
   //
}
