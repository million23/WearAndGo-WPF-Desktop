Imports System.Xml

Public Class item_yourCart

    Public ID, category, gender As String

    Private Sub removeFromCart(sender As Object, e As RoutedEventArgs)



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
    End Sub
End Class
