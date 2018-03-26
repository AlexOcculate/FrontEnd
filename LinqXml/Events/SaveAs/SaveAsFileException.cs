using System;
using System.Linq;

namespace LinqXml.Control
{
   [System.Serializable]
   public class SaveAsFileException : System.Exception
   {
      public SaveAsFileException() : base( )
      {
      }

      public SaveAsFileException( string message ) : base( message )
      {
      }

      public SaveAsFileException( string format, params object[ ] args ) 
         : base( string.Format( format, args ) )
      {
      }

      public SaveAsFileException( string message, System.Exception innerException )
         : base( message, innerException )
      {
      }

      public SaveAsFileException( string format, System.Exception innerException, params object[ ] args )
         : base( string.Format( format, args ), innerException )
      {
      }

      protected SaveAsFileException( System.Runtime.Serialization.SerializationInfo info,
                                    System.Runtime.Serialization.StreamingContext context )
         : base( info, context )
      {
      }
   }
}
