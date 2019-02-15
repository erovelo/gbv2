﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GuestBooker.Pages.Navigation
{
    public partial class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base()
        {
            InitializeComponent();
        }

        public CustomNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }

        public static readonly BindableProperty RightColorProperty = BindableProperty.Create(propertyName: nameof(RightColor),
              returnType: typeof(Color),
              declaringType: typeof(CustomNavigationPage),
              defaultValue: Color.Accent);

        public static readonly BindableProperty LeftColorProperty = BindableProperty.Create(propertyName: nameof(LeftColor),
               returnType: typeof(Color),
               declaringType: typeof(CustomNavigationPage),
               defaultValue: Color.Accent);

        public Color RightColor
        {
            get { return (Color)GetValue(RightColorProperty); }
            set { SetValue(RightColorProperty, value); }
        }

        public Color LeftColor
        {
            get { return (Color)GetValue(LeftColorProperty); }
            set { SetValue(LeftColorProperty, value); }
        }
    }
}
