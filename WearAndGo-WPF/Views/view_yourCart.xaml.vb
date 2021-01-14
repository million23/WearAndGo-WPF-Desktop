Imports System.Xml
Imports ModernWpf.Controls

Class view_yourCart

    Public totalSum As Double

    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainwindow.Width = actualW
        mainwindow.Height = actualH - 120
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

        'write the total sum to UI
        cart_sum.Text = totalSum.ToString

    End Sub

    Public Async Sub ClearCart(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ContentDialog
        dialog.Title = "Your Cart"
        dialog.Content = "Would you like to remove this from your cart?"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.PrimaryButtonText = "Yes"
        dialog.CloseButtonText = "No"

        'load all database
        _itemlist_app.Load(_itemlist_app_path)
        _itemlist_acc.Load(_itemlist_acc_path)
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim root_app As XmlNode = _itemlist_app.DocumentElement
        Dim root_acc As XmlNode = _itemlist_acc.DocumentElement
        Dim root_ftw As XmlNode = _itemlist_ftw.DocumentElement

        'show prompt if wanted to delete all item
        Dim result As ContentDialogResult = Await dialog.ShowAsync

        'check if the user prompts to YES to delete all item
        If result = ContentDialogResult.Primary Then
            ' loads cart data
            _datalist_cart.Load(_datalist_cart_path)
            Dim cartRoot As XmlNode = _datalist_cart.DocumentElement

            'restock all items
            For Each item As XmlNode In cartRoot
                'loop all items to retrieve stock
                ' ' apparel
                If item.Attributes(0).Value = "app" Then
                    For Each appItem As XmlNode In root_app
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                            appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                            appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

                ' ' accessory
                If item.Attributes(0).Value = "acc" Then
                    For Each appItem As XmlNode In root_acc
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                            appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                            appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

                ' ' footwear
                If item.Attributes(0).Value = "ftw" Then
                    For Each appItem As XmlNode In root_ftw
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                            appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                            appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

            Next

            'remove all cart items
            cartRoot.RemoveAll()


            'save the database
            _datalist_cart.Save(_datalist_cart_path)
            _itemlist_app.Save(_itemlist_app_path)
            _itemlist_acc.Save(_itemlist_acc_path)
            _itemlist_ftw.Save(_itemlist_ftw_path)

            'reload the window
            _view_yourCart.getCartData(Nothing, Nothing)

            'feedback to user
            Dim notification As New Notifications.Wpf.NotificationManager
            Dim notificationContent As New Notifications.Wpf.NotificationContent

            notificationContent.Title = "Your Cart"
            notificationContent.Message = "All of your cart content has been removed"
            notificationContent.Type = Notifications.Wpf.NotificationType.Error

            notification.Show(notificationContent)
        End If
    End Sub

    Private Async Sub checkout(sender As Object, e As RoutedEventArgs)
        Dim dialog As New ContentDialog
        dialog.Title = "Your Cart"
        dialog.Content = "Would you like proceed to Checkout?"
        dialog.DefaultButton = ContentDialogButton.Close
        dialog.PrimaryButtonText = "Yes"
        dialog.CloseButtonText = "No"

        'make reference ID
        Dim timestamp As String = Now.Year.ToString + "Y" + Now.Month.ToString + "M" + Now.Day.ToString + "D"
        Randomize()
        Dim ID_int As Integer = Int(Rnd() * 999999999) + 111111111
        Dim referenceID As String = timestamp + "_" + ID_int.ToString

        'show prompt if wanted to checkout
        Dim result As ContentDialogResult = Await dialog.ShowAsync

        'check if the user prompts to YES to checkout
        If result = ContentDialogResult.Primary Then
            ' loads cart and sale history data
            _datalist_cart.Load(_datalist_cart_path)
            _datalist_history.Load(_datalist_history_path)
            Dim cartRoot As XmlNode = _datalist_cart.DocumentElement
            Dim historyRoot As XmlNode = _datalist_history.DocumentElement

            Dim sales As XmlNode = _datalist_history.CreateElement("sale")
            Dim sales_date As XmlAttribute = _datalist_history.CreateAttribute("date")
            Dim sales_id As XmlAttribute = _datalist_history.CreateAttribute("id")
            Dim sales_sum As XmlAttribute = _datalist_history.CreateAttribute("totalSale")

            sales_date.Value = Now.ToShortDateString + "_" + Now.ToShortTimeString
            sales_id.Value = referenceID
            sales_sum.Value = totalSum.ToString

            sales.Attributes.Append(sales_date)
            sales.Attributes.Append(sales_id)
            sales.Attributes.Append(sales_sum)

            For Each cartItem As XmlNode In cartRoot
                Dim item As XmlNode = _datalist_history.CreateElement("item")
                Dim itemCategory As XmlNode = _datalist_history.CreateAttribute("category")
                Dim itemGender As XmlNode = _datalist_history.CreateAttribute("gender")
                Dim itemID As XmlNode = _datalist_history.CreateAttribute("id")

                itemCategory.Value = cartItem.Attributes(0).Value
                itemGender.Value = cartItem.Attributes(1).Value
                itemID.Value = cartItem.Attributes(2).Value

                item.Attributes.Append(itemCategory)
                item.Attributes.Append(itemGender)
                item.Attributes.Append(itemID)

                sales.AppendChild(item)
            Next

            historyRoot.AppendChild(sales)

            _datalist_history.Save(_datalist_history_path)


        End If
    End Sub

    'force clear your cart content
    Public Sub ForceClearCart(feedback As Boolean, restock As Boolean)

        'load all database
        _itemlist_app.Load(_itemlist_app_path)
        _itemlist_acc.Load(_itemlist_acc_path)
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim root_app As XmlNode = _itemlist_app.DocumentElement
        Dim root_acc As XmlNode = _itemlist_acc.DocumentElement
        Dim root_ftw As XmlNode = _itemlist_ftw.DocumentElement

        ' loads cart data
        _datalist_cart.Load(_datalist_cart_path)
        Dim cartRoot As XmlNode = _datalist_cart.DocumentElement

        If restock Then
            'restock all items
            For Each item As XmlNode In cartRoot
                'loop all items to retrieve stock
                ' ' apparel
                If item.Attributes(0).Value = "app" Then
                    For Each appItem As XmlNode In root_app
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                                appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                                appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

                ' ' accessory
                If item.Attributes(0).Value = "acc" Then
                    For Each appItem As XmlNode In root_acc
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                                appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                                appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

                ' ' footwear
                If item.Attributes(0).Value = "ftw" Then
                    For Each appItem As XmlNode In root_ftw
                        If appItem.Attributes(0).Value = item.Attributes(0).Value AndAlso
                                appItem.Attributes(1).Value = item.Attributes(1).Value AndAlso
                                appItem.Attributes(2).Value = item.Attributes(2).Value Then

                            appItem("stock").InnerXml = CInt(appItem("stock").InnerXml) + 1
                        End If
                    Next
                End If

            Next
        End If


        'remove all cart items
        cartRoot.RemoveAll()

        'save the database
        _datalist_cart.Save(_datalist_cart_path)
        _itemlist_app.Save(_itemlist_app_path)
        _itemlist_acc.Save(_itemlist_acc_path)
        _itemlist_ftw.Save(_itemlist_ftw_path)


        If feedback Then
            'reload the window
            _view_yourCart.getCartData(Nothing, Nothing)

            'feedback to user
            Dim notification As New Notifications.Wpf.NotificationManager
            Dim notificationContent As New Notifications.Wpf.NotificationContent

            notificationContent.Title = "Your Cart"
            notificationContent.Message = "Your Cart content reset"
            notificationContent.Type = Notifications.Wpf.NotificationType.Error

            notification.Show(notificationContent)
        End If


    End Sub
End Class
