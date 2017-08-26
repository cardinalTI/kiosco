Public Class clsXML
    ''NUEVO
    Private m_rol As Integer
    Private m_nombre As String
    Private m_email As String
    Private m_rfc As String
    Private m_numempleado As Integer
    Private m_empresae As Integer
    Private m_pass As String
    Private m_periodopago As String
    ''NUEVO
    Private m_Empresa As String
    Private m_RFCEmpresa As String
    Private m_NombreEmpleado As String
    Private m_SalarioDiarioIntegrado As Double
    Private m_RFCEmplado As String
    Private m_CURP As String
    Private m_FechaIPago As Date
    Private m_FechaFPago As Date
    Private m_DiasTrabajados As Integer
    Private m_departamento As String
    Private m_Puesto As String
    Private m_clavePercepcion As String
    Private m_tipoPercepcion As String
    Private m_conceptoPercepcion As String
    Private m_importepercepciongravado As Double
    Private m_importepercepcionexento As Double
    Private m_clavededuccion As String
    Private m_conceptodeduccion As String
    Private m_importededucciongravado As Double
    Private m_importededuccionexento As Double
    Private m_TotalPago As Double
    Private m_FolioFiscal As String
    Private m_SelloDigitalCFDI As String
    Private m_SelloDigitalSAT As String
    Private m_NumeroCertificado As String
    Private m_LugarExpedicion As String
    Private m_FechaExpedicion As String
    Private m_TipoPago As String
    Private m_NSS As String
    Private m_FechaTimbrado As String
    Private m_Tipo As String
    Private m_total As String
    Private m_certificadosat As String
    Private m_jubilaciones As String

    ''junio

    Private m_sueldosyjornales As String
    Public Property sueldosyjornales As String
        Get
            Return Me.m_sueldosyjornales
        End Get
        Set(ByVal value As String)
            Me.m_sueldosyjornales = value
        End Set
    End Property
    Private m_subsidio As String
    Public Property subsidio As String
        Get
            Return Me.m_subsidio
        End Get
        Set(ByVal value As String)
            Me.m_subsidio = value
        End Set
    End Property
    Private m_seguridadsocial As String
    Public Property seguridadsocial As String
        Get
            Return Me.m_seguridadsocial
        End Get
        Set(ByVal value As String)
            Me.m_seguridadsocial = value
        End Set
    End Property
    Private m_isr As String
    Public Property isr As String
        Get
            Return Me.m_isr
        End Get
        Set(ByVal value As String)
            Me.m_isr = value
        End Set
    End Property
    Private m_infonavit As String
    Public Property infonavit As String
        Get
            Return Me.m_infonavit
        End Get
        Set(ByVal value As String)
            Me.m_infonavit = value
        End Set
    End Property
    Private m_infonacot As String
    Public Property infonacot As String
        Get
            Return Me.m_infonacot
        End Get
        Set(ByVal value As String)
            Me.m_infonacot = value
        End Set
    End Property


    ''junio

    ''mayo
    Public Property jubilaciones As String
        Get
            Return Me.m_jubilaciones
        End Get
        Set(ByVal value As String)
            Me.m_jubilaciones = value
        End Set
    End Property

    Public Property periodopago As String
        Get
            Return Me.m_periodopago
        End Get
        Set(ByVal value As String)
            Me.m_periodopago = value
        End Set
    End Property

    ''mayo

    ''NUEVO

    Public Property noCertificadoSAT As String
        Get
            Return Me.m_certificadosat
        End Get
        Set(ByVal value As String)
            Me.m_certificadosat = value
        End Set
    End Property

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

    Public Property empresae() As Integer
        Get
            Return Me.m_Empresa
        End Get
        Set(ByVal value As Integer)
            Me.m_Empresa = value
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
    ''NUEVO

    'Private m_Empresa As String
    Public Property Empresa() As String
        Get
            Return Me.m_Empresa
        End Get
        Set(ByVal value As String)
            Me.m_Empresa = value
        End Set
    End Property
    'Private m_RFCEmpresa As String
    Public Property RFCEmpresa() As String
        Get
            Return Me.m_RFCEmpresa
        End Get
        Set(ByVal value As String)
            Me.m_RFCEmpresa = value
        End Set
    End Property
    'Private m_NombreEmpleado As String
    Public Property NombreEmpleado() As String
        Get
            Return Me.m_NombreEmpleado
        End Get
        Set(ByVal value As String)
            Me.m_NombreEmpleado = value
        End Set
    End Property
    'Private m_SalarioDiarioIntegrado As Double
    Public Property SalarioDiarioIntegrado() As Double
        Get
            Return Me.m_SalarioDiarioIntegrado
        End Get
        Set(ByVal value As Double)
            Me.m_SalarioDiarioIntegrado = value
        End Set
    End Property
    'Private m_RFCEmplado As String
    Public Property RFCEmpleado() As String
        Get
            Return Me.m_RFCEmplado
        End Get
        Set(ByVal value As String)
            Me.m_RFCEmplado = value
        End Set
    End Property

    'Private m_CURP As String
    Public Property CURP() As String
        Get
            Return Me.m_CURP
        End Get
        Set(ByVal value As String)
            Me.m_CURP = value
        End Set
    End Property
    'Private m_FechaIPago As Date
    Public Property FechaIPago() As Date
        Get
            Return Me.m_FechaIPago
        End Get
        Set(ByVal value As Date)
            Me.m_FechaIPago = value
        End Set
    End Property
    'Private m_FechaFPago As Date
    Public Property FechaFPago() As Date
        Get
            Return Me.m_FechaFPago
        End Get
        Set(ByVal value As Date)
            Me.m_FechaFPago = value
        End Set
    End Property
    'Private m_DiasTrabajados As Integer
    Public Property DiasTrabajados() As Integer
        Get
            Return Me.m_DiasTrabajados
        End Get
        Set(ByVal value As Integer)
            Me.m_DiasTrabajados = value
        End Set
    End Property
    'Private m_departamento As String
    Public Property Departamento() As String
        Get
            Return Me.m_departamento
        End Get
        Set(ByVal value As String)
            Me.m_departamento = value
        End Set
    End Property
    'Private m_Puesto As String
    Public Property Puesto() As String
        Get
            Return Me.m_Puesto
        End Get
        Set(ByVal value As String)
            Me.m_Puesto = value
        End Set
    End Property
    'Private m_clavePercepcion As String
    Public Property ClavePercepcion() As String
        Get
            Return Me.m_clavePercepcion
        End Get
        Set(ByVal value As String)
            Me.m_clavePercepcion = value
        End Set
    End Property
    Public Property tipoPercepcion() As String
        Get
            Return Me.m_tipoPercepcion
        End Get
        Set(ByVal value As String)
            Me.m_tipoPercepcion = value
        End Set
    End Property
    'Private m_conceptoPercepcion As String
    Public Property ConceptoPercepcion() As String
        Get
            Return Me.m_conceptoPercepcion

        End Get
        Set(ByVal value As String)
            Me.m_conceptoPercepcion = value
        End Set
    End Property
    'Private m_importepercepciongravado As Double
    Public Property ImportePercepcionGravado() As Double
        Get
            Return Me.m_importepercepciongravado
        End Get
        Set(ByVal value As Double)
            Me.m_importepercepciongravado = value
        End Set
    End Property
    'Private m_importepercepcionexento As Double
    Public Property ImportePercepcionExento() As Double
        Get
            Return Me.m_importepercepcionexento
        End Get
        Set(ByVal value As Double)
            Me.m_importepercepcionexento = value
        End Set
    End Property
    'Private m_clavededuccion As String
    'Private m_conceptodeduccion As String
    'Private m_importededucciongravado As Double
    'Private m_importededuccionexento As Double
    Public Property Clavededuccion() As String
        Get
            Return Me.m_clavededuccion
        End Get
        Set(ByVal value As String)
            Me.m_clavededuccion = value
        End Set
    End Property
    'Private m_conceptoPercepcion As String
    Public Property Conceptodeduccion() As String
        Get
            Return Me.m_conceptodeduccion

        End Get
        Set(ByVal value As String)
            Me.m_conceptodeduccion = value
        End Set
    End Property
    'Private m_importepercepciongravado As Double
    Public Property ImportededuccionGravado() As Double
        Get
            Return Me.m_importededucciongravado
        End Get
        Set(ByVal value As Double)
            Me.m_importededucciongravado = value
        End Set
    End Property
    'Private m_importepercepcionexento As Double
    Public Property ImportededuccionExento() As Double
        Get
            Return Me.m_importededuccionexento
        End Get
        Set(ByVal value As Double)
            Me.m_importededuccionexento = value
        End Set
    End Property
    'Private m_TotalPago As Double
    Public Property TotalPago() As Double
        Get
            Return Me.m_TotalPago
        End Get
        Set(ByVal value As Double)
            Me.m_TotalPago = value
        End Set
    End Property
    'Private m_FolioFiscal As String
    Public Property FolioFiscal() As String
        Get
            Return Me.m_FolioFiscal
        End Get
        Set(ByVal value As String)
            Me.m_FolioFiscal = value
        End Set
    End Property
    'Private m_SelloDigitalCFDI As String
    Public Property SelloDigitalCFDI() As String
        Get
            Return Me.m_SelloDigitalCFDI
        End Get
        Set(ByVal value As String)
            Me.m_SelloDigitalCFDI = value
        End Set
    End Property
    'Private m_SelloDigitalSAT As String
    Public Property SelloDigitalSAT() As String
        Get
            Return Me.m_SelloDigitalSAT
        End Get
        Set(ByVal value As String)
            Me.m_SelloDigitalSAT = value
        End Set
    End Property
    'Private m_NumeroCertificado As String
    Public Property NumeroCertificado() As String
        Get
            Return Me.m_NumeroCertificado
        End Get
        Set(ByVal value As String)
            Me.m_NumeroCertificado = value
        End Set
    End Property
    'Private m_LugarExpedicion As String
    Public Property LugarExpedicion() As String
        Get
            Return Me.m_LugarExpedicion
        End Get
        Set(ByVal value As String)
            Me.m_LugarExpedicion = value
        End Set
    End Property
    'Private m_FechaExpedicion As String
    Public Property FechaExpedicion() As String
        Get
            Return Me.m_FechaExpedicion
        End Get
        Set(ByVal value As String)
            Me.m_FechaExpedicion = value
        End Set
    End Property
    'Private m_TipoPago As String
    Public Property TipoPago() As String
        Get
            Return Me.m_TipoPago
        End Get
        Set(ByVal value As String)
            Me.m_TipoPago = value
        End Set
    End Property

    Public Property NSS() As String
        Get
            Return Me.m_NSS
        End Get
        Set(ByVal value As String)
            Me.m_NSS = value
        End Set
    End Property

    Public Property FechaTimbrado() As String
        Get
            Return Me.m_FechaTimbrado
        End Get
        Set(ByVal value As String)
            Me.m_FechaTimbrado = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return Me.m_Tipo
        End Get
        Set(ByVal value As String)
            Me.m_Tipo = value
        End Set
    End Property

   

    Public Property total() As String
        Get
            Return Me.m_total
        End Get
        Set(ByVal value As String)
            Me.m_total = value
        End Set
    End Property


   

End Class
