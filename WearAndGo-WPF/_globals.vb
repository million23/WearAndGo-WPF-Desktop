Imports System.Xml

Module _globals

    ' views
    Public _view_loadingScreen As New view_loadingScreen
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
    Public _admin_sales As New admin_sales

    'admin mode side panels
    'user window
    Public _admin_users_sidepane_addAccount As New admin_users_sidepane_addAccount
    Public _admin_users_sidepane_removeAccount As New admin_users_sidepane_removeAccount
    Public _admin_users_sidepane_editAccount As New admin_users_sidepane_editAccount
    'inventory window
    Public _admin_inventory_sidepane_itemlist_addItem As New itemlist_addItem
    Public _admin_inventory_sidepane_itemlist_removeItem As New itemlist_removeItem
    Public _admin_inventory_sidepane_itemlist_updateItem As New itemlist_updateItem

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
    Public _dataset_saleHistory As New Data.DataSet
    Public _dataset_app As New Data.DataSet
    Public _dataset_acc As New Data.DataSet
    Public _dataset_ftw As New Data.DataSet
    Public _datatable_saleHistory As New Data.DataTable
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

    Public Sub cabinetMode_loadItemList()
        'preloads all assets for the cabinet mode
        'apparel
        _cm_men_app.wrapContainer.Children.Clear()
        _cm_wom_app.wrapContainer.Children.Clear()
        _itemlist_app.Load(_itemlist_app_path)
        Dim app_root As XmlNode = _itemlist_app.DocumentElement
        For Each item As XmlNode In app_root
            'men
            If item.Attributes(1).Value = "men" AndAlso CInt(item("stock").InnerXml) > 0 Then
                Dim card As New card_app

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_men_app.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_app

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_wom_app.wrapContainer.Children.Add(card)
            End If
        Next

        'accessory
        _cm_men_acc.wrapContainer.Children.Clear()
        _cm_wom_acc.wrapContainer.Children.Clear()
        _itemlist_acc.Load(_itemlist_acc_path)
        Dim Macc_root As XmlNode = _itemlist_acc.DocumentElement
        For Each item As XmlNode In Macc_root
            'men
            If item.Attributes(1).Value = "men" Then
                Dim card As New card_acc

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemVariant.Text = item("desc").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_men_acc.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_acc

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemVariant.Text = item("desc").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_wom_acc.wrapContainer.Children.Add(card)
            End If
        Next

        'footwear
        _cm_men_ftw.wrapContainer.Children.Clear()
        _cm_wom_ftw.wrapContainer.Children.Clear()
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim Mftw_root As XmlNode = _itemlist_ftw.DocumentElement

        For Each item As XmlNode In Mftw_root
            'men
            If item.Attributes(1).Value = "men" Then
                Dim card As New card_ftw

                card.mainCard.ToolTip = item("name").InnerText
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_men_ftw.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_ftw

                card.mainCard.ToolTip = item("name").InnerText
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                Try
                    card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))
                Catch ex As Exception
                    card.itemImage.Source = Nothing
                End Try

                _cm_wom_ftw.wrapContainer.Children.Add(card)
            End If
        Next
    End Sub

    Public Sub _salesHistory_getData()
        _datatable_saleHistory.Reset()
        _datatable_saleHistory.Rows.Clear()

        _datatable_saleHistory.Columns.Add("Count").AutoIncrement = True
        _datatable_saleHistory.Columns.Add("Date").ReadOnly = True
        _datatable_saleHistory.Columns.Add("ID").ReadOnly = True
        _datatable_saleHistory.Columns.Add("Total Sale").ReadOnly = True
        _datatable_saleHistory.Columns.Add("Item Count").ReadOnly = True

        _datatable_saleHistory.Columns(0).AutoIncrementSeed = 1

        _datalist_history.Load(_datalist_history_path)
        Dim root As XmlNode = _datalist_history.DocumentElement
        If root.HasChildNodes Then
            For Each sale As XmlNode In root
                _datatable_saleHistory.Rows.Add(Nothing,
                                                sale.Attributes(0).Value,
                                                sale.Attributes(1).Value,
                                                sale.Attributes(2).Value,
                                                sale.ChildNodes.Count)
            Next

        End If
        _admin_sales.mainGrid.ItemsSource = _datatable_saleHistory.DefaultView
    End Sub
End Module
