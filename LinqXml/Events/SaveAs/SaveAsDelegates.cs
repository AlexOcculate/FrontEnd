using System;
using System.Linq;

namespace LinqXml.Control.SaveAs
{
   public delegate void AllowedToSaveAsFileEventHandler( object sender );
   public delegate void NotAllowedToSaveAsFileEventHandler( object sender );
   //
   public delegate void BeforeSaveAsFileEventHandler( object sender, BeforeSaveAsFileEventArgs ea );
   public delegate void AfterSaveAsFileEventHandler( object sender, AfterSaveAsFileEventArgs ea );
   //
   public delegate void SavedFileNameChangedEventHandler( object sender, SavedFileNameChangedEventArgs args );
}
