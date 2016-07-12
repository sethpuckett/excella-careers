// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ExcellaCareers.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView JobTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LoadingLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (JobTableView != null) {
                JobTableView.Dispose ();
                JobTableView = null;
            }

            if (LoadingLabel != null) {
                LoadingLabel.Dispose ();
                LoadingLabel = null;
            }
        }
    }
}