﻿Class cm_men_app
    Private Sub resizescrollviewer(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        Dim actualW = My.Application.MainWindow.ActualWidth

        mainscrollviewer.Width = actualW
        mainscrollviewer.Height = actualH - 100
    End Sub
End Class
