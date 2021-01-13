Imports System.Xml

Class view_adminMode
    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainContainer.Width = actualW
        mainContainer.Height = actualH - 40

        _admin_home.Width = actualW
        _admin_home.Height = actualH - 40
        _admin_users.Width = actualW
        _admin_users.Height = actualH - 40
    End Sub
    Private Sub selectedPane(sender As ModernWpf.Controls.NavigationView, args As ModernWpf.Controls.NavigationViewItemInvokedEventArgs)
        Select Case mainNav.SelectedItem.Tag
            Case "Home"
                adminFrame.Navigate(_admin_home)
            Case "Users"
                adminFrame.Navigate(_admin_users)
            Case "Inventory"
                adminFrame.Navigate(_admin_itemList)

        End Select
    End Sub

    Private Sub pageLoad(sender As Object, e As RoutedEventArgs)
        'navigate automatically to Home
        adminFrame.Navigate(_admin_home)
        resizeWindow(Nothing, Nothing)

        'check if the account is admin
        If My.Settings.activeUserType = "Administrator" Then
            usersTab.IsEnabled = True
            usersTab.Content = "Users"
        Else
            usersTab.IsEnabled = False
            usersTab.Content = "Users (Requires an Administrator Account)"
        End If

        ' load user list
        _userList.ReadXml(_datalist_users_path)
        _itemlist_generate_Columns()
        _itemlist_getDatatable()
    End Sub

End Class
