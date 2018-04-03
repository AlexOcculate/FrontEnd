using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.File
{
   [System.Serializable]
   public class SaveFileException : System.Exception
   {
      public SaveFileException()
         : base( )
      {
      }

      public SaveFileException( string message )
         : base( message )
      {
      }

      public SaveFileException( string format, params object[ ] args )
         : base( string.Format( format, args ) )
      {
      }

      public SaveFileException( string message, System.Exception innerException )
         : base( message, innerException )
      {
      }

      public SaveFileException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected SaveFileException( System.Runtime.Serialization.SerializationInfo info,
                                  System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
