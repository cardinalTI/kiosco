Public Class clsKiosco

    Private m_Fecha As Date
    Private m_xml As String
    Private m_FechaHoraTimbrado As Date
    Private m_UUID As String
    Private m_CFDI_ID As Integer

    Private m_IdNomina As Integer
    Private m_FechaNomina As Date


    Public Property Fecha() As Date
        Get
            Return Me.m_Fecha
        End Get
        Set(ByVal value As Date)
            Me.m_Fecha = value
        End Set
    End Property

    Public Property XML() As String
        Get
            Return Me.m_xml
        End Get
        Set(ByVal value As String)
            Me.m_xml = value
        End Set
    End Property

    Public Property FechaHoraTimbrado() As Date
        Get
            Return Me.m_FechaHoraTimbrado
        End Get
        Set(ByVal value As Date)
            Me.m_FechaHoraTimbrado = value
        End Set
    End Property

    Public Property UUID() As String
        Get
            Return Me.m_UUID
        End Get
        Set(ByVal value As String)
            Me.m_UUID = value
        End Set
    End Property

    Public Property CFDI_ID() As Integer
        Get
            Return Me.m_CFDI_ID
        End Get
        Set(ByVal value As Integer)
            Me.m_CFDI_ID = value
        End Set
    End Property

    Public Property IdNomina() As Integer
        Get
            Return Me.m_IdNomina
        End Get
        Set(ByVal value As Integer)
            Me.m_IdNomina = value
        End Set
    End Property

    Public Property FechaNomina() As Date
        Get
            Return Me.m_FechaNomina
        End Get
        Set(ByVal value As Date)
            Me.m_FechaNomina = value
        End Set
    End Property

End Class
