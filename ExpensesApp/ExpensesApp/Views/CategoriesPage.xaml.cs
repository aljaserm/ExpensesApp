using ExpensesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriesPage : ContentPage
	{
        CategoriesVM categories;
		public CategoriesPage ()
		{
			InitializeComponent ();
            categories = Resources["vm"] as CategoriesVM;
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            categories.GetExpensePerCategories();
        }
    }
}