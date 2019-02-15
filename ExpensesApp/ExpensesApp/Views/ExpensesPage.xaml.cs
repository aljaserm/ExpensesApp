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
	public partial class ExpensesPage : ContentPage
	{
        ExpenseVM expense;
		public ExpensesPage ()
		{
			InitializeComponent ();
            expense = Resources["vm"] as ExpenseVM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            expense.GetExpenses();
        }
    }
}