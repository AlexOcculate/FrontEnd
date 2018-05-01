using ActiveQueryBuilder.Core;
using DPControls.Controls.MetadataPuller;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataPhilosophiae.MainForm
{
   public partial class Form1 : DevExpress.XtraEditors.XtraForm
   {
      public Form1()
      {
         this.InitializeComponent();
         this.PostInitializeComponent();
      }

      private void PostInitializeComponent()
      {
         this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
         this.ActiveGlowColor = Color.Lime;
         this.Icon = DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx(
            "DPMainForm.Resources.AppIcon.ico",
            typeof(Form1).Assembly
            );
   //      bool testAqbSqlContext4SQLiteConnection = MetadataPullerXtraUserControl.TestAqbSqlContext4SQLiteConnection(string.Empty);
   //      SQLContext scOffilne = MetadataPullerXtraUserControl.CreateAqbSqlContext4SQLiteOffline(string.Empty);
    //     SQLContext scOnline = MetadataPullerXtraUserControl.CreateAqbSqlContext4SQLiteOnline(string.Empty);
    //     System.Data.DataTable dt = MetadataPullerXtraUserControl.CreateMetadataItemTable();
    //     MetadataPullerXtraUserControl.DrillDownAqbSqlContext(scOffilne, dt, "XPTO");
      }

      #region --- Splash Screen ---
      private void Form1_Load(object sender, EventArgs e)
      {
         BeginInvoke(new MethodInvoker(this.InitDemo));
      }

      private void InitDemo()
      {
         DevExpress.XtraSplashScreen.SplashScreenManager.HideImage(1000, this);
      }
      #endregion

      private void sysCSXtraUserControl1_FocusedSysCSChangedEvent(object sender, GridDataPhilosophiae.Events.SysCS.FocusedSysCSChangedEventArgs ea)
      {
         this.sysCSPropXtraUserControl.SetSelectedObject(ea.FocusedSysCS);
      }
   }
}
