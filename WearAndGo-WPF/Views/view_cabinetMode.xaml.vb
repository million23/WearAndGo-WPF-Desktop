Class view_cabinetMode

    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)

    End Sub

    Private Sub selectedPane(sender As ModernWpf.Controls.NavigationView, args As ModernWpf.Controls.NavigationViewItemInvokedEventArgs)
        Select Case mainNav.SelectedItem.Tag
            Case "map"
                cabinetFrame.Navigate(_cm_men_app)
            Case "mac"
                cabinetFrame.Navigate(_cm_men_acc)
            Case "mfw"
                cabinetFrame.Navigate(_cm_men_ftw)
            Case "wap"
                cabinetFrame.Navigate(_cm_wom_app)
            Case "wac"
                cabinetFrame.Navigate(_cm_wom_acc)
            Case "wft"
                cabinetFrame.Navigate(_cm_wom_ftw)
            Case "cart"
                cabinetFrame.Navigate(_view_yourCart)

            Case Else

        End Select
    End Sub

    Private Sub pageLoad(sender As Object, e As RoutedEventArgs)
        cabinetFrame.Navigate(_view_yourCart)
    End Sub

End Class
