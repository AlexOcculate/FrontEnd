using System;
using System.Linq;

namespace LinqXml.Control.SaveFile
{
   public delegate void AllowedToSaveFileEventHandler( object sender );
   public delegate void NotAllowedToSaveFileEventHandler( object sender );
   //
   public delegate void BeforeSaveFileEventHandler( object sender, BeforeSaveFileEventArgs ea );
   public delegate void AfterSaveFileEventHandler( object sender, AfterSaveFileEventArgs ea );

}
