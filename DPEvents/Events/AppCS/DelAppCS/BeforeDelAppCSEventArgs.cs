﻿using DataPhilosophiae.Exceptions.AppCS;
using DataPhilosophiae.Model;
using System;
using System.Linq;

namespace DataPhilosophiae.Events.AppCS
{
   public class BeforeDelAppCSEventArgs : System.EventArgs
   {
      public bool Cancel
      {
         get; set;
      }

      public ConnectionString AppCS
      {
         get; set;
      }

      public DelAppCSException Exception
      {
         get; set;
      }
      public bool wasCanceled
      {
         get
         {
            return this.Cancel;
         }
      }

      public bool hasException
      {
         get
         {
            return this.Exception != null;
         }
      }

      public bool isOk
      {
         get
         {
            return !this.wasCanceled && !this.hasException;
         }
      }
   }
}
