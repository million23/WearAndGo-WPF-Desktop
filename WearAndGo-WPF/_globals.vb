Imports System.Xml

Module _globals

    ' views
    Public _view_hero As New view_hero
    Public _view_cabinetMode As New view_cabinetMode
    Public _view_yourCart As New view_yourCart
    Public _view_adminMode As New view_adminMode

    'cabinet mode view
    Public _cm_men_app As New cm_men_app
    Public _cm_men_acc As New cm_men_acc
    Public _cm_men_ftw As New cm_men_ftw
    Public _cm_wom_app As New cm_wom_app
    Public _cm_wom_acc As New cm_wom_acc
    Public _cm_wom_ftw As New cm_wom_ftw

    'admin mode views
    Public _admin_home As New admin_home
    Public _admin_users As New admin_users

    'admin mode side panels
    Public _admin_users_sidepane_addAccount As New admin_users_sidepane_addAccount
    Public _admin_users_sidepane_removeAccount As New admin_users_sidepane_removeAccount
    Public _admin_users_sidepane_editAccount As New admin_users_sidepane_editAccount

    'data
    Public _itemlist_app As New XmlDocument
    Public _itemlist_app_path As String = "Data/itemlist_apparel.xml"
    Public _itemlist_acc As New XmlDocument
    Public _itemlist_acc_path As String = "Data/itemlist_accessory.xml"
    Public _itemlist_ftw As New XmlDocument
    Public _itemlist_ftw_path As String = "Data/itemlist_footwear.xml"
    Public _datalist_cart As New XmlDocument
    Public _datalist_cart_path As String = "Data/datalist_cart.xml"
    Public _datalist_history As New XmlDocument
    Public _datalist_history_path As String = "Data/datalist_salehistory.xml"
    Public _datalist_users As New XmlDocument
    Public _datalist_users_path As String = "Data/datalist_users.xml"

    'datasets
    Public _userList As New Data.DataSet



End Module
