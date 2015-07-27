Imports System.Xml

Public Class Administrador
    Inherits Usuario



    Sub New(tipoUsuario As String, id As String, nombre As String, usuario As String, clave As String)

        MyBase.New(tipoUsuario, id, nombre, usuario, clave)
    End Sub

    Public Function datosRestaXml(ruta As String)

        Dim restau As Restaurante = New Restaurante()
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim restaurantes As XmlNodeList = xmlDoc.GetElementsByTagName("restaurantes")
        Dim idResta, nomResta, asisIdResta, dirResta, telResta, dueResta As String
        For Each restaurantess As XmlNode In restaurantes
            For Each restauranteSimple As XmlNode In restaurantess
                Select Case restauranteSimple.Name
                    Case "restaurante"

                        idResta = restauranteSimple.Attributes(0).Value
                        nomResta = restauranteSimple.Attributes(1).Value
                        asisIdResta = restauranteSimple.Attributes(2).Value


                        'idResta = restauranteSimple.Attributes(0).Value
                        'nomResta = restauranteSimple.Attributes(1).Value
                        'asisIdResta = restauranteSimple.Attributes(2).Value

                        For Each restaurantePropiedades As XmlNode In restauranteSimple.ChildNodes

                            Select Case restaurantePropiedades.Name
                                Case "direccion"

                                    dirResta = restaurantePropiedades.InnerText
                                    'dirResta = restaurantePropiedades.InnerText
                                Case "telefono"
                                    telResta = restaurantePropiedades.InnerText
                                    'telResta = restaurantePropiedades.InnerText
                                Case "duenio"
                                    dueResta = restaurantePropiedades.InnerText
                                    'dueResta = restaurantePropiedades.InnerText
                                Case Else

                            End Select

                        Next
                        restau = New Restaurante(idResta, nomResta, asisIdResta, dirResta, telResta, dueResta)

                    Case Else

                End Select
                'Console.WriteLine("Restaurante--- id: {0}, nombre: {1}, asis: {2}, dir: {3}, tel: {4}, due: {5}", idResta, nomResta, asisIdResta, dirResta, telResta, dueResta)

            Next
            Dim resta As New Restaurante(idResta, nomResta, asisIdResta, dirResta, telResta, dueResta)
            'listaRestaurantes.Add(resta)
        Next
        ' *****************************************************************************************************
        ' *****************************************************************************************************
        ' *****************************************************************************************************
        Dim categorias As XmlNodeList = xmlDoc.GetElementsByTagName("categorias")
        Dim idCat, nombreCat As String
        Dim idPlati, nombrePlati, resIdPlati, tempePlati, tipoPlati, descriPlati As String

        For Each categoriass As XmlNode In categorias

            For Each categoriaSimple As XmlNode In categoriass
                idCat = categoriaSimple.Attributes(0).Value
                nombreCat = categoriaSimple.Attributes(1).Value
                Dim cate As Categoria = New Categoria(idCat, nombreCat)

                For Each plati As XmlNode In categoriaSimple
                    idPlati = plati.Attributes(0).Value
                    nombrePlati = plati.Attributes(1).Value
                    resIdPlati = plati.Attributes(2).Value
                    tempePlati = plati.Attributes(3).Value
                    tipoPlati = plati.Attributes(4).Value
                    descriPlati = plati.InnerText
                    Dim platil As Platillo = New Platillo(idPlati, nombrePlati, resIdPlati, tempePlati, tipoPlati, descriPlati, cate)

                    cate.AgregarPlatillo(platil)
                    restau.AgregarPlatillo(platil)


                Next
                restau.AgregarCategoria(cate)
            Next
        Next

        Return restau
    End Function

    Public Sub listarRestaurantes(lista As ArrayList, listausu As ArrayList)
        Console.WriteLine("Lista de Restaurantes: ")
        For Each res As Restaurante In lista
            Console.WriteLine("*******************************************")
            Console.WriteLine("**                                       **")
            Console.WriteLine("**                                       **")
            Console.WriteLine("* Nombre: " + res.Nombre)
            Console.WriteLine("* Dirección: " + res.Direccion)
            Console.WriteLine("* Teléfono: " + res.Telefono)
            Console.WriteLine("* Dueño: " + res.Dueno)
            Dim asis As Asistente = obtenerUsuarioPorId(res.AsistenteId, listausu)
            Console.WriteLine("* Asistente: " + asis.Nombre)
            Console.WriteLine("* ")
            Console.WriteLine("* Platillos ofrecidos: ")
            For Each plati As Platillo In res.Platillos
                Console.WriteLine("*    Nombre: " + plati.Nombre)
                Console.WriteLine("*    Descripción: " + plati.Descripcion)
                Console.WriteLine("*    Categoria: " + plati.Categoria.Nombre)
                Console.WriteLine("*    Tipo: " + plati.Tipo)
                Console.WriteLine("**                                       **")
                Console.WriteLine("**                                       **")
            Next

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
