using DataPhilosophiae.Events.File;
using System;
using System.Linq;

namespace DataPhilosophiae.Delegates.File
{
   public delegate void AllowedToSaveAsFileEventHandler(object sender);
   public delegate void NotAllowedToSaveAsFileEventHandler(object sender);
   //
   public delegate void BeforeSaveAsFileEventHandler(object sender, BeforeSaveAsFileEventArgs ea);
   public delegate void AfterSaveAsFileEventHandler(object sender, AfterSaveAsFileEventArgs ea);
   //
   public delegate void SavedFileNameChangedEventHandler(object sender, SavedFileNameChangedEventArgs args);
}
