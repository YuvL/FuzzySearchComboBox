using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace DemoApplication
{
    public struct ApplicationOptions
    {
        public string Style
        { get; set; }
    }
    public class Options
    {
        public static ApplicationOptions AppOptions;

        private const string DefaultStyle = "DefaultStyle.xaml";
        [Option('s', "Style", HelpText = "Style resource", DefaultValue = DefaultStyle, Required = false)]
        public string Style
        { get; set; }

        /// <summary>
        /// Инициализация параметров приложения, задаваемых в качестве параметров командной строки
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool InitializeOptions(string[] args)
        {
            var options = new Options();
            try
            {
                if (!CommandLine.Parser.Default.ParseArguments(args, options))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            AppOptions = new ApplicationOptions()
            {
                Style = options.Style,
            };
            return true;
        }
    }
}
