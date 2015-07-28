Imports System.Xml


Module Module1
    Dim listaUsuarios As New ArrayList()
    Dim listaRestaurantes As New ArrayList()
    Dim listaCategorias As ArrayList = New ArrayList()

    Dim clien As Cliente
    Dim asist As Asistente
    Dim admin As Administrador
    Dim tipoUsuario As String
    Dim categ As String

    Dim idUltimoPlatillo As Integer
    Dim idUltimaCategoria As Integer

    Sub Main()

        'Dim rutaXml As New String("C:\Users\Carlos Leon\Desktop\ProyectoVisual\ProyectoPrimerParcial\aaa.xml")
        Dim rutaXml As New String("D:\sistemaPlatillos2.xml")


        cargarXml(rutaXml)
        Console.WriteLine("Restaurantes: ")
        For Each res As Restaurante In listaRestaurantes
            Console.WriteLine(res.Nombre)
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



        Dim usuarios As XmlNodeList = xmlDoc.GetElementsByTagName("usuarios")
        For Each usuarioss As XmlNode In usuarios
            For Each usuarioTipo As XmlNode In usuarioss
                Select Case usuarioTipo.Name
                    Case "administradores"
                        For Each usuarioAdmin As XmlNode In usuarioTipo
                            'Console.WriteLine(usuarioAdmin.Name)
                            Dim tipoUsuario = usuarioAdmin.Name
                            Dim idUsuAdmin = usuarioAdmin.Attributes(0).Value
                            Dim usuarioUsuAdmin = usuarioAdmin.Attributes(1).Value
                            Dim claveUsuAdmin = usuarioAdmin.Attributes(2).Value
                            Dim nombreUsuAdmin = usuarioAdmin.InnerText
                            'Console.WriteLine("id:  {0}, nombre: {1}, usuario: {2}, clave: {3}", idUsuAdmin, nombreUsuAdmin, usuarioUsuAdmin, claveUsuAdmin)
                            admin = New Administrador(tipoUsuario, idUsuAdmin, nombreUsuAdmin, usuarioUsuAdmin, claveUsuAdmin)
                            listaUsuarios.Add(admin)

                        Next
                    Case "asistentes"
                        For Each usuarioAsist As XmlNode In usuarioTipo
                            'Console.WriteLine(usuarioAsist.Name)
                            Dim tipoUsuario = usuarioAsist.Name
                            Dim idUsuAsist = usuarioAsist.Attributes(0).Value
                            Dim usuarioUsuAsist = usuarioAsist.Attributes(1).Value
                            Dim claveUsuAsist = usuarioAsist.Attributes(2).Value
                            Dim nombreUsuAsist = usuarioAsist.InnerText
                            'Console.WriteLine("id:  {0}, nombre: {1}, usuario: {2}, clave: {3}", idUsuAsist, nombreUsuAsist, usuarioUsuAsist, claveUsuAsist)
                            asist = New Asistente(tipoUsuario, idUsuAsist, nombreUsuAsist, usuarioUsuAsist, claveUsuAsist)
                            listaUsuarios.Add(asist)
                        Next
                    Case "clientes"
                        For Each usuarioClien As XmlNode In usuarioTipo
                            'Console.WriteLine(usuarioClien.Name)
                            Dim tipoUsuario = usuarioClien.Name
                            Dim idUsuClien = usuarioClien.Attributes(0).Value
                            Dim usuarioUsuClien = usuarioClien.Attributes(1).Value
                            Dim claveUsuClien = usuarioClien.Attributes(2).Value
                            Dim nombreUsuClien = usuarioClien.InnerText
                            'Console.WriteLine("id:  {0}, nombre: {1}, usuario: {2}, clave: {3}", idUsuClien, nombreUsuClien, usuarioUsuClien, claveUsuClien)
                            clien = New Cliente(tipoUsuario, idUsuClien, nombreUsuClien, usuarioUsuClien, claveUsuClien)
                            listaUsuarios.Add(clien)
                        Next
                    Case Else

                End Select
            Next
        Next
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

                        listaRestaurantes.Add(New Restaurante(idResta, nomResta, asisIdResta, dirResta, telResta, dueResta))
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


                    idUltimoPlatillo = Integer.Parse(idPlati)
                    GetRestauranteById(resIdPlati).AgregarPlatillo(platil)

                    cate.AgregarPlatillo(platil)


                Next
                idUltimaCategoria = Integer.Parse(idCat)
                listaCategorias.Add(cate)

            Next
        Next
    End Sub

    Public Sub Menu()
        Dim input As Integer
        Dim inputSub

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
                    Console.Clear()
                    Console.WriteLine("1) Listar categorías de platillos")
                    Console.WriteLine("2) Buscar platillo")
                    Console.WriteLine("3) Salir del sistema")

                    Console.Write("Ingrese una opción: ")
                    Try
                        input = Integer.Parse(Console.ReadLine())
                    Catch ex As Exception

                    End Try



                    Select Case input
                        Case 1
                            Dim inputt As Integer
                            Console.Clear()
                            ListarCategorias()
                            Console.WriteLine("1) Mostrar platillos ")
                            Console.WriteLine("2) Regresar")
                            Try
                                inputt = Integer.Parse(Console.ReadLine())
                            Catch ex As Exception

                            End Try
                            Select Case inputt
                                Case 1

                                    Console.WriteLine("Escoja una categoría: ")
                                    categ = Console.ReadLine()
                                    MostrarPlatillos(categ)
                                    Console.WriteLine("Escoja un platillo de la lista anterior")
                                    Dim platiMos As String = Console.ReadLine
                                    MostrarPlatillo(platiMos)



                                Case Else
                                    Console.Write("Opción incorrecta, Presione ENTER para volver a intentarlo")
                                    Console.ReadLine()



                            End Select



                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()


                        Case 2
                            Console.Clear()
                            Console.WriteLine("2) Buscar platillo")
                            Console.WriteLine("Ingrese parte del nombre o descripción de platillo a buscar: ")
                            Dim inf As String = Console.ReadLine()
                            buscar(inf)



                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()

                        Case 3

                        Case Else
                            Console.Write("Opción incorrecta, Presione ENTER para volver a intentarlo")
                            Console.ReadLine()
                    End Select


                Loop Until (input = "3")
                '--------------------------------------------------------------------------------------------------------------------------------------------------------------
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
                        input = Console.ReadLine()
                        Select Case input
                            Case 1
                                Console.Clear()
                                Console.WriteLine("1) Agregar platillo")
                                AsisAgregarPlatillo(usuarioActivo.Id)


                                Console.Write(vbNewLine & "Presione ENTER para regresar")
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
                                        input = Console.ReadLine()

                                        Select Case input
                                            Case 1
                                                Console.WriteLine(vbNewLine & "1. Mostrar platillo (escoger platillo de mi restaurante)" & vbNewLine)

                                                AsisMostrarPlatillo(usuarioActivo.Id)

                                                Console.Write(vbNewLine & "Presione ENTER para regresar")
                                                Console.ReadLine()
                                            Case 2
                                                Console.WriteLine(vbNewLine & "2. Modificar/actualizar platillo (escoger platillo de mi restaurante)" & vbNewLine)

                                                AsisModificarPlatillo(usuarioActivo.Id)

                                                Console.Write(vbNewLine & "Presione ENTER para regresar")
                                                Console.ReadLine()
                                            Case 3

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

                                Loop Until (input = "3")

                            Case 3
                                Do
                                    Console.Clear()
                                    Console.WriteLine("3) Listar categorías de platillos")
                                    AsisListarCategorias(usuarioActivo.Id)


                                    Console.WriteLine(vbNewLine & "1. Mostrar platillo (escoger categoría)")
                                    Console.WriteLine("2. Regresar")
                                    Console.Write(vbNewLine & "Ingrese una opción (1-2): ")
                                    Try
                                        input = Console.ReadLine()

                                        Select Case input
                                            Case 1
                                                Do
                                                    Console.WriteLine(vbNewLine & "1. Mostrar platillo (escoger categoría)")



                                                    Console.WriteLine(vbNewLine & "1.1. Mostrar platillo (escoger platillo de mi restaurante)")
                                                    Console.WriteLine("1.2. Modificar/actualizar platillo (escoger platillo de mi restaurante)")
                                                    Console.WriteLine("1.3. Regresar")
                                                    Console.Write(vbNewLine & "Ingrese una opción (1-3): ")
                                                    Try
                                                        input = Console.ReadLine()

                                                        Select Case input
                                                            Case 1

                                                                Console.WriteLine(vbNewLine & "1.1. Mostrar platillo (escoger platillo de mi restaurante)")

                                                                Console.Write(vbNewLine & "Presione ENTER para regresar")
                                                                Console.ReadLine()
                                                            Case 2
                                                                Console.WriteLine("1.2. Modificar/actualizar platillo (escoger platillo de mi restaurante)")

                                                                Console.Write(vbNewLine & "Presione ENTER para regresar")
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

                '---------------------------------------------------------------------------------------------------------------------------------------------------------------

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
        For Each categor As Categoria In listaCategorias
            Console.WriteLine("Título: " + categor.Nombre + "|| Número de platillos ofrecidos: " + CStr(categor.ListaPlatillos.Count))


        Next

    End Sub

    Public Sub MostrarPlatillos(categoria)

        If tipoUsuario = "cliente" Then

            For Each categor As Categoria In listaCategorias
                If categoria = categor.Nombre Then
                    Dim total As Integer = categor.ListaPlatillos.Count - 1
                    For i = 0 To total Step 1
                        Dim platill As Platillo = categor.ListaPlatillos.Item(i)
                        Console.Write(CStr(i) + ") " + platill.Nombre)
                        For Each resta As Restaurante In listaRestaurantes
                            If resta.Id = platill.RestauranteId Then
                                Console.WriteLine("; Restaurante: " + resta.Nombre)

                            End If
                        Next
                    Next

                End If


            Next
        End If





    End Sub

    Public Sub MostrarPlatillo(platillo)

        For Each categor As Categoria In listaCategorias
            If categor.Nombre = categ Then
                Dim total As Integer = categor.ListaPlatillos.Count - 1
                For i = 0 To total Step 1
                    Dim platill As Platillo = categor.ListaPlatillos.Item(i)
                    If platill.Nombre = platillo Then

                        Console.Write(platill.Nombre + " ; " + categor.Nombre + " ; " + platill.Descripcion + " ; " + " ; " + platill.Tipo + " ; " + platill.Temperatura)
                        For Each resta As Restaurante In listaRestaurantes
                            If resta.Id = platill.RestauranteId Then
                                Console.WriteLine("; Restaurante: " + resta.Nombre)

                            End If
                        Next
                    End If

                Next



            End If


        Next





    End Sub

    Public Sub buscar(info)
        For Each categor As Categoria In listaCategorias

            Dim total As Integer = categor.ListaPlatillos.Count - 1
            For i = 0 To total Step 1
                Dim platill As Platillo = categor.ListaPlatillos.Item(i)

                If platill.Nombre.Contains(info) Or platill.Descripcion.Contains(info) Then
                    Console.Write(platill.Nombre)
                    For Each resta As Restaurante In listaRestaurantes
                        If resta.Id = platill.RestauranteId Then
                            Console.WriteLine("; Restaurante: " + resta.Nombre)

                        End If
                    Next
                End If
            Next
        Next

    End Sub

    Public Function GetRestauranteByAsistente(idAsistente As String) As Restaurante
        For Each rest As Restaurante In listaRestaurantes
            If rest.AsistenteId = idAsistente Then
                Return rest
            End If
        Next
        Return Nothing
    End Function

    Public Function GetRestauranteById(resIdPlati As String) As Restaurante
        For Each rest As Restaurante In listaRestaurantes
            If rest.Id = resIdPlati Then
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
            newPlatillo = New Platillo((idUltimoPlatillo + 1).ToString, nombrePlati, GetRestauranteByAsistente(idAsistente).Id.ToString, tempePlati, tipoPlati, descriPlati, auxCat)
            auxCat.AgregarPlatillo(newPlatillo)
        Else
            newCat = New Categoria((idUltimaCategoria + 1).ToString, catPlati)
            newPlatillo = New Platillo((idUltimoPlatillo + 1).ToString, nombrePlati, GetRestauranteByAsistente(idAsistente).Id.ToString, tempePlati, tipoPlati, descriPlati, newCat)
            newCat.AgregarPlatillo(newPlatillo)
        End If

        GetRestauranteByAsistente(idAsistente).AgregarPlatillo(newPlatillo)

    End Sub


    Public Sub AsisListarPlatillo(idAsistente As String)
        Dim res As Restaurante = GetRestauranteByAsistente(idAsistente)

        Console.WriteLine(vbNewLine & "Restaurante: " & res.Nombre & vbNewLine)
        Console.WriteLine("ID".PadRight(8) & "Nombre".PadRight(32) & "Categoría")
        Console.WriteLine("----------------------------------------------------------")
        For Each plat As Platillo In res.Platillos
            Console.WriteLine(plat.Id.ToString.PadRight(8) & plat.Nombre.ToString.PadRight(32) & plat.Categoria.Nombre)
        Next

    End Sub


    Public Sub AsisMostrarPlatillo(idAsistente As String)
        Dim res As Restaurante = GetRestauranteByAsistente(idAsistente)
        Dim idPlato As Integer
        Dim cont As Integer = 0

        Console.Write("Ingrese la ID del platillo: ")
        Try
            idPlato = Integer.Parse(Console.ReadLine)

            'Console.WriteLine(vbNewLine & "Nombre".PadRight(20) & "Restaurante".PadRight(20) & "Categoría")
            'Console.WriteLine("----------------------------------------------------------")

            For Each plat As Platillo In res.Platillos
                If plat.Id = idPlato.ToString Then
                    'Console.WriteLine(plat.Nombre.ToString.PadRight(20) & res.Nombre.PadRight(20) & plat.Categoria.Nombre)
                    Console.WriteLine("-------------------------------------------------------------------------------")
                    Console.WriteLine("ID:".PadRight(18) & plat.Id)
                    Console.WriteLine("Nombre:".PadRight(18) & plat.Nombre)
                    Console.WriteLine("Restaurante:".PadRight(18) & res.Nombre)
                    Console.WriteLine("Categoría:".PadRight(18) & plat.Categoria.Nombre)
                    Console.WriteLine("Temperatura:".PadRight(18) & plat.Temperatura)
                    Console.WriteLine("Tipo:".PadRight(18) & plat.Tipo)
                    Console.WriteLine("Descripción:".PadRight(18) & plat.Descripcion)
                    Console.WriteLine("-------------------------------------------------------------------------------")
                    cont = cont + 1
                End If
            Next

            If cont = 0 Then
                'Console.WriteLine("NULL".PadRight(20) & "NULL".PadRight(20) & "NULL")
                Console.WriteLine(vbNewLine & "No existe un platillo con esa ID o no tiene los permisos")
            End If

        Catch ex As Exception
            Console.WriteLine(vbNewLine & "ERROR, ID invalida. Vuelvalo a intentar")
        End Try

    End Sub


    Public Sub AsisModificarPlatillo(idAsistente As String)
        Dim res As Restaurante = GetRestauranteByAsistente(idAsistente)
        Dim idPlato As Integer
        Dim cont As Integer = 0

        Dim newNombre, newNombreCategoría, newTemperatura, newTipo, newDescripcion As String

        Console.WriteLine("Instrucciones: Ingrese el nuevo valor donde corresponda. Si no quiere modificar el valor, solo de ENTER para pasar al siguiente." & vbNewLine)
        Console.Write("Ingrese la ID del platillo: ")
        Try
            idPlato = Integer.Parse(Console.ReadLine)

            For Each plat As Platillo In res.Platillos
                If plat.Id = idPlato.ToString Then

                    Console.WriteLine("-------------------------------------------------------------------------------")

                    Console.Write("Nombre:".PadRight(18))
                    newNombre = Console.ReadLine
                    If newNombre <> "" Then
                        plat.Nombre = newNombre
                    End If

                    Console.Write("Categoría:".PadRight(18))
                    newNombreCategoría = Console.ReadLine
                    If newNombreCategoría <> "" Or newNombreCategoría <> plat.Categoria.Nombre Then
                        Dim newCategoria As Categoria = New Categoria((idUltimaCategoria + 1).ToString, newNombreCategoría)
                        listaCategorias.Add(newCategoria)
                        plat.Categoria.EliminarPlatillo(plat)
                        plat.Categoria = newCategoria
                    End If

                    Console.Write("Temperatura:".PadRight(18))
                    newTemperatura = Console.ReadLine
                    If newTemperatura <> "" Then
                        plat.Temperatura = newTemperatura
                    End If

                    Console.Write("Tipo:".PadRight(18))
                    newTipo = Console.ReadLine
                    If newTipo <> "" Then
                        plat.Tipo = newTipo
                    End If

                    Console.Write("Descripción:".PadRight(18))
                    newDescripcion = Console.ReadLine
                    If newDescripcion <> "" Then
                        plat.Descripcion = newDescripcion
                    End If

                    Console.WriteLine("-------------------------------------------------------------------------------")
                    cont = cont + 1
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
        Dim res As Restaurante = GetRestauranteByAsistente(idAsistente)
        Dim auxIdRes As Integer = res.Id

        Console.WriteLine("Restaurante: " & res.Nombre)
        Console.WriteLine("Categorías")

        For Each cat As Categoria In listaCategorias
            For Each plat As Platillo In cat.ListaPlatillos
                If plat.RestauranteId = auxIdRes Then
                    Console.WriteLine(plat.Categoria.Nombre)
                End If
            Next

        Next

    End Sub

End Module
