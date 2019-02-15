using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {

        public ObservableCollection<string> Categories
        {
            get;
            set;
        }
        public ObservableCollection<CategoryExpenses> categoryExpenses { get; set; }

        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            categoryExpenses = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensePerCategories();
            
        }

        public void GetExpensePerCategories()
        {
            categoryExpenses.Clear();
            float TotalAmount = Expense.TotalExpenses();
            foreach(var c in Categories)
            {
                var expense = Expense.GetExpenses(c);
                float expensesAmountinCategory = expense.Sum(e=>e.Ammount);
                CategoryExpenses ce = new CategoryExpenses()
                {
                    Category=c,
                    ExpensePercentage=expensesAmountinCategory/TotalAmount
                };
                categoryExpenses.Add(ce);
            }
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensePercentage { get; set; }

        }

    }
}
