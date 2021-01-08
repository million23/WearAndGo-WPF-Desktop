Imports System.Xml

Class view_yourCart

    Public totalSum As Double

    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainwindow.Width = actualW
        mainwindow.Height = actualH - 80
        scroller.Height = actualH - 140
    End Sub

    Public Sub getCartData(sender As Object, e As RoutedEventArgs)
        'clear cart item container children
        cartItemContainer.Children.Clear()
        'load from database
        _datalist_cart.Load(_datalist_cart_path)
        _itemlist_acc.Load(_itemlist_acc_path)
        _itemlist_app.Load(_itemlist_app_path)
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim root_cart As XmlNode = _datalist_cart.DocumentElement
        Dim root_acc As XmlNode = _itemlist_acc.DocumentElement
        Dim root_app As XmlNode = _itemlist_app.DocumentElement
        Dim root_ftw As XmlNode = _itemlist_ftw.DocumentElement

        'check if cart has items. If false, hide the transaction commands
        If root_cart.HasChildNodes Then
            transactionCommands.Visibility = Visibility.Visible
        Else
            transactionCommands.Visibility = Visibility.Hidden
        End If

        'make sum change to 0 everytime the page loads
        totalSum = 0

        'loop thru cart items
        For Each item_cart As XmlNode In root_cart
            'check if cart item is men's apparel
            If item_cart.Attributes(0).Value = "app" AndAlso item_cart.Attributes(1).Value = "men" Then
                For Each item_app As XmlNode In root_app
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_app.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_app.Attributes(0).Value
                        card.gender = item_app.Attributes(1).Value
                        card.ID = item_app.Attributes(2).Value
                        card.itemID.Text = item_app.Attributes(2).Value
                        card.itemName.Text = item_app("name").InnerXml
                        card.itemPrice.Text = item_app("price").InnerXml
                        card.itemVariant.Text = item_app("size").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_app("image").InnerXml))

                        totalSum = totalSum + CDbl(item_app("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
            'check if cart item is women's apparel
            If item_cart.Attributes(0).Value = "app" AndAlso item_cart.Attributes(1).Value = "wom" Then
                For Each item_app As XmlNode In root_app
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_app.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_app.Attributes(0).Value
                        card.gender = item_app.Attributes(1).Value
                        card.ID = item_app.Attributes(2).Value
                        card.itemID.Text = item_app.Attributes(2).Value
                        card.itemName.Text = item_app("name").InnerXml
                        card.itemPrice.Text = item_app("price").InnerXml
                        card.itemVariant.Text = item_app("size").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_app("image").InnerXml))

                        totalSum = totalSum + CDbl(item_app("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
            'check if cart item is men's accessory
            If item_cart.Attributes(0).Value = "acc" AndAlso item_cart.Attributes(1).Value = "men" Then
                For Each item_acc As XmlNode In root_acc
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_acc.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_acc.Attributes(0).Value
                        card.gender = item_acc.Attributes(1).Value
                        card.ID = item_acc.Attributes(2).Value
                        card.itemID.Text = item_acc.Attributes(2).Value
                        card.itemName.Text = item_acc("name").InnerXml
                        card.itemPrice.Text = item_acc("price").InnerXml
                        card.itemVariant.Text = item_acc("desc").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_acc("image").InnerXml))

                        totalSum = totalSum + CDbl(item_acc("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
            'check if cart item is women's accessory
            If item_cart.Attributes(0).Value = "acc" AndAlso item_cart.Attributes(1).Value = "wom" Then
                For Each item_acc As XmlNode In root_acc
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_acc.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_acc.Attributes(0).Value
                        card.gender = item_acc.Attributes(1).Value
                        card.ID = item_acc.Attributes(2).Value
                        card.itemID.Text = item_acc.Attributes(2).Value
                        card.itemName.Text = item_acc("name").InnerXml
                        card.itemPrice.Text = item_acc("price").InnerXml
                        card.itemVariant.Text = item_acc("desc").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_acc("image").InnerXml))

                        totalSum = totalSum + CDbl(item_acc("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
            'check if cart item is men's footwear
            If item_cart.Attributes(0).Value = "ftw" AndAlso item_cart.Attributes(1).Value = "men" Then
                For Each item_acc As XmlNode In root_ftw
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_acc.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_acc.Attributes(0).Value
                        card.gender = item_acc.Attributes(1).Value
                        card.ID = item_acc.Attributes(2).Value
                        card.itemID.Text = item_acc.Attributes(2).Value
                        card.itemName.Text = item_acc("name").InnerXml
                        card.itemPrice.Text = item_acc("price").InnerXml
                        card.itemVariant.Text = item_acc("size").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_acc("image").InnerXml))

                        totalSum = totalSum + CDbl(item_acc("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
            'check if cart item is women's footwear
            If item_cart.Attributes(0).Value = "ftw" AndAlso item_cart.Attributes(1).Value = "wom" Then
                For Each item_acc As XmlNode In root_ftw
                    'check if IDs are matched then return the information from the database
                    If item_cart.Attributes(2).Value = item_acc.Attributes(2).Value Then
                        'create cart item then append to cart item container
                        Dim card As New item_yourCart

                        card.category = item_acc.Attributes(0).Value
                        card.gender = item_acc.Attributes(1).Value
                        card.ID = item_acc.Attributes(2).Value
                        card.itemID.Text = item_acc.Attributes(2).Value
                        card.itemName.Text = item_acc("name").InnerXml
                        card.itemPrice.Text = item_acc("price").InnerXml
                        card.itemVariant.Text = item_acc("size").InnerXml
                        card.itemImage.Source = New BitmapImage(New Uri(item_acc("image").InnerXml))

                        totalSum = totalSum + CDbl(item_acc("price").InnerXml)

                        cartItemContainer.Children.Add(card)
                    End If
                Next
            End If
        Next

        cart_sum.Text = totalSum.ToString

    End Sub
End Class
