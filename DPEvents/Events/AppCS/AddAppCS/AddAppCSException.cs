using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.AppCS
{
   [System.Serializable]
   public class AddAppCSException : System.Exception
   {
      public AddAppCSException() : base( )
      {
      }

      public AddAppCSException( string message ) : base( message )
      {
      }

      public AddAppCSException( string format, params object[ ] args )
          : base( string.Format( format, args ) )
      {
      }

      public AddAppCSException( string message, System.Exception innerException )
          : base( message, innerException )
      {
      }

      public AddAppCSException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException )
      {
      }

      protected AddAppCSException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context )
      {
      }
   }
}
