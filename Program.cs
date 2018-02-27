using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FrontEnd
{
   internal static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      private static void Main()
      {
         DevExpress.UserSkins.BonusSkins.Register( );
         DevExpress.Skins.SkinManager.EnableFormSkins( );
         string skinStyle = "Visual Studio 2013 Blue"; // "Metropolis Dark";
         //if( true )
         //   skinStyle = "Office 2016 Colorful";
         //else
         //   skinStyle = "Visual Studio 2013 Blue";
         DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle( skinStyle );
         //
         Bitmap splashScreenImage = new Bitmap( CurrentAssembly.GetManifestResourceStream( "FrontEnd.Resources.splashScreen.png" ) );
         DevExpress.XtraSplashScreen.SplashScreenManager.ShowImage( splashScreenImage, true, false );
         //
         {
            System.Configuration.ExeConfigurationFileMap configMap = new System.Configuration.ExeConfigurationFileMap( );
            configMap.ExeConfigFilename = @"SampleProject.config";
            System.Configuration.Configuration config = System.Configuration.ConfigurationManager
               .OpenMappedExeConfiguration( configMap, System.Configuration.ConfigurationUserLevel.None );
            string x = nameof( ProjectSetting.ProjectSection );
            ProjectSetting.ProjectSection ps = config.GetSection( nameof( ProjectSetting.ProjectSection ) ) as ProjectSetting.ProjectSection;

            //DataPhilosophiaeSection dps = System.Configuration.ConfigurationManager.
            //   .GetSection( nameof( DataPhilosophiaeSection ) ) as DataPhilosophiaeSection;
         }
         Application.EnableVisualStyles( );
         Application.SetCompatibleTextRenderingDefault( false );
         Application.Run( new Form1( ) );
      }

      private static Assembly currentAssemblyCore;
      private static Assembly CurrentAssembly
      {
         get
         {
            if( currentAssemblyCore == null )
            {
               currentAssemblyCore = Assembly.GetExecutingAssembly( );
            }

            return currentAssemblyCore;
         }
      }
   }
}
