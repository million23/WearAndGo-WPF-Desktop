Imports System.Xml

Class admin_users

    Private Sub getData(sender As Object, e As RoutedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        mainGrid.ItemsSource = _userList.Tables(0).DefaultView
        mainGrid.MinColumnWidth = 200


        _admin_users_sidepane_addAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_removeAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_editAccount.scroller.Height = actualH - 150

    End Sub

    Private Sub removeAccount(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = (_admin_users_sidepane_removeAccount)
    End Sub

    Private Sub addAccount(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = (_admin_users_sidepane_addAccount)
    End Sub

    Private Sub editAccount(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = (_admin_users_sidepane_editAccount)

    End Sub
End Class
