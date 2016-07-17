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
    [Register ("JobTableViewCell")]
    partial class JobTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton jobButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel jobLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (jobButton != null) {
                jobButton.Dispose ();
                jobButton = null;
            }

            if (jobLabel != null) {
                jobLabel.Dispose ();
                jobLabel = null;
            }
        }
    }
}