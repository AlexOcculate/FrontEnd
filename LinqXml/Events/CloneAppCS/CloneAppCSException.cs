using System;
using System.Linq;

namespace LinqXml.Control
{
   //
   [System.Serializable]
   public class CloneAppCSException : System.Exception
   {
      public CloneAppCSException() : base( ) { }

      public CloneAppCSException( string message ) : base( message ) { }

      public CloneAppCSException( string format, params object[ ] args )
          : base( string.Format( format, args ) ) { }

      public CloneAppCSException( string message, System.Exception innerException )
          : base( message, innerException ) { }

      public CloneAppCSException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException ) { }

      protected CloneAppCSException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context ) { }
   }
}
