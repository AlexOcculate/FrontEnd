using DataPhilosophiae.Events.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.File
{
   public delegate void AllowedToSaveFileEventHandler(object sender);
   public delegate void NotAllowedToSaveFileEventHandler(object sender);
   //
   public delegate void BeforeSaveFileEventHandler(object sender, BeforeSaveFileEventArgs ea);
   public delegate void AfterSaveFileEventHandler(object sender, AfterSaveFileEventArgs ea);
}
