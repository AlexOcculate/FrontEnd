using System;
using System.Linq;

namespace LinqXml.Control
{
   public class BeforeCloneAppCSEventArgs : System.EventArgs
   {
      public bool Cancel { get; set; }
      public string Filename { get; set; }
      public CloneAppCSException Exception { get; set; }
   }
}
