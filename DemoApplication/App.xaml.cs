using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            PresettingApplication(e.Args);
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Предварительная настройка приложения 
        /// </summary>
        private void PresettingApplication(string[] args)
        {
            //1 Parse Command Line
            if (!Options.InitializeOptions(args))
            {
                MessageBox.Show("Error command line arguments.", "Error", MessageBoxButton.OK);
                System.Environment.Exit(1);
            }

            //2а Проверка наличия ресурса стиля 
            var resource = Application.Current.Resources[Options.AppOptions.Style] as ResourceDictionary;
            if (resource == null)
            {
                MessageBox.Show("Missing resource file.", "Error", MessageBoxButton.OK);
                System.Environment.Exit(1);
            }
            //2б Добавление ресурса стиля 
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }
    }
}
