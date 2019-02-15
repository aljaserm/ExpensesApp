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
	public partial class NewExpensePage : ContentPage
	{
        NewExpenseVM newExpense;
        public NewExpensePage ()
		{
			InitializeComponent ();
            newExpense = Resources["vm"] as NewExpenseVM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            newExpense.getExpenseStatus();
            int count = 0;
            foreach(var es in newExpense.expenseStatuses)
            {
                var cell = new SwitchCell { Text = es.Name };
                Binding binding = new Binding();
                binding.Source = newExpense.expenseStatuses[count];
                binding.Path = "Status";
                binding.Mode = BindingMode.TwoWay;
                cell.SetBinding(SwitchCell.OnProperty, binding);
                var section = new TableSection("Statuses");
                section.Add(cell);
                tblExpense.Root.Add(section);
                count++;
            }
        }
    }
}