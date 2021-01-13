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
    Public _admin_itemList As New admin_itemList

    'admin mode side panels
    'user window
    Public _admin_users_sidepane_addAccount As New admin_users_sidepane_addAccount
    Public _admin_users_sidepane_removeAccount As New admin_users_sidepane_removeAccount
    Public _admin_users_sidepane_editAccount As New admin_users_sidepane_editAccount
    'inventory window
    Public _admin_inventory_sidepane_itemlist_addItem As New itemlist_addItem

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
    Public _dataset_app As New Data.DataSet
    Public _dataset_acc As New Data.DataSet
    Public _dataset_ftw As New Data.DataSet
    Public _datatable_app As New Data.DataTable
    Public _datatable_acc As New Data.DataTable
    Public _datatable_ftw As New Data.DataTable

    Public Sub _itemlist_generate_Columns()
        _datatable_app.Reset()
        _datatable_acc.Reset()
        _datatable_ftw.Reset()

        ' apparel datatable
        _datatable_app.Columns.Add("ID")
        _datatable_app.Columns.Add("Gender")
        _datatable_app.Columns.Add("Category")
        _datatable_app.Columns.Add("Name")
        _datatable_app.Columns.Add("Price")
        _datatable_app.Columns.Add("Size")
        _datatable_app.Columns.Add("Stock")
        _datatable_app.Columns.Add("Image Source")

        ' accessory datatable
        _datatable_acc.Columns.Add("ID")
        _datatable_acc.Columns.Add("Gender")
        _datatable_acc.Columns.Add("Category")
        _datatable_acc.Columns.Add("Name")
        _datatable_acc.Columns.Add("Price")
        _datatable_acc.Columns.Add("Variant")
        _datatable_acc.Columns.Add("Stock")
        _datatable_acc.Columns.Add("Image Source")

        ' footwear datatable
        _datatable_ftw.Columns.Add("ID")
        _datatable_ftw.Columns.Add("Gender")
        _datatable_ftw.Columns.Add("Category")
        _datatable_ftw.Columns.Add("Name")
        _datatable_ftw.Columns.Add("Price")
        _datatable_ftw.Columns.Add("Size")
        _datatable_ftw.Columns.Add("Stock")
        _datatable_ftw.Columns.Add("Image Source")
    End Sub

    Public Sub _itemlist_getDatatable()
        _datatable_app.Rows.Clear()
        _datatable_acc.Rows.Clear()
        _datatable_ftw.Rows.Clear()
        ' append data to datatable
        ' apparel
        _itemlist_app.Load(_itemlist_app_path)
        Dim root_app As XmlNode = _itemlist_app.DocumentElement
        For Each item As XmlNode In root_app
            _datatable_app.Rows.Add(
                item.Attributes(2).Value,
                item.Attributes(1).Value,
                item.Attributes(0).Value,
                item("name").InnerXml,
                item("price").InnerXml,
                item("size").InnerXml,
                item("stock").InnerXml,
                item("image").InnerXml)
        Next

        ' accessory
        _itemlist_acc.Load(_itemlist_acc_path)
        Dim root_acc As XmlNode = _itemlist_acc.DocumentElement
        For Each item As XmlNode In root_acc
            _datatable_acc.Rows.Add(
                item.Attributes(2).Value,
                item.Attributes(1).Value,
                item.Attributes(0).Value,
                item("name").InnerXml,
                item("price").InnerXml,
                item("desc").InnerXml,
                item("stock").InnerXml,
                item("image").InnerXml)
        Next

        ' footwear
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim root_ftw As XmlNode = _itemlist_ftw.DocumentElement
        For Each item As XmlNode In root_ftw
            _datatable_ftw.Rows.Add(
                item.Attributes(2).Value,
                item.Attributes(1).Value,
                item.Attributes(0).Value,
                item("name").InnerXml,
                item("price").InnerXml,
                item("size").InnerXml,
                item("stock").InnerXml,
                item("image").InnerXml)
        Next
    End Sub


End Module
