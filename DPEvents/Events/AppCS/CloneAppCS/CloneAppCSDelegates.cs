using DataPhilosophiae.Events.AppCS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.AppCS
{
   public delegate void AllowedToCloneAppCSEventHandler(object sender);
   public delegate void NotAllowedToCloneAppCSEventHandler(object sender);
   //
   public delegate void BeforeCloneAppCSEventHandler(object sender, BeforeCloneAppCSEventArgs ea);
   public delegate void AfterCloneAppCSEventHandler(object sender, AfterCloneAppCSEventArgs ea);
}
