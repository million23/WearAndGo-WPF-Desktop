Imports ModernWpf.Controls
Imports System.Xml
Imports Notifications.Wpf

Public Class card_acc
    Private Async Sub addToCart(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ContentDialog
        dialog.Title = "Your Cart"
        dialog.Content = "Add this item to your cart?" + vbNewLine + vbNewLine + itemName.Text
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.PrimaryButtonText = "Yes"
        dialog.CloseButtonText = "No"

        Dim result As ContentDialogResult = Await dialog.ShowAsync

        If result = ContentDialogResult.Primary Then
            Try
                _datalist_cart.Load(_datalist_cart_path)
                _itemlist_acc.Load(_itemlist_acc_path)
                Dim cart_root As XmlNode = _datalist_cart.DocumentElement
                Dim acc_root As XmlNode = _itemlist_acc.DocumentElement

                For Each itemList_item As XmlNode In acc_root
                    If itemList_item.Attributes(2).Value = itemID.Text Then

                        Dim item As XmlElement = _datalist_cart.CreateElement("item")
                        Dim category As XmlAttribute = _datalist_cart.CreateAttribute("category")
                        Dim gender As XmlAttribute = _datalist_cart.CreateAttribute("gender")
                        Dim id As XmlAttribute = _datalist_cart.CreateAttribute("id")
                        category.Value = itemList_item.Attributes(0).Value
                        gender.Value = itemList_item.Attributes(1).Value
                        id.Value = itemList_item.Attributes(2).Value

                        item.Attributes.Append(category)
                        item.Attributes.Append(gender)
                        item.Attributes.Append(id)

                        itemList_item("stock").InnerXml = CInt(itemList_item("stock").InnerXml) - 1

                        cart_root.AppendChild(item)

                        _datalist_cart.Save(_datalist_cart_path)
                        _itemlist_acc.Save(_itemlist_acc_path)

                        Exit For

                    End If
                Next
            Catch ex As Exception
                MsgBox("Something went wrong, try again.", MsgBoxStyle.OkOnly, "Your Cart")
            End Try
        End If

        Dim notification As New NotificationManager
        Dim notificationContent As New NotificationContent

        notificationContent.Title = "Your Cart"
        notificationContent.Message = itemName.Text + " has been added to your cart!"
        notificationContent.Type = NotificationType.Success

        notification.Show(notificationContent)
    End Sub
End Class
