﻿#pragma checksum "..\..\AdminPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "16B8993E91AF33DF1DFFC0617A621E5326A48D7594ECE366F549D9940423031F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AMONIC_Airlines_3;
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


namespace AMONIC_Airlines_3 {
    
    
    /// <summary>
    /// AdminPage
    /// </summary>
    public partial class AdminPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AddUserMenuBt;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem ExitMenuBt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_offices;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_Users;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_changeRole;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\AdminPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_EnDiLogin;
        
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
            System.Uri resourceLocater = new System.Uri("/AMONIC_Airlines_3;component/adminpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminPage.xaml"
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
            
            #line 9 "..\..\AdminPage.xaml"
            ((AMONIC_Airlines_3.AdminPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddUserMenuBt = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\AdminPage.xaml"
            this.AddUserMenuBt.Click += new System.Windows.RoutedEventHandler(this.AddUser_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExitMenuBt = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\AdminPage.xaml"
            this.ExitMenuBt.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cb_offices = ((System.Windows.Controls.ComboBox)(target));
            
            #line 25 "..\..\AdminPage.xaml"
            this.cb_offices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cb_offices_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dg_Users = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\AdminPage.xaml"
            this.dg_Users.GotFocus += new System.Windows.RoutedEventHandler(this.dg_Users_GotFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bt_changeRole = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\AdminPage.xaml"
            this.bt_changeRole.Click += new System.Windows.RoutedEventHandler(this.bt_changeRole_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.bt_EnDiLogin = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\AdminPage.xaml"
            this.bt_EnDiLogin.Click += new System.Windows.RoutedEventHandler(this.bt_EnDiLogin_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

