using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.File
{
   [System.Serializable]
   public class CloseFileException : System.Exception
   {
      public CloseFileException() : base( )
      {
      }

      public CloseFileException( string message )
         : base( message )
      {
      }

      public CloseFileException( string format, params object[ ] args )
         : base( string.Format( format, args ) )
      {
      }

      public CloseFileException( string message, System.Exception innerException )
         : base( message, innerException )
      {
      }

      public CloseFileException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected CloseFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
