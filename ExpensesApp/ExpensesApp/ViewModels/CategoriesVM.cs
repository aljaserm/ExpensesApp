using ExpensesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using ExpensesApp.Interfaces;
using Xamarin.Forms;
using PCLStorage;
using System.IO;
using ExpensesApp.Resources;

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

        public Command ExportCommand { get; set; }
        public CategoriesVM()
        {
            ExportCommand = new Command(ShareReport);
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
            Categories.Add(AppResource.HousingCategory);
            Categories.Add(AppResource.DebtCategory);
            Categories.Add(AppResource.HealthCategory);
            Categories.Add(AppResource.FoodCategory);
            Categories.Add(AppResource.PersonalCategory);
            Categories.Add(AppResource.TravelCategory);
            Categories.Add(AppResource.OtherCategory);
            //Categories.Add("Housing");
            //Categories.Add("Debt");
            //Categories.Add("Health");
            //Categories.Add("Food");
            //Categories.Add("Personal");
            //Categories.Add("Travel");
            //Categories.Add("Other");
        }


        public async void ShareReport()
        {
            IFileSystem fileSystem = FileSystem.Current;
            IFolder rootFolder = fileSystem.LocalStorage;
            IFolder reportsFolder = await rootFolder.CreateFolderAsync("reports", CreationCollisionOption.OpenIfExists);

            var txtFile = await reportsFolder.CreateFileAsync("report.txt", CreationCollisionOption.ReplaceExisting);

            using (StreamWriter sw = new StreamWriter(txtFile.Path))
            {
                foreach (var ce in categoryExpenses)
                {
                    sw.WriteLine($"{ce.Category} - {ce.ExpensePercentage:p}");
                }
            }

            IShare shareDependency = DependencyService.Get<IShare>();
            await shareDependency.Show("Expense Report", "Here is your expenses report", txtFile.Path);
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensePercentage { get; set; }

        }

    }
}
