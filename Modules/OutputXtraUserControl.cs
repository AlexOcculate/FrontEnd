﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FrontEnd
{
   public partial class OutputXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public OutputXtraUserControl()
      {
         InitializeComponent( );
         this.comboBox.SelectedIndex = 0;
         this.textBox.ContextMenu = new ContextMenu( );
      }
      private void comboBox_SelectedIndexChanged( object sender, System.EventArgs e )
      {
         if( this.comboBox.SelectedIndex == 0 )
         {
            this.textBox.Text = " ------ Build started: Project: VisualStudioInspiredUIDemo, Configuration: Debug .NET ------\r\n\r\n Preparing resources...\r\n Updating references...\r\n Performing main compilation...\r\n\r\n Build complete -- 0 errors, 0 warnings\r\n Building satellite assemblies...\r\n\r\n\r\n ---------------------- Done ----------------------\r\n\r\n     Build: 1 succeeded, 0 failed, 0 skipped";
         }
         else
         {
            this.textBox.Text = " 'DefaultDomain': Loaded 'd:\\winnt\\microsoft.net\\framework\\v1.0.3705\\mscorlib.dll', No symbols loaded.\r\n 'VisualStudioInspiredUIDemo': Loaded 'C:\\BarDemos\\CS\\DockingDemo\\bin\\Debug\\DockingDemo.exe', Symbols loaded.";
         }
      }
      private void textBox_KeyDown( object sender, System.Windows.Forms.KeyEventArgs e )
      {
         e.Handled = true;
      }
   }
}
