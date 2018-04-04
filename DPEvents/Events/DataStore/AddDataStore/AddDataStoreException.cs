using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.DS
{
   //
   [System.Serializable]
   public class AddDataStoreException : System.Exception
   {
      public AddDataStoreException() : base( )
      {
      }

      public AddDataStoreException( string message ) : base( message )
      {
      }

      public AddDataStoreException( string format, params object[ ] args )
          : base( string.Format( format, args ) )
      {
      }

      public AddDataStoreException( string message, System.Exception innerException )
          : base( message, innerException )
      {
      }

      public AddDataStoreException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException )
      {
      }

      protected AddDataStoreException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context )
      {
      }
   }
}
