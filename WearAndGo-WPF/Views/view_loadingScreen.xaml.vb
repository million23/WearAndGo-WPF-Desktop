Imports System.Media
Imports System.Windows.Threading

Class view_loadingScreen

    Private timerTick As Integer = 0
    Private timerDis As New DispatcherTimer

    Private Sub pagLoad(sender As Object, e As RoutedEventArgs)

        timerDis.Interval = New TimeSpan(0, 0, 1)
        AddHandler timerDis.Tick, AddressOf timerTicks
        timerDis.Start()

    End Sub

    Private Sub timerTicks()
        timerTick += 1
        If timerTick >= 5 Then
            timerTick = 0
            timerDis.Stop()
            My.Application.MainWindow.FindName("mainFrame").Navigate(_view_hero)
        End If
    End Sub
End Class
