﻿Imports System.Xml
Imports System.Media

Class MainWindow
    Private Sub pageLoad(sender As Object, e As RoutedEventArgs)
        My.Application.MainWindow.FindName("mainFrame").content = _view_loadingScreen

        ' load user list
        _userList.ReadXml(_datalist_users_path)
        _itemlist_generate_Columns()
        _itemlist_getDatatable()

        'delete all cart items on startup
        _datalist_cart.Load(_datalist_cart_path)
        Dim cartRoot As XmlNode = _datalist_cart.DocumentElement
        If cartRoot.HasChildNodes Then
            cartRoot.RemoveAll()
            _datalist_cart.Save(_datalist_cart_path)
        End If


    End Sub

    Private Sub PageClosing(sender As Object, e As ComponentModel.CancelEventArgs)
        _view_yourCart.ForceClearCart(False, True)
    End Sub
End Class
