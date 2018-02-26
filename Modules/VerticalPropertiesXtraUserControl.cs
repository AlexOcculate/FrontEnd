using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FrontEnd.Modules
{
   public partial class VerticalPropertiesXtraUserControl : DevExpress.XtraEditors.XtraUserControl
   {
      public VerticalPropertiesXtraUserControl()
      {
         InitializeComponent( );
         this.vGridControl.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
      }

      internal void SetXXX( DataRow row )
      {
         this.vGridControl.DataSource = row.Table;
      }
   }
}
