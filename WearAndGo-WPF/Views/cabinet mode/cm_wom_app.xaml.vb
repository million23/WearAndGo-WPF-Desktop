Imports System.Xml

Class cm_wom_app
    Private Sub resizescrollviewer(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainscrollviewer.Width = actualW
        mainscrollviewer.Height = actualH - 75
    End Sub

    Private Sub getData(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
