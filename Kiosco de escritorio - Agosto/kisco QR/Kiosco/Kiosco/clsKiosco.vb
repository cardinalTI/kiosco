Public Class clsKiosco

    Private m_Fecha As Date
    Private m_xml As String
    Private m_FechaHoraTimbrado As Date
    Private m_UUID As String
    Private m_CFDI_ID As Integer

    Private m_IdNomina As Integer
    Private m_FechaNomina As Date
    ''NUEVO
    Private m_rol As Integer
    Private m_nombre As String
    Private m_email As String
    Private m_rfc As String
    Private m_numempleado As Integer
    Private m_empresa As Integer
    Private m_pass As String
    Private m_RutaArchivo As String
    Private m_RutaArchivopdf As String
    ''NUEVO
    Private m_salario As String
    Private m_puestoe As String



    ''frecuencias de pago

    Private m_IdFrecuencia As String
    Private m_NombreFrecuencia As String

    Public Property IdFrecuencia() As Integer
        Get
            Return Me.m_IdFrecuencia
        End Get
        Set(ByVal value As Integer)
            Me.m_IdFrecuencia = value
        End Set
    End Property

    Public Property NombreFrecuencia() As String
        Get
            Return Me.m_NombreFrecuencia
        End Get
        Set(ByVal value As String)
            Me.m_NombreFrecuencia = value
        End Set
    End Property


    ''frecuencias de pago
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

    ''NUEVO
    Public Property rol() As Integer
        Get
            Return Me.m_rol
        End Get
        Set(ByVal value As Integer)
            Me.m_rol = value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return Me.m_nombre
        End Get
        Set(ByVal value As String)
            Me.m_nombre = value
        End Set
    End Property

    Public Property email() As String
        Get
            Return Me.m_email
        End Get
        Set(ByVal value As String)
            Me.m_email = value
        End Set
    End Property

    Public Property rfc() As String
        Get
            Return Me.m_rfc
        End Get
        Set(ByVal value As String)
            Me.m_rfc = value
        End Set
    End Property

    Public Property nempleado() As Integer
        Get
            Return Me.m_numempleado
        End Get
        Set(ByVal value As Integer)
            Me.m_numempleado = value
        End Set
    End Property

    Public Property empresa() As Integer
        Get
            Return Me.m_empresa
        End Get
        Set(ByVal value As Integer)
            Me.m_empresa = value
        End Set
    End Property

    Public Property pass() As String
        Get
            Return Me.m_pass
        End Get
        Set(ByVal value As String)
            Me.m_pass = value
        End Set
    End Property

    Public Property RutaArchivo() As String
        Get
            Return Me.m_RutaArchivo
        End Get
        Set(ByVal value As String)
            Me.m_RutaArchivo = value
        End Set
    End Property

    Public Property RutaArchivopdf() As String
        Get
            Return Me.m_RutaArchivopdf
        End Get
        Set(ByVal value As String)
            Me.m_RutaArchivopdf = value
        End Set
    End Property

    ''NUEVO

    Public Property salario() As String
        Get
            Return Me.m_salario
        End Get
        Set(ByVal value As String)
            Me.m_salario = value
        End Set
    End Property

    Public Property puestoe() As String
        Get
            Return Me.m_puestoe
        End Get
        Set(ByVal value As String)
            Me.m_puestoe = value
        End Set
    End Property

    ''28 septiembre

    Private m_redondeo As Double
    Public Property redondeo() As Double
        Get
            Return Me.m_redondeo
        End Get
        Set(ByVal value As Double)
            Me.m_redondeo = value
        End Set
    End Property

    Private m_numeroemp As String


    ''NUEVO

    Public Property numeroemp() As String
        Get
            Return Me.m_numeroemp
        End Get
        Set(ByVal value As String)
            Me.m_numeroemp = value
        End Set
    End Property

End Class
