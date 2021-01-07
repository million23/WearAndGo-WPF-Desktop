Imports System.Xml

Class cm_men_app
    Private Sub resizescrollviewer(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainscrollviewer.Width = actualW
        mainscrollviewer.Height = actualH - 40
    End Sub

    Private Sub getData(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
