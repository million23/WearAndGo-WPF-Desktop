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
                End If
            Next

            'save the database
            _datalist_cart.Save(_datalist_cart_path)

            'reload the window
            _view_yourCart.getCartData(Nothing, Nothing)
        End If

    End Sub
End Class
