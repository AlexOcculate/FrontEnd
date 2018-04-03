using DataPhilosophiae.Events.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.File
{
   public delegate void AllowedNewFileEventHandler(object sender);
   public delegate void NotAllowedNewFileEventHandler(object sender);
   //
   public delegate void BeforeNewFileEventHandler(object sender, BeforeNewFileEventArgs ea);
   public delegate void AfterNewFileEventHandler(object sender, AfterNewFileEventArgs ea);
}
