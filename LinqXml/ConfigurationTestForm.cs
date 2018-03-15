using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LinqXml
{
   public partial class ConfigurationTestForm : DevExpress.XtraEditors.XtraForm
   {
      public ConfigurationTestForm()
      {
         InitializeComponent( );
         this.configurationView1.BeforeSaveAsFileEvent += this.ConfigurationView1_BeforeSaveAsFileEvent;
         this.configurationView1.AfterSaveAsFileEvent += this.ConfigurationView1_AfterSaveAsFileEvent;
      }

      private void ConfigurationView1_AfterSaveAsFileEvent( object sender, Control.ConfigurationView.AfterSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.args.SavedFilename;
      }

      private void ConfigurationView1_BeforeSaveAsFileEvent( object sender, Control.ConfigurationView.BeforeSaveAsFileEventArgs ea )
      {
         this.labelStatusBarStaticItem.Caption = ea.SavedFilename;
      }

      private void barButtonItem3_ItemClick( object sender, DevExpress.XtraBars.ItemClickEventArgs e )
      {
         this.configurationView1.SaveAsFile( );
      }
   }
}