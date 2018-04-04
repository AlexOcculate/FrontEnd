using DataPhilosophiae.Events;
using DataPhilosophiae.Events.DS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.DS
{
   public delegate void AllowedAddDataStoreEventHandler(object sender);
   public delegate void NotAllowedAddDataStoreEventHandler(object sender);
   //
   public delegate void BeforeAddDataStoreEventHandler(object sender, BeforeAddDataStoreEventArgs ea);
   public delegate void AfterAddDataStoreEventHandler(object sender, AfterAddDataStoreEventArgs ea);
}
