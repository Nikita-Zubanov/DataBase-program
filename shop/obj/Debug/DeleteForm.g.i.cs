﻿#pragma checksum "..\..\DeleteForm.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6B8B850C71FE1F5E1B1781281193E75FC3916CFA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using shop;


namespace shop {
    
    
    /// <summary>
    /// DeleteForm
    /// </summary>
    public partial class DeleteForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\DeleteForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridDelete;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\DeleteForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxColumns;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\DeleteForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDelete;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\DeleteForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonDelete;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\DeleteForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridOutputData;
        
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
            System.Uri resourceLocater = new System.Uri("/shop;component/deleteform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DeleteForm.xaml"
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
            
            #line 8 "..\..\DeleteForm.xaml"
            ((shop.DeleteForm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridDelete = ((System.Windows.Controls.Grid)(target));
            
            #line 9 "..\..\DeleteForm.xaml"
            this.GridDelete.KeyUp += new System.Windows.Input.KeyEventHandler(this.GridDelete_KeyUp);
            
            #line default
            #line hidden
            
            #line 9 "..\..\DeleteForm.xaml"
            this.GridDelete.PreviewMouseUp += new System.Windows.Input.MouseButtonEventHandler(this.GridDelete_PreviewMouseUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listBoxColumns = ((System.Windows.Controls.ListBox)(target));
            
            #line 10 "..\..\DeleteForm.xaml"
            this.listBoxColumns.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxColumns_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxDelete = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ButtonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\DeleteForm.xaml"
            this.ButtonDelete.Click += new System.Windows.RoutedEventHandler(this.ButtonSelect_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DataGridOutputData = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

