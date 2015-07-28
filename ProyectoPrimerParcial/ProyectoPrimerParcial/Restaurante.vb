Public Class Restaurante
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _asistente As Asistente
    Public Property Asistente() As Asistente
        Get
            Return _asistente
        End Get
        Set(ByVal value As Asistente)
            _asistente = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _telefono As String
    Public Property Telefono() As String
        Get
            Return _telefono
        End Get
        Set(ByVal value As String)
            _telefono = value
        End Set
    End Property

    Private _dueno As String
    Public Property Dueno() As String
        Get
            Return _dueno
        End Get
        Set(ByVal value As String)
            _dueno = value
        End Set
    End Property


    Private _platillos As ArrayList
    Public Property Platillos() As ArrayList
        Get
            Return _platillos
        End Get
        Set(ByVal value As ArrayList)
            _platillos = value
        End Set
    End Property


    

    Public Sub AgregarPlatillo(pla As Platillo)
        Me._platillos.Add(pla)
    End Sub

    Public Sub New(id As String, nombre As String, asistente As Asistente, direccion As String, telefono As String, dueno As String)
        Me._id = id
        Me._nombre = nombre
        Me._asistente = asistente
        Me._direccion = direccion
        Me._telefono = telefono
        Me._dueno = dueno
        Me._platillos = New ArrayList
    End Sub

    Public Sub New(id As String, nombre As String, asistente As Asistente, direccion As String, telefono As String, dueno As String, platillos As ArrayList)
        Me._id = id
        Me._nombre = nombre
        Me._asistente = asistente
        Me._direccion = direccion
        Me._telefono = telefono
        Me._dueno = dueno
        Me._platillos = platillos
    End Sub

    Public Sub New()
        Me._id = 0
        Me._nombre = ""
        Me._asistente = Nothing
        Me._direccion = ""
        Me._telefono = ""
        Me._dueno = ""
        Me._platillos = New ArrayList
    End Sub

End Class
