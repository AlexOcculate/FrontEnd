//using DevExpress.Skins;
//using DevExpress.UserSkins;
using System;
//using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DataPhilosophiae.MainForm
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         DevExpress.UserSkins.BonusSkins.Register();
         DevExpress.Skins.SkinManager.EnableFormSkins();
         DevExpress.Skins.SkinManager.EnableMdiFormSkins( );

         string skinStyle = "The Bezier"; // "Metropolis Dark";
         //string skinStyle = "Visual Studio 2013 Blue"; // "Metropolis Dark";
         //if( true )
         //   skinStyle = "Office 2016 Colorful";
         //else
         //   skinStyle = "Visual Studio 2013 Blue";
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinStyle);
         //
         System.Drawing.Bitmap splashScreenImage = new System.Drawing.Bitmap(
            Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("DPMainForm.Resources.splashScreen.png")
            );
         DevExpress.XtraSplashScreen.SplashScreenManager.ShowImage(splashScreenImage, true, false);

         Application.Run(new Form1());
      }
   }
}
