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
        _admin_sales.Width = actualW
        _admin_sales.Height = actualH - 40

        _admin_users_sidepane_addAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_editAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_removeAccount.scroller.Height = actualH - 150
    End Sub
    Private Sub selectedPane(sender As ModernWpf.Controls.NavigationView, args As ModernWpf.Controls.NavigationViewItemInvokedEventArgs)
        Select Case mainNav.SelectedItem.Tag
            Case "Home"
                adminFrame.Navigate(_admin_home)
            Case "Users"
                adminFrame.Navigate(_admin_users)
            Case "Inventory"
                adminFrame.Navigate(_admin_itemList)
            Case "Sales"
                adminFrame.Navigate(_admin_sales)

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

        _salesHistory_getData()
    End Sub

End Class
