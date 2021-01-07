Imports System.Xml

Module _globals

    ' views
    Public _view_hero As New view_hero
    Public _view_cabinetMode As New view_cabinetMode
    Public _view_yourCart As New view_yourCart

    'cabinet mode view
    Public _cm_men_app As New cm_men_app
    Public _cm_men_acc As New cm_men_acc
    Public _cm_men_ftw As New cm_men_ftw
    Public _cm_wom_app As New cm_wom_app
    Public _cm_wom_acc As New cm_wom_acc
    Public _cm_wom_ftw As New cm_wom_ftw


    'data
    Public _itemlist_app As New XmlDocument
    Public _itemlist_app_path As String = "Data/itemlist_apparel.xml"
    Public _itemlist_acc As New XmlDocument
    Public _itemlist_acc_path As String = "Data/itemlist_accessory.xml"
    Public _itemlist_ftw As New XmlDocument
    Public _itemlist_ftw_path As String = "Data/itemlist_footwear.xml"

End Module
