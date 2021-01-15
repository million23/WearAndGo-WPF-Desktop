Imports System.Xml

Class admin_itemList

    Private Sub getData(sender As Object, e As RoutedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        scrollViewer.Height = actualH - 150

        grid_app.ItemsSource = _datatable_app.DefaultView
        grid_acc.ItemsSource = _datatable_acc.DefaultView
        grid_ftw.ItemsSource = _datatable_ftw.DefaultView

        _admin_itemList.scrollViewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_addItem.scrollviewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_removeItem.scrollviewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_updateItem.scrollviewer.Height = actualH - 150
    End Sub

    Private Sub resizeWindow(sender As Object, e As SizeChangedEventArgs)
        Dim actualH = My.Application.MainWindow.ActualHeight
        scrollViewer.Height = actualH - 100
        _admin_itemList.scrollViewer.Height = actualH - 100
        _admin_itemList.scrollViewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_addItem.scrollviewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_removeItem.scrollviewer.Height = actualH - 150
        _admin_inventory_sidepane_itemlist_updateItem.scrollviewer.Height = actualH - 150
    End Sub

    Private Sub AddItem(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = _admin_inventory_sidepane_itemlist_addItem
    End Sub
    Private Sub RemoveItem(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = _admin_inventory_sidepane_itemlist_removeItem
    End Sub
    Private Sub UpdateItem(sender As Object, e As RoutedEventArgs)
        sidepane.IsPaneOpen = True
        sidepaneFrame.Content = _admin_inventory_sidepane_itemlist_updateItem
    End Sub
End Class
