using System;
using System.Windows;
using System.Windows.Markup;

using ChessLearningTool.Presentation.ViewModels;
using System.Collections.Generic;

namespace ChessLearningTool.Presentation
{
    public abstract class TemplateManager
    {
        public abstract IEnumerable<DataTemplate> Templates { get; }
        protected DataTemplate AddDataTemplate<TViewModel, TView>()
            where TViewModel : ViewModel
            where TView : FrameworkElement
        {
            string xaml = "<DataTemplate DataType=\"{{x:Type viewmodel:{0}}}\"><view:{1} /></DataTemplate>";

            return AddDataTemplate<TViewModel, TView>(xaml);
        }
        protected DataTemplate AddOverlayDataTemplate<TViewModel, TView>()
            where TViewModel : ViewModel
            where TView : FrameworkElement
        {
            // TODO overlay template xaml (opacity = 0.5)
            string xaml = string.Empty;

            return AddDataTemplate<TViewModel, TView>(xaml);
        }
        private DataTemplate AddDataTemplate<TViewModel, TView>(string xamlTemplate)
            where TViewModel : ViewModel
            where TView : FrameworkElement
        {
            Type vmType = typeof(TViewModel);
            Type vType = typeof(TView);
            var xaml = string.Format(xamlTemplate, vmType.Name, vType.Name, vmType.Namespace, vType.Namespace);

            var context = new ParserContext();

            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", vmType.Namespace, vmType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", vType.Namespace, vType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;
        }
    }
}
