﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On



<Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
 Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0"),  _
 Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
Partial Friend NotInheritable Class Settings
    Inherits Global.System.Configuration.ApplicationSettingsBase
    
    Private Shared defaultInstance As Settings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New Settings()),Settings)
    
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
    
    Public Shared ReadOnly Property [Default]() As Settings
        Get
            
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
            Return defaultInstance
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=172.16.10.218;Initial Catalog=AMSdb;User ID=HSDPI;Password=123456$hsd"& _ 
        "p")>  _
    Public ReadOnly Property AMSdbConnectionString() As String
        Get
            Return CType(Me("AMSdbConnectionString"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=172.16.4.111;Initial Catalog=AMSdb;Persist Security Info=True;User ID"& _ 
        "=HSDPI;Password=123456$hsdp")>  _
    Public ReadOnly Property AMSdbConnectionString1() As String
        Get
            Return CType(Me("AMSdbConnectionString1"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=HSDP_SYS_DEV;Initial Catalog=AMSdb;Integrated Security=True")>  _
    Public ReadOnly Property AMSdbConnectionString2() As String
        Get
            Return CType(Me("AMSdbConnectionString2"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=172.16.10.218;Initial Catalog=AMSdb;Persist Security Info=True;User I"& _ 
        "D=HSDPI;Password=123456$hsdp")>  _
    Public ReadOnly Property AMSdbConnectionString3() As String
        Get
            Return CType(Me("AMSdbConnectionString3"),String)
        End Get
    End Property
    
    <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
     Global.System.Configuration.DefaultSettingValueAttribute("Data Source=172.16.10.218;Initial Catalog=AMSdb;Persist Security Info=True;User I"& _ 
        "D=HSDPI")>  _
    Public ReadOnly Property AMSdbConnectionString4() As String
        Get
            Return CType(Me("AMSdbConnectionString4"),String)
        End Get
    End Property
End Class

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.AssetMonitoringAsset.Settings
            Get
                Return Global.AssetMonitoringAsset.Settings.Default
            End Get
        End Property
    End Module
End Namespace
