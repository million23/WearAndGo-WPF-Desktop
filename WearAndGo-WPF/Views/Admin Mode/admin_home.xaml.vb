Imports System.Xml

Class admin_home

    Private Sub getData(sender As Object, e As RoutedEventArgs)
        timeLabel.Text = "Today is " + Now.ToLongDateString
        nameLabel.Text = "Hello, " + My.Settings.activeUser + "!"

        _datalist_history.Load(_datalist_history_path)
        Dim historyRoot As XmlNode = _datalist_history.DocumentElement

        recent_date.Text = historyRoot.LastChild.Attributes(0).Value
        recent_id.Text = historyRoot.LastChild.Attributes(1).Value
        recent_total.Text = "PHP " + historyRoot.LastChild.Attributes(2).Value

        If historyRoot.LastChild.ChildNodes.Count > 1 Then
            recent_itemCount.Text = "The last client bought " + historyRoot.LastChild.ChildNodes.Count.ToString + " items"
        Else
            recent_itemCount.Text = "The last client bought " + historyRoot.LastChild.ChildNodes.Count.ToString + " item"
        End If
    End Sub
End Class
