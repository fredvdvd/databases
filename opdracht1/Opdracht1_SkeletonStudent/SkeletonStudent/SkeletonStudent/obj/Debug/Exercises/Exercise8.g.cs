﻿#pragma checksum "..\..\..\Exercises\Exercise8.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A7A0C6635106C683E9E4FE6A13DA58E7BCBDE4F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SkeletonStudent.Exercises;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SkeletonStudent.Exercises {
    
    
    /// <summary>
    /// Exercise8
    /// </summary>
    public partial class Exercise8 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Exercises\Exercise8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Exe8Datagrid;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Exercises\Exercise8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox JobTitle;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Exercises\Exercise8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxSalary;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Exercises\Exercise8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MinSalary;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Exercises\Exercise8.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateSalary;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SkeletonStudent;component/exercises/exercise8.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Exercises\Exercise8.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Exe8Datagrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\..\Exercises\Exercise8.xaml"
            this.Exe8Datagrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Exe8Datagrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.JobTitle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.MaxSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MinSalary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.UpdateSalary = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Exercises\Exercise8.xaml"
            this.UpdateSalary.Click += new System.Windows.RoutedEventHandler(this.UpdateSalary_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
