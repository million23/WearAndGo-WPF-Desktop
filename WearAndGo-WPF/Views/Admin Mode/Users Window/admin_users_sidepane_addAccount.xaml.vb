Imports System.Xml
Imports ModernWpf.Controls

Public Class admin_users_sidepane_addAccount
    Private Async Sub AddAccount(sender As Object, e As RoutedEventArgs)
        If AccountName.Text = "" Or
            AccountPassword.Password = "" Or
            AccountPasswordConfirm.Password = "" Or
            AccountType.SelectedIndex = -1 Or
            AccountUsername.Text = "" Then

            Dim dialog As New ContentDialog
            dialog.Title = "Account Creation"
            dialog.Content = "Please input all of the required field then try again"
            dialog.CloseButtonText = "Ok"
            dialog.DefaultButton = ContentDialogButton.Close

            Await dialog.ShowAsync

        Else

            If AccountPassword.Password = AccountPasswordConfirm.Password Then
                Dim dialog As New ContentDialog
                dialog.Title = "Account Creation"
                dialog.Content = "Account Created"
                dialog.CloseButtonText = "Ok"
                dialog.DefaultButton = ContentDialogButton.Close


                _datalist_users.Load(_datalist_users_path)
                Dim root As XmlNode = _datalist_users.DocumentElement

                Dim user As XmlNode = _datalist_users.CreateElement("user")
                Dim u_type As XmlAttribute = _datalist_users.CreateAttribute("Type")
                Dim u_name As XmlAttribute = _datalist_users.CreateAttribute("Name")
                Dim u_username As XmlAttribute = _datalist_users.CreateAttribute("Username")
                Dim u_password As XmlAttribute = _datalist_users.CreateAttribute("Password")

                u_type.Value = AccountType.SelectionBoxItem.ToString
                u_name.Value = AccountName.Text
                u_password.Value = AccountPassword.Password
                u_username.Value = AccountUsername.Text

                user.Attributes.Append(u_type)
                user.Attributes.Append(u_name)
                user.Attributes.Append(u_username)
                user.Attributes.Append(u_password)

                root.AppendChild(user)

                _datalist_users.Save(_datalist_users_path)

                _admin_users.sidepane.IsPaneOpen = False

                Await dialog.ShowAsync

                _userList.Clear()
                _userList.ReadXml(_datalist_users_path)
                _admin_users.mainGrid.Items.Refresh()

            End If



        End If

        AccountName.Text = ""
        AccountPassword.Password = ""
        AccountPasswordConfirm.Password = ""
        AccountUsername.Text = ""
        AccountType.SelectedIndex = -1

    End Sub

    Private Sub detectWhiteSpace(sender As Object, e As TextChangedEventArgs)
        AccountUsername.Text = AccountUsername.Text.Replace(" ", String.Empty)
    End Sub

    Private Sub detectWhiteSpace(sender As Object, e As RoutedEventArgs)


    End Sub
End Class
