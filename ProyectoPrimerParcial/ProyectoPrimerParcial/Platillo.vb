Public Class Platillo
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

    Private _restauranteId As Integer
    Public Property RestauranteId() As Integer
        Get
            Return _restauranteId
        End Get
        Set(ByVal value As Integer)
            _restauranteId = value
        End Set
    End Property

    Private _temperatura As String
    Public Property Temperatura() As String
        Get
            Return _temperatura
        End Get
        Set(ByVal value As String)
            _temperatura = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property


    Public Sub New(id As String, nombre As String, restauranteid As Integer, temperatura As String, tipo As String, descripcion As String)
        Me._id = id
        Me._nombre = nombre
        Me._restauranteId = restauranteid
        Me._temperatura = temperatura
        Me._tipo = tipo
        Me._descripcion = descripcion
    End Sub

    Public Sub New()

    End Sub

End Class
