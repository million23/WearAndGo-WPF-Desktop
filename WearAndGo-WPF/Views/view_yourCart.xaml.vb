Class view_yourCart
    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainwindow.Width = actualW
        mainwindow.Height = actualH - 40
    End Sub
End Class
