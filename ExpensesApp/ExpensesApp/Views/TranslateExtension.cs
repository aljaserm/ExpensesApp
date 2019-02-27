using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci = null;
        public string Text { get; set; }
        static readonly Lazy<ResourceManager> rm = new Lazy<ResourceManager>(() => new ResourceManager("ExpensesApp.Resources.AppResource", IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));
        public TranslateExtension()
        {
            ci = CultureInfo.CurrentCulture;
        }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return string.Empty;
            }
            else
            {
                var translation = rm.Value.GetString(Text, ci);
                if (translation == null)
                {
                    return string.Empty;
                }
                return translation;
            }

        }
    }
}
