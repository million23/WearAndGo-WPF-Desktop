Imports System.Xml

Class MainWindow
    Private Sub pageLoad(sender As Object, e As RoutedEventArgs)
        My.Application.MainWindow.FindName("mainFrame").content = _view_hero

        'preloads all assets for the cabinet mode
        'apparel
        _cm_men_app.wrapContainer.Children.Clear()
        _itemlist_app.Load(_itemlist_app_path)
        Dim app_root As XmlNode = _itemlist_app.DocumentElement
        For Each item As XmlNode In app_root
            'men
            If item.Attributes(1).Value = "men" Then
                Dim card As New card_app

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_men_app.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_app

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_wom_app.wrapContainer.Children.Add(card)
            End If
        Next

        'men
        _cm_men_acc.wrapContainer.Children.Clear()
        _itemlist_acc.Load(_itemlist_acc_path)
        Dim Macc_root As XmlNode = _itemlist_acc.DocumentElement
        For Each item As XmlNode In Macc_root
            'men
            If item.Attributes(1).Value = "men" Then
                Dim card As New card_acc

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemVariant.Text = item("desc").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_men_acc.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_acc

                card.mainCard.ToolTip = item("name").InnerXml
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemVariant.Text = item("desc").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_wom_acc.wrapContainer.Children.Add(card)
            End If
        Next

        'footwear
        _cm_men_ftw.wrapContainer.Children.Clear()
        _itemlist_ftw.Load(_itemlist_ftw_path)
        Dim Mftw_root As XmlNode = _itemlist_ftw.DocumentElement

        For Each item As XmlNode In Mftw_root
            'men
            If item.Attributes(1).Value = "men" Then
                Dim card As New card_ftw

                card.mainCard.ToolTip = item("name").InnerText
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_men_ftw.wrapContainer.Children.Add(card)
            End If
            'women
            If item.Attributes(1).Value = "wom" Then
                Dim card As New card_ftw

                card.mainCard.ToolTip = item("name").InnerText
                card.itemName.Text = item("name").InnerXml
                card.itemID.Text = item.Attributes(2).Value
                card.itemPrice.Text = item("price").InnerXml
                card.itemSize.Text = item("size").InnerXml
                card.itemImage.Source = New BitmapImage(New Uri(item("image").InnerXml))

                _cm_wom_ftw.wrapContainer.Children.Add(card)
            End If
        Next



    End Sub
End Class
