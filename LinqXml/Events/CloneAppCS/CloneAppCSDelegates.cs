﻿using LinqXml.Control;
using System;
using System.Linq;

namespace LinqXml.Events.CloneAppCS
{
   public delegate void AllowedToCloneAppCSEventHandler(object sender);
   public delegate void NotAllowedToCloneAppCSEventHandler(object sender);
   //
   public delegate void BeforeCloneAppCSEventHandler(object sender, BeforeCloneAppCSEventArgs ea);
   public delegate void AfterCloneAppCSEventHandler(object sender, AfterCloneAppCSEventArgs ea);
}
