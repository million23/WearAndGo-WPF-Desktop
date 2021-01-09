Imports System.Xml
Imports ModernWpf.Controls

Public Class admin_users_sidepane_removeAccount
    Dim dialog As New ContentDialog

    Private Async Sub RemoveAccount(sender As Object, e As RoutedEventArgs)


        _datalist_users.Load(_datalist_users_path)
        Dim user_root As XmlNode = _datalist_users.DocumentElement

        For Each user As XmlNode In user_root
            If AccountUsername.Text = user.Attributes(2).Value Then
                dialog.Title = "Remove Account"
                dialog.Content = "You cannot delete the account that was signed in here"
                dialog.CloseButtonText = "Ok"
                dialog.DefaultButton = ContentDialogButton.Close
                Exit For

            Else
                If AccountUsername.Text = "" Then
                    dialog.Title = "Remove Account"
                    dialog.Content = "Please input the required fields"
                    dialog.CloseButtonText = "Ok"
                    dialog.DefaultButton = ContentDialogButton.Close

                Else
                    If AccountPasswordConfirm.Password = "" Then
                        dialog.Title = "Remove Account"
                        dialog.Content = "Please input your Administrator Password"
                        dialog.CloseButtonText = "Ok"
                        dialog.DefaultButton = ContentDialogButton.Close

                    Else
                        For Each userSelect As XmlNode In user_root
                            If userSelect.Attributes(3).Value = AccountPasswordConfirm.Password Then
                                For Each userToDelete As XmlNode In user_root
                                    If userToDelete.Attributes(2).Value = AccountUsername.Text Then
                                        userToDelete.ParentNode.RemoveChild(userToDelete)

                                        dialog.Title = "Remove Account"
                                        dialog.Content = "Account Removed"
                                        dialog.CloseButtonText = "Ok"
                                        dialog.DefaultButton = ContentDialogButton.Close


                                        _datalist_users.Save(_datalist_users_path)

                                        _userList.Clear()
                                        _userList.ReadXml(_datalist_users_path)
                                        _admin_users.mainGrid.Items.Refresh()
                                        Exit For
                                    End If
                                Next
                            End If
                        Next

                    End If
                End If
            End If
        Next





        Await dialog.ShowAsync
    End Sub
End Class
