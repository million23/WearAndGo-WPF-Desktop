Imports System.Xml

Public Class itemlist_removeItem
    Private Sub deleteItem(sender As Object, e As RoutedEventArgs)
        Dim dialog As New Notifications.Wpf.NotificationManager
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

                Dim content As New Notifications.Wpf.NotificationContent
                content.Title = "Inventory"
                content.Message = "This item has been deleted from the database"
                content.Type = Notifications.Wpf.NotificationType.Success

                _itemlist_app.Save(_itemlist_app_path)
                _itemlist_getDatatable()

                dialog.Show(content)

            Case "Accessory"
                _itemlist_acc.Load(_itemlist_acc_path)
                Dim root As XmlNode = _itemlist_acc.DocumentElement

                For Each item As XmlNode In root
                    If item.Attributes(2).Value = in_itemID.Text Then
                        item.ParentNode.RemoveChild(item)
                        Exit For
                    End If
                Next

                Dim content As New Notifications.Wpf.NotificationContent
                content.Title = "Inventory"
                content.Message = "This item has been deleted from the database"
                content.Type = Notifications.Wpf.NotificationType.Success

                _itemlist_acc.Save(_itemlist_acc_path)
                _itemlist_getDatatable()

                dialog.Show(content)

            Case "Footwear"

            Case Else

        End Select


        in_itemID.Text = ""
        in_itemCategory.Text = ""
        _admin_itemList.sidepane.IsPaneOpen = False
    End Sub
End Class
