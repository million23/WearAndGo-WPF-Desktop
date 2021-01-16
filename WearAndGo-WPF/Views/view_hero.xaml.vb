Imports System.Xml
Imports System.Media
Imports ModernWpf.Controls
Imports Notifications.Wpf

Class view_hero
    Private Sub cabinetMode(sender As Object, e As RoutedEventArgs)
        My.Application.MainWindow.FindName("mainFrame").content = _view_cabinetMode
    End Sub

    Private Sub paneOpen(sender As Object, e As RoutedEventArgs)
        If splitviewer.IsPaneOpen = False Then
            splitviewer.IsPaneOpen = True
        End If
    End Sub

    Private Sub enterKeyPress(sender As Object, e As KeyEventArgs)
        If splitviewer.IsPaneOpen Then
            If e.Key = Key.Return Then
                adminMode(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub adminMode(sender As Object, e As RoutedEventArgs)
        _datalist_users.Load(_datalist_users_path)
        Dim root As XmlNode = _datalist_users.DocumentElement

        Dim dialog As New ContentDialog

        For Each user As XmlNode In root
            If emptb_username.Text = user.Attributes(2).Value AndAlso emptb_password.Password = user.Attributes(3).Value Then
                My.Application.MainWindow.FindName("mainFrame").navigate(_view_adminMode)
                My.Settings.activeUser = user.Attributes(1).Value
                My.Settings.activeUserType = user.Attributes(0).Value

                splitviewer.IsPaneOpen = False
            End If
        Next

        emptb_username.Text = ""
        emptb_password.Password = ""
    End Sub

    Private Sub pageLoad(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
