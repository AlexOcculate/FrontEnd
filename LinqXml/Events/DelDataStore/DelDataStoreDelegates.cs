﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXml.Control.Configuration.DelDataStore
{
   public delegate void AllowedDelDataStoreEventHandler( object sender );
   public delegate void NotAllowedDelDataStoreEventHandler( object sender );
   //
   public delegate void BeforeDelDataStoreEventHandler( object sender, BeforeDelDataStoreEventArgs ea );
   public delegate void AfterDelDataStoreEventHandler( object sender, AfterDelDataStoreEventArgs ea );
   //
}
