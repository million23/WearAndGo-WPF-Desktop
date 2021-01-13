Imports System.Xml

Public Class itemlist_addItem
    Private Sub addItemToDatabase(sender As Object, e As RoutedEventArgs)
        If in_itemName.Text = "" Or
            in_itemCategory.Text = "" Or
            in_itemGender.Text = "" Or
            in_itemID.Text = "" Or
            in_itemPrice.Text = "" Or
            in_itemVariant.Text = "" Then

            Dim dialog As New ModernWpf.Controls.ContentDialog
            dialog.Title = "Missing Input"
            dialog.Content = "Please input all the fields"
            dialog.CloseButtonText = "Ok"
            dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
            dialog.ShowAsync()

            in_itemName.Text = ""
            in_itemCategory.Text = ""
            in_itemGender.Text = ""
            in_itemID.Text = ""
            in_itemPrice.Text = ""
            in_itemVariant.Text = ""
        Else
            InputData()
        End If

    End Sub

    Private Sub InputData()
        Dim dialog As New ModernWpf.Controls.ContentDialog

        Select Case in_itemCategory.Text
            Case "Apparel"
                label_itemvariant.Content = "Item Size"
                Try
                    _itemlist_app.Load(_itemlist_app_path)
                    Dim root As XmlNode = _itemlist_app.DocumentElement

                    Dim _itemname As String = in_itemName.Text
                    Dim _itemid As String = String.Empty
                    Select Case in_itemID.Text.Length
                        Case 1
                            _itemid = "00" + in_itemID.Text
                        Case 2
                            _itemid = "0" + in_itemID.Text
                    End Select
                    Select Case in_itemGender.Text
                        Case "Men"
                            _itemid = "MP1" + _itemid
                        Case "Women"
                            _itemid = "WP1" + _itemid
                    End Select
                    Dim _itemprice As String = in_itemPrice.Text
                    Dim _itemvariant As String = in_itemVariant.Text
                    Dim _itemstock As String = in_stockCount.Text
                    Dim _itemimage As String = in_imageURL.Text

                    Dim node_item As XmlNode = _itemlist_app.CreateElement("item")
                    Dim node_category As XmlAttribute = _itemlist_app.CreateAttribute("category")
                    Dim node_gender As XmlAttribute = _itemlist_app.CreateAttribute("gender")
                    Dim node_id As XmlAttribute = _itemlist_app.CreateAttribute("id")
                    Dim node_name As XmlNode = _itemlist_app.CreateElement("name")
                    Dim node_price As XmlNode = _itemlist_app.CreateElement("price")
                    Dim node_image As XmlNode = _itemlist_app.CreateElement("image")
                    Dim node_variant As XmlNode = _itemlist_app.CreateElement("size")
                    Dim node_stock As XmlNode = _itemlist_app.CreateElement("stock")

                    node_category.Value = "app"
                    node_gender.Value = in_itemGender.Text.ToLower
                    node_id.Value = _itemid
                    node_name.InnerXml = _itemname
                    node_price.InnerXml = _itemprice
                    node_image.InnerXml = in_imageURL.Text
                    node_variant.InnerXml = in_itemVariant.Text
                    node_stock.InnerXml = in_stockCount.Text

                    node_item.Attributes.Append(node_category)
                    node_item.Attributes.Append(node_gender)
                    node_item.Attributes.Append(node_id)
                    node_item.AppendChild(node_name)
                    node_item.AppendChild(node_price)
                    node_item.AppendChild(node_image)
                    node_item.AppendChild(node_variant)
                    node_item.AppendChild(node_stock)

                    root.AppendChild(node_item)
                    _itemlist_app.Save(_itemlist_app_path)
                    _itemlist_getDatatable()

                    dialog.Title = "Item Added"
                    dialog.Content = "Your item has been added to database"
                    dialog.CloseButtonText = "Great!"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close

                    in_itemName.Text = ""
                    in_itemCategory.Text = ""
                    in_itemGender.Text = ""
                    in_itemID.Text = ""
                    in_itemPrice.Text = ""
                    in_itemVariant.Text = ""

                    dialog.ShowAsync()
                Catch ex As Exception

                    dialog.Title = "Script Error"
                    dialog.Content = "Please input all the fields"
                    dialog.CloseButtonText = "Ok"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close

                    dialog.ShowAsync()
                    Exit Select
                End Try

            Case "Accessory"
                label_itemvariant.Content = "Item Variant"
                Try
                    _itemlist_acc.Load(_itemlist_acc_path)
                    Dim root As XmlNode = _itemlist_acc.DocumentElement

                    Dim _itemname As String = in_itemName.Text
                    Dim _itemid As String = String.Empty
                    Select Case in_itemID.Text.Length
                        Case 1
                            _itemid = "00" + in_itemID.Text
                        Case 2
                            _itemid = "0" + in_itemID.Text
                    End Select
                    Select Case in_itemGender.Text
                        Case "Men"
                            _itemid = "MP1" + _itemid
                        Case "Women"
                            _itemid = "WP1" + _itemid
                    End Select
                    Dim _itemprice As String = in_itemPrice.Text
                    Dim _itemvariant As String = in_itemVariant.Text
                    Dim _itemstock As String = in_stockCount.Text
                    Dim _itemimage As String = in_imageURL.Text

                    Dim node_item As XmlNode = _itemlist_acc.CreateElement("item")
                    Dim node_category As XmlAttribute = _itemlist_acc.CreateAttribute("category")
                    Dim node_gender As XmlAttribute = _itemlist_acc.CreateAttribute("gender")
                    Dim node_id As XmlAttribute = _itemlist_acc.CreateAttribute("id")
                    Dim node_name As XmlNode = _itemlist_acc.CreateElement("name")
                    Dim node_price As XmlNode = _itemlist_acc.CreateElement("price")
                    Dim node_image As XmlNode = _itemlist_acc.CreateElement("image")
                    Dim node_variant As XmlNode = _itemlist_acc.CreateElement("variant")
                    Dim node_stock As XmlNode = _itemlist_acc.CreateElement("stock")

                    node_category.Value = "acc"
                    node_gender.Value = in_itemGender.Text.ToLower
                    node_id.Value = _itemid
                    node_name.InnerXml = _itemname
                    node_price.InnerXml = _itemprice
                    node_image.InnerXml = in_imageURL.Text
                    node_variant.InnerXml = in_itemVariant.Text
                    node_stock.InnerXml = in_stockCount.Text

                    node_item.Attributes.Append(node_category)
                    node_item.Attributes.Append(node_gender)
                    node_item.Attributes.Append(node_id)
                    node_item.AppendChild(node_name)
                    node_item.AppendChild(node_price)
                    node_item.AppendChild(node_image)
                    node_item.AppendChild(node_variant)
                    node_item.AppendChild(node_stock)

                    root.AppendChild(node_item)
                    _itemlist_acc.Save(_itemlist_acc_path)
                    _itemlist_getDatatable()

                    dialog.Title = "Item Added"
                    dialog.Content = "Your item has been added to database"
                    dialog.CloseButtonText = "Great!"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close

                    in_itemName.Text = ""
                    in_itemCategory.Text = ""
                    in_itemGender.Text = ""
                    in_itemID.Text = ""
                    in_itemPrice.Text = ""
                    in_itemVariant.Text = ""

                    dialog.ShowAsync()
                Catch ex As Exception

                    dialog.Title = "Script Error"
                    dialog.Content = "Please input all the fields"
                    dialog.CloseButtonText = "Ok"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                    dialog.ShowAsync()
                    Exit Select
                End Try


            Case "Footwear"
                label_itemvariant.Content = "Item Size"
                Try
                    _itemlist_ftw.Load(_itemlist_ftw_path)
                    Dim root As XmlNode = _itemlist_ftw.DocumentElement

                    Dim _itemname As String = in_itemName.Text
                    Dim _itemid As String = String.Empty
                    Select Case in_itemID.Text.Length
                        Case 1
                            _itemid = "00" + in_itemID.Text
                        Case 2
                            _itemid = "0" + in_itemID.Text
                    End Select
                    Select Case in_itemGender.Text
                        Case "Men"
                            _itemid = "MP1" + _itemid
                        Case "Women"
                            _itemid = "WP1" + _itemid
                    End Select
                    Dim _itemprice As String = in_itemPrice.Text
                    Dim _itemvariant As String = in_itemVariant.Text
                    Dim _itemstock As String = in_stockCount.Text
                    Dim _itemimage As String = in_imageURL.Text

                    Dim node_item As XmlNode = _itemlist_ftw.CreateElement("item")
                    Dim node_category As XmlAttribute = _itemlist_ftw.CreateAttribute("category")
                    Dim node_gender As XmlAttribute = _itemlist_ftw.CreateAttribute("gender")
                    Dim node_id As XmlAttribute = _itemlist_ftw.CreateAttribute("id")
                    Dim node_name As XmlNode = _itemlist_ftw.CreateElement("name")
                    Dim node_price As XmlNode = _itemlist_ftw.CreateElement("price")
                    Dim node_image As XmlNode = _itemlist_ftw.CreateElement("image")
                    Dim node_variant As XmlNode = _itemlist_ftw.CreateElement("size")
                    Dim node_stock As XmlNode = _itemlist_ftw.CreateElement("stock")

                    node_category.Value = "app"
                    node_gender.Value = in_itemGender.Text.ToLower
                    node_id.Value = _itemid
                    node_name.InnerXml = _itemname
                    node_price.InnerXml = _itemprice
                    node_image.InnerXml = in_imageURL.Text
                    node_variant.InnerXml = in_itemVariant.Text
                    node_stock.InnerXml = in_stockCount.Text

                    node_item.Attributes.Append(node_category)
                    node_item.Attributes.Append(node_gender)
                    node_item.Attributes.Append(node_id)
                    node_item.AppendChild(node_name)
                    node_item.AppendChild(node_price)
                    node_item.AppendChild(node_image)
                    node_item.AppendChild(node_variant)
                    node_item.AppendChild(node_stock)

                    root.AppendChild(node_item)
                    _itemlist_ftw.Save(_itemlist_ftw_path)
                    _itemlist_getDatatable()

                    dialog.Title = "Item Added"
                    dialog.Content = "Your item has been added to database"
                    dialog.CloseButtonText = "Great!"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close

                    in_itemName.Text = ""
                    in_itemCategory.Text = ""
                    in_itemGender.Text = ""
                    in_itemID.Text = ""
                    in_itemPrice.Text = ""
                    in_itemVariant.Text = ""

                    dialog.ShowAsync()
                Catch ex As Exception

                    dialog.Title = "Script Error"
                    dialog.Content = "Please input all the fields"
                    dialog.CloseButtonText = "Ok"
                    dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close

                    dialog.ShowAsync()
                    Exit Select
                End Try

        End Select


    End Sub

    Private Sub detectCategory(sender As Object, e As SelectionChangedEventArgs)
        Select Case in_itemCategory.SelectedIndex
            Case 1
                label_itemvariant.Content = "Item Variant"
            Case Else
                label_itemvariant.Content = "Item Size"
        End Select
    End Sub
End Class
