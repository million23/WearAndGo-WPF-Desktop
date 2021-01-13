Imports System.Xml
Imports ModernWpf.Controls

Public Class item_yourCart

    Public ID, category, gender As String


    Private Async Sub removeFromCart(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ContentDialog
        dialog.Title = "Your Cart"
        dialog.Content = "Would you like to remove this from your cart?"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.PrimaryButtonText = "Yes"
        dialog.CloseButtonText = "No"

        _itemlist_app.Load(_itemlist_app_path)
        _itemlist_acc.Load(_itemlist_acc_path)
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim root_app As XmlNode = _itemlist_app.DocumentElement
        Dim root_acc As XmlNode = _itemlist_acc.DocumentElement
        Dim root_ftw As XmlNode = _itemlist_ftw.DocumentElement

        'show prompt if wanted to delete item
        Dim result As ContentDialogResult = Await dialog.ShowAsync

        'check if the user prompts to YES to delete the item
        If result = ContentDialogResult.Primary Then
            ' loads cart data
            _datalist_cart.Load(_datalist_cart_path)
            Dim cartRoot As XmlNode = _datalist_cart.DocumentElement

            'loop thru items
            For Each item As XmlNode In cartRoot
                'check if this item matched in the database
                If item.Attributes(0).Value = category AndAlso
                        item.Attributes(1).Value = gender AndAlso
                        item.Attributes(2).Value = ID Then
                    'remove this child if matched
                    item.ParentNode.RemoveChild(item)


                    'loop all items to retrieve stock
                    ' ' apparel
                    If category = "app" Then
                        For Each appItem As XmlNode In root_app
                            If appItem.Attributes(0).Value = category AndAlso
                            appItem.Attributes(1).Value = gender AndAlso
                            appItem.Attributes(2).Value = ID Then
                                appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                            End If
                        Next
                    End If

                    ' ' accessory
                    If category = "acc" Then
                        For Each appItem As XmlNode In root_acc
                            If appItem.Attributes(0).Value = category AndAlso
                                appItem.Attributes(1).Value = gender AndAlso
                                appItem.Attributes(2).Value = ID Then
                                appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                            End If
                        Next
                    End If

                    ' ' footwear
                    If category = "ftw" Then
                        For Each appItem As XmlNode In root_ftw
                            If appItem.Attributes(0).Value = category AndAlso
                            appItem.Attributes(1).Value = gender AndAlso
                            appItem.Attributes(2).Value = ID Then
                                appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                            End If
                        Next
                    End If
                End If
            Next


            'save the database
            _datalist_cart.Save(_datalist_cart_path)
            _itemlist_app.Save(_itemlist_app_path)
            _itemlist_acc.Save(_itemlist_acc_path)
            _itemlist_ftw.Save(_itemlist_ftw_path)

            'reload the window
            _view_yourCart.getCartData(Nothing, Nothing)


            Dim notification As New Notifications.Wpf.NotificationManager
            Dim notificationContent As New Notifications.Wpf.NotificationContent

            notificationContent.Title = "Your Cart"
            notificationContent.Message = itemName.Text + " has been removed from your cart"
            notificationContent.Type = Notifications.Wpf.NotificationType.Error

            notification.Show(notificationContent)

        End If

    End Sub
End Class
