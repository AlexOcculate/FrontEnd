using DataPhilosophiae.Events.AppCS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.AppCS
{
   public delegate void AllowedAddAppCSEventHandler(object sender);
   public delegate void NotAllowedAddAppCSEventHandler(object sender);
   //
   public delegate void BeforeAddAppCSEventHandler(object sender, BeforeAddAppCSEventArgs ea);
   public delegate void AfterAddAppCSEventHandler(object sender, AfterAddAppCSEventArgs ea);
}
