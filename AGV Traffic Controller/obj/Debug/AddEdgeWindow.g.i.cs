﻿#pragma checksum "..\..\AddEdgeWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "881E9B486054B11424A748ECBED0C688"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AGV_Traffic_Controller;
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


namespace AGV_Traffic_Controller {
    
    
    /// <summary>
    /// AddEdgeWindow
    /// </summary>
    public partial class AddEdgeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxDirected;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxPredecessor;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxSuccessor;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboxWeight;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPredecessor;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSuccesso;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDirected;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AddEdgeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblWeight;
        
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
            System.Uri resourceLocater = new System.Uri("/AGV Traffic Controller;component/addedgewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddEdgeWindow.xaml"
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
            this.cboxDirected = ((System.Windows.Controls.ComboBox)(target));
            
            #line 10 "..\..\AddEdgeWindow.xaml"
            this.cboxDirected.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboxTipo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cboxPredecessor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\AddEdgeWindow.xaml"
            this.cboxPredecessor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboxInicial_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cboxSuccessor = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\AddEdgeWindow.xaml"
            this.cboxSuccessor.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboxFinal_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cboxWeight = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\AddEdgeWindow.xaml"
            this.cboxWeight.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cboxPeso_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\AddEdgeWindow.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\AddEdgeWindow.xaml"
            this.btnCancel.Click += new System.Windows.RoutedEventHandler(this.btnCancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblPredecessor = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblSuccesso = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblDirected = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.lblWeight = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

