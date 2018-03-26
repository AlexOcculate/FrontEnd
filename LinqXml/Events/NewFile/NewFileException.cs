using System;
using System.Linq;

namespace LinqXml.Control
{
   [System.Serializable]
   public class NewFileException : System.Exception
   {
      public NewFileException() : base( )
      {
      }

      public NewFileException( string message ) : base( message )
      {
      }

      public NewFileException( string format, params object[ ] args )
          : base( string.Format( format, args ) )
      {
      }

      public NewFileException( string message, System.Exception innerException )
          : base( message, innerException )
      {
      }

      public NewFileException( string format, System.Exception innerException, params object[ ] args )
          : base( string.Format( format, args ), innerException )
      {
      }

      protected NewFileException( System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context )
          : base( info, context )
      {
      }
   }
}
