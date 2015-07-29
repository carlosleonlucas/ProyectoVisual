Imports System.Xml

Public Class Administrador
    Inherits Usuario



    Sub New(tipoUsuario As String, id As String, nombre As String, usuario As String, clave As String)

        MyBase.New(tipoUsuario, id, nombre, usuario, clave)
    End Sub

    Public Function datosRestaXml(ruta As String, listaRestaurantes As ArrayList, listaCategorias As ArrayList, listausu As ArrayList)
        Dim restau



        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        ' *****************************************************************************************************
        Dim usuarios As XmlNodeList = xmlDoc.GetElementsByTagName("usuarios")
        For Each usuarioss As XmlNode In usuarios
            For Each usuarioTipo As XmlNode In usuarioss
                Select Case usuarioTipo.Name

                    Case "asistentes"
                        For Each usuarioAsist As XmlNode In usuarioTipo
                            Dim tipoUsuario = usuarioAsist.Name
                            Dim idUsuAsist = usuarioAsist.Attributes(0).Value
                            Dim usuarioUsuAsist = usuarioAsist.Attributes(1).Value
                            Dim claveUsuAsist = usuarioAsist.Attributes(2).Value
                            Dim nombreUsuAsist = usuarioAsist.InnerText
                            Dim asist = New Asistente(tipoUsuario, idUsuAsist, nombreUsuAsist, usuarioUsuAsist, claveUsuAsist)
                            listausu.Add(asist)
                        Next

                    Case Else

                End Select
            Next
        Next
        ' *****************************************************************************************************
        Dim restaurantes As XmlNodeList = xmlDoc.GetElementsByTagName("restaurantes")
        Dim idResta, nomResta, asisIdResta, dirResta, telResta, dueResta As String
        For Each restaurantess As XmlNode In restaurantes
            For Each restauranteSimple As XmlNode In restaurantess
                Select Case restauranteSimple.Name
                    Case "restaurante"
                        idResta = restauranteSimple.Attributes(0).Value
                        nomResta = restauranteSimple.Attributes(1).Value
                        asisIdResta = restauranteSimple.Attributes(2).Value

                        For Each restaurantePropiedades As XmlNode In restauranteSimple.ChildNodes
                            Select Case restaurantePropiedades.Name
                                Case "direccion"
                                    dirResta = restaurantePropiedades.InnerText
                                Case "telefono"
                                    telResta = restaurantePropiedades.InnerText
                                Case "duenio"
                                    dueResta = restaurantePropiedades.InnerText
                                Case Else
                            End Select

                        Next
                        restau = New Restaurante(idResta, nomResta, obtenerUsuarioPorId(asisIdResta, listausu), dirResta, telResta, dueResta)
                        listaRestaurantes.Add(restau)
                    Case Else
                End Select
            Next
        Next
        '' *****************************************************************************************************
        'Dim categorias As XmlNodeList = xmlDoc.GetElementsByTagName("categorias")
        'Dim idCat, nombreCat As String
        'Dim idPlati, nombrePlati, resIdPlati, tempePlati, tipoPlati, descriPlati As String

        'For Each categoriass As XmlNode In categorias

        '    For Each categoriaSimple As XmlNode In categoriass
        '        idCat = categoriaSimple.Attributes(0).Value
        '        nombreCat = categoriaSimple.Attributes(1).Value
        '        Dim cate As Categoria = New Categoria(idCat, nombreCat)

        '        For Each plati As XmlNode In categoriaSimple
        '            idPlati = plati.Attributes(0).Value
        '            nombrePlati = plati.Attributes(1).Value
        '            resIdPlati = plati.Attributes(2).Value
        '            tempePlati = plati.Attributes(3).Value
        '            tipoPlati = plati.Attributes(4).Value
        '            descriPlati = plati.InnerText
        '            Dim platil As Platillo = New Platillo(idPlati, nombrePlati, GetRestauranteById(resIdPlati), tempePlati, tipoPlati, descriPlati, cate)

        '            cate.AgregarPlatillo(platil)

        '        Next
        '        listaCategorias.Add(cate)
        '    Next
        'Next

        Return restau
    End Function

    Public Sub listarRestaurantes(lista As ArrayList, listausu As ArrayList, lista2 As ArrayList)
        Console.WriteLine("Lista de Restaurantes: ")
        Console.WriteLine("")
        Console.WriteLine("")
        For Each res As Restaurante In lista
            Console.WriteLine("")
            Console.WriteLine("")
            Console.WriteLine("+--------------------------------------------------------------------------+")
            Console.WriteLine("|".PadRight(75) & "|")
            Console.WriteLine("|".PadRight(20) & "Restaurante:".PadRight(16) + res.Nombre.PadRight(39) & "|")
            Console.WriteLine("|".PadRight(75) & "|")
            Console.WriteLine("+--------------------------------------------------------------------------+")
            Console.WriteLine("| Dirección:".PadRight(16) + res.Direccion.PadRight(59) & "|")
            Console.WriteLine("| Teléfono:".PadRight(16) + res.Telefono.PadRight(59) & "|")
            Console.WriteLine("| Dueño:".PadRight(16) + res.Dueno.PadRight(59) & "|")
            Dim asis As Asistente = obtenerUsuarioPorId(res.Asistente.Id, listausu)
            Console.WriteLine("| Asistente:".PadRight(16) + asis.Nombre.PadRight(59) & "|")
            Console.WriteLine("| ".PadRight(75) & "|")
            Console.WriteLine("+--------------------------------------------------------------------------+")
            Console.WriteLine("| Platillos ofrecidos: ".PadRight(75) & "|")
            Console.WriteLine("|".PadRight(75) & "|")
            For Each catt As Categoria In lista2


                For Each plati As Platillo In catt.ListaPlatillos
                    Console.WriteLine("|    Nombre:".PadRight(22) + plati.Nombre.PadRight(53) & "|")
                    Console.WriteLine("|    Descripción:".PadRight(22) + plati.Descripcion.PadRight(53) & "|")
                    Console.WriteLine("|    Categoria:".PadRight(22) + plati.Categoria.Nombre.PadRight(53) & "|")
                    Console.WriteLine("|    Tipo:".PadRight(22) + plati.Tipo.PadRight(53) & "|")
                    Console.WriteLine("|".PadRight(75) & "|")
                    Console.WriteLine("|".PadRight(75) & "|")
                Next

            Next
            Console.WriteLine("+--------------------------------------------------------------------------+")
        Next
    End Sub

    Public Function obtenerUsuarioPorId(id As String, lista As ArrayList)
        For Each usu As Usuario In lista
            If usu.Id = id Then
                Return usu
            End If
        Next
        Return 0
    End Function

End Class
