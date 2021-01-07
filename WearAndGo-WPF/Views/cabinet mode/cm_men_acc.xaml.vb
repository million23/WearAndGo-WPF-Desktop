Class cm_men_acc
    Private Sub resizeChanged(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainscrollviewer.Width = actualW
        mainscrollviewer.Height = actualH - 40
    End Sub
End Class
