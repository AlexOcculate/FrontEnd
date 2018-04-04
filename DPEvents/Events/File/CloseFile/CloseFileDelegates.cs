using DataPhilosophiae.Events.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.File
{
   public delegate void AllowedToCloseFileEventHandler(object sender);
   public delegate void NotAllowedToCloseFileEventHandler(object sender);
   //
   public delegate void AfterCloseFileEventHandler(object sender, AfterCloseFileEventArgs ea);
   public delegate void BeforeCloseFileEventHandler(object sender, BeforeCloseFileEventArgs ea);
}
