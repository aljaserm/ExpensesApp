using ExpensesApp.Models;
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
	public partial class ExpenseDetailsPage : ContentPage
	{
        ExpenseDetailsVM expenseDetailsVM;
        public ExpenseDetailsPage ()
		{
			InitializeComponent ();
		}
        public ExpenseDetailsPage(Expense expense)
        {
            InitializeComponent();

            expenseDetailsVM = Resources["vm"] as ExpenseDetailsVM;
            expenseDetailsVM.Expense = expense;
        }
    }
}