Imports System.Xml

Public Class admin_users_sidepane_editAccount

    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight

        _admin_users_sidepane_addAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_removeAccount.scroller.Height = actualH - 150
        _admin_users_sidepane_editAccount.scroller.Height = actualH - 150
    End Sub
    Private Sub updateAccount(sender As Object, e As RoutedEventArgs)
        Try
            If AccountUsernameSelect.Text <> "" Then
                _datalist_users.Load(_datalist_users_path)
                Dim root As XmlNode = _datalist_users.DocumentElement

                For Each user As XmlNode In root
                    If AccountUsernameSelect.Text = user.Attributes(2).Value Then
                        If AccountType.Text <> "" Then
                            user.Attributes(0).Value = AccountType.Text
                        End If
                        If AccountName.Text <> "" Then
                            user.Attributes(1).Value = AccountName.Text
                        End If
                        If AccountUsername.Text <> "" Then
                            user.Attributes(2).Value = AccountUsername.Text
                        End If
                        If AccountPassword.Password <> "" Then
                            If AccountPassword.Password = AccountPasswordConfirm.Password Then
                                user.Attributes(3).Value = AccountPassword.Password
                            End If
                        End If
                    End If
                Next

                _datalist_users.Save(_datalist_users_path)

                _userList.Clear()
                _userList.ReadXml(_datalist_users_path)
                _admin_users.mainGrid.Items.Refresh()


                Dim dialog As New ModernWpf.Controls.ContentDialog
                dialog.Title = "User Account Updated"
                dialog.Content = "The account has been successfully updated and changed"
                dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
                dialog.CloseButtonText = "Great!"
                dialog.ShowAsync()
            End If
        Catch ex As Exception
            Dim dialog As New ModernWpf.Controls.ContentDialog
            dialog.Title = "Something went wrong"
            dialog.Content = "Something you did went wrong. Try again or contact the administrator"
            dialog.DefaultButton = ModernWpf.Controls.ContentDialogButton.Close
            dialog.CloseButtonText = "Great!"
            dialog.ShowAsync()
        End Try
    End Sub
End Class
