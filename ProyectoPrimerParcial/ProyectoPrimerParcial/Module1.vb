Imports System.Xml
'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
Module Module1
    Dim restau As Restaurante = New Restaurante()
    Dim listaUsuarios As New ArrayList()
    Dim listaRestaurantes As New ArrayList()
    Dim clien As Cliente
    Dim asist As Asistente
    Dim admin As Administrador
    Sub Main()

        Dim rutaXml As New String("F:\Ejercicios Visual\ProyectoPrimerParcial\aaa.xml")


        'Dim admin As New Usuario
        'Dim asist As New Usuario
        'Dim clien As New Usuario

        'sistema.Add(admin)
        'sistema.Add(asist)
        'sistema.Add(clien)

        cargarXml(rutaXml)
        Console.WriteLine("Restaurantes: ")
        For Each res As Restaurante In listaRestaurantes
            Console.WriteLine(res.Nombre)
        Next
        Console.WriteLine("Usuarios: ")
        For Each usuario As Usuario In listaUsuarios
            Console.WriteLine(usuario.Usuario)
        Next
        Console.WriteLine("Platillos: ")
        For Each platilo As Platillo In restau.Platillos
            Console.WriteLine(platilo.Nombre)
        Next
        Console.WriteLine("Categorias: ")
        For Each cate As Categoria In restau.Categorias
            Console.WriteLine(cate.Nombre)
        Next

        Menu()


        'Dim opcion As Integer
        'Dim entrada
        'Do Until opcion = 4
        '    'Se pide al usuario elejir una opción del menú
        '    Console.Write("Elija opcion: ")

        '    'Valida la opción ingresada por el usuario, en caso de ser invalida, se le notifica
        '    Try
        '        entrada = Console.ReadLine()
        '        opcion = CInt(entrada)
        '    Catch ex As Exception
        '        Console.WriteLine("Opción no valida, por favor elija otra opción")
        '    End Try


        '    Select Case opcion
        '        Case 1
        '            Console.WriteLine("...")
        '        Case Else
        '            Console.WriteLine("-")
        '    End Select
        'Loop
        Console.ReadLine()
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
                        restau = New Restaurante(idResta, nomResta, asisIdResta, dirResta, telResta, dueResta)
                        listaRestaurantes.Add(restau)
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
                    Dim platil As Platillo = New Platillo(idPlati, nombrePlati, resIdPlati, tempePlati, tipoPlati, descriPlati)

                    cate.AgregarPlatillo(platil)
                    restau.AgregarPlatillo(platil)


                Next
                restau.AgregarCategoria(cate)
            Next
        Next
    End Sub

    Public Sub Menu()
        Dim input As Integer
        Dim inputSub
        Console.WriteLine("Catálogo de Delicias ")

        Console.Write("Nombre de usuario: ")
        Dim usuario As String = Console.ReadLine()
        Console.Write("Contraseña: ")
        Dim contraseña As String = Console.ReadLine()



        Dim tipoUsuario = ExisteUsuario(usuario, contraseña)

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
                            Console.Clear()
                            Console.WriteLine("1) Listar categorías de platillos")

                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()


                        Case 2
                            Console.Clear()
                            Console.WriteLine("2) Buscar platillo")


                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()

                        Case 3

                        Case Else
                            Console.Write("Opción incorrecta, Presione ENTER para volver a intentarlo")
                            Console.ReadLine()
                    End Select


                Loop Until (input = "3")
            Case "asistente"
                Do
                    Console.Clear()
                    Console.WriteLine("1) Agregar platillo")
                    Console.WriteLine("2) Listar platillos (de mi restaurante)")
                    Console.WriteLine("3) Listar categorías de platillos")
                    Console.WriteLine("4) Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    input = Console.ReadLine()

                    Select Case input
                        Case 1
                            Console.Clear()
                            Console.WriteLine("1) Agregar platillo")

                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()


                        Case 2
                            Console.Clear()
                            Console.WriteLine("2) Listar platillos (de mi restaurante)")


                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()
                        Case 3
                            Console.Clear()
                            Console.WriteLine("3) Listar categorías de platillos")


                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()
                    End Select


                Loop Until (input = "4")

            Case "administrador"
                Do
                    Console.Clear()
                    Console.WriteLine("1.- Agregar restaurante (desde XML) ")
                    Console.WriteLine("2.- Listar restaurante")
                    Console.WriteLine("3.- Salir del sistema")
                    Console.Write("Ingrese una opción: ")
                    input = Console.ReadLine()


                    Select Case input
                        Case 1
                            Console.Clear()
                            Console.WriteLine("Especifique la ruta del archivo XML")
                            Dim rutaArchivo = Console.ReadLine
                            Try
                                agregarRestauranteXml(obtenerUsuario(tipoUsuario), rutaArchivo)
                                'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                            Catch ex As Exception
                                Console.WriteLine("No se encontró archivo XML")
                            End Try
                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()


                        Case 2
                            Console.Clear()
                            Console.WriteLine("2) Listar Restaurantes")
                            Console.WriteLine("Restaurantes: ")
                            For Each res As Restaurante In listaRestaurantes
                                Console.WriteLine(res.Nombre)
                            Next

                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()
                        Case 3
                            Console.Clear()
                            Console.WriteLine("3) Listar categorías de platillos")


                            Console.Write("Presione ENTER para regresar")
                            Console.ReadLine()
                    End Select
                Loop Until (input = "3")


        End Select




    End Sub



    Public Function ExisteUsuario(usuario, contrasenia)
        Dim existe As Boolean = False
        Dim tipoUser As String = ""

        'Do

        For Each user As Usuario In listaUsuarios
            'Console.WriteLine(user.Usuario)
            'Console.WriteLine(user.Clave)
            'Console.WriteLine(usuario)
            'Console.WriteLine(contrasenia)


            If user.Usuario = usuario And user.Clave = contrasenia Then
                tipoUser = user.tipUsu
                existe = True
            End If
        Next

        If existe = True Then
            Return tipoUser
        Else
            Console.WriteLine("Nombre De usuario o contraseña incorrecto, vuelva a intentarlo. ")
        End If

        'Loop While existe = False
        Return tipoUser
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
	
Public Sub prueba(abc As Administrador, rutaNew As String)
        listaRestaurantes.Add(abc.datosRestaXml(rutaNew))
    End Sub
End Module
