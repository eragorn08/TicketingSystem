﻿#pragma checksum "..\..\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8AF5DB75C3B4BEC4BB404B6A00E1A7D1CADA542E2CC7DB711972F51F35EAA67C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Ticketing_System;


namespace Ticketing_System {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rUName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rPass;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox rCPass;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _return;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clear;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reg;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nname;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nuname;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label npass;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ncpass;
        
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
            System.Uri resourceLocater = new System.Uri("/Ticketing System;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.rName = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\Window1.xaml"
            this.rName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rUName = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\Window1.xaml"
            this.rUName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rUName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rPass = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\Window1.xaml"
            this.rPass.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rPass_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rCPass = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\Window1.xaml"
            this.rCPass.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.rCPass_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this._return = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Window1.xaml"
            this._return.Click += new System.Windows.RoutedEventHandler(this._return_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.clear = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Window1.xaml"
            this.clear.Click += new System.Windows.RoutedEventHandler(this.clear_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.reg = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Window1.xaml"
            this.reg.Click += new System.Windows.RoutedEventHandler(this.reg_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.nname = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.nuname = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.npass = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ncpass = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

