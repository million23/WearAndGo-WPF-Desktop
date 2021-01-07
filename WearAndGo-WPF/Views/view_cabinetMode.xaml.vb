Class view_cabinetMode

    Private Sub selectedPane(sender As ModernWpf.Controls.NavigationView, args As ModernWpf.Controls.NavigationViewItemInvokedEventArgs)
        Select Case mainNav.SelectedItem.Tag
            Case "map"
                cabinetFrame.Content = _cm_men_app
            Case "mac"
                cabinetFrame.Content = _cm_men_acc
            Case "mfw"
                cabinetFrame.Content = _cm_men_ftw
            Case "wap"
                cabinetFrame.Content = _cm_wom_app
            Case "wac"
                cabinetFrame.Content = _cm_wom_acc
            Case "wft"
                cabinetFrame.Content = _cm_wom_ftw

            Case Else

        End Select
    End Sub
End Class
