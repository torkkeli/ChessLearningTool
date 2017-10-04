using ChessLearningTool.Presentation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ChessLearningTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            foreach (Type type in
                Assembly.GetAssembly(typeof(App)).GetTypes()
                .Where(t => t.IsClass && t.IsSealed && t.IsSubclassOf(typeof(TemplateManager))))
            {
                TemplateManager tm = (TemplateManager)Activator.CreateInstance(type);

                foreach (DataTemplate dt in tm.Templates)
                    Resources.Add(dt.DataTemplateKey, dt);
            }
        }
    }
}
