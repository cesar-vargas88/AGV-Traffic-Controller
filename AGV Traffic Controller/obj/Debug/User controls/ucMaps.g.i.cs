﻿#pragma checksum "..\..\..\User controls\ucMaps.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D4E60FCACFF5C981A6215C179C5533F6"
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
    /// ucMaps
    /// </summary>
    public partial class ucMaps : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMapName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateMaps;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadMaps;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveMaps;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCloseMaps;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNodes;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lboxNodes;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddNodes;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteNodes;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEdges;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lboxEdges;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddEdges;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteEdges;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAdjacencyLists;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lboxAdjacencyLists;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\User controls\ucMaps.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas MyCanvas;
        
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
            System.Uri resourceLocater = new System.Uri("/AGV Traffic Controller;component/user%20controls/ucmaps.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User controls\ucMaps.xaml"
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
            this.lblMapName = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btnCreateMaps = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\User controls\ucMaps.xaml"
            this.btnCreateMaps.Click += new System.Windows.RoutedEventHandler(this.btnCreateMaps_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnLoadMaps = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\User controls\ucMaps.xaml"
            this.btnLoadMaps.Click += new System.Windows.RoutedEventHandler(this.btnLoadMaps_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnSaveMaps = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\User controls\ucMaps.xaml"
            this.btnSaveMaps.Click += new System.Windows.RoutedEventHandler(this.btnSaveMaps_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCloseMaps = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\User controls\ucMaps.xaml"
            this.btnCloseMaps.Click += new System.Windows.RoutedEventHandler(this.btnCloseMaps_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblNodes = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lboxNodes = ((System.Windows.Controls.ListBox)(target));
            
            #line 21 "..\..\..\User controls\ucMaps.xaml"
            this.lboxNodes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lboxNodes_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAddNodes = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\User controls\ucMaps.xaml"
            this.btnAddNodes.Click += new System.Windows.RoutedEventHandler(this.btnAddNodes_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnDeleteNodes = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\User controls\ucMaps.xaml"
            this.btnDeleteNodes.Click += new System.Windows.RoutedEventHandler(this.btnDeleteNodes_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lblEdges = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lboxEdges = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\..\User controls\ucMaps.xaml"
            this.lboxEdges.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lboxEdges_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnAddEdges = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\User controls\ucMaps.xaml"
            this.btnAddEdges.Click += new System.Windows.RoutedEventHandler(this.btnAddEdges_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnDeleteEdges = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\User controls\ucMaps.xaml"
            this.btnDeleteEdges.Click += new System.Windows.RoutedEventHandler(this.btnDeleteEdges_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lblAdjacencyLists = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            this.lboxAdjacencyLists = ((System.Windows.Controls.ListBox)(target));
            
            #line 31 "..\..\..\User controls\ucMaps.xaml"
            this.lboxAdjacencyLists.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lboxEdges_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 16:
            this.MyCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 35 "..\..\..\User controls\ucMaps.xaml"
            this.MyCanvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MyCanvas_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

