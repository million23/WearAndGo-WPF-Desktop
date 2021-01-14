Imports System.Xml

Public Class itemlist_updateItem
    Private Sub updateItem(sender As Object, e As RoutedEventArgs)
        Try
            If in_selectedItemID.Text <> "" Or in_selectedItemCategory.Text <> "" Then
                Select Case in_selectedItemCategory.Text
                    Case "Apparel"
                        _itemlist_app.Load(_itemlist_app_path)
                        Dim root As XmlNode = _itemlist_app.DocumentElement

                        For Each item As XmlNode In root
                            If in_selectedItemID.Text = item.Attributes(2).Value Then

                                If in_itemGender.Text = "Men" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "MP100" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "MP10" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "MP1" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemGender.Text = "Women" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "WP100" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "WP10" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "WP1" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemCategory.Text <> "" Then
                                    item.Attributes(0).Value = in_itemCategory.Text
                                End If
                                If in_itemGender.Text <> "" Then
                                    item.Attributes(1).Value = in_itemGender.Text
                                End If
                                If in_itemName.Text <> "" Then
                                    item("name").InnerXml = in_itemName.Text
                                End If
                                If in_itemPrice.Text <> "" Then
                                    item("price").InnerXml = in_itemPrice.Text
                                End If
                                If in_imageURL.Text <> "" Then
                                    item("image").InnerXml = in_imageURL.Text
                                End If
                                If in_itemVariant.Text <> "" Then
                                    item("size").InnerXml = in_itemVariant.Text
                                End If
                                If in_stockCount.Text <> "" Then
                                    item("stock").InnerXml = in_stockCount.Text
                                End If


                            End If
                        Next

                        _itemlist_app.Save(_itemlist_app_path)
                        _itemlist_getDatatable()
                        _admin_itemList.sidepane.IsPaneOpen = False

                    Case "Accessory"
                        _itemlist_acc.Load(_itemlist_acc_path)
                        Dim root As XmlNode = _itemlist_acc.DocumentElement

                        For Each item As XmlNode In root
                            If in_selectedItemID.Text = item.Attributes(2).Value Then

                                If in_itemGender.Text = "Men" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "MP200" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "MP20" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "MP2" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemGender.Text = "Women" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "WP200" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "WP20" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "WP2" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemCategory.Text <> "" Then
                                    item.Attributes(0).Value = in_itemCategory.Text
                                End If
                                If in_itemGender.Text <> "" Then
                                    item.Attributes(1).Value = in_itemGender.Text
                                End If
                                If in_itemName.Text <> "" Then
                                    item("name").InnerXml = in_itemName.Text
                                End If
                                If in_itemPrice.Text <> "" Then
                                    item("price").InnerXml = in_itemPrice.Text
                                End If
                                If in_imageURL.Text <> "" Then
                                    item("image").InnerXml = in_imageURL.Text
                                End If
                                If in_itemVariant.Text <> "" Then
                                    item("desc").InnerXml = in_itemVariant.Text
                                End If
                                If in_stockCount.Text <> "" Then
                                    item("stock").InnerXml = in_stockCount.Text
                                End If


                            End If
                        Next

                        _itemlist_acc.Save(_itemlist_acc_path)
                        _itemlist_getDatatable()
                        _admin_itemList.sidepane.IsPaneOpen = False
                    Case "Footwear"
                        _itemlist_ftw.Load(_itemlist_ftw_path)
                        Dim root As XmlNode = _itemlist_ftw.DocumentElement

                        For Each item As XmlNode In root
                            If in_selectedItemID.Text = item.Attributes(2).Value Then

                                If in_itemGender.Text = "Men" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "MP300" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "MP30" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "MP3" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemGender.Text = "Women" Then
                                    If in_itemID.Text <> "" Then
                                        Select Case in_itemID.Text.Length
                                            Case 1
                                                item.Attributes(2).Value = "WP300" + in_itemID.Text
                                            Case 2
                                                item.Attributes(2).Value = "WP30" + in_itemID.Text
                                            Case Else
                                                item.Attributes(2).Value = "WP3" + in_itemID.Text
                                        End Select
                                    End If
                                End If
                                If in_itemCategory.Text <> "" Then
                                    item.Attributes(0).Value = in_itemCategory.Text
                                End If
                                If in_itemGender.Text <> "" Then
                                    item.Attributes(1).Value = in_itemGender.Text
                                End If
                                If in_itemName.Text <> "" Then
                                    item("name").InnerXml = in_itemName.Text
                                End If
                                If in_itemPrice.Text <> "" Then
                                    item("price").InnerXml = in_itemPrice.Text
                                End If
                                If in_imageURL.Text <> "" Then
                                    item("image").InnerXml = in_imageURL.Text
                                End If
                                If in_itemVariant.Text <> "" Then
                                    item("size").InnerXml = in_itemVariant.Text
                                End If
                                If in_stockCount.Text <> "" Then
                                    item("stock").InnerXml = in_stockCount.Text
                                End If


                            End If
                        Next

                        _itemlist_ftw.Save(_itemlist_ftw_path)
                        _itemlist_getDatatable()
                        _admin_itemList.sidepane.IsPaneOpen = False
                    Case Else

                End Select

                in_selectedItemCategory.Text = ""
                in_selectedItemID.Text = ""
                in_itemID.Text = ""
                in_itemCategory.Text = ""
                in_itemGender.Text = ""
                in_itemName.Text = ""
                in_itemPrice.Text = ""
                in_imageURL.Text = ""
                in_itemVariant.Text = ""
                in_stockCount.Text = ""
                _admin_itemList.sidepane.IsPaneOpen = False
                Dim dialog As New ModernWpf.Controls.ContentDialog
                dialog.Title = "Item Updated"
                dialog.Content = "The item has been successfully updated and changed"
                dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                dialog.CloseButtonText = "Great!"
                dialog.ShowAsync()

            End If

        Catch ex As Exception
            _admin_itemList.sidepane.IsPaneOpen = False
            Dim dialog As New ModernWpf.Controls.ContentDialog
            dialog.Title = "Something went wrong"
            dialog.Content = "Somthing what you did went wrong. Can you try again?"
            dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
            dialog.CloseButtonText = "Ok"
            dialog.ShowAsync()
        End Try


    End Sub
End Class
