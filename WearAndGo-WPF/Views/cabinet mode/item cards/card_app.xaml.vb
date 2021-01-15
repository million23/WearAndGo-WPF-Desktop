Imports ModernWpf.Controls
Imports System.Xml

Public Class card_app
    Private Async Sub addToCart(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ContentDialog
        Dim dialog1 As New ContentDialog
        dialog.Title = "Your Cart"
        dialog.Content = "Add this item to your cart?" + vbNewLine + vbNewLine + itemName.Text
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.PrimaryButtonText = "Yes"
        dialog.CloseButtonText = "No"

        Dim result As ContentDialogResult = Await dialog.ShowAsync

        If result = ContentDialogResult.Primary Then
            Try
                _datalist_cart.Load(_datalist_cart_path)
                _itemlist_app.Load(_itemlist_app_path)
                Dim cart_root As XmlNode = _datalist_cart.DocumentElement
                Dim app_root As XmlNode = _itemlist_app.DocumentElement

                For Each itemList_item As XmlNode In app_root
                    If itemList_item.Attributes(2).Value = itemID.Text Then
                        If CInt(itemList_item("stock").InnerXml) > 0 Then
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
                            _itemlist_app.Save(_itemlist_app_path)

                            dialog1.Title = "Your Cart"
                            dialog1.Content = itemName.Text + " has been added to your cart!"
                            dialog1.CloseButtonText = "Ok"
                            Await dialog1.ShowAsync()

                            Exit For

                        Else
                            dialog1.Title = "Your Cart"
                            dialog1.Content = "That item has no stock at the moment"
                            dialog1.CloseButtonText = "Ok"
                            Await dialog1.ShowAsync()
                            Exit For
                        End If



                    End If
                Next
            Catch ex As Exception
                dialog1.Title = "Your Cart"
                dialog1.Content = "Something happened unexpectedly. Can you try again?"
                dialog1.CloseButtonText = "Ok"
                dialog1.ShowAsync()

            End Try

            _view_yourCart.getCartData(Nothing, Nothing)
        End If

    End Sub
End Class
