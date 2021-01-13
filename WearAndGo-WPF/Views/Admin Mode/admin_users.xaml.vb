Imports System.Xml

Class admin_users

    Private Sub getData(sender As Object, e As RoutedEventArgs)
        mainGrid.ItemsSource = _userList.Tables(0).DefaultView
        mainGrid.MinColumnWidth = 200



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
