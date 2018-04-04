using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.File
{
   [System.Serializable]
   public class OpenFileException : System.Exception
   {
      public OpenFileException() : base( )
      {
      }

      public OpenFileException( string message ) : base( message )
      {
      }

      public OpenFileException( string format, params object[ ] args )
         : base( string.Format( format, args ) )
      {
      }

      public OpenFileException( string message, System.Exception innerException )
         : base( message, innerException )
      {
      }

      public OpenFileException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected OpenFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
