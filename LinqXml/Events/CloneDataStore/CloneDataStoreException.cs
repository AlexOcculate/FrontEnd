using System;
using System.Linq;

namespace LinqXml.Control
{
   //
   [System.Serializable]
   public class CloneDataStoreException : System.Exception
   {
      public CloneDataStoreException() : base( ) { }

      public CloneDataStoreException( string message ) : base( message ) { }

      public CloneDataStoreException( string format, params object[ ] args )
          : base( string.Format( format, args ) ) { }

      public CloneDataStoreException( string message, System.Exception innerException )
          : base( message, innerException ) { }

      public CloneDataStoreException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException ) { }

      protected CloneDataStoreException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context ) { }
   }
}
