using System;
using System.Linq;

namespace LinqXml.Control
{
   //
   [System.Serializable]
   public class DelDataStoreException : System.Exception
   {
      public DelDataStoreException() : base( ) { }

      public DelDataStoreException( string message ) : base( message ) { }

      public DelDataStoreException( string format, params object[ ] args )
          : base( string.Format( format, args ) ) { }

      public DelDataStoreException( string message, System.Exception innerException )
          : base( message, innerException ) { }

      public DelDataStoreException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException ) { }

      protected DelDataStoreException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context ) { }
   }
}
