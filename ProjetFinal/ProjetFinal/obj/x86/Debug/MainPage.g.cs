﻿#pragma checksum "C:\Users\thoma\Desktop\School\ProjetFinal\ProjetFinal\ProjetFinal\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A62E5682C50CAFBEBFA7FB7E120FC180"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetFinal
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 34
                {
                    this.mainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 3: // MainPage.xaml line 19
                {
                    this.btAdd = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btAdd).Click += this.btAdd_Click;
                }
                break;
            case 4: // MainPage.xaml line 20
                {
                    this.btRemove = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btRemove).Click += this.btRemove_Click;
                }
                break;
            case 5: // MainPage.xaml line 21
                {
                    this.btSave = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btSave).Click += this.btSave_Click;
                }
                break;
            case 6: // MainPage.xaml line 24
                {
                    this.btBack = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btBack).Click += this.btBack_Click;
                }
                break;
            case 7: // MainPage.xaml line 28
                {
                    this.btClient = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btClient).Click += this.btClient_Click;
                }
                break;
            case 8: // MainPage.xaml line 29
                {
                    this.btMateriel = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btMateriel).Click += this.btMateriel_Click;
                }
                break;
            case 9: // MainPage.xaml line 30
                {
                    this.btPret = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btPret).Click += this.btPret_Click;
                }
                break;
            case 10: // MainPage.xaml line 31
                {
                    this.btUtilisateur = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.btUtilisateur).Click += this.btUtilisateur_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

