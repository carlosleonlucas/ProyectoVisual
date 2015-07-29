Imports System.Xml


Module Module1
    Dim listaUsuarios As ArrayList = New ArrayList()
    Dim listaRestaurantes As ArrayList = New ArrayList()
    Dim listaCategorias As ArrayList = New ArrayList()

    Dim clien As Cliente
    Dim asist As Asistente
    Dim admin As Administrador

    Dim tipoUsuario As String
    Dim categ As String

    Sub Main()

        'Dim rutaXml As New String("C:\Users\Carlos Leon\Desktop\ProyectoVisual\ProyectoPrimerParcial\aaa.xml")
        Dim rutaXml As New String("D:\sistemaPlatillos2.xml")


        cargarXml(rutaXml)

        Console.WriteLine("Restaurantes: ")
        For Each res As Restaurante In listaRestaurantes
            Console.WriteLine(res.Nombre & vbTab & res.Asistente.Nombre)
        Next
        Console.WriteLine("Usuarios: ")
        For Each usuario As Usuario In listaUsuarios
            Console.WriteLine(usuario.Usuario)
        Next

        Console.WriteLine("Categorias: ")
        For Each cate As Categoria In listaCategorias
            Console.WriteLine(cate.Nombre)
            Console.WriteLine(vbTab & "Platillos: ")
            For Each platillo As Platillo In cate.ListaPlatillos

                Console.WriteLine(vbTab & platillo.Nombre)
            Next
        Next


        
        Menu()

        'Console.ReadLine()
    End Sub

    Public Sub cargarXml(ruta As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        ' *****************************************************************************************************
        Dim usuarios As XmlNodeList = xmlDoc.GetElementsByTagName("usuarios")
        For Each usuarioss As XmlNode In usuarios
            For Each usuarioTipo As XmlNode In usuarioss
                Select Case usuarioTipo.Name
                    Case "administradores"
                        For Each usuarioAdmin As XmlNode In usuarioTipo
                            Dim tipoUsuario = usuarioAdmin.Name
                            Dim idUsuAdmin = usuarioAdmin.Attributes(0).Value
                            Dim usuarioUsuAdmin = usuarioAdmin.Attributes(1).Value
                            Dim claveUsuAdmin = usuarioAdmin.Attributes(2).Value
                            Dim nombreUsuAdmin = usuarioAdmin.InnerText
                            admin = New Administrador(tipoUsuario, idUsuAdmin, nombreUsuAdmin, usuarioUsuAdmin, claveUsuAdmin)
                            listaUsuarios.Add(admin)

                        Next
                    Case "asistentes"
                        For Each usuarioAsist As XmlNode In usuarioTipo
                            Dim tipoUsuario = usuarioAsist.Name
                            Dim idUsuAsist = usuarioAsist.Attributes(0).Value
                            Dim usuarioUsuAsist = usuarioAsist.Attributes(1).Value
                            Dim claveUsuAsist = usuarioAsist.Attributes(2).Value
                            Dim nombreUsuAsist = usuarioAsist.InnerText
                            asist = New Asistente(tipoUsuario, idUsuAsist, nombreUsuAsist, usuarioUsuAsist, claveUsuAsist)
                            listaUsuarios.Add(asist)
                        Next
                    Case "clientes"
                        For Each usuarioClien As XmlNode In usuarioTipo
                            Dim tipoUsuario = usuarioClien.Name
                            Dim idUsuClien = usuarioClien.Attributes(0).Value
                            Dim usuarioUsuClien = usuarioClien.Attributes(1).Value
                            Dim claveUsuClien = usuarioClien.Attributes(2).Value
                            Dim nombreUsuClien = usuarioClien.InnerText
                            clien = New Cliente(tipoUsuario, idUsuClien, nombreUsuClien, usuarioUsuClien, claveUsuClien)
                            listaUsuarios.Add(clien)
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

                        listaRestaurantes.Add(New Restaurante(idResta, nomResta, GetUsuarioById(asisIdResta), dirResta, telResta, dueResta))
                    Case Else
                End Select
            Next
        Next
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
                    Dim platil As Platillo = New Platillo(idPlati, nombrePlati, GetRestauranteById(resIdPlati), tempePlati, tipoPlati, descriPlati, cate)

                    cate.AgregarPlatillo(platil)

                Next
                listaCategorias.Add(cate)
            Next
        Next
    End Sub

    Public Sub Menu()
        Dim input As Integer
        Dim usuarioActivo As Usuario
        Dim usuario, contrasenia, idAux As String

        Do
            'Console.Clear()
            Console.WriteLine("Catálogo de Delicias ")
            Console.Write("Nombre de usuario: ")
            usuario = Console.ReadLine()
            Console.Write("Contraseña: ")
            contrasenia = Console.ReadLine()
            idAux = ExisteUsuario(usuario, contrasenia)
        Loop While idAux = "No existe"

        usuarioActivo = GetUsuarioById(idAux)

        tipoUsuario = usuarioActivo.tipUsu

        Select Case tipoUsuario
            Case "cliente"
                Do
                    'menuClienteActual = "menu0"
                    'While menuClienteActual = "menu0"
                    Console.Clear()
                    Console.WriteLine("1) Listar categorías de platillos")
                    Console.WriteLine("2) Buscar platillo")
                    Console.WriteLine("3) Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    Try
                        input = Integer.Parse(Console.ReadLine())
                        If input = "1" Then

                        End If
                    Catch ex As Exception
                    End Try
                    Select Case input
                        Case 1
                            'menuClienteActual = "menu1"
                            'While menuClienteActual = "menu1"
                            Dim inputt As Integer
                            Console.Clear()
                            ListarCategorias()
                            Console.WriteLine("1) Mostrar platillos ")
                            Console.WriteLine("2) Regresar")
                            Console.Write("Ingrese una opción: ")

                            Try
                                inputt = Integer.Parse(Console.ReadLine())
                            Catch ex As Exception
                            End Try
                            Select Case inputt
                                Case 1
                                    'menuClienteActual = "menu1.1"
                                    'While menuClienteActual = "menu1.1"
                                    'categ = Console.ReadLine()
                                    Console.WriteLine(ControlChars.NewLine)
                                    MostrarPlatillos(usuarioActivo)
                                    Console.WriteLine(ControlChars.NewLine)
                                    Console.WriteLine("1) Mostrar info de platillo de la lista anterior ")
                                    Console.WriteLine("2) Regresar")
                                    Console.Write("Ingrese una opción: ")

                                    Dim inmp As Integer
                                    Try
                                        inmp = Console.ReadLine()
                                    Catch ex As Exception
                                    End Try
                                    Select Case inmp

                                        Case 1
                                            'menuClienteActual = "menu1.1.1"
                                            'While menuClienteActual = "menu1.1.1"
                                            Dim platiID As Integer
                                            Console.WriteLine(ControlChars.NewLine)
                                            Console.Write("Ingrese el ID del platillo: ")
                                            Try
                                                platiID = CInt(Console.ReadLine())
                                            Catch ex As Exception
                                            End Try
                                            Console.Clear()
                                            MostrarPlatillo(platiID)
                                            'End While

                                        Case 2
                                            'menuClienteActual = "menu1.1"
                                            Exit Select
                                        Case Else
                                            Console.WriteLine("Dato incorrecto , presione ENTER")
                                    End Select
                                    'End While
                                Case 2
                                    Console.Clear()
                                    'menuClienteActual = "menu0"
                                    Exit Select
                                    Exit Select
                                Case Else
                                    Console.Write("Opción incorrecta, Presione ENTER para volver a intentarlo")
                                    Console.ReadLine()
                            End Select
                            Console.Write("Presione ENTER para regresar")
                            'End While
                        Case 2
                            'menuClienteActual = "menu2"
                            'While menuClienteActual = "menu2"
                            '    Console.Clear()
                            Console.WriteLine("Ingrese parte del nombre o descripción de platillo a buscar: ")
                            Dim inf As String = Console.ReadLine()
                            buscar(inf)
                            Console.WriteLine(ControlChars.NewLine)
                            Console.WriteLine("1) Mostrar platillo (Seleccionar platillo)")
                            Console.WriteLine("2) Regresar")
                            Console.Write("Ingrese una opción: ")
                            Dim inp As Integer
                            Try
                                inp = CInt(Console.ReadLine)
                            Catch ex As Exception
                            End Try
                            Select Case inp
                                Case 1
                                    'menuClienteActual = "menu2.1"
                                    'While menuClienteActual = "menu2.1"
                                    Console.WriteLine(ControlChars.NewLine)

                                    Console.Write("Seleccione el id del platillo a mostrar: ")
                                    Dim idplat As Integer
                                    Try
                                        idplat = CInt(Console.ReadLine)
                                    Catch ex As Exception
                                    End Try
                                    MostrarPlatillo(idplat)
                                    Console.WriteLine("Presione ENTER para volver")
                                    Console.ReadLine()
                                    'End While

                                Case 2

                                    'menuClienteActual = "menu2"
                                    Exit Select
                                Case Else
                                    Console.WriteLine("Dato incorrecto , presione ENTER")
                            End Select
                            'End While

                        Case 3
                            Console.Clear()
                            'menuClienteActual = "salida"
                            Exit Select
                            Exit Select
                        Case Else
                            Console.Write("Opción incorrecta, Presione ENTER para volver a intentarlo")

                    End Select
                    'End While


                Loop Until (input = "3")
                ' ****************************************************************************************************************************************************
            Case "asistente"
                Do
                    Console.Clear()
                    Console.WriteLine("1) Agregar platillo")
                    Console.WriteLine("2) Listar platillos (de mi restaurante)")
                    Console.WriteLine("3) Listar categorías de platillos")
                    Console.WriteLine("4) Log Out")
                    Console.WriteLine("5) Salir del sistema")
                    Console.Write(vbNewLine & "Ingrese una opción (1-5): ")
                    Try
                        input = Integer.Parse(Console.ReadLine())
                        Select Case input
                            Case 1
                                Console.Clear()
                                Console.WriteLine("1) Agregar platillo")
                                AsisAgregarPlatillo(usuarioActivo.Id)

                                Console.WriteLine(vbNewLine & "Platillo Ingresado con éxito")
                                Console.Write("Presione ENTER para regresar...")
                                Console.ReadLine()
                            Case 2
                                Do
                                    Console.Clear()
                                    Console.WriteLine("2) Listar platillos (de mi restaurante)")
                                    AsisListarPlatillo(usuarioActivo.Id)

                                    Console.WriteLine(vbNewLine & "1. Mostrar platillo (escoger platillo de mi restaurante)")
                                    Console.WriteLine("2. Modificar/actualizar platillo (escoger platillo de mi restaurante)")
                                    Console.WriteLine("3. Regresar")
                                    Console.Write(vbNewLine & "Ingrese una opción (1-3): ")

                                    Try
                                        input = Integer.Parse(Console.ReadLine())

                                        Select Case input
                                            Case 1
                                                Console.WriteLine(vbNewLine & "1. Mostrar platillo (escoger platillo de mi restaurante)" & vbNewLine)

                                                AsisMostrarPlatillo(usuarioActivo.Id)

                                                Console.Write(vbNewLine & "Presione ENTER para regresar...")
                                                Console.ReadLine()
                                            Case 2
                                                Console.WriteLine(vbNewLine & "2. Modificar/actualizar platillo (escoger platillo de mi restaurante)" & vbNewLine)

                                                AsisModificarPlatillo(usuarioActivo.Id)

                                                Console.WriteLine(vbNewLine & "Platillo Actualizado con éxito")
                                                Console.Write("Presione ENTER para regresar...")
                                                Console.ReadLine()
                                            Case 3

                                            Case Else
                                                Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar   ELSE")
                                                Console.ReadLine()
                                                Console.Clear()
                                        End Select

                                    Catch ex As Exception
                                        Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar  CATCH")
                                        Console.ReadLine()
                                        Console.Clear()
                                    End Try

                                Loop Until (input = "3")

                            Case 3
                                Do
                                    Console.Clear()
                                    Console.WriteLine("3) Listar categorías de platillos")
                                    ListarCategorias()

                                    Console.WriteLine(vbNewLine & "1. Mostrar platillos (escoger categoría)")
                                    Console.WriteLine("2. Regresar")
                                    Console.Write(vbNewLine & "Ingrese una opción (1-2): ")
                                    Try
                                        input = Integer.Parse(Console.ReadLine())

                                        Select Case input
                                            Case 1
                                                Do
                                                    Console.WriteLine(vbNewLine & "1. Mostrar platillos (escoger categoría)")

                                                    MostrarPlatillos(usuarioActivo)

                                                    Console.WriteLine(vbNewLine & "1.1. Mostrar platillo (escoger platillo de mi restaurante)")
                                                    Console.WriteLine("1.2. Modificar/actualizar platillo (escoger platillo de mi restaurante)")
                                                    Console.WriteLine("1.3. Regresar")
                                                    Console.Write(vbNewLine & "Ingrese una opción (1-3): ")
                                                    Try
                                                        input = Integer.Parse(Console.ReadLine())

                                                        Select Case input
                                                            Case 1

                                                                Console.WriteLine(vbNewLine & "1.1. Mostrar platillo (escoger platillo de mi restaurante)")

                                                                AsisMostrarPlatillo(usuarioActivo.Id)

                                                                Console.Write(vbNewLine & "Presione ENTER para regresar...")
                                                                Console.ReadLine()
                                                            Case 2
                                                                Console.WriteLine(vbNewLine & "1.2. Modificar/actualizar platillo (escoger platillo de mi restaurante)" & vbNewLine)

                                                                AsisModificarPlatillo(usuarioActivo.Id)

                                                                Console.WriteLine(vbNewLine & "Platillo Actualizado con éxito")
                                                                Console.Write("Presione ENTER para regresar...")
                                                                Console.ReadLine()
                                                            Case 3

                                                            Case Else
                                                                Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                                                                Console.ReadLine()
                                                        End Select

                                                    Catch ex As Exception
                                                        Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                                                        Console.ReadLine()

                                                    End Try

                                                Loop Until (input = "3")

                                            Case 2

                                            Case Else
                                                Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                                                Console.ReadLine()
                                                Console.Clear()
                                        End Select

                                    Catch ex As Exception
                                        Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                                        Console.ReadLine()
                                        Console.Clear()
                                    End Try

                                Loop Until (input = "2")

                            Case 4
                                Console.Clear()

                                Menu()
                            Case 5
                                End
                            Case Else
                                Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                                Console.ReadLine()
                        End Select

                    Catch ex As Exception
                        Console.WriteLine("ERROR, ingrese una opcion correcta, presione ENTER para volver a intentar")
                        Console.ReadLine()
                    End Try

                Loop Until (input = "5")

                ' ****************************************************************************************************************************************************
            Case "administrador"
                Do
                    Console.Clear()
                    Console.WriteLine("1.- Agregar restaurante (desde XML) ")
                    Console.WriteLine("2.- Listar restaurante")
                    Console.WriteLine("3.- Log Out")
                    Console.WriteLine("4.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    input = Console.ReadLine()


                    Select Case input
                        Case 1
                            Console.Clear()
                            Console.WriteLine("Especifique la ruta del archivo XML")
                            Dim rutaArchivo = Console.ReadLine
                            Try
                                agregarRestauranteXml(obtenerUsuario(tipoUsuario), rutaArchivo)
                                Console.WriteLine("Restaurante agregado")
                            Catch ex As Exception
                                Console.WriteLine("No se encontró archivo XML")
                            End Try
                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()


                        Case 2
                            Console.Clear()
                            Console.WriteLine("2) Listar Restaurantes")
                            obtenerUsuario(tipoUsuario).listarRestaurantes(listaRestaurantes, listaUsuarios)

                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()
                        Case 3
                            Console.Clear()
                            Menu()
                        Case Else
                            Console.WriteLine("Opción inválida, por favor ingrese una opción válida")
                    End Select
                Loop Until (input = "4")


        End Select

    End Sub


    Public Function ExisteUsuario(usuario, contrasenia) As String
        Dim id As String = "No existe"

        For Each user As Usuario In listaUsuarios
            If user.Usuario = usuario And user.Clave = contrasenia Then
                id = user.Id
            End If
        Next

        If id = "No existe" Then
            Console.WriteLine("Nombre De usuario o contraseña incorrecto, Presione ENTER para volverlo a intentar.")
            Console.ReadLine()
        End If

        Return id
    End Function


    Public Sub agregarRestauranteXml(abc As Administrador, rutaNew As String)
        listaRestaurantes.Add(abc.datosRestaXml(rutaNew))
    End Sub


    Public Function obtenerUsuario(tipo As String)
        For Each usu As Usuario In listaUsuarios
            If tipo = usu.tipUsu Then
                Return usu
            End If
        Next
        Return 0
    End Function

    Public Sub ListarCategorias()
        Console.WriteLine(vbNewLine & "ID".PadRight(10) + "Título".PadRight(26) & "Número de platillos ofrecidos")
        Console.WriteLine("--------------------------------------------------------")
        For Each categor As Categoria In listaCategorias
            Console.WriteLine(categor.Id.PadRight(10) + categor.Nombre.PadRight(26) & CStr(categor.ListaPlatillos.Count))
        Next
    End Sub

    Public Sub MostrarPlatillos(usuarioActivo As Usuario)

        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(usuarioActivo.Id)
        Dim idCategoriaIngresada As String
        Dim cont As Integer = 0
        Console.Clear()
        ListarCategorias()
        Console.Write(vbNewLine & "Escoja el ID de una categoría: ")

        idCategoriaIngresada = Console.ReadLine()
        Console.Clear()
        Select Case usuarioActivo.tipUsu
            Case "cliente"
                Console.WriteLine(vbNewLine & "ID".PadRight(8) & "Nombre".PadRight(32) & "Restaurante")
                Console.WriteLine("--------------------------------------------------------")

                For Each categoria As Categoria In listaCategorias
                    For Each plato As Platillo In categoria.ListaPlatillos
                        If idCategoriaIngresada = categoria.Id Then
                            Console.WriteLine(plato.Id.ToString.PadRight(8) & plato.Nombre.PadRight(32) & plato.Restaurante.Nombre)
                            cont = cont + 1
                        End If
                    Next
                Next
                If cont = 0 Then
                    Console.WriteLine("NULL".ToString.PadRight(8) & "NULL".PadRight(32) & "NULL")
                    Console.WriteLine(vbNewLine & "No existe un platillo con esa ID o no tiene los permisos")
                End If

            Case "asistente"
                Console.WriteLine(vbNewLine & "Restaurante: ".PadRight(16) & restauranteAsociado.Nombre)
                Console.WriteLine(vbNewLine & "ID".PadRight(8) & "Nombre".PadRight(32))
                Console.WriteLine("--------------------------------------------------------")

                For Each categoria As Categoria In listaCategorias
                    For Each plato As Platillo In categoria.ListaPlatillos
                        If plato.Restaurante Is restauranteAsociado Then
                            If idCategoriaIngresada = categoria.Nombre Then
                                Console.WriteLine(plato.Id.ToString.PadRight(8) & plato.Nombre.PadRight(32))
                                cont = cont + 1
                            End If
                        End If
                    Next
                Next
                If cont = 0 Then
                    Console.WriteLine("NULL".ToString.PadRight(8) & "NULL".PadRight(32))
                    Console.WriteLine(vbNewLine & "No existe un platillo con esa ID o no tiene los permisos")
                End If
        End Select
    End Sub

    Public Sub MostrarPlatillo(platillo)
        For Each categor As Categoria In listaCategorias
            'If categor.Id.ToString = categID.ToString Then
            For Each pla As Platillo In categor.ListaPlatillos
                If pla.Id.ToString = platillo.ToString Then
                    Console.WriteLine("-------------------------------------------------------------------------------")
                    Console.WriteLine("Nombre: ".PadRight(13) + pla.Nombre)
                    Console.WriteLine("Categoría: ".PadRight(13) + categor.Nombre)
                    Console.WriteLine("Descripción: ".PadRight(4) + pla.Descripcion)
                    Console.WriteLine("Tipo: ".PadRight(13) + pla.Tipo)
                    Console.WriteLine("Temperatura: ".PadRight(4) + pla.Temperatura)
                    For Each resta As Restaurante In listaRestaurantes
                        If resta.Id = pla.Restaurante.Id Then
                            Console.WriteLine("Restaurante: ".PadRight(4) + resta.Nombre)
                            Console.WriteLine("-------------------------------------------------------------------------------")

                        End If
                    Next
                End If

            Next



            'End If


        Next





    End Sub

    Public Sub buscar(info)
        For Each categor As Categoria In listaCategorias

            Dim total As Integer = categor.ListaPlatillos.Count - 1
            For i = 0 To total Step 1
                Dim platill As Platillo = categor.ListaPlatillos.Item(i)

                If platill.Nombre.Contains(info) Or platill.Descripcion.Contains(info) Then
                    Console.Write("ID: " + platill.Id + " ; " + platill.Nombre)
                    For Each resta As Restaurante In listaRestaurantes
                        If resta.Id = platill.Restaurante.Id Then
                            Console.WriteLine("; Restaurante: " + resta.Nombre)

                        End If
                    Next
                End If
            Next
        Next

    End Sub

    Public Function GetRestauranteByAsistente(idAsistente As String) As Restaurante
        For Each rest As Restaurante In listaRestaurantes
            If rest.Asistente.Id = idAsistente Then
                Return rest
            End If
        Next
        Return Nothing
    End Function

    Public Function GetRestauranteById(restauranteId As String) As Restaurante
        For Each rest As Restaurante In listaRestaurantes
            If rest.Id = restauranteId Then
                Return rest
            End If
        Next
        Return Nothing
    End Function

    Public Function GetUsuarioById(idUser As String) As Usuario
        For Each user As Usuario In listaUsuarios
            If user.Id = idUser Then
                Return user
            End If
        Next
        Return Nothing
    End Function

    Public Function GetCategoriaByNombre(nombreCat As String) As Categoria
        For Each cat As Categoria In listaCategorias
            If cat.Nombre = nombreCat Then
                Return cat
            End If
        Next
        Return Nothing
    End Function

    Public Sub AsisAgregarPlatillo(idAsistente As String)
        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(idAsistente)

        Dim nombrePlati, catPlati, tempePlati, tipoPlati, descriPlati As String

        Dim auxCat As Categoria
        Dim newCat As Categoria
        Dim newPlatillo As Platillo

        Console.Write("Nombre: ")
        nombrePlati = Console.ReadLine()
        Console.Write("Categoría: ")
        catPlati = Console.ReadLine()
        Console.Write("Descripción: ")
        descriPlati = Console.ReadLine()
        Console.Write("Temperatura {caliente, frío}: ")
        tempePlati = Console.ReadLine()
        Console.Write("Tipo {aperitivo, plato fuerte, postre}: ")
        tipoPlati = Console.ReadLine()

        auxCat = GetCategoriaByNombre(catPlati)

        If Not (auxCat Is Nothing) Then
            newPlatillo = New Platillo(nombrePlati, restauranteAsociado, tempePlati, tipoPlati, descriPlati, auxCat)
            auxCat.AgregarPlatillo(newPlatillo)
        Else
            newCat = New Categoria(catPlati)
            newPlatillo = New Platillo(nombrePlati, restauranteAsociado, tempePlati, tipoPlati, descriPlati, newCat)
            newCat.AgregarPlatillo(newPlatillo)
            listaCategorias.Add(newCat)
        End If

    End Sub


    Public Sub AsisListarPlatillo(idAsistente As String)
        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(idAsistente)

        Console.WriteLine(vbNewLine & "Restaurante: " & restauranteAsociado.Nombre & vbNewLine)
        Console.WriteLine("ID".PadRight(8) & "Nombre".PadRight(32) & "Categoría")
        Console.WriteLine("----------------------------------------------------------")

        For Each cat As Categoria In listaCategorias
            For Each plato As Platillo In cat.ListaPlatillos
                If plato.Restaurante Is restauranteAsociado Then
                    Console.WriteLine(plato.Id.ToString.PadRight(8) & plato.Nombre.ToString.PadRight(32) & plato.Categoria.Nombre)
                End If
            Next
        Next

    End Sub


    Public Sub AsisMostrarPlatillo(idAsistente As String)
        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(idAsistente)
        Dim idPlato As Integer
        Dim cont As Integer = 0

        Console.Write("Ingrese la ID del platillo: ")
        Try
            idPlato = Integer.Parse(Console.ReadLine)

            For Each cat As Categoria In listaCategorias
                For Each plato As Platillo In cat.ListaPlatillos
                    If plato.Restaurante Is restauranteAsociado Then
                        If plato.Id = idPlato.ToString Then
                            Console.WriteLine("-------------------------------------------------------------------------------")
                            Console.WriteLine("ID:".PadRight(18) & plato.Id)
                            Console.WriteLine("Nombre:".PadRight(18) & plato.Nombre)
                            Console.WriteLine("Restaurante:".PadRight(18) & plato.Restaurante.Nombre)
                            Console.WriteLine("Categoría:".PadRight(18) & plato.Categoria.Nombre)
                            Console.WriteLine("Temperatura:".PadRight(18) & plato.Temperatura)
                            Console.WriteLine("Tipo:".PadRight(18) & plato.Tipo)
                            Console.WriteLine("Descripción:".PadRight(18) & plato.Descripcion)
                            Console.WriteLine("-------------------------------------------------------------------------------")
                            cont = cont + 1
                        End If
                    End If
                Next
            Next

            If cont = 0 Then
                Console.WriteLine(vbNewLine & "No existe un platillo con esa ID o no tiene los permisos")
            End If

        Catch ex As Exception
            Console.WriteLine(vbNewLine & "ERROR, ID invalida. Vuelvalo a intentar")
        End Try

    End Sub


    Public Sub AsisModificarPlatillo(idAsistente As String)
        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(idAsistente)

        Dim idPlato As Integer
        Dim cont As Integer = 0

        Dim newNombre, newNombreCategoria, newTemperatura, newTipo, newDescripcion As String

        Console.WriteLine("Instrucciones: Ingrese el nuevo valor donde corresponda. Si no quiere modificar el valor, solo de ENTER para pasar al siguiente." & vbNewLine)
        Console.Write("Ingrese la ID del platillo: ")

        Try
            idPlato = Integer.Parse(Console.ReadLine)

            For Each cat As Categoria In listaCategorias
                For Each plato As Platillo In cat.ListaPlatillos
                    If plato.Restaurante Is restauranteAsociado And plato.Id = idPlato.ToString Then

                        Console.WriteLine("-------------------------------------------------------------------------------")

                        Console.Write("Nombre:".PadRight(18))
                        newNombre = Console.ReadLine()
                        If newNombre <> "" Then
                            plato.Nombre = newNombre
                        End If

                        Console.Write("Categoría:".PadRight(18))
                        newNombreCategoria = Console.ReadLine()
                        If (Not (newNombreCategoria Is "")) And Not (newNombreCategoria.Equals(plato.Categoria.Nombre)) Then
                            Dim newCategoria As Categoria = New Categoria(newNombreCategoria)
                            listaCategorias.Add(newCategoria)

                            newCategoria.AgregarPlatillo(plato)
                            plato.Categoria.EliminarPlatillo(plato)
                            plato.Categoria = newCategoria

                            'If cat.ListaPlatillos.Count = 0 Then
                            '    listaCategorias.Remove(cat)
                            'End If
                        End If

                        Console.Write("Temperatura:".PadRight(18))
                        newTemperatura = Console.ReadLine
                        If newTemperatura <> "" Then
                            plato.Temperatura = newTemperatura
                        End If

                        Console.Write("Tipo:".PadRight(18))
                        newTipo = Console.ReadLine
                        If newTipo <> "" Then
                            plato.Tipo = newTipo
                        End If

                        Console.Write("Descripción:".PadRight(18))
                        newDescripcion = Console.ReadLine
                        If newDescripcion <> "" Then
                            plato.Descripcion = newDescripcion
                        End If

                        Console.WriteLine("-------------------------------------------------------------------------------")
                        cont = cont + 1
                        Exit For
                    End If

                Next
                If cont <> 0 Then
                    Exit For
                End If
            Next

            If cont = 0 Then
                Console.WriteLine(vbNewLine & "No existe un platillo con esa ID o no tiene los permisos")
            End If

        Catch ex As Exception
            Console.WriteLine(vbNewLine & "ERROR, ID invalida. Vuelvalo a intentar")
        End Try

    End Sub

    Public Sub AsisListarCategorias(idAsistente As String)
        Dim restauranteAsociado As Restaurante = GetRestauranteByAsistente(idAsistente)
        Dim catsAux As ArrayList = New ArrayList

        Console.WriteLine("Restaurante: " & restauranteAsociado.Nombre)
        Console.WriteLine("Categorías: ")

        For Each cat As Categoria In listaCategorias
            For Each plato As Platillo In cat.ListaPlatillos
                If plato.Restaurante Is restauranteAsociado Then
                    If Not (catsAux.Contains(cat)) Then
                        catsAux.Add(cat)
                    End If
                End If
            Next
        Next

        For Each cat As Categoria In catsAux
            Console.WriteLine(cat.Nombre)
        Next

    End Sub

End Module
