using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesApp.Interfaces;
using ExpensesApp.iOS.Dependecies;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace ExpensesApp.iOS.Dependecies
{
    class Share : IShare
    {
        public async Task Show(string title, string msg, string filePath)
        {
            var viewController = GetVisiableViewController();
            var Items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) };
            var activityController = new UIActivityViewController(Items,null);
            if (activityController.PopoverPresentationController != null)
            {
                activityController.PopoverPresentationController.SourceView = viewController.View;
            }
            await viewController.PresentViewControllerAsync(activityController,true);
        }

        private UIViewController GetVisiableViewController()
        {
            var rootVIewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            if (rootVIewController.PresentedViewController == null)
            {
                return rootVIewController;
            }

            if(rootVIewController.PresentedViewController is UINavigationController)
            {
                return ((UINavigationController)rootVIewController.PresentedViewController).TopViewController;
            }

            if(rootVIewController.PresentedViewController is UITabBarController)
            {
                return ((UITabBarController)rootVIewController.PresentedViewController).SelectedViewController;
            }

            return rootVIewController.PresentedViewController;
        }
    }
}