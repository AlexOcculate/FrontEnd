using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace LinqXml
{
   public class LoginUserControl : XtraUserControl
   {
      public LoginUserControl()
      {
         LayoutControl lc = new LayoutControl( );
         lc.Dock = DockStyle.Fill;
         TextEdit teLogin = new TextEdit( );
         TextEdit tePassword = new TextEdit( );
         CheckEdit ceKeep = new CheckEdit( ) { Text = "Keep me signed in" };
         lc.AddItem( String.Empty, teLogin ).TextVisible = false;
         lc.AddItem( String.Empty, tePassword ).TextVisible = false;
         lc.AddItem( String.Empty, ceKeep );
         this.Controls.Add( lc );
         this.Dock = DockStyle.Fill;
      }

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // LoginUserControl
         // 
         this.Name = "LoginUserControl";
         this.Size = new System.Drawing.Size(299, 141);
         this.ResumeLayout(false);

      }
   }
}
