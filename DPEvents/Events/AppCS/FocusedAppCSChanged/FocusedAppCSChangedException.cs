using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.AppCS
{
   [System.Serializable]
   public class FocusedAppCSChangedException : System.Exception
   {
      public FocusedAppCSChangedException() : base( )
      {
      }

      public FocusedAppCSChangedException( string message ) : base( message )
      {
      }

      public FocusedAppCSChangedException( string format, params object[ ] args ) : base( string.Format( format, args ) )
      {
      }

      public FocusedAppCSChangedException( string message, System.Exception innerException ) : base( message, innerException )
      {
      }

      public FocusedAppCSChangedException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected FocusedAppCSChangedException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
