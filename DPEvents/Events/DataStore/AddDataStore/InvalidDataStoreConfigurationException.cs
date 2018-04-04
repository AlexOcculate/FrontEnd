using System;
using System.Linq;

namespace DataPhilosophiae.Exceptions.DS
{
   //
   [System.Serializable]
   public class InvalidDataStoreConfigurationException : System.Exception
   {
      public InvalidDataStoreConfigurationException() : base()
      {
      }

      public InvalidDataStoreConfigurationException(string message) : base(message)
      {
      }

      public InvalidDataStoreConfigurationException(string format, params object[ ] args)
         : base(string.Format(format, args))
      {
      }

      public InvalidDataStoreConfigurationException(string message, System.Exception innerException)
         : base(message, innerException)
      {
      }

      public InvalidDataStoreConfigurationException(string format,
                                                    System.Exception innerException,
                                                    params object[ ] args)
         : base(string.Format(format, args), innerException)
      {
      }

      protected InvalidDataStoreConfigurationException(System.Runtime.Serialization.SerializationInfo info,
                                                       System.Runtime.Serialization.StreamingContext context)
         : base(info, context)
      {
      }
   }
}
