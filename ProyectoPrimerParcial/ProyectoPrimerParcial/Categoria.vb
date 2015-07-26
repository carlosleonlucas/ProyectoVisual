Public Class Categoria
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

    Private _platillos As ArrayList
    Public Property ListaPlatillos() As ArrayList
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

    Public Sub New(id As String, nombre As String, platillos As ArrayList)
        Me._id = id
        Me._nombre = nombre
        Me._platillos = platillos
    End Sub

    Public Sub New(id As String, nombre As String)
        Me._id = id
        Me._nombre = nombre
        Me._platillos = New ArrayList
    End Sub

End Class
