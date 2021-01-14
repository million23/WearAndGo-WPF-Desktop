Imports System.Xml

Public Class itemlist_removeItem
    Private Sub deleteItem(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ModernWpf.Controls.ContentDialog
        Select Case in_itemCategory.Text
            Case "Apparel"
                _itemlist_app.Load(_itemlist_app_path)
                Dim root As XmlNode = _itemlist_app.DocumentElement

                For Each item As XmlNode In root
                    If item.Attributes(2).Value = in_itemID.Text Then
                        item.ParentNode.RemoveChild(item)
                        Exit For
                    End If
                Next


                dialog.Title = "Inventory"
                dialog.Content = "This item has been deleted from the database"
                dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                dialog.CloseButtonText = "Ok"
                dialog.ShowAsync()

                _itemlist_app.Save(_itemlist_app_path)
                _itemlist_getDatatable()


            Case "Accessory"
                _itemlist_acc.Load(_itemlist_acc_path)
                Dim root As XmlNode = _itemlist_acc.DocumentElement

                For Each item As XmlNode In root
                    If item.Attributes(2).Value = in_itemID.Text Then
                        item.ParentNode.RemoveChild(item)
                        Exit For
                    End If
                Next

                dialog.Title = "Inventory"
                dialog.Content = "This item has been deleted from the database"
                dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                dialog.CloseButtonText = "Ok"
                dialog.ShowAsync()

                _itemlist_acc.Save(_itemlist_acc_path)
                _itemlist_getDatatable()


            Case "Footwear"
                _itemlist_ftw.Load(_itemlist_ftw_path)
                Dim root As XmlNode = _itemlist_ftw.DocumentElement

                For Each item As XmlNode In root
                    If item.Attributes(2).Value = in_itemID.Text Then
                        item.ParentNode.RemoveChild(item)
                        Exit For
                    End If
                Next

                dialog.Title = "Inventory"
                dialog.Content = "This item has been deleted from the database"
                dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                dialog.CloseButtonText = "Ok"
                dialog.ShowAsync()

                _itemlist_ftw.Save(_itemlist_ftw_path)
                _itemlist_getDatatable()

            Case Else

        End Select


        in_itemID.Text = ""
        in_itemCategory.Text = ""
        _admin_itemList.sidepane.IsPaneOpen = False
    End Sub
End Class
