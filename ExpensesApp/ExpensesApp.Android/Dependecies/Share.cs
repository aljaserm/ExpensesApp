using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using ExpensesApp.Droid.Dependecies;
using ExpensesApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.Droid.Dependecies
{
    class Share : IShare
    {
        public  Task Show(string title, string msg, string filePath)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var docUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.aljaserm.ExpensesApp.provider", new Java.IO.File(filePath));
            intent.PutExtra(Intent.ExtraStream, docUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, msg);
            var choserInteent = Intent.CreateChooser(intent, title);
            choserInteent.SetFlags(ActivityFlags.GrantReadUriPermission);
            Android.App.Application.Context.StartActivity(choserInteent);
            return Task.FromResult(true);
        }
    }
}