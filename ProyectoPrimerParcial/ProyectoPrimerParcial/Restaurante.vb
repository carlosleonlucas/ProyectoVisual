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

    Private _asistenteid As Integer
    Public Property AsistenteId() As Integer
        Get
            Return _asistenteid
        End Get
        Set(ByVal value As Integer)
            _asistenteid = value
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

    Private _categorias As ArrayList
    Public Property Categorias() As ArrayList
        Get
            Return _categorias
        End Get
        Set(ByVal value As ArrayList)
            _categorias = value
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


   

    Public Sub AgregarCategoria(cate As Categoria)
        Me._categorias.Add(cate)
    End Sub

    Public Sub AgregarPlatillo(pla As Platillo)
        Me._platillos.Add(pla)
    End Sub

    Public Sub New(id As String, nombre As String, asistenteid As Integer, direccion As String, telefono As String, dueno As String)
        Me._id = id
        Me._nombre = nombre
        Me._asistenteid = asistenteid
        Me._direccion = direccion
        Me._telefono = telefono
        Me._dueno = dueno
        Me._categorias = New ArrayList
        Me._platillos = New ArrayList
    End Sub

    Public Sub New(id As String, nombre As String, asistenteid As Integer, direccion As String, telefono As String, dueno As String, categorias As ArrayList, platillos As ArrayList)
        Me._id = id
        Me._nombre = nombre
        Me._asistenteid = asistenteid
        Me._direccion = direccion
        Me._telefono = telefono
        Me._dueno = dueno

        Me._categorias = categorias
        Me._platillos = platillos
    End Sub

    Public Sub New()
        Me._id = 0
        Me._nombre = ""
        Me._asistenteid = 0
        Me._direccion = ""
        Me._telefono = ""
        Me._dueno = ""

        Me._categorias = New ArrayList
        Me._platillos = New ArrayList
    End Sub

End Class
