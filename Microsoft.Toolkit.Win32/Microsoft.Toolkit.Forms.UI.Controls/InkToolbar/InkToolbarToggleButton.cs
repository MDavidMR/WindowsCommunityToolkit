﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using Microsoft.Toolkit.Forms.UI.XamlHost;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace Microsoft.Toolkit.Forms.UI.Controls
{
    /// <summary>
    /// WinForms-enabled wrapper for <see cref="Windows.UI.Xaml.Controls.InkToolbarToggleButton"/>
    /// </summary>
    [Designer(typeof(InkToolbarToolButtonDesigner))]
    public class InkToolbarToggleButton : WindowsXamlHostBase
    {
        internal Windows.UI.Xaml.Controls.InkToolbarToggleButton UwpControl { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InkToolbarToggleButton"/> class, a
        /// WinForms-enabled wrapper for <see cref="Windows.UI.Xaml.Controls.InkToolbarToggleButton"/>
        /// </summary>
        public InkToolbarToggleButton()
            : this(typeof(Windows.UI.Xaml.Controls.InkToolbarToggleButton).FullName)
        {
        }

        protected InkToolbarToggleButton(string name)
            : base(name)
        {
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UwpControl = GetUwpInternalObject() as Windows.UI.Xaml.Controls.InkToolbarToggleButton;
            UwpControl.Checked += UwpControl_Checked;
            UwpControl.Indeterminate += UwpControl_Indeterminate;
            UwpControl.Unchecked += UwpControl_Unchecked;
        }

        /// <summary>
        /// Raised when the underlying Uwp control's Checked event is fired. <see cref="Windows.UI.Xaml.Controls.Primitives.ToggleButton.Checked"/>
        /// </summary>
        public event EventHandler Checked;

        /// <summary>
        /// Raised when the underlying Uwp control's Indeterminate event is fired. <see cref="Windows.UI.Xaml.Controls.Primitives.ToggleButton.Indeterminate"/>
        /// </summary>
        public event EventHandler Indeterminate;

        /// <summary>
        /// Raised when the underlying Uwp control's Unchecked event is fired. <see cref="Windows.UI.Xaml.Controls.Primitives.ToggleButton.Unchecked"/>
        /// </summary>
        public event EventHandler Unchecked;

        private void UwpControl_Unchecked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Unchecked?.Invoke(this, EventArgs.Empty);
        }

        private void UwpControl_Indeterminate(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Indeterminate?.Invoke(this, EventArgs.Empty);
        }

        private void UwpControl_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Checked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the underlying Uwp control's IsThreeState is set. <see cref="Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsThreeState"/>
        /// </summary>
        public bool IsThreeState { get => UwpControl.IsThreeState; set => UwpControl.IsThreeState = value; }

        /// <summary>
        /// Gets or sets a value indicating whether the underlying Uwp control's IsChecked is set. <see cref="Windows.UI.Xaml.Controls.Primitives.ToggleButton.IsChecked"/>
        /// </summary>
        public bool? IsChecked { get => UwpControl.IsChecked; set => UwpControl.IsChecked = value; }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                UwpControl.Checked -= UwpControl_Checked;
                UwpControl.Unchecked -= UwpControl_Unchecked;
                UwpControl.Indeterminate -= UwpControl_Indeterminate;
            }
        }

        /// <summary>
        /// Gets the underlying Uwp control's ToggleKind value. <see cref="Windows.UI.Xaml.Controls.InkToolbarToggleButton.ToggleKind"/>
        /// </summary>
        public InkToolbarToggle ToggleKind { get => (InkToolbarToggle)UwpControl.ToggleKind; }
    }
}