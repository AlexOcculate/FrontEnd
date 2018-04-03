using DataPhilosophiae.Events.AppCS;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.AppCS
{
   public delegate void AllowedDelAppCSEventHandler(object sender);
   public delegate void NotAllowedDelAppCSEventHandler(object sender);
   //
   public delegate void BeforeDelAppCSEventHandler(object sender, BeforeDelAppCSEventArgs ea);
   public delegate void AfterDelAppCSEventHandler(object sender, AfterDelAppCSEventArgs ea);
}
