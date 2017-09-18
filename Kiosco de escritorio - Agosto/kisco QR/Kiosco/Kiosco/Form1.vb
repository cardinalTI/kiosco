Imports System.Xml
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.Odbc
Imports System.Net
Imports System.Data.OleDb



Public Class Form1

    ''nuevo
    Private ccalculos As reportehandler
    Private arreDatoss As ArrayList
    Private rptReporte1 As New rptcoti

    Private ccalculosn As reportehandler
    Private arreDatossn As ArrayList
    Private rptReporteno As New rptnotimbrados
    Public conexionn As String
    Public ruta As String

    ''nuevo

    Private cKiosco As clsKioscoHandler
    Private arreDatos As ArrayList
    Private arredatosUsuarios As ArrayList
    Private arreDetalles As New ArrayList
    Private arrenominas As New ArrayList
    Private rptPDFXML As New crpPdfXml
    Private hrptPDFXML As New haberescrpPdfXml
    Public opconexion As clsKioscoHandler
    Public conexion As String
    Public conexiont As String
    Private arreArchivos As New ArrayList
    Private arreArchivospdf As New ArrayList
    Private rptPDFXML2 As New crpPdfXml2
    Private rptPDFXML3 As New crpPdfXml3
    Private rptPDFXML4 As New crpPdfXml4
    Private rptPDFXML5 As New crpPdfXml5
    Private rptPDFXML6 As New crpPdfXml6
    Private rptPDFXML7 As New crpPdfXml7
    Private rptPDFXML8 As New crpPdfXml8
    Private rptPDFXML9 As New crpPdfXml9
    Private rptPDFXML10 As New crpPdfXmlH
    Private rptPDFXML11 As New crpPdfXml11
    Private rptPDFXML12 As New crpPdfXmlAicel
    Private rptPDFXML13 As New crpPdfXml13
    Private rptPDFXML14 As New crpPdfXml14
    Private rptPDFXML15 As New crpPdfXml15
    Private rptPDFXML16 As New crpPdfXml16

    Private DirectorioPrincipal As String
    Dim contadorxml As Integer
    Dim contadorpdf As Integer
    Dim estimado As String
    Dim estimado1 As String

    Dim faltantes As String
    Dim contadorfa As Integer
    Dim contadorfaipp As Integer
    Dim faltantesipp As String
    Dim mensaje As String
    Dim contadorxml1 As Integer
    Dim contadorpdf1 As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        FolderBrowserDialog1.SelectedPath =
           System.IO.Directory.GetCurrentDirectory()
        Button2.Enabled = False

        btnObtenerDatos.Enabled = False
        chcsicoss.Checked = True
        chbpc.Checked = True

        '        Me.ccalculos = New reportehandler("DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
        ' ";PWD=ata8244;DBNAME=201.139.106.58" & _
        '":C:\microsip datos\TALENTO Y DESARROLLO DEL VALLE.FDB")

    End Sub
    ''muestra reporte

    Private Sub MuestraReporte3()


        ''fecha
        Dim fechasi As Date = DateTimePicker3.Value
        Dim fechasf As Date = DateTimePicker4.Value

        Dim año, mes, dia, año2, mes2, dia2 As String
        Dim inicial1 As String
        Dim final1 As String

        año = fechasi.Year.ToString
        mes = fechasi.Month.ToString
        dia = fechasi.Day.ToString

        If mes.Length = 1 Then
            mes = "0" & mes
        End If

        Dim nombrem As String
        nombrem = MonthName(mes)

        año2 = fechasf.Year.ToString
        mes2 = fechasf.Month.ToString
        dia2 = fechasf.Day.ToString

        If mes2.Length = 1 Then
            mes2 = "0" & mes2
        End If

        Dim nombrem2 As String
        nombrem2 = MonthName(mes2)
        inicial1 = dia + "/" + nombrem + "/" + año
        final1 = dia2 + "/" + nombrem2 + "/" + año2

        ''fecha

        Me.arreDatoss = Me.ccalculos.Calculocompra(fechasi, fechasf)

        Try
            Me.DataSet11.Clear()
            Me.rptReporte1 = Nothing
            Me.rptReporte1 = New rptcoti
            Me.DataSet11.Clear()
            Me.rptReporte1.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptReporte1.Name))

            For i As Integer = 0 To Me.arreDatoss.Count - 1
                With CType(Me.arreDatoss(i), clscotizacion)
                    Me.DataSet11.timbrado.AddtimbradoRow(.centro, .fecha_inicial, .fecha_timbrado, .numero_epleado, .certificado, .sin_certificado)
                End With
            Next
            Me.rptReporte1.SetDataSource(Me.DataSet11)
            'Me.rptReporte1.SetParameterValue("fechaini", inicial1)
            'Me.rptReporte1.SetParameterValue("fechafin", final1)
            Me.CrystalReportViewer1.ReportSource = Me.rptReporte1
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message, MsgBoxStyle.Critical, "REPORTE")
        End Try
    End Sub

    Private Sub MuestraReporte4()


        ''fecha
        Dim fechasi As Date = DateTimePicker3.Value
        Dim fechasf As Date = DateTimePicker4.Value

        Dim año, mes, dia, año2, mes2, dia2 As String
        Dim inicial1 As String
        Dim final1 As String

        año = fechasi.Year.ToString
        mes = fechasi.Month.ToString
        dia = fechasi.Day.ToString

        If mes.Length = 1 Then
            mes = "0" & mes
        End If

        Dim nombrem As String
        nombrem = MonthName(mes)

        año2 = fechasf.Year.ToString
        mes2 = fechasf.Month.ToString
        dia2 = fechasf.Day.ToString

        If mes2.Length = 1 Then
            mes2 = "0" & mes2
        End If

        Dim nombrem2 As String
        nombrem2 = MonthName(mes2)
        inicial1 = dia + "/" + nombrem + "/" + año
        final1 = dia2 + "/" + nombrem2 + "/" + año2

        ''fecha

        Me.arreDatossn = Me.ccalculosn.Calculocompran(fechasi, fechasf)

        Try
            Me.DataSet11.Clear()
            Me.rptReporteno = Nothing
            Me.rptReporteno = New rptnotimbrados
            Me.DataSet11.Clear()
            Me.rptReporteno.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptReporteno.Name))

            For i As Integer = 0 To Me.arreDatossn.Count - 1
                With CType(Me.arreDatossn(i), clscotizacion)
                    'Me.DataSet12.notimbrado.AddtimbradoRow(.centro, .fecha_inicial, .fecha_timbrado, .numero_epleado, .certificado, .sin_certificado)
                    Me.DataSet11.notimbrados.AddnotimbradosRow(.centro, .fecha_inicial, .fecha_timbrado, .nombre_empleado, .rfc, .cfdi_timbrado)

                End With
            Next
            Me.rptReporteno.SetDataSource(Me.DataSet11)
            'Me.rptReporte1.SetParameterValue("fechaini", inicial1)
            'Me.rptReporte1.SetParameterValue("fechafin", final1)
            Me.CrystalReportViewer2.ReportSource = Me.rptReporteno
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message, MsgBoxStyle.Critical, "REPORTE")
        End Try
    End Sub


    ''muestra reporte


    Private Sub btnbase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbase.Click
        btnObtenerDatos.Enabled = True
        conexion = cbxbase.Text
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()

        '201.139.106.58

        'nuevas empresas

        If conexion = "INFORMATION THECNOLOGY INDUSTRIES ITI SA DE CV" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\INFORMATION THECNOLOGY.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If
        If conexion = "PEPSAT SA DE CV" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\PEPSAT SA DE CV.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If
        If conexion = "CROTEC SA DE CV" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\CROTEC SA DE CV.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If
        If conexion = "NUBULA SA DE CV" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\NUBULA SA DE CV.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        ''nuevas empresas

        If conexion = "AICEL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\AICEL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        If conexion = "UPHETILOLI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\UPHETILOLI 2.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If


        ''Talento

        If conexion = "TALENTO Y DESARROLLO DEL VALLE" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\TALENTO Y DESARROLLO DEL VALLE.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If




        ''morget 

        If conexion = "MORGET SEMANAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\1 MORGET SEMANAL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        If conexion = "MORGET CATORCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\2 MORGET CATORCENAL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        If conexion = "MORGET QUINCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\3  MORGET QUINCENAL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        If conexion = "MORGET MENSUAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\4 MORGET MENSUAL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If
        ''morget


        If conexion = "MORGET" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=201.139.106.58" &
":C:\microsip datos\MORGET.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If



        If conexion = "IT TELECOM" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\IT RESOURCES TELECOM SA DE CV.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If

        If conexion = "CONISAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\GRUPO CONISAL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If


        If conexion = "WIPSI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
 ";PWD=ata8244;DBNAME=192.168.2.83" &
":C:\microsip datos\WIPSI A C.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        End If


        If conexion = "ATALANTA" Then

            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
            ";PWD=8244Ata;DBNAME=192.168.2.21:C:\microsip datos\ATALANTA.fdb"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()

        ElseIf conexion = "NEXTEL" Then


            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" &
  ";PWD=ata8244;DBNAME=192.168.2.83" &
 ":C:\microsip datos\NEXTEL.FDB"
            Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            Me.MuestraNominas()
            Me.MuestraFrecuencias()


           
        End If
    End Sub



    Private Sub MuestraNominas()
        Try
            Me.arrenominas = Me.cKiosco.ObtenNominas()
            Me.cbxNominasGeneradas.DataSource = Nothing
            Me.cbxNominasGeneradas.Items.Clear()
            If Me.arrenominas.Count > 0 Then
                With Me.cbxNominasGeneradas
                    .DisplayMember = "FechaNomina"
                    .DataSource = Me.arrenominas
                    .ValueMember = "IdNomina"
                End With
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 33: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub


    ''nuevo frecuencias

    Private Sub MuestraFrecuencias()
        Try
            Me.arrenominas = Me.cKiosco.ObtenFrecuencias()
            Me.cbxfrecuenciapago.DataSource = Nothing
            Me.cbxfrecuenciapago.Items.Clear()
            If Me.arrenominas.Count > 0 Then
                With Me.cbxfrecuenciapago
                    .DisplayMember = "NombreFrecuencia"
                    .DataSource = Me.arrenominas
                    .ValueMember = "IdFrecuencia"
                End With
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 33: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    ''nuevo frecuencias

    Public Sub MuestraDatos()
        Try
            Me.arreDatos = Me.cKiosco.ObtenDatosArticulo(Me.cbxNominasGeneradas.Text, Me.cbxfrecuenciapago.SelectedValue())
            Me.DataGridView1.Rows.Clear()
            Me.arreDetalles.Clear()
            If Me.arreDatos.Count > 0 Then
                For i As Integer = 0 To Me.arreDatos.Count - 1
                    Dim c As clsXML

                    With CType(Me.arreDatos(i), clsKiosco)
                        Me.DataGridView1.Rows.Add()
                        Me.DataGridView1.Rows(i).Cells(0).Value = .Fecha
                        Dim BArre As Byte() = Encoding.Default.GetBytes(.XML)
                        Dim stream As New MemoryStream(BArre)
                        stream.Position = 0
                        Dim sr As New StreamReader(stream)
                        Me.DataGridView1.Rows(i).Cells(1).Value = sr.ReadToEnd()
                        Me.DataGridView1.Rows(i).Cells(2).Value = .FechaHoraTimbrado
                        Me.DataGridView1.Rows(i).Cells(3).Value = .UUID
                        Me.DataGridView1.Rows(i).Cells(4).Value = .CFDI_ID
                        Me.DataGridView1.Rows(i).Cells(33).Value = .salario
                        Me.DataGridView1.Rows(i).Cells(34).Value = .puestoe
                        Me.DataGridView1.Rows(i).Cells(35).Value = .redondeo
                        c = Me.Campo1(.XML)

                        With c
                            Me.DataGridView1.Rows(i).Cells(5).Value = .Empresa
                            Me.DataGridView1.Rows(i).Cells(6).Value = .RFCEmpresa
                            Me.DataGridView1.Rows(i).Cells(7).Value = .NombreEmpleado
                            Me.DataGridView1.Rows(i).Cells(8).Value = .RFCEmpleado
                            Me.DataGridView1.Rows(i).Cells(9).Value = .NSS
                            Me.DataGridView1.Rows(i).Cells(10).Value = .CURP
                            Me.DataGridView1.Rows(i).Cells(11).Value = .FechaIPago
                            Me.DataGridView1.Rows(i).Cells(12).Value = .FechaFPago
                            Me.DataGridView1.Rows(i).Cells(13).Value = .DiasTrabajados
                            Me.DataGridView1.Rows(i).Cells(14).Value = .Departamento
                            Me.DataGridView1.Rows(i).Cells(15).Value = .ClavePercepcion
                            Me.DataGridView1.Rows(i).Cells(16).Value = .ConceptoPercepcion
                            Me.DataGridView1.Rows(i).Cells(17).Value = .ImportePercepcionGravado
                            Me.DataGridView1.Rows(i).Cells(18).Value = .ImportePercepcionExento
                            Me.DataGridView1.Rows(i).Cells(19).Value = .Clavededuccion
                            Me.DataGridView1.Rows(i).Cells(20).Value = .Conceptodeduccion
                            Me.DataGridView1.Rows(i).Cells(21).Value = .ImportededuccionGravado
                            Me.DataGridView1.Rows(i).Cells(22).Value = .ImportededuccionExento
                            Me.DataGridView1.Rows(i).Cells(23).Value = .FolioFiscal
                            Me.DataGridView1.Rows(i).Cells(24).Value = .SelloDigitalCFDI
                            Me.DataGridView1.Rows(i).Cells(25).Value = .SelloDigitalSAT
                            Me.DataGridView1.Rows(i).Cells(26).Value = .NumeroCertificado
                            Me.DataGridView1.Rows(i).Cells(27).Value = .FechaTimbrado
                            Me.DataGridView1.Rows(i).Cells(28).Value = .LugarExpedicion
                            Me.DataGridView1.Rows(i).Cells(29).Value = .TipoPago
                            Me.DataGridView1.Rows(i).Cells(30).Value = i
                            Me.DataGridView1.Rows(i).Cells(31).Value = .total
                            Me.DataGridView1.Rows(i).Cells(32).Value = .noCertificadoSAT



                            Me.Detalles(CType(Me.arreDatos(i), clsKiosco).XML, .FolioFiscal, .NumeroCertificado)
                            'Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .RFCEmpresa, CType(Me.arreDatos(i), clsKiosco).FechaHoraTimbrado, .RFCEmpleado)
                            'Me.CreaPDFyFTP(c)
                        End With

                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 94: " & ex.Message)
        End Try
    End Sub



    ''nuevo por lotes

    Public Sub MuestraDatos2()
        Try
            Me.arreDatos = Me.cKiosco.ObtenDatosArticulolotes(Me.cbxfrecuenciapago.SelectedValue(), Me.DateTimePicker1.Value(), Me.DateTimePicker2.Value())
            Me.DataGridView1.Rows.Clear()
            Me.arreDetalles.Clear()
            If Me.arreDatos.Count > 0 Then
                For i As Integer = 0 To Me.arreDatos.Count - 1
                    Dim c As clsXML

                    With CType(Me.arreDatos(i), clsKiosco)
                        Me.DataGridView1.Rows.Add()
                        Me.DataGridView1.Rows(i).Cells(0).Value = .Fecha
                        Dim BArre As Byte() = Encoding.Default.GetBytes(.XML)
                        Dim stream As New MemoryStream(BArre)
                        stream.Position = 0
                        Dim sr As New StreamReader(stream)
                        Me.DataGridView1.Rows(i).Cells(1).Value = sr.ReadToEnd()
                        Me.DataGridView1.Rows(i).Cells(2).Value = .FechaHoraTimbrado
                        Me.DataGridView1.Rows(i).Cells(3).Value = .UUID
                        Me.DataGridView1.Rows(i).Cells(4).Value = .CFDI_ID
                        Me.DataGridView1.Rows(i).Cells(33).Value = .salario
                        Me.DataGridView1.Rows(i).Cells(34).Value = .puestoe
                        Me.DataGridView1.Rows(i).Cells(35).Value = .redondeo
                        c = Me.Campo1(.XML)

                        With c
                            Me.DataGridView1.Rows(i).Cells(5).Value = .Empresa
                            Me.DataGridView1.Rows(i).Cells(6).Value = .RFCEmpresa
                            Me.DataGridView1.Rows(i).Cells(7).Value = .NombreEmpleado
                            Me.DataGridView1.Rows(i).Cells(8).Value = .RFCEmpleado
                            Me.DataGridView1.Rows(i).Cells(9).Value = .NSS
                            Me.DataGridView1.Rows(i).Cells(10).Value = .CURP
                            Me.DataGridView1.Rows(i).Cells(11).Value = .FechaIPago
                            Me.DataGridView1.Rows(i).Cells(12).Value = .FechaFPago
                            Me.DataGridView1.Rows(i).Cells(13).Value = .DiasTrabajados
                            Me.DataGridView1.Rows(i).Cells(14).Value = .Departamento
                            Me.DataGridView1.Rows(i).Cells(15).Value = .ClavePercepcion
                            Me.DataGridView1.Rows(i).Cells(16).Value = .ConceptoPercepcion
                            Me.DataGridView1.Rows(i).Cells(17).Value = .ImportePercepcionGravado
                            Me.DataGridView1.Rows(i).Cells(18).Value = .ImportePercepcionExento
                            Me.DataGridView1.Rows(i).Cells(19).Value = .Clavededuccion
                            Me.DataGridView1.Rows(i).Cells(20).Value = .Conceptodeduccion
                            Me.DataGridView1.Rows(i).Cells(21).Value = .ImportededuccionGravado
                            Me.DataGridView1.Rows(i).Cells(22).Value = .ImportededuccionExento
                            Me.DataGridView1.Rows(i).Cells(23).Value = .FolioFiscal
                            Me.DataGridView1.Rows(i).Cells(24).Value = .SelloDigitalCFDI
                            Me.DataGridView1.Rows(i).Cells(25).Value = .SelloDigitalSAT
                            Me.DataGridView1.Rows(i).Cells(26).Value = .NumeroCertificado
                            Me.DataGridView1.Rows(i).Cells(27).Value = .FechaTimbrado
                            Me.DataGridView1.Rows(i).Cells(28).Value = .LugarExpedicion
                            Me.DataGridView1.Rows(i).Cells(29).Value = .TipoPago
                            Me.DataGridView1.Rows(i).Cells(30).Value = i
                            Me.DataGridView1.Rows(i).Cells(31).Value = .total
                            Me.DataGridView1.Rows(i).Cells(32).Value = .noCertificadoSAT



                            Me.Detalles(CType(Me.arreDatos(i), clsKiosco).XML, .FolioFiscal, .NumeroCertificado)
                            'Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .RFCEmpresa, CType(Me.arreDatos(i), clsKiosco).FechaHoraTimbrado, .RFCEmpleado)
                            'Me.CreaPDFyFTP(c)
                        End With

                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 94: " & ex.Message)
        End Try
    End Sub


    ''nuevo por lotes

    ''nuevo metodo

    Public Sub MuestraDatosempleado(ByVal usuarios As String)
        Try
            Me.arreDatos = Me.cKiosco.ObtenDatosnempleado(Me.cbxNominasGeneradas.SelectedValue(), Me.TextBox2.Text)
            Me.DataGridView1.Rows.Clear()
            Me.arreDetalles.Clear()
            If Me.arreDatos.Count > 0 Then
                For i As Integer = 0 To Me.arreDatos.Count - 1
                    Dim c As clsXML

                    With CType(Me.arreDatos(i), clsKiosco)
                        Me.DataGridView1.Rows.Add()
                        Me.DataGridView1.Rows(i).Cells(0).Value = .Fecha
                        Dim BArre As Byte() = Encoding.Default.GetBytes(.XML)
                        Dim stream As New MemoryStream(BArre)
                        stream.Position = 0
                        Dim sr As New StreamReader(stream)
                        Me.DataGridView1.Rows(i).Cells(1).Value = sr.ReadToEnd()
                        Me.DataGridView1.Rows(i).Cells(2).Value = .FechaHoraTimbrado
                        Me.DataGridView1.Rows(i).Cells(3).Value = .UUID
                        Me.DataGridView1.Rows(i).Cells(4).Value = .CFDI_ID
                        Me.DataGridView1.Rows(i).Cells(33).Value = .salario
                        Me.DataGridView1.Rows(i).Cells(34).Value = .puestoe
                        Me.DataGridView1.Rows(i).Cells(35).Value = .redondeo
                        Me.DataGridView1.Rows(i).Cells(36).Value = .numeroemp

                        c = Me.Campo1(.XML)

                        With c
                            Me.DataGridView1.Rows(i).Cells(5).Value = .Empresa
                            Me.DataGridView1.Rows(i).Cells(6).Value = .RFCEmpresa
                            Me.DataGridView1.Rows(i).Cells(7).Value = .NombreEmpleado
                            Me.DataGridView1.Rows(i).Cells(8).Value = .RFCEmpleado
                            Me.DataGridView1.Rows(i).Cells(9).Value = .NSS
                            Me.DataGridView1.Rows(i).Cells(10).Value = .CURP
                            Me.DataGridView1.Rows(i).Cells(11).Value = .FechaIPago
                            Me.DataGridView1.Rows(i).Cells(12).Value = .FechaFPago
                            Me.DataGridView1.Rows(i).Cells(13).Value = .DiasTrabajados
                            Me.DataGridView1.Rows(i).Cells(14).Value = .Departamento
                            Me.DataGridView1.Rows(i).Cells(15).Value = .ClavePercepcion
                            Me.DataGridView1.Rows(i).Cells(16).Value = .ConceptoPercepcion
                            Me.DataGridView1.Rows(i).Cells(17).Value = .ImportePercepcionGravado
                            Me.DataGridView1.Rows(i).Cells(18).Value = .ImportePercepcionExento
                            Me.DataGridView1.Rows(i).Cells(19).Value = .Clavededuccion
                            Me.DataGridView1.Rows(i).Cells(20).Value = .Conceptodeduccion
                            Me.DataGridView1.Rows(i).Cells(21).Value = .ImportededuccionGravado
                            Me.DataGridView1.Rows(i).Cells(22).Value = .ImportededuccionExento
                            Me.DataGridView1.Rows(i).Cells(23).Value = .FolioFiscal
                            Me.DataGridView1.Rows(i).Cells(24).Value = .SelloDigitalCFDI
                            Me.DataGridView1.Rows(i).Cells(25).Value = .SelloDigitalSAT
                            Me.DataGridView1.Rows(i).Cells(26).Value = .NumeroCertificado
                            Me.DataGridView1.Rows(i).Cells(27).Value = .FechaTimbrado
                            Me.DataGridView1.Rows(i).Cells(28).Value = .LugarExpedicion
                            Me.DataGridView1.Rows(i).Cells(29).Value = .TipoPago
                            Me.DataGridView1.Rows(i).Cells(30).Value = i
                            Me.DataGridView1.Rows(i).Cells(31).Value = .total
                            Me.DataGridView1.Rows(i).Cells(32).Value = .noCertificadoSAT



                            Me.Detalles(CType(Me.arreDatos(i), clsKiosco).XML, .FolioFiscal, .NumeroCertificado)
                            'Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .RFCEmpresa, CType(Me.arreDatos(i), clsKiosco).FechaHoraTimbrado, .RFCEmpleado)
                            'Me.CreaPDFyFTP(c)
                        End With

                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 94: " & ex.Message)
        End Try
    End Sub


    ''nuevo metodo


    ''nuevo (usuario)
    Public Sub MuestrAusuario()
        Try
            Me.arredatosUsuarios = Me.cKiosco.Obtenusuario
            Me.DataGridView2.Rows.Clear()

            If Me.arredatosUsuarios.Count > 0 Then
                For i As Integer = 0 To Me.arredatosUsuarios.Count - 1


                    With CType(Me.arredatosUsuarios(i), clsKiosco)
                        Me.DataGridView2.Rows.Add()

                        Me.DataGridView2.Rows(i).Cells(0).Value = .rol
                        Me.DataGridView2.Rows(i).Cells(1).Value = .nombre
                        Me.DataGridView2.Rows(i).Cells(2).Value = .email
                        Me.DataGridView2.Rows(i).Cells(3).Value = .rfc
                        Me.DataGridView2.Rows(i).Cells(4).Value = .nempleado
                        Me.DataGridView2.Rows(i).Cells(5).Value = .empresa
                        Me.DataGridView2.Rows(i).Cells(6).Value = .pass

                    End With
                Next
            End If

        Catch ex As Exception
            MsgBox("Error No Controlado 144: " & ex.Message)
        End Try
    End Sub


    ''nuevo (usuario)

    Private Sub btnObtenerDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerDatos.Click
        btnInsertarMYSQL.Enabled = True

        If checlote.Enabled = True Then
            Me.MuestraDatos2()

            If checlote.Enabled = False Then
                Me.MuestraDatos()
            End If
        End If



        ' Me.MuestrAusuario()

    End Sub

    Private Function Campo1(ByVal value As String) As clsXML
        Try
            Dim BArre As Byte() = Encoding.Default.GetBytes(value)
            Dim stream As New MemoryStream(BArre)
            Dim reader As New XmlTextReader(stream)
            reader.WhitespaceHandling = WhitespaceHandling.None

            Dim c As New clsXML

            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            Case "cfdi:Emisor"
                                c.Empresa = reader.GetAttribute("nombre")
                                c.RFCEmpresa = reader.GetAttribute("rfc")
                            Case "cfdi:Receptor"
                                c.NombreEmpleado = reader.GetAttribute("nombre")
                                c.RFCEmpleado = reader.GetAttribute("rfc")
                            Case "nomina12:Nomina"
                                'c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                'c.CURP = reader.GetAttribute("Curp")
                                c.FechaIPago = reader.GetAttribute("FechaInicialPago")
                                c.FechaFPago = reader.GetAttribute("FechaFinalPago")
                                c.DiasTrabajados = reader.GetAttribute("NumDiasPagados")
                                'c.Departamento = reader.GetAttribute("Departamento")

                            Case "nomina12:Receptor"
                                c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                c.CURP = reader.GetAttribute("Curp")
                                c.Departamento = reader.GetAttribute("Departamento")
                                ''nuevo
                                'c.Puesto = reader.GetAttribute("Puesto")
                                'c.SalarioDiarioIntegrado = reader.GetAttribute("SalarioDiarioIntegrado")
                                ''nuevo

                            Case "nomina12:OtroPago"
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.tipoPercepcion = reader.GetAttribute("Clave")


                            Case "nomina12:Percepcion"
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.tipoPercepcion = reader.GetAttribute("TipoPercepcion")
                            Case "nomina12:Deduccion"
                                c.Clavededuccion = reader.GetAttribute("Clave")
                                c.Conceptodeduccion = reader.GetAttribute("Concepto")
                                c.ImportededuccionGravado = reader.GetAttribute("Importe")
                                c.ImportededuccionExento = 0
                                'c.ImportededuccionExento = reader.GetAttribute("ImporteExento")
                            Case "tfd:TimbreFiscalDigital"
                                c.FolioFiscal = reader.GetAttribute("UUID")
                                c.SelloDigitalCFDI = reader.GetAttribute("selloCFD")
                                c.SelloDigitalSAT = reader.GetAttribute("selloSAT")
                                c.noCertificadoSAT = reader.GetAttribute("noCertificadoSAT")
                            Case "cfdi:Comprobante"
                                c.NumeroCertificado = reader.GetAttribute("noCertificado")
                                c.FechaTimbrado = reader.GetAttribute("fecha")
                                c.LugarExpedicion = reader.GetAttribute("LugarExpedicion")
                                c.TipoPago = reader.GetAttribute("formaDePago")
                                c.total = reader.GetAttribute("total")
                        End Select
                End Select
            End While
            reader.Close()
            Return c
        Catch ex As Exception
            MsgBox("Error No Controlado 153: " & ex.Message)
        End Try
    End Function


    Private Sub Detalles(ByVal value As String, ByVal uuid As String, ByVal nocert As String)
        Try
            Dim BArre As Byte() = Encoding.Default.GetBytes(value)
            Dim stream As New MemoryStream(BArre)
            Dim reader As New XmlTextReader(stream)
            reader.WhitespaceHandling = WhitespaceHandling.None



            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            ''nuevo

                            Case "nomina12:OtroPago"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("Importe")
                                c.ImportePercepcionExento = 0
                                c.Tipo = "Percepcion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)

                            Case "nomina12:Percepcion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.tipoPercepcion = reader.GetAttribute("TipoPercepcion")
                                c.Tipo = "Percepcion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)
                            Case "nomina12:Deduccion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("Importe")
                                c.ImportePercepcionExento = 0
                                c.Tipo = "Deduccion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)
                        End Select
                End Select
            End While
            reader.Close()

        Catch ex As Exception
            MsgBox("Error No Controlado 197: " & ex.Message)
        End Try
    End Sub



    ''nuevo
    Private Sub Detallesarchivo(ByVal value As String, ByVal uuid As String, ByVal nocert As String)
        Try

            Dim reader As New XmlTextReader(value)
            reader.WhitespaceHandling = WhitespaceHandling.None



            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            'Case "nomina12:OtroPago"
                            '    Dim c As New clsXML
                            '    c.ClavePercepcion = reader.GetAttribute("Clave")
                            '    c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                            '    c.ImportePercepcionGravado = reader.GetAttribute("Importe")
                            '    c.ImportePercepcionExento = 0
                            '    c.Tipo = "Percepcion"
                            '    c.FolioFiscal = uuid
                            '    c.NumeroCertificado = nocert
                            '    Me.arreDetalles.Add(c)

                            'Case "nomina12:Percepcion"
                            '    Dim c As New clsXML
                            '    c.ClavePercepcion = reader.GetAttribute("Clave")
                            '    c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                            '    c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                            '    c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                            '    c.tipoPercepcion = reader.GetAttribute("TipoPercepcion")
                            '    c.Tipo = "Percepcion"
                            '    c.FolioFiscal = uuid
                            '    c.NumeroCertificado = nocert
                            '    Me.arreDetalles.Add(c)
                            'Case "nomina12:Deduccion"
                            '    Dim c As New clsXML
                            '    c.ClavePercepcion = reader.GetAttribute("Clave")
                            '    c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                            '    c.ImportePercepcionGravado = reader.GetAttribute("Importe")
                            '    c.ImportePercepcionExento = 0
                            '    c.Tipo = "Deduccion"
                            '    c.FolioFiscal = uuid
                            '    c.NumeroCertificado = nocert
                            Case "nomina:Percepcion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("TipoPercepcion")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.tipoPercepcion = reader.GetAttribute("TipoPercepcion")
                                c.Tipo = "Percepcion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)
                            Case "nomina:Deduccion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("TipoDeduccion")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.Tipo = "Deduccion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)
                        End Select
                End Select
            End While
            reader.Close()

        Catch ex As Exception
            MsgBox("Error No Controlado 197: " & ex.Message)
        End Try
    End Sub

    Private Function Campo2(ByVal value As String) As String
        Try
            Dim campo As String
            Dim BArre As Byte() = Encoding.Default.GetBytes(value)
            Dim stream As New MemoryStream(BArre)
            Dim reader As New XmlTextReader(stream)
            reader.WhitespaceHandling = WhitespaceHandling.None

            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            Case "cfdi:Concepto"
                                campo = reader.GetAttribute("valorUnitario")
                        End Select
                End Select
            End While
            reader.Close()
            Return campo
        Catch ex As Exception
            MsgBox("Error No Controlado 221: " & ex.Message)
        End Try
    End Function
    ''nuevo


    Private Sub btnInsertarMYSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarMYSQL.Click

        ' Dim ruta As String
        ''
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

            ' List files in the folder.

            ListFiles(FolderBrowserDialog1.SelectedPath)


            ruta = FolderBrowserDialog1.SelectedPath
            ''

        End If


        Dim contador As Integer = 0
        Dim contador2 As Integer = 0

        '''nuevo ( usuario)
        'Try
        '    For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
        '        With Me.DataGridView1.Rows(i)
        '            'inicio
        '            'AQUI VA UNA VALIDACION SI EL USUARIO YA ESTA EN MY SQL SI NO, SE AGREGA
        '            If Me.Validausuarioxml(.Cells(8).Value) = False Then
        '                ''foldur
        '                If (.Cells(6).Value = "FOL1505208V8") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "14"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)
        '                    ''nuevo

        '                    ''wipsi

        '                ElseIf (.Cells(6).Value = "DAS060320KQ5") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "20"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)


        '                    ''talento

        '                ElseIf (.Cells(6).Value = "TDV0809118T3") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "18"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)

        '                    ''conisal
        '                ElseIf (.Cells(6).Value = "GCO130624LY4") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "10"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)

        '                    ''morget 
        '                ElseIf (.Cells(6).Value = "GMO150901R32") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "17"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)


        '                    ''it teelcom

        '                ElseIf (.Cells(6).Value = "IRT150703HD0") Then
        '                    Dim correo As String
        '                    Dim uno As String = "2"
        '                    Dim dos As String = "0"
        '                    Dim tres As String = "9"
        '                    correo = Convert.ToString(.Cells(7).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
        '                    Me.cKiosco.Agregausuario(.Cells(7).Value, correo.ToString, .Cells(8).Value, .Cells(8).Value, uno, dos, tres)

        '                    ''nuevo
        '                End If
        '                'Me.cKiosco.Agregausuario(.Cells(1).Value, .Cells(2).Value, .Cells(6).Value, .Cells(3).Value, .Cells(0).Value, .Cells(4).Value, .Cells(5).Value)

        '            End If

        '        End With
        '    Next

        'Catch ex As Exception
        '    MsgBox("Error No Controlado 351: " & ex.Message)
        'End Try
        '''nuevo ( usuario)



        Try
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                With Me.DataGridView1.Rows(i)
                    ProgressBar3.Minimum = 1
                    ProgressBar3.Maximum = Me.DataGridView1.Rows.Count
                    Dim c As clsXML

                    If Me.CBXPS.Checked = True Then

                        c = New clsXML
                        c.nempleado = Me.DataGridView1.Rows(i).Cells(4).Value
                        c.NombreEmpleado = Me.DataGridView1.Rows(i).Cells(5).Value
                        c.SalarioDiarioIntegrado = Me.DataGridView1.Rows(i).Cells(11).Value
                        c.NSS = Me.DataGridView1.Rows(i).Cells(10).Value
                        c.RFCEmpleado = Me.DataGridView1.Rows(i).Cells(6).Value
                        c.CURP = Me.DataGridView1.Rows(i).Cells(7).Value
                        c.FechaIPago = Me.DataGridView1.Rows(i).Cells(2).Value
                        c.FechaFPago = Me.DataGridView1.Rows(i).Cells(3).Value
                        c.DiasTrabajados = Me.DataGridView1.Rows(i).Cells(14).Value
                        c.Departamento = Me.DataGridView1.Rows(i).Cells(12).Value
                        c.Puesto = Me.DataGridView1.Rows(i).Cells(13).Value
                        c.periodopago = Me.DataGridView1.Rows(i).Cells(9).Value

                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(15).Value) Then

                            c.sueldosyjornales = "0"
                        Else
                            c.sueldosyjornales = Me.DataGridView1.Rows(i).Cells(15).Value
                        End If

                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(16).Value) Then

                            c.subsidio = "0"
                        Else
                            c.subsidio = Me.DataGridView1.Rows(i).Cells(16).Value
                        End If

                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(18).Value) Then

                            c.seguridadsocial = "0"
                        Else
                            c.seguridadsocial = Me.DataGridView1.Rows(i).Cells(18).Value
                        End If

                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(19).Value) Then

                            c.isr = "0"
                        Else
                            c.isr = Me.DataGridView1.Rows(i).Cells(19).Value
                        End If
                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(20).Value) Then

                            c.infonavit = "0"
                        Else
                            c.infonavit = Me.DataGridView1.Rows(i).Cells(20).Value
                        End If
                        If IsDBNull(Me.DataGridView1.Rows(i).Cells(21).Value) Then

                            c.infonacot = "0"
                        Else
                            c.infonacot = Me.DataGridView1.Rows(i).Cells(21).Value
                        End If


                        Me.CreaPDFyFTPCONISAL_SINTIMBREps(c)
                        'Else
                        '    Me.CreaPDFyFTPCONISAL(Me.DataGridView1.Rows(i).Cells(15).Value, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                    End If


                    If Me.CheckBox2.Checked = True Then

                        c = New clsXML
                        c.nempleado = Me.DataGridView1.Rows(i).Cells(4).Value
                        c.NombreEmpleado = Me.DataGridView1.Rows(i).Cells(5).Value
                        c.SalarioDiarioIntegrado = Me.DataGridView1.Rows(i).Cells(10).Value
                        c.NSS = Me.DataGridView1.Rows(i).Cells(9).Value
                        c.RFCEmpleado = Me.DataGridView1.Rows(i).Cells(6).Value
                        c.CURP = Me.DataGridView1.Rows(i).Cells(7).Value
                        c.FechaIPago = Me.DataGridView1.Rows(i).Cells(2).Value
                        c.FechaFPago = Me.DataGridView1.Rows(i).Cells(3).Value
                        c.DiasTrabajados = Me.DataGridView1.Rows(i).Cells(13).Value
                        c.Departamento = Me.DataGridView1.Rows(i).Cells(11).Value
                        c.Puesto = Me.DataGridView1.Rows(i).Cells(12).Value
                        c.jubilaciones = Me.DataGridView1.Rows(i).Cells(15).Value
                        c.periodopago = Me.DataGridView1.Rows(i).Cells(8).Value

                        Me.CreaPDFyFTPCONISAL_SINTIMBRE(c)
                        'Else
                        '    Me.CreaPDFyFTPCONISAL(Me.DataGridView1.Rows(i).Cells(15).Value, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                    End If


                    If Me.CheckBox2.Checked = False And Me.CBXPS.Checked = False Then


                        c = Me.Campo1(CType(Me.arreDatos(.Cells(30).Value), clsKiosco).XML)


                        Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .Cells(6).Value, .Cells(2).Value, .Cells(8).Value, .Cells(12).Value, .Cells(7).Value)

                        If cbxbase.Text = "CONISAL" Then
                            Me.CreaPDFyFTPCONISAL(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "NEXTEL" Then

                            Me.CreaPDFyFTP(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "WIPSI" Then
                            Me.CreaPDFyFTPWIPSI(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)

                        End If


                        If cbxbase.Text = "IT TELECOM" Then
                            Me.CreaPDFyFTPteleco(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "MORGET" Or cbxbase.Text = "MORGET SEMANAL" Or cbxbase.Text = "MORGET QUINCENAL" Or cbxbase.Text = "MORGET CATORCENAL" Or cbxbase.Text = "MORGET MENSUAL" Then
                            Me.CreaPDFyFTPMORGET(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        'talento
                        If cbxbase.Text = "TALENTO Y DESARROLLO DEL VALLE" Then
                            Me.CreaPDFyFTPTALENTO(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "UPHETILOLI" Then
                            Me.CreaPDFyFTPUPHETILOLI(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If


                        'AICEL

                        If cbxbase.Text = "AICEL" Then
                            Me.CreaPDFyFTPAICEL(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        'AICEL


                        ''nuevas empresas
                        If cbxbase.Text = "INFORMATION THECNOLOGY INDUSTRIES ITI SA DE CV" Then
                            Me.CreaPDFyFTPINFORMATION(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "PEPSAT SA DE CV" Then
                            Me.CreaPDFyFTPPEPSAT(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "CROTEC SA DE CV" Then
                            Me.CreaPDFyFTPCROTEC(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If

                        If cbxbase.Text = "NUBULA SA DE CV" Then
                            Me.CreaPDFyFTPNUBULA(c, Me.DataGridView1.Rows(i).Cells(33).Value, Me.DataGridView1.Rows(i).Cells(34).Value, .Cells(35).Value)
                        End If


                        ''nuevas empresas

                        'contador = contador + 1
                        ''fin

                        'Else
                    End If

                    TextBox1.Text = Me.faltantesipp
                    contador2 = contador2 + 1

                    ''SI YA ESTA EL FOLIO FISCAL NOTIFICAMOS QUE ESTE NO SE AGREGO PORQUE YA SE ENCUENTRA
                    'End If

                End With
                My.Application.DoEvents()
                If i = 0 Then
                    ProgressBar3.Value = 1
                Else
                    ProgressBar3.Value = ProgressBar3.Value + 1
                End If


            Next
            MsgBox("Total de archivos registrados correctamente " & contador2)
            MsgBox("Los archivos no ingresados al kiosco fueron " & Me.contadorfaipp)
            TextBox1.Text = Me.faltantesipp
            'MsgBox("Total de archivos que ya se encontraban registrados " & contador2)
            'Application.Restart()
        Catch ex As Exception
            MsgBox("Error No Controlado 1: " & ex.Message)
        End Try


    End Sub


    'crear desde excel inicio

    Private Sub CreaPDFyFTPCONISAL_SINTIMBRE(ByVal c As clsXML)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Dim entero As Integer
        entero = Math.Ceiling(c.DiasTrabajados)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML9 = Nothing
            Me.rptPDFXML9 = New crpPdfXml9
            Me.rptPDFXML9.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML9.Name))


            'Me.arreDetallesPagoPersonal = Me.cKiosco.ObtenDatosDetallesPagoPersona(Me.cbxNominasGeneradas.Text, Me.cbxfrecuenciapago.SelectedValue(), c.nempleado)
            'If Me.arreDetallesPagoPersonal.Count > 0 Then
            '    For i As Integer = 0 To Me.arreDetallesPagoPersonal.Count - 1
            '        With CType(Me.arreDetallesPagoPersonal(i), clsKiosco)
            '            If c.nempleado = .nempleado22 Then
            '                If .naturalezaab = "P" Then
            '                    If .naturalezaab = "P" And .nombre = "Subsidio para el empleo" Or .nombre = "Subsidios por incapacidad" Then
            '                        .exentoab = .otros_pagosab
            '                    End If
            '                    Me.DsPercepciones1.Percepcion.AddPercepcionRow(.claveab, .nombre, .exentoab, .gravableab, "", 1)
            '                ElseIf .naturalezaab = "R" Then
            '                    Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.claveab, .nombre, .exentoab, .gravableab, "", 1)
            '                End If
            '            End If
            '        End With
            '    Next
            'End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML9.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML9.SetParameterValue("Empresa", "WIPSSI A.C.")
            Dim rfcempresa As String
            rfcempresa = "DAS060320KQ5"
            Me.rptPDFXML9.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML9.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML9.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML9.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML9.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML9.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML9.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML9.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML9.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML9.SetParameterValue("FolioFiscal", "N")
            Me.rptPDFXML9.SetParameterValue("SelloCFDI", "N")
            Me.rptPDFXML9.SetParameterValue("SelloSAT", "N")
            Me.rptPDFXML9.SetParameterValue("NumCert", "00001000000301251152")
            Me.rptPDFXML9.SetParameterValue("FechaTimbrado", c.FechaFPago)
            Me.rptPDFXML9.SetParameterValue("LugarExpedicion", "Ciudad de México")
            Me.rptPDFXML9.SetParameterValue("TipoPago", "Pago en una sola  exhibición")
            Me.rptPDFXML9.SetParameterValue("Total", "1")
            Me.rptPDFXML9.SetParameterValue("CertificadoSAT", "N")
            Me.rptPDFXML9.SetParameterValue("clave1", "044")
            Me.rptPDFXML9.SetParameterValue("descripcion", "JUBILACIONES, PENSIONES O HABERES DEL RETIRO")
            Me.rptPDFXML9.SetParameterValue("jubilacion", c.jubilaciones)
            Me.rptPDFXML9.SetParameterValue("QR", "N")
            Me.rptPDFXML9.SetParameterValue("SalarioDiarioIntegrado", c.SalarioDiarioIntegrado)
            Me.rptPDFXML9.SetParameterValue("puesto", c.Puesto)
            Me.rptPDFXML9.SetParameterValue("periodopago", c.periodopago)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaIPago
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                'Me.rptPDFXML9.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML9.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML9.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML9.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML9.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML9.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML9.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML9.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML9.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML9.Close()

            'Dim mensaje As String
            'mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            'faltantesipp = faltantesipp + mensaje + vbCrLf
            'contadorpdf1 = contadorpdf1 + 1
            'Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    ''junio
    Private Sub CreaPDFyFTPCONISAL_SINTIMBREps(ByVal c As clsXML)

        Dim ruta As String
        ''
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

            ' List files in the folder.

            ListFiles(FolderBrowserDialog1.SelectedPath)


            ruta = FolderBrowserDialog1.SelectedPath
            ''

        End If

        Dim entero As Integer
        entero = Math.Ceiling(c.DiasTrabajados)
        Try

            Me.DsPercepciones1.Clear()
            Me.rptPDFXML11 = Nothing
            Me.rptPDFXML11 = New crpPdfXml11
            Me.rptPDFXML11.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML11.Name))


            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML11.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML11.SetParameterValue("Empresa", "GRUPO CONISAL")
            Dim rfcempresa As String
            rfcempresa = "GCO130624LY4"
            Me.rptPDFXML11.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML11.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML11.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML11.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML11.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML11.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML11.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML11.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML11.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML11.SetParameterValue("FolioFiscal", "N")
            Me.rptPDFXML11.SetParameterValue("SelloCFDI", "N")
            Me.rptPDFXML11.SetParameterValue("SelloSAT", "N")
            Me.rptPDFXML11.SetParameterValue("NumCert", "00001000000301251152")
            Me.rptPDFXML11.SetParameterValue("FechaTimbrado", c.FechaFPago)
            Me.rptPDFXML11.SetParameterValue("LugarExpedicion", "Ciudad de México")
            Me.rptPDFXML11.SetParameterValue("TipoPago", "Pago en una sola  exhibición")
            Me.rptPDFXML11.SetParameterValue("Total", "1")
            Me.rptPDFXML11.SetParameterValue("CertificadoSAT", "N")
            Me.rptPDFXML11.SetParameterValue("clave1", "001")
            Me.rptPDFXML11.SetParameterValue("clave2", "002")
            Me.rptPDFXML11.SetParameterValue("clave3", "001")
            Me.rptPDFXML11.SetParameterValue("clave4", "002")
            Me.rptPDFXML11.SetParameterValue("clave5", "010")
            Me.rptPDFXML11.SetParameterValue("clave6", "011")
            Me.rptPDFXML11.SetParameterValue("descripcion1", "Sueldos, Salarios, Rayas y Jornales")
            Me.rptPDFXML11.SetParameterValue("descripcion2", "Subsidio al Empleo")
            Me.rptPDFXML11.SetParameterValue("descripcion3", "Seguridad Social")
            Me.rptPDFXML11.SetParameterValue("descripcion4", "ISR")
            Me.rptPDFXML11.SetParameterValue("descripcion5", "Infonavit")
            Me.rptPDFXML11.SetParameterValue("descripcion6", "Infonacot")
            Me.rptPDFXML11.SetParameterValue("des1", c.sueldosyjornales)
            Me.rptPDFXML11.SetParameterValue("des2", c.subsidio)
            Me.rptPDFXML11.SetParameterValue("des3", c.seguridadsocial)
            Me.rptPDFXML11.SetParameterValue("des4", c.isr)
            Me.rptPDFXML11.SetParameterValue("des5", c.infonavit)
            Me.rptPDFXML11.SetParameterValue("des6", c.infonacot)
            Me.rptPDFXML11.SetParameterValue("QR", "N")
            Me.rptPDFXML11.SetParameterValue("SalarioDiarioIntegrado", c.SalarioDiarioIntegrado)
            Me.rptPDFXML11.SetParameterValue("puesto", c.Puesto)
            Me.rptPDFXML11.SetParameterValue("periodopago", c.periodopago)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaIPago
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML11.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML11.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML11.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML11.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML11.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML11.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML11.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML11.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML11.Close()

            'Dim mensaje As String
            'mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            'faltantesipp = faltantesipp + mensaje + vbCrLf
            'contadorpdf1 = contadorpdf1 + 1
            'Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    ''junio
    'crear desde excel fin



    Private Sub InsertaDetalles(ByVal foliofiscal As String)
        'VAMOS A AGREGAR UN PARAMETRO PARA QUE SOLO ENCUENTRE LOS DETALLES DE UN FOLIO FISCAL
        Try
            For i As Integer = 0 To Me.arreDetalles.Count - 1
                With CType(Me.arreDetalles(i), clsXML)
                    If .FolioFiscal = foliofiscal Then
                        Me.cKiosco.AgregaDatosDetalles(.FolioFiscal, .NumeroCertificado, .ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionGravado, .ImportePercepcionExento, .Tipo)
                    End If
                    'SI EL PARAMETRO ES IGUAL AL FOLIO FISCAL VAMOS AGREGAR EL DETALLE
                End With
            Next
        Catch ex As Exception
            MsgBox("Error No Controlado 277: " & ex.Message)
        End Try
    End Sub
    Private Sub CreaPDFyFTP(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML3 = Nothing
            Me.rptPDFXML3 = New crpPdfXml3
            Me.rptPDFXML3.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML3.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML3.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML3.SetParameterValue("Empresa", "Foldur S.A. de C.V.")
            Me.rptPDFXML3.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML3.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML3.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML3.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML3.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML3.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML3.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML3.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML3.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML3.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML3.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML3.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML3.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML3.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML3.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML3.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML3.SetParameterValue("Total", c.total)
            Me.rptPDFXML3.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML3.SetParameterValue("QR", qr)
            Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML3.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML3.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML3.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML3.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML3.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML3.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML3.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML3.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML3.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML3.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub


    'CONISAL
    Private Sub CreaPDFyFTPCONISAL(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML2 = Nothing
            Me.rptPDFXML2 = New crpPdfXml2
            Me.rptPDFXML2.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML2.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML2.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML2.SetParameterValue("Empresa", "GRUPO CONISAL")
            Me.rptPDFXML2.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML2.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML2.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML2.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML2.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML2.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML2.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML2.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML2.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML2.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML2.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML2.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML2.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML2.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML2.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML2.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML2.SetParameterValue("Total", c.total)
            Me.rptPDFXML2.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML2.SetParameterValue("QR", qr)
            Me.rptPDFXML2.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML2.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML2.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML2.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML2.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML2.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML2.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML2.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML2.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML2.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML2.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    'CONISAL


    'WIPSI
    Private Sub CreaPDFyFTPWIPSI(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)
        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML5 = Nothing
            Me.rptPDFXML5 = New crpPdfXml5
            Me.rptPDFXML5.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML3.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML5.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML5.SetParameterValue("Empresa", "WIPSSI A.C.")
            Me.rptPDFXML5.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML5.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML5.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            If c.NSS = "" Then
                c.NSS = "xxxxxxxxxxx"
            End If
            Me.rptPDFXML5.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML5.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML5.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML5.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML5.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML5.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML5.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML5.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML5.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML5.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML5.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML5.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML5.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML5.SetParameterValue("Total", c.total)
            Me.rptPDFXML5.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML5.SetParameterValue("QR", qr)
            Me.rptPDFXML5.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML5.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML5.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML5.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML5.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML5.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML3.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML3.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML5.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML5.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML5.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    'WIPSI

    'telecom 
    Private Sub CreaPDFyFTPteleco(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML6 = Nothing
            Me.rptPDFXML6 = New crpPdfXml6
            Me.rptPDFXML6.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML3.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML6.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML6.SetParameterValue("Empresa", "MORGET")
            Me.rptPDFXML6.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML6.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML6.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML6.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML6.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML6.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML6.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML6.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML6.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML6.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML6.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML6.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML6.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML6.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML6.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML6.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML6.SetParameterValue("Total", c.total)
            Me.rptPDFXML6.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML6.SetParameterValue("QR", qr)
            Me.rptPDFXML6.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML6.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML6.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML6.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML6.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML6.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML6.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML6.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML6.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML6.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML6.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub
    Private Sub CreaPDFyFTPUPHETILOLI(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)
        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML10 = Nothing
            Me.rptPDFXML10 = New crpPdfXmlH
            Me.rptPDFXML10.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML10.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML10.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML10.SetParameterValue("Empresa", "UPHETITOLI")
            Me.rptPDFXML10.SetParameterValue("RFCEmpresa", "UPH1603104G8")
            Me.rptPDFXML10.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML10.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            If c.NSS = "" Then
                c.NSS = "xxxxxxxxxxx"
            End If
            Me.rptPDFXML10.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML10.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML10.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML10.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML10.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML10.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML10.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML10.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML10.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML10.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML10.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML10.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML10.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML10.SetParameterValue("Total", c.total)
            Me.rptPDFXML10.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML10.SetParameterValue("QR", qr)
            Me.rptPDFXML10.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML10.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML10.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML10.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML10.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML10.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML10.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML10.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML10.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML10.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML10.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub





    ''talento
    Private Sub CreaPDFyFTPTALENTO(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML8 = Nothing
            Me.rptPDFXML8 = New crpPdfXml8
            Me.rptPDFXML8.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML3.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML8.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML8.SetParameterValue("Empresa", "TALENTO Y DESARROLLO DEL VALLE")
            Me.rptPDFXML8.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML8.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML8.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            If c.NSS = "" Then
                c.NSS = "xxxxxxxxxxx"
            End If
            Me.rptPDFXML8.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML8.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML8.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML8.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML8.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML8.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML8.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML8.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML8.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML8.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML8.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML8.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML8.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML8.SetParameterValue("Total", c.total)
            Me.rptPDFXML8.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML8.SetParameterValue("QR", qr)
            Me.rptPDFXML8.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML8.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML8.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML8.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML8.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML8.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML8.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML8.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML8.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML8.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML8.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    'telecom

    ''morget
    Private Sub CreaPDFyFTPMORGET(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML7 = Nothing
            Me.rptPDFXML7 = New crpPdfXml7
            Me.rptPDFXML7.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML3.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML7.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML7.SetParameterValue("Empresa", "Grupo Morget SA de CV")
            Me.rptPDFXML7.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML7.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML7.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML7.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML7.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML7.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML7.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML7.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML7.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML7.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML7.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML7.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML7.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML7.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML7.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML7.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML7.SetParameterValue("Total", c.total)
            Me.rptPDFXML7.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML7.SetParameterValue("QR", qr)
            Me.rptPDFXML7.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML7.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML7.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML7.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML7.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML7.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML7.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML7.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML7.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML7.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML7.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub
    ''morget

    'aicel
    Private Sub CreaPDFyFTPAICEL(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)


        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML12 = Nothing
            Me.rptPDFXML12 = New crpPdfXmlAicel
            Me.rptPDFXML12.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML12.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML12.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML12.SetParameterValue("Empresa", "ASOCIACION IBEROAMERICANA DE CONTENIDOS EDUCATIVOS EN LINEA AC")
            Me.rptPDFXML12.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML12.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML12.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML12.SetParameterValue("NSS", "xxx")
            Me.rptPDFXML12.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML12.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML12.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML12.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML12.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML12.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML12.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML12.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML12.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML12.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML12.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML12.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML12.SetParameterValue("Total", c.total)
            Me.rptPDFXML12.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML12.SetParameterValue("QR", qr)
            Me.rptPDFXML12.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML12.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML12.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML12.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML12.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML12.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML12.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML12.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML12.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML12.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML12.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub
    'aicel


    ''nuevas empresas

    ''empresa 1 
    Private Sub CreaPDFyFTPINFORMATION(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)


        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML13 = Nothing
            Me.rptPDFXML13 = New crpPdfXml13
            Me.rptPDFXML13.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML13.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML13.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML13.SetParameterValue("Empresa", "INFORMATION THECNOLOGY INDUSTRIES ITI SA DE CV")
            Me.rptPDFXML13.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML13.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML13.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML13.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML13.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML13.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML13.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML13.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML13.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML13.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML13.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML13.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML13.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML13.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML13.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML13.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML13.SetParameterValue("Total", c.total)
            Me.rptPDFXML13.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML13.SetParameterValue("QR", qr)
            Me.rptPDFXML13.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML13.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML13.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML13.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML13.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML13.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML13.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML13.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML13.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML13.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML13.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub


    ''empresa 2

    Private Sub CreaPDFyFTPPEPSAT(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML14 = Nothing
            Me.rptPDFXML14 = New crpPdfXml14
            Me.rptPDFXML14.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML14.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML14.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML14.SetParameterValue("Empresa", "PEPSAT SA DE CV")
            Me.rptPDFXML14.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML14.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML14.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML14.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML14.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML14.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML14.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML14.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML14.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML14.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML14.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML14.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML14.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML14.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML14.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML14.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML14.SetParameterValue("Total", c.total)
            Me.rptPDFXML14.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML14.SetParameterValue("QR", qr)
            Me.rptPDFXML14.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML14.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML14.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML14.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML14.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML14.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML14.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML14.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML14.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML14.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML14.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    ''empresa 3

    Private Sub CreaPDFyFTPCROTEC(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If


        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML15 = Nothing
            Me.rptPDFXML15 = New crpPdfXml15
            Me.rptPDFXML15.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML15.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML15.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML15.SetParameterValue("Empresa", "CROTEC SA DE CV")
            Me.rptPDFXML15.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML15.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML15.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML15.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML15.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML15.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML15.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML15.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML15.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML15.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML15.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML15.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML15.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML15.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML15.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML15.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML15.SetParameterValue("Total", c.total)
            Me.rptPDFXML15.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML15.SetParameterValue("QR", qr)
            Me.rptPDFXML15.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML15.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML15.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML15.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML15.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML15.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML15.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML15.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML15.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML15.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML15.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    ''empresa 4

    Private Sub CreaPDFyFTPNUBULA(ByVal c As clsXML, ByVal c2 As Double, ByVal c3 As String, ByVal redondeo As Double)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Dim entero As Integer
        entero = Math.Ceiling(redondeo)
        Try
            ' AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML16 = Nothing
            Me.rptPDFXML16 = New crpPdfXml16
            Me.rptPDFXML16.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML15.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.tipoPercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If

            Me.rptPDFXML16.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML16.SetParameterValue("Empresa", "NUBULA SA DE CV")
            Me.rptPDFXML16.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML16.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML16.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML16.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML16.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML16.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML16.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML16.SetParameterValue("DiasTrabajados", entero)
            Me.rptPDFXML16.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML16.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML16.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML16.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML16.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML16.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML16.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML16.SetParameterValue("TipoPago", c.TipoPago)
            Me.rptPDFXML16.SetParameterValue("Total", c.total)
            Me.rptPDFXML16.SetParameterValue("CertificadoSAT", c.noCertificadoSAT)
            Dim qr As String = "?re=" + c.RFCEmpresa + "&rr=" + c.RFCEmpleado + "&tt=" + c.total + "&id=" + c.FolioFiscal
            Me.rptPDFXML16.SetParameterValue("QR", qr)
            Me.rptPDFXML16.SetParameterValue("SalarioDiarioIntegrado", c2)
            Me.rptPDFXML16.SetParameterValue("puesto", c3)

            'Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegral", c.TipoPago)
            'Me.rptPDFXML3.SetParameterValue("puesto", c.Puesto)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = c.FechaFPago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = c.RFCEmpresa.ToString.ToLower

            'yyy
            nombre = c.RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & c.RFCEmpleado
            If chbpc.Checked Then
                '  Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ''prueba

                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML16.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML16.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML16.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML16.Export()
                Catch ex As Exception
                    Throw ex
                End Try



                ''prueba



                ' AdminMemory.LibrerarMemoria()

            Else
                Dim vFileName As String = Nothing
                Dim diskOpts As New DiskFileDestinationOptions()

                Try
                    rptPDFXML16.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
                    rptPDFXML16.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat

                    'Este es la ruta donde se guardara tu archivo.
                    vFileName = ruta & "\" & nombre & ".pdf"
                    If File.Exists(vFileName) Then
                        File.Delete(vFileName)
                    End If
                    diskOpts.DiskFileName = vFileName
                    rptPDFXML16.ExportOptions.DestinationOptions = diskOpts
                    rptPDFXML16.Export()
                Catch ex As Exception
                    Throw ex
                End Try

                ''Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
                ' AdminMemory.LibrerarMemoria()
                Dim clsRequest As System.Net.FtpWebRequest = _
        DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".pdf")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()

                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".pdf")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            End If
            '   AdminMemory.LibrerarMemoria()
            Me.rptPDFXML16.Close()

            'Dim mensaje As String
            mensaje = c.NombreEmpleado.ToLower + "PDF" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf
            contadorpdf1 = contadorpdf1 + 1
            Label15.Text = contadorpdf1

        Catch ex As Exception


            ' MsgBox("El recibo con nombre  " + c.NombreEmpleado + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde ")
            mensaje = c.NombreEmpleado.ToLower + "PDF  " + ex.Message
            faltantesipp = faltantesipp + mensaje + vbCrLf

            ' faltantesipp = faltantesipp + c.NombreEmpleado + vbCrLf
            contadorfaipp = contadorfaipp + 1

        End Try
    End Sub

    ''nuevas empresas




    'nuevo pdf
    Private Sub crearpdf(ByVal empresaa As String, ByVal rfcempresa As String, ByVal empleado As String, ByVal integrado As String, ByVal rfcempleado As String, ByVal nss As String, ByVal curp As String, ByVal fechaipago As String, ByVal fechafpago As String,
                         ByVal diastrabajados As String, ByVal departamento As String, ByVal puesto As String, ByVal foliofiscal As String, ByVal sellocfdi As String, ByVal sellosat As String, ByVal numcert As String, ByVal fechatimbrado As Date,
                         ByVal lugarexp As String, ByVal tipopago As String, ByVal total As String, ByVal certificadosat As String)

        Try

            AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML = Nothing

            Me.rptPDFXML = New crpPdfXml
            Me.rptPDFXML.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If foliofiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer



            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If



            Me.rptPDFXML.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML.SetParameterValue("Empresa", empresaa)
            Me.rptPDFXML.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML.SetParameterValue("Empleado", empleado)
            Me.rptPDFXML.SetParameterValue("SalarioDiarioIntegrado", integrado)
            Me.rptPDFXML.SetParameterValue("RFCEmpleado", rfcempleado)
            Me.rptPDFXML.SetParameterValue("NSS", nss)
            Me.rptPDFXML.SetParameterValue("CURP", curp)
            Me.rptPDFXML.SetParameterValue("FechaIPago", fechaipago)
            Me.rptPDFXML.SetParameterValue("FechaFPago", fechafpago)
            Me.rptPDFXML.SetParameterValue("DiasTrabajados", diastrabajados)
            Me.rptPDFXML.SetParameterValue("Departamento", departamento)
            Me.rptPDFXML.SetParameterValue("Puesto", puesto)
            Me.rptPDFXML.SetParameterValue("FolioFiscal", foliofiscal)
            Me.rptPDFXML.SetParameterValue("SelloCFDI", sellocfdi)
            Me.rptPDFXML.SetParameterValue("SelloSAT", sellosat)
            Me.rptPDFXML.SetParameterValue("NumCert", numcert)
            Me.rptPDFXML.SetParameterValue("FechaTimbrado", fechatimbrado)
            Me.rptPDFXML.SetParameterValue("LugarExpedicion", lugarexp)
            Me.rptPDFXML.SetParameterValue("TipoPago", tipopago)
            Me.rptPDFXML.SetParameterValue("Total", total)



            Me.rptPDFXML.SetParameterValue("CertificadoSAT", certificadosat)



            Dim qr As String = "?re=" + rfcempresa + "&rr=" + rfcempleado + "&tt=" + total + "&id=" + foliofiscal
            Me.rptPDFXML.SetParameterValue("QR", qr)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = fechatimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = fechafpago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            If empresa = "itp070516tk8" Then
                empresa = "Ivve1303205f0"
            End If


            If empresa = "coi130409ew6" Then
                empresa = "irt150703hd0"
            End If

            'yyy
            nombre = rfcempresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            Me.rptPDFXML.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()

            Dim clsRequest As System.Net.FtpWebRequest = _
     DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()
            Me.rptPDFXML.Close()

        Catch ex As Exception


            MsgBox("El archivo PDF no se pudo crear" & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try
    End Sub

    Private Sub crearpdfconi(ByVal empresaa As String, ByVal rfcempresa As String, ByVal empleado As String, ByVal integrado As String, ByVal rfcempleado As String, ByVal nss As String, ByVal curp As String, ByVal fechaipago As String, ByVal fechafpago As String,
                         ByVal diastrabajados As String, ByVal departamento As String, ByVal puesto As String, ByVal foliofiscal As String, ByVal sellocfdi As String, ByVal sellosat As String, ByVal numcert As String, ByVal fechatimbrado As Date,
                         ByVal lugarexp As String, ByVal tipopago As String, ByVal total As String, ByVal certificadosat As String)

        Try

            AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML2 = Nothing

            Me.rptPDFXML2 = New crpPdfXml2
            Me.rptPDFXML2.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML2.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If foliofiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer



            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If



            Me.rptPDFXML2.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML2.SetParameterValue("Empresa", empresaa)
            Me.rptPDFXML2.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML2.SetParameterValue("Empleado", empleado)
            Me.rptPDFXML2.SetParameterValue("SalarioDiarioIntegrado", integrado)
            Me.rptPDFXML2.SetParameterValue("RFCEmpleado", rfcempleado)
            Me.rptPDFXML2.SetParameterValue("NSS", nss)
            Me.rptPDFXML2.SetParameterValue("CURP", curp)
            Me.rptPDFXML2.SetParameterValue("FechaIPago", fechaipago)
            Me.rptPDFXML2.SetParameterValue("FechaFPago", fechafpago)
            Me.rptPDFXML2.SetParameterValue("DiasTrabajados", diastrabajados)
            Me.rptPDFXML2.SetParameterValue("Departamento", departamento)
            Me.rptPDFXML2.SetParameterValue("Puesto", puesto)
            Me.rptPDFXML2.SetParameterValue("FolioFiscal", foliofiscal)
            Me.rptPDFXML2.SetParameterValue("SelloCFDI", sellocfdi)
            Me.rptPDFXML2.SetParameterValue("SelloSAT", sellosat)
            Me.rptPDFXML2.SetParameterValue("NumCert", numcert)
            Me.rptPDFXML2.SetParameterValue("FechaTimbrado", fechatimbrado)
            Me.rptPDFXML2.SetParameterValue("LugarExpedicion", lugarexp)
            Me.rptPDFXML2.SetParameterValue("TipoPago", tipopago)
            Me.rptPDFXML2.SetParameterValue("Total", total)



            Me.rptPDFXML2.SetParameterValue("CertificadoSAT", certificadosat)



            Dim qr As String = "?re=" + rfcempresa + "&rr=" + rfcempleado + "&tt=" + total + "&id=" + foliofiscal
            Me.rptPDFXML2.SetParameterValue("QR", qr)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = fechatimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = fechafpago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            If empresa = "itp070516tk8" Then
                empresa = "Ivve1303205f0"
            End If


            If empresa = "coi130409vve6" Then
                empresa = "vve1303205f0"
            End If

            'yyy
            nombre = rfcempresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            Me.rptPDFXML2.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()

            Dim clsRequest As System.Net.FtpWebRequest = _
     DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".pdf")

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()
            Me.rptPDFXML2.Close()

        Catch ex As Exception


            MsgBox("El archivo PDF no se pudo crear" & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try
    End Sub



    ''pdf market

    Private Sub crearpdfvirtual(ByVal empresaa As String, ByVal rfcempresa As String, ByVal empleado As String, ByVal integrado As String, ByVal rfcempleado As String, ByVal nss As String, ByVal curp As String, ByVal fechaipago As String, ByVal fechafpago As String,
                        ByVal diastrabajados As String, ByVal departamento As String, ByVal puesto As String, ByVal foliofiscal As String, ByVal sellocfdi As String, ByVal sellosat As String, ByVal numcert As String, ByVal fechatimbrado As Date,
                        ByVal lugarexp As String, ByVal tipopago As String, ByVal total As String, ByVal certificadosat As String)

        Try

            AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML4 = Nothing

            Me.rptPDFXML4 = New crpPdfXml4
            Me.rptPDFXML4.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML4.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If foliofiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer



            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If



            Me.rptPDFXML4.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML4.SetParameterValue("Empresa", empresaa)
            Me.rptPDFXML4.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML4.SetParameterValue("Empleado", empleado)
            Me.rptPDFXML4.SetParameterValue("SalarioDiarioIntegrado", integrado)
            Me.rptPDFXML4.SetParameterValue("RFCEmpleado", rfcempleado)
            Me.rptPDFXML4.SetParameterValue("NSS", nss)
            Me.rptPDFXML4.SetParameterValue("CURP", curp)
            Me.rptPDFXML4.SetParameterValue("FechaIPago", fechaipago)
            Me.rptPDFXML4.SetParameterValue("FechaFPago", fechafpago)
            Me.rptPDFXML4.SetParameterValue("DiasTrabajados", diastrabajados)
            Me.rptPDFXML4.SetParameterValue("Departamento", departamento)
            Me.rptPDFXML4.SetParameterValue("Puesto", puesto)
            Me.rptPDFXML4.SetParameterValue("FolioFiscal", foliofiscal)
            Me.rptPDFXML4.SetParameterValue("SelloCFDI", sellocfdi)
            Me.rptPDFXML4.SetParameterValue("SelloSAT", sellosat)
            Me.rptPDFXML4.SetParameterValue("NumCert", numcert)
            Me.rptPDFXML4.SetParameterValue("FechaTimbrado", fechatimbrado)
            Me.rptPDFXML4.SetParameterValue("LugarExpedicion", lugarexp)
            Me.rptPDFXML4.SetParameterValue("TipoPago", tipopago)
            Me.rptPDFXML4.SetParameterValue("Total", total)



            Me.rptPDFXML4.SetParameterValue("CertificadoSAT", certificadosat)



            Dim qr As String = "?re=" + rfcempresa + "&rr=" + rfcempleado + "&tt=" + total + "&id=" + foliofiscal
            Me.rptPDFXML4.SetParameterValue("QR", qr)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = fechatimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = fechafpago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            'yyy
            nombre = rfcempresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            Me.rptPDFXML4.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()

            Dim clsRequest As System.Net.FtpWebRequest = _
     DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()
            Me.rptPDFXML2.Close()

        Catch ex As Exception


            MsgBox("El archivo PDF no se pudo crear" & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try
    End Sub

    ''pdf market


    ''pdf3

    Private Sub crearpdf3(ByVal empresaa As String, ByVal rfcempresa As String, ByVal empleado As String, ByVal integrado As String, ByVal rfcempleado As String, ByVal nss As String, ByVal curp As String, ByVal fechaipago As String, ByVal fechafpago As String,
                         ByVal diastrabajados As String, ByVal departamento As String, ByVal puesto As String, ByVal foliofiscal As String, ByVal sellocfdi As String, ByVal sellosat As String, ByVal numcert As String, ByVal fechatimbrado As Date,
                         ByVal lugarexp As String, ByVal tipopago As String, ByVal total As String, ByVal certificadosat As String)

        Try

            AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML3 = Nothing

            Me.rptPDFXML3 = New crpPdfXml3
            Me.rptPDFXML3.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML2.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If foliofiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer



            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If



            Me.rptPDFXML3.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML3.SetParameterValue("Empresa", empresaa)
            Me.rptPDFXML3.SetParameterValue("RFCEmpresa", rfcempresa)
            Me.rptPDFXML3.SetParameterValue("Empleado", empleado)
            Me.rptPDFXML3.SetParameterValue("SalarioDiarioIntegrado", integrado)
            Me.rptPDFXML3.SetParameterValue("RFCEmpleado", rfcempleado)
            Me.rptPDFXML3.SetParameterValue("NSS", nss)
            Me.rptPDFXML3.SetParameterValue("CURP", curp)
            Me.rptPDFXML3.SetParameterValue("FechaIPago", fechaipago)
            Me.rptPDFXML3.SetParameterValue("FechaFPago", fechafpago)
            Me.rptPDFXML3.SetParameterValue("DiasTrabajados", diastrabajados)
            Me.rptPDFXML3.SetParameterValue("Departamento", departamento)
            Me.rptPDFXML3.SetParameterValue("Puesto", puesto)
            Me.rptPDFXML3.SetParameterValue("FolioFiscal", foliofiscal)
            Me.rptPDFXML3.SetParameterValue("SelloCFDI", sellocfdi)
            Me.rptPDFXML3.SetParameterValue("SelloSAT", sellosat)
            Me.rptPDFXML3.SetParameterValue("NumCert", numcert)
            Me.rptPDFXML3.SetParameterValue("FechaTimbrado", fechatimbrado)
            Me.rptPDFXML3.SetParameterValue("LugarExpedicion", lugarexp)
            Me.rptPDFXML3.SetParameterValue("TipoPago", tipopago)
            Me.rptPDFXML3.SetParameterValue("Total", total)



            Me.rptPDFXML3.SetParameterValue("CertificadoSAT", certificadosat)



            Dim qr As String = "?re=" + rfcempresa + "&rr=" + rfcempleado + "&tt=" + total + "&id=" + foliofiscal
            Me.rptPDFXML3.SetParameterValue("QR", qr)

            Dim año, mes, dia, hora, minuto As String
            Dim nombre As String
            Dim fecha As Date = fechatimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = fechafpago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresa.ToString.ToLower

            'yyy
            nombre = rfcempresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            Me.rptPDFXML3.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()

            Dim clsRequest As System.Net.FtpWebRequest = _
     DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()
            Me.rptPDFXML3.Close()

        Catch ex As Exception


            MsgBox("El archivo PDF no se pudo crear" & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try
    End Sub

    ''pdf3


    ''haberes
    Private Sub crearpdfh(ByVal empresaa As String, ByVal rfcempresa As String, ByVal empleado As String, ByVal rfcempleado As String, ByVal curp As String, ByVal fechaipago As String, ByVal fechafpago As String,
                        ByVal diastrabajados As String, ByVal foliofiscal As String, ByVal sellocfdi As String, ByVal sellosat As String, ByVal numcert As String, ByVal fechatimbrado As Date,
                        ByVal lugarexp As String, ByVal tipopago As String, ByVal total As String, ByVal certificadosat As String, ByVal rfcempresapadre As String)
        Try

            AdminMemory.LibrerarMemoria()
            Me.DsPercepciones1.Clear()
            Me.hrptPDFXML = Nothing

            Me.hrptPDFXML = New haberescrpPdfXml
            Me.hrptPDFXML.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.hrptPDFXML.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If foliofiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal, 1)
                            End If
                        End If
                    End With
                Next
            End If

            Dim diferencia As Integer
            Dim contador As Integer


            If Me.DsPercepciones1.Percepcion.Rows.Count <> Me.DsPercepciones1.Deducciones.Rows.Count Then
                If Me.DsPercepciones1.Percepcion.Rows.Count > Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Percepcion.Rows.Count - Me.DsPercepciones1.Deducciones.Rows.Count
                    contador = 0
                    While contador < diferencia
                        Me.DsPercepciones1.Deducciones.AddDeduccionesRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                ElseIf Me.DsPercepciones1.Percepcion.Rows.Count < Me.DsPercepciones1.Deducciones.Rows.Count Then
                    diferencia = Me.DsPercepciones1.Deducciones.Rows.Count - Me.DsPercepciones1.Percepcion.Rows.Count
                    While contador < diferencia
                        Me.DsPercepciones1.Percepcion.AddPercepcionRow("", "", 0, 0, "", 0)
                        contador += 1
                    End While
                End If
            End If


            Me.hrptPDFXML.SetDataSource(Me.DsPercepciones1)
            Me.hrptPDFXML.SetParameterValue("Empresa", "WIPSSI A.C.")
            Me.hrptPDFXML.SetParameterValue("RFCEmpresa", "DAS060320KQ5")
            Me.hrptPDFXML.SetParameterValue("Empleado", empleado)
            Me.hrptPDFXML.SetParameterValue("RFCEmpleado", rfcempleado)
            Me.hrptPDFXML.SetParameterValue("CURP", curp)
            Me.hrptPDFXML.SetParameterValue("FechaIPago", fechaipago)
            Me.hrptPDFXML.SetParameterValue("FechaFPago", fechafpago)
            Me.hrptPDFXML.SetParameterValue("DiasTrabajados", diastrabajados)
            Me.hrptPDFXML.SetParameterValue("FolioFiscal", foliofiscal)
            Me.hrptPDFXML.SetParameterValue("SelloCFDI", sellocfdi)
            Me.hrptPDFXML.SetParameterValue("SelloSAT", sellosat)
            Me.hrptPDFXML.SetParameterValue("NumCert", numcert)
            Me.hrptPDFXML.SetParameterValue("FechaTimbrado", fechatimbrado)
            Me.hrptPDFXML.SetParameterValue("LugarExpedicion", lugarexp)
            Me.hrptPDFXML.SetParameterValue("TipoPago", tipopago)
            Me.hrptPDFXML.SetParameterValue("Total", total)
            Me.hrptPDFXML.SetParameterValue("CertificadoSAT", certificadosat)

            Dim qr As String = "?re=" + rfcempresa + "&rr=" + rfcempleado + "&tt=" + total + "&id=" + foliofiscal
            Me.hrptPDFXML.SetParameterValue("QR", qr)

            Dim año, mes, dia, hora, minuto, segundo As String
            Dim nombre As String
            Dim fecha As Date = fechatimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString

            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyyy
            Dim mesm As String
            Dim fpago As Date = fechafpago
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = rfcempresapadre.ToString.ToLower

            'yyy
            nombre = "H" & rfcempresapadre & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            Me.hrptPDFXML.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()

            '       Dim clsRequest As System.Net.FtpWebRequest = _
            'DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            '       clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            '       clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            '       ' read in file...
            '       Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")

            '       ' upload file...
            '       Dim clsStream As System.IO.Stream = _
            '           clsRequest.GetRequestStream()
            '       clsStream.Write(bFile, 0, bFile.Length)
            '       clsStream.Close()
            '       clsStream.Dispose()

            '       My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")
            AdminMemory.LibrerarMemoria()
            Me.hrptPDFXML.Close()

        Catch ex As Exception


            MsgBox("El archivo PDF no se pudo crear" & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try
    End Sub
    ''haberes
    'nuevo pdf

    Private Sub CreaXMLYFTP(ByVal xml As String, ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal nombreemp As String)

        'Dim ruta As String
        '''
        'If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then

        '    ' List files in the folder.

        '    ListFiles(FolderBrowserDialog1.SelectedPath)


        '    ruta = FolderBrowserDialog1.SelectedPath
        '    ''

        'End If

        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower

            Label2.Text = empresa
            If chbpc.Checked Then
                Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
                Dim xmldoc As New XmlDocument
                'Dim xmldecl As XmlDeclaration
                xmldoc.LoadXml(xml)
                xmldoc.Save(ruta & "\" & nombre & ".xml")
                'xmldoc.Save(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".xml")

            Else

                Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
                Dim xmldoc As New XmlDocument
                'Dim xmldecl As XmlDeclaration
                xmldoc.LoadXml(xml)

                'xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
                'Dim root As XmlElement = xmldoc.DocumentElement
                'xmldoc.InsertBefore(xmldecl, root)
                xmldoc.Save(ruta & "\" & nombre & ".xml")
                ' xmldoc.Save(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".xml")



                Dim clsRequest As System.Net.FtpWebRequest =
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                ' read in file...

                Dim bFile() As Byte = System.IO.File.ReadAllBytes("c:\Recibos nextel\" & nombre & ".xml")
                'Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Recibos\" & nombre & ".xml")

                ' upload file...
                Dim clsStream As System.IO.Stream =
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()


                My.Computer.FileSystem.DeleteFile("c:\Recibos nextel\" & nombre & ".xml")
                ' My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".xml")

            End If
            mensaje = nombreemp.ToLower + "XML" + " Ok "
            faltantesipp = faltantesipp + mensaje + vbCrLf

            contadorxml1 = contadorxml1 + 1
            Label13.Text = contadorxml1
        Catch ex As Exception
            mensaje = nombreemp.ToLower + "XML" + " Error "
            faltantesipp = faltantesipp + mensaje + vbCrLf
        End Try
    End Sub

    ''nuevo
    Private Sub subirxml(ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal ruta As String, ByVal rutapdf As String)
        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "Ivve1303205f0"
            End If


            If empresa = "coi130409ew6" Then
                empresa = "irt150703hd0"
            End If

            ''revisar si exste el fichero y si no crearlo

            Dim nombre As String = empresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            ''revisar si exste el fichero y si no crearlo
            Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(ruta)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()




        Catch ex As Exception
            MsgBox("Error No Controlado Al Crear Xml: " & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try

        'subir pdf

        '        Try
        '            Dim año, mes, dia, hora, minuto As String
        '            año = fecha.Year.ToString
        '            mes = fecha.Month.ToString
        '            dia = fecha.Day.ToString
        '            hora = fecha.Hour.ToString
        '            minuto = fecha.Minute.ToString
        '            If mes.Length = 1 Then
        '                mes = "0" & mes
        '            End If
        '            'yyyyy
        '            Dim mesm As String
        '            mesm = fpago.Month.ToString
        '            If mesm.Length = 1 Then
        '                mesm = "0" & mesm
        '            End If
        '            Dim mesl As Integer
        '            Dim nombrem As String
        '            mesl = mesm
        '            nombrem = MonthName(mesl)
        '            Dim empresa As String = RFCEmpresa.ToString.ToLower
        '            Label2.Text = empresa

        '            ''revisar si exste el fichero y si no crearlo

        '            Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

        '            ''revisar si exste el fichero y si no crearlo
        '            Dim clsRequest As System.Net.FtpWebRequest = _
        'DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
        '            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "Ajpb1Q02T9yF")
        '            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
        '            ' read in file...
        '            Dim bFile() As Byte = System.IO.File.ReadAllBytes(rutapdf)

        '            ' upload file...
        '            Dim clsStream As System.IO.Stream = _
        '                clsRequest.GetRequestStream()
        '            clsStream.Write(bFile, 0, bFile.Length)
        '            clsStream.Close()
        '            clsStream.Dispose()




        '        Catch ex As Exception
        '            MsgBox("Error No Controlado Al Crear Xml: " & ex.Message, MsgBoxStyle.Critical, "Sistema")

        '        End Try

        'subir pdf
    End Sub

    ''nuevo
    Private Sub subirxml1(ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal ruta As String, ByVal rutapdf As String)
        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Minute.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "vve1303205f0"
            End If

            If empresa = "COI130409EW6" Then
                empresa = "irt150703hd0"
            End If

            ''revisar si exste el fichero y si no crearlo
            Dim nombre As String = empresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
            'Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            ''revisar si exste el fichero y si no crearlo
            Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Timeout = 3600
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile


            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(ruta)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()




        Catch ex As Exception
            MsgBox("Error No Controlado Al Crear Xml: " & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try

        'subir pdf

        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "vve1303205f0"
            End If




            If empresa = "COI130409EW6" Then
                empresa = "irt150703hd0"
            End If



            ''revisar si exste el fichero y si no crearlo
            Dim nombre As String = empresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
            'Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado

            ''revisar si exste el fichero y si no crearlo
            Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(rutapdf)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()




        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try

        'subir pdf
    End Sub

    Private Sub SubirXmlYPDF(ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal directorio As String, ByVal archivo As String)


        Try




            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "vve1303205f0"
            End If

            If empresa = "coi130409ew6" Or empresa = "COI130409EW6" Then
                empresa = "irt150703hd0"
            End If

            If empresa = "das060320kq5" Then
                empresa = "tdv0809118t3"

                'If emoresa = "gco130624L4" Then
                '    empresa = ""
                'End If
            End If
            '        For Each foundFile As String In My.Computer.FileSystem.GetFiles(
            'My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RecibosSicoss\",
            'Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

            '            My.Computer.FileSystem.DeleteFile(foundFile,
            '                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
            '                Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            '        Next

            ''revisar si exste el fichero y si no crearlo
            Dim nombre As String = empresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
            'Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado
            If chcsicoss.Checked Then
                My.Computer.FileSystem.CopyFile(
                    directorio & "\" & archivo & ".xml",
                SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml"
                   )
                My.Computer.FileSystem.RenameFile(SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & ".xml")
                'My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & "")

            Else
                ''revisar si exste el fichero y si no crearlo
                Dim clsRequest As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.KeepAlive = False
                clsRequest.UsePassive = False
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes(directorio & "\" & archivo & ".xml")

                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()
            End If
            ''''septiembre

            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy

            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If

            mesl = mesm
            nombrem = MonthName(mesl)

            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "vve1303205f0"
            End If


            If empresa = "coi130409ew6" Then
                empresa = "irt150703hd0"
            End If

            If empresa = "das060320kq5" Then
                empresa = "tdv0809118t3"
            End If



            ''revisar si exste el fichero y si no crearlo
            nombre = empresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado
            'Dim nombre As String = RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & "_N_" & rfcempleado
            If chcsicoss.Checked Then
                My.Computer.FileSystem.CopyFile(
                    directorio & "\" & archivo & ".pdf",
                SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".pdf"
                   )
                My.Computer.FileSystem.RenameFile(SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".pdf", nombre & ".pdf")
                'My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & "")

            Else
                ''revisar si exste el fichero y si no crearlo
                Dim clsRequest1 As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest1.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest1.KeepAlive = False
                clsRequest1.UsePassive = False
                clsRequest1.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                ' read in file...
                Dim bFile1() As Byte = System.IO.File.ReadAllBytes(directorio & "\" & archivo & ".pdf")

                ' upload file...
                Dim clsStream1 As System.IO.Stream = _
                    clsRequest1.GetRequestStream()
                clsStream1.Write(bFile1, 0, bFile1.Length)
                clsStream1.Close()
                clsStream1.Dispose()
            End If
        Catch ex As Exception
            Timer1.Enabled = True
            'El intervalo es de 5 segundos 
            Timer1.Interval = 1000
            MsgBox("Error : " & ex.Message)
            'MsgBox("El recibo con nombre  " + archivo + " No pudo ser subido debido a una interrupción en su conexión  por favor intentelo mas tarde")

            faltantes = faltantes + archivo + vbCrLf
            contadorfa = contadorfa + 1

        End Try

    End Sub

    ''sequincena
    Private Sub subirxmlq(ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal ruta As String, ByVal rutapdf As String)
        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            ''revisar si exste el fichero y si no crearlo

            Dim nombre As String = "2" & RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            ''revisar si exste el fichero y si no crearlo
            Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(ruta)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()




        Catch ex As Exception
            MsgBox("Error No Controlado Al Crear Xml: " & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try

        'subir pdf

        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            ''revisar si exste el fichero y si no crearlo

            Dim nombre As String = "2" & RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            ''revisar si exste el fichero y si no crearlo
            Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(rutapdf)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()




        Catch ex As Exception
            MsgBox("No se e: " & ex.Message, MsgBoxStyle.Critical, "Sistema")

        End Try

        'subir pdf
    End Sub
    ''sequincena

    ''nuevo

    ''haberes

    ''nuevo
    Private Sub subirxml2(ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String, ByVal fpago As Date, ByVal directorio As String, ByVal archivo As String)
        Try
            Dim año, mes, dia, hora, minuto, segundo As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy
            Dim mesm As String
            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If
            Dim mesl As Integer
            Dim nombrem As String
            mesl = mesm
            nombrem = MonthName(mesl)
            Dim empresa As String = RFCEmpresa.ToString.ToLower
            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "Ivve1303205f0"
            End If


            If empresa = "coi130409ew6" Or empresa = "COI130409EW6" Then
                empresa = "irt150703hd0"

            End If
            ''revisar si exste el fichero y si no crearlo

            Dim nombre As String = "H" & RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            ''cambiar nombre y guardar
            If chcsicoss.Checked Then
                My.Computer.FileSystem.CopyFile(
                    directorio & "\" & archivo & ".xml",
                SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml"
                   )
                My.Computer.FileSystem.RenameFile(SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & ".xml")
                'My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & "")

            Else

                ''revisar si exste el fichero y si no crearlo
                Dim clsRequest As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".xml"), System.Net.FtpWebRequest)
                clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest.Timeout = 3600
                clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                ' read in file...
                Dim bFile() As Byte = System.IO.File.ReadAllBytes(directorio & "\" & archivo & ".xml")
                ' upload file...
                Dim clsStream As System.IO.Stream = _
                    clsRequest.GetRequestStream()
                clsStream.Write(bFile, 0, bFile.Length)
                clsStream.Close()
                clsStream.Dispose()
            End If


            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            hora = fecha.Hour.ToString
            minuto = fecha.Minute.ToString
            segundo = fecha.Second.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            'yyyyy

            mesm = fpago.Month.ToString
            If mesm.Length = 1 Then
                mesm = "0" & mesm
            End If

            mesl = mesm
            nombrem = MonthName(mesl)

            Label2.Text = empresa

            If empresa = "itp070516tk8" Then
                empresa = "Ivve1303205f0"
            End If


            If empresa = "coi130409ew6" Or empresa = "COI130409EW6" Then
                empresa = "irt150703hd0"
            End If

            ''revisar si exste el fichero y si no crearlo

            nombre = "H" & RFCEmpresa & "_" & "Pago_de_Nómina" & "_" & año & mes & dia & hora & minuto & segundo & "_N_" & rfcempleado

            If chcsicoss.Checked Then
                My.Computer.FileSystem.CopyFile(
                    directorio & "\" & archivo & ".pdf",
                SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".pdf"
                   )
                My.Computer.FileSystem.RenameFile(SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".pdf", nombre & ".pdf")
                'My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\RecibosSicoss\" & archivo & ".xml", nombre & "")

            Else

                ''revisar si exste el fichero y si no crearlo
                Dim clsRequest1 As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & empresa.ToString & "/" & año.ToString & "/" & nombrem & "/" & nombre & ".pdf"), System.Net.FtpWebRequest)
                clsRequest1.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                clsRequest1.Timeout = 3600
                clsRequest1.Method = System.Net.WebRequestMethods.Ftp.UploadFile
                ' read in file...
                Dim bFile1() As Byte = System.IO.File.ReadAllBytes(directorio & "\" & archivo & ".pdf")

                ' upload file...
                Dim clsStream1 As System.IO.Stream = _
                    clsRequest1.GetRequestStream()
                clsStream1.Write(bFile1, 0, bFile1.Length)
                clsStream1.Close()
                clsStream1.Dispose()

            End If

        Catch ex As Exception
            MsgBox("El recibo con nombre  " + archivo + "  No pudo ser subido por favor intentelo mas tarde")

            faltantes = faltantes + archivo + vbCrLf
            contadorfa = contadorfa + 1

        End Try


        'subir pdf
    End Sub
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer2.Enabled = True
        Else
            Timer2.Enabled = False
        End If

    End Sub
    ''haberes

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click


        Button2.Enabled = True
        Me.DirectorioPrincipal = ""
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            filesListBox.Items.Clear()
            Me.DirectorioPrincipal = FolderBrowserDialog1.SelectedPath
            ListFiles(FolderBrowserDialog1.SelectedPath)
            ListFiles1(FolderBrowserDialog1.SelectedPath)
            Me.ObtenNombreArchivo(FolderBrowserDialog1.SelectedPath)
            'Me.MuestraDatosXML()
            Me.MuestraDatosXMLFer()
        End If

        estimado = (contadorpdf + contadorxml) * 3
        estimado1 = estimado / 60
        Label6.Text = estimado1.ToString & " Minutos"




        'If contadorxml <> contadorpdf Then
        '    MsgBox("El total de archivos XML es de " & contadorxml & " y el total de archivos PDF es de " & contadorpdf & vbCrLf & " Revisa tu listado de archivos para poder continuar ")
        '    Me.Close()
        'End If



    End Sub
    ''nuevo (leer archivo xml)

    Public Sub ListFiles1(ByVal folderPath As String)


        Dim fileNamespdf As String() =
            System.IO.Directory.GetFiles(folderPath,
                "*.xml", System.IO.SearchOption.TopDirectoryOnly)
        Me.arreArchivospdf.Clear()
        For Each fileName As String In fileNamespdf
            filesListBox.Items.Add(fileName)
            Dim c As New clsKiosco
            c.RutaArchivopdf = fileName
            Me.arreArchivospdf.Add(c)
            contadorxml = contadorxml + 1
        Next
    End Sub

    Public Sub ListFiles(ByVal folderPath As String)
        filesListBox.Items.Clear()

        Dim fileNames As String() =
            System.IO.Directory.GetFiles(folderPath,
                "*.pdf", System.IO.SearchOption.TopDirectoryOnly)

        Me.arreArchivos.Clear()

        For Each fileName As String In fileNames
            filesListBox.Items.Add(fileName)
            Dim c As New clsKiosco
            c.RutaArchivo = fileName
            Me.arreArchivos.Add(c)
            contadorpdf = contadorpdf + 1
        Next
    End Sub

    Public Sub ObtenNombreArchivo(ByVal folderPath As String)
        filesListBox.Items.Clear()

        Dim fileNames As String() =
            System.IO.Directory.GetFiles(folderPath,
                "*.XML", System.IO.SearchOption.TopDirectoryOnly)

        Me.arreArchivos.Clear()

        For Each fileName As String In fileNames
            filesListBox.Items.Add(fileName)
            Dim c As New clsKiosco
            c.RutaArchivo = Path.GetFileNameWithoutExtension(fileName)
            Me.arreArchivos.Add(c)
        Next
    End Sub

    Private Function LeerXMLArchivo(ByVal archivo As String) As clsXML
        Try


            Dim reader As New XmlTextReader(archivo)
            reader.WhitespaceHandling = WhitespaceHandling.None

            Dim c As New clsXML

            While reader.Read()
                Select Case reader.NodeType
                    Case XmlNodeType.Element
                        Select Case reader.Name
                            Case "cfdi:Emisor"
                                c.Empresa = reader.GetAttribute("nombre")
                                c.RFCEmpresa = reader.GetAttribute("rfc")
                            Case "cfdi:Receptor"
                                c.NombreEmpleado = reader.GetAttribute("nombre")
                                c.RFCEmpleado = reader.GetAttribute("rfc")
                            Case "nomina12:Nomina"
                                'c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                'c.CURP = reader.GetAttribute("Curp")
                                c.FechaIPago = reader.GetAttribute("FechaInicialPago")
                                c.FechaFPago = reader.GetAttribute("FechaFinalPago")
                                c.DiasTrabajados = reader.GetAttribute("NumDiasPagados")
                                'c.Departamento = reader.GetAttribute("Departamento")

                            Case "nomina12:Receptor"
                                c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                c.CURP = reader.GetAttribute("Curp")
                                c.Departamento = reader.GetAttribute("Departamento")
                                ''nuevo
                                'c.Puesto = reader.GetAttribute("Puesto")
                                'c.SalarioDiarioIntegrado = reader.GetAttribute("SalarioDiarioIntegrado")
                                ''nuevo

                            Case "nomina12:OtroPago"
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.tipoPercepcion = reader.GetAttribute("Clave")


                            Case "nomina12:Percepcion"
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.tipoPercepcion = reader.GetAttribute("TipoPercepcion")
                            Case "nomina12:Deduccion"
                                c.Clavededuccion = reader.GetAttribute("Clave")
                                c.Conceptodeduccion = reader.GetAttribute("Concepto")
                                c.ImportededuccionGravado = reader.GetAttribute("Importe")
                                c.ImportededuccionExento = 0
                                'c.ImportededuccionExento = reader.GetAttribute("ImporteExento")
                            Case "tfd:TimbreFiscalDigital"
                                c.FolioFiscal = reader.GetAttribute("UUID")
                                c.SelloDigitalCFDI = reader.GetAttribute("selloCFD")
                                c.SelloDigitalSAT = reader.GetAttribute("selloSAT")
                                c.noCertificadoSAT = reader.GetAttribute("noCertificadoSAT")
                            Case "cfdi:Comprobante"
                                c.NumeroCertificado = reader.GetAttribute("noCertificado")
                                c.FechaTimbrado = reader.GetAttribute("fecha")
                                c.LugarExpedicion = reader.GetAttribute("LugarExpedicion")
                                c.TipoPago = reader.GetAttribute("formaDePago")
                                c.total = reader.GetAttribute("total")
                            Case "cfdi:Emisor"
                                c.Empresa = reader.GetAttribute("nombre")
                                c.RFCEmpresa = reader.GetAttribute("rfc")
                            Case "cfdi:Receptor"
                                c.NombreEmpleado = reader.GetAttribute("nombre")
                                c.RFCEmpleado = reader.GetAttribute("rfc")
                            Case "nomina:Nomina"
                                c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                c.CURP = reader.GetAttribute("CURP")
                                c.FechaIPago = reader.GetAttribute("FechaInicialPago")
                                c.FechaFPago = reader.GetAttribute("FechaFinalPago")
                                c.DiasTrabajados = reader.GetAttribute("NumDiasPagados")
                                c.Puesto = reader.GetAttribute("Puesto")
                                c.SalarioDiarioIntegrado = reader.GetAttribute("SalarioDiarioIntegrado")
                                c.Departamento = reader.GetAttribute("Departamento")
                            Case "nomina:Percepcion"
                                c.ClavePercepcion = reader.GetAttribute("TipoPercepcion")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                            Case "nomina:Deduccion"
                                c.Clavededuccion = reader.GetAttribute("TipoDeduccion")
                                c.Conceptodeduccion = reader.GetAttribute("Concepto")
                                c.ImportededuccionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportededuccionExento = reader.GetAttribute("ImporteExento")
                            Case "tfd:TimbreFiscalDigital"
                                c.FolioFiscal = reader.GetAttribute("UUID")
                                c.SelloDigitalCFDI = reader.GetAttribute("selloCFD")
                                c.SelloDigitalSAT = reader.GetAttribute("selloSAT")
                                c.noCertificadoSAT = reader.GetAttribute("noCertificadoSAT")
                            Case ("cfdi:Comprobante")
                                c.NumeroCertificado = reader.GetAttribute("noCertificado")
                                c.FechaTimbrado = reader.GetAttribute("fecha")
                                c.LugarExpedicion = reader.GetAttribute("LugarExpedicion")
                                c.TipoPago = reader.GetAttribute("formaDePago")
                                c.total = reader.GetAttribute("total")
                        End Select
                End Select
            End While
            reader.Close()
            Return c
        Catch ex As Exception
            MsgBox("Error No Controlado 153: " & ex.Message)
        End Try
    End Function

    ''nuevo xml


    Private Function GetTextForOutput(ByVal filePath As String) As String

        If System.IO.File.Exists(filePath) = False Then
            Throw New Exception("Archivo no encontrado: " & filePath)
        End If
        Dim sb As New System.Text.StringBuilder()


        Dim thisFile As New System.IO.FileInfo(filePath)


        sb.Append("File: " & thisFile.FullName)
        sb.Append(vbCrLf)
        sb.Append("Modified: " & thisFile.LastWriteTime.ToString)
        sb.Append(vbCrLf)
        sb.Append("Size: " & thisFile.Length.ToString & " bytes")
        sb.Append(vbCrLf)


        Dim sr As System.IO.StreamReader =
            System.IO.File.OpenText(filePath)


        If sr.Peek() >= 0 Then
            sb.Append("First Line: " & sr.ReadLine())
        End If
        sr.Close()

        Return sb.ToString
    End Function

    Public Sub MuestraDatosXML()
        Try
            'Me.arreDatos = Me.ListFiles.filesListBox_SelectedIndexChanged(Me.filesListBox())
            Me.DataGridView3.Rows.Clear()

            If Me.arreArchivos.Count > 0 Then
                For i As Integer = 0 To Me.arreArchivos.Count - 1
                    Dim c As clsXML
                    Me.DataGridView3.Rows.Add()
                    With CType(Me.arreArchivos(i), clsKiosco)


                        c = Me.LeerXMLArchivo(.RutaArchivo)




                        Me.DataGridView3.Rows(i).Cells(27).Value = .RutaArchivo
                        Me.DataGridView3.Rows(i).Cells(28).Value = .RutaArchivopdf



                        With c
                            Me.DataGridView3.Rows(i).Cells(0).Value = .Empresa
                            Me.DataGridView3.Rows(i).Cells(1).Value = .RFCEmpresa
                            Me.DataGridView3.Rows(i).Cells(2).Value = .NombreEmpleado
                            Me.DataGridView3.Rows(i).Cells(3).Value = .SalarioDiarioIntegrado
                            Me.DataGridView3.Rows(i).Cells(4).Value = .RFCEmpleado
                            Me.DataGridView3.Rows(i).Cells(5).Value = .NSS
                            Me.DataGridView3.Rows(i).Cells(6).Value = .CURP
                            Me.DataGridView3.Rows(i).Cells(7).Value = .FechaIPago
                            Me.DataGridView3.Rows(i).Cells(8).Value = .FechaFPago
                            Me.DataGridView3.Rows(i).Cells(9).Value = .DiasTrabajados
                            Me.DataGridView3.Rows(i).Cells(10).Value = .Departamento
                            Me.DataGridView3.Rows(i).Cells(11).Value = .Puesto
                            Me.DataGridView3.Rows(i).Cells(1212345678).Value = .ClavePercepcion
                            Me.DataGridView3.Rows(i).Cells(13).Value = .ConceptoPercepcion
                            Me.DataGridView3.Rows(i).Cells(14).Value = .ImportePercepcionGravado
                            Me.DataGridView3.Rows(i).Cells(15).Value = .ImportePercepcionExento
                            Me.DataGridView3.Rows(i).Cells(16).Value = .Clavededuccion
                            Me.DataGridView3.Rows(i).Cells(17).Value = .Conceptodeduccion
                            Me.DataGridView3.Rows(i).Cells(18).Value = .ImportededuccionGravado
                            Me.DataGridView3.Rows(i).Cells(19).Value = .ImportededuccionExento
                            Me.DataGridView3.Rows(i).Cells(20).Value = .FolioFiscal
                            Me.DataGridView3.Rows(i).Cells(21).Value = .SelloDigitalCFDI
                            Me.DataGridView3.Rows(i).Cells(22).Value = .SelloDigitalSAT
                            Me.DataGridView3.Rows(i).Cells(23).Value = .NumeroCertificado
                            Me.DataGridView3.Rows(i).Cells(24).Value = .FechaTimbrado
                            Me.DataGridView3.Rows(i).Cells(25).Value = .LugarExpedicion
                            Me.DataGridView3.Rows(i).Cells(26).Value = .TipoPago
                            Me.DataGridView3.Rows(i).Cells(29).Value = .total
                            Me.DataGridView3.Rows(i).Cells(30).Value = .noCertificadoSAT


                            Me.Detallesarchivo(Me.DataGridView3.Rows(i).Cells(27).Value, .FolioFiscal, .NumeroCertificado)
                        End With
                    End With

                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 380: " & ex.Message)
        End Try

        ''nuevo
        Try
            'Me.arreDatos = Me.ListFiles.filesListBox_SelectedIndexChanged(Me.filesListBox())


            If Me.arreArchivospdf.Count > 0 Then
                For i As Integer = 0 To Me.arreArchivospdf.Count - 1

                    'Me.DataGridView3.Rows.Add()
                    With CType(Me.arreArchivospdf(i), clsKiosco)


                        Me.DataGridView3.Rows(i).Cells(28).Value = .RutaArchivopdf


                    End With

                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 380: " & ex.Message)
        End Try


        ''nuevo


    End Sub

    Public Sub MuestraDatosXMLFer()
        Try
            'Me.arreDatos = Me.ListFiles.filesListBox_SelectedIndexChanged(Me.filesListBox())
            Me.DataGridView3.Rows.Clear()

            If Me.arreArchivos.Count > 0 Then
                For i As Integer = 0 To Me.arreArchivos.Count - 1
                    Dim c As clsXML
                    Me.DataGridView3.Rows.Add()
                    With CType(Me.arreArchivos(i), clsKiosco)


                        c = Me.LeerXMLArchivo(Me.DirectorioPrincipal & "\" & .RutaArchivo & ".xml")




                        Me.DataGridView3.Rows(i).Cells(27).Value = .RutaArchivo
                        ' Me.DataGridView3.Rows(i).Cells(28).Value = .RutaArchivopdf



                        With c
                            Me.DataGridView3.Rows(i).Cells(0).Value = .Empresa
                            Me.DataGridView3.Rows(i).Cells(1).Value = .RFCEmpresa
                            Me.DataGridView3.Rows(i).Cells(2).Value = .NombreEmpleado
                            Me.DataGridView3.Rows(i).Cells(3).Value = .SalarioDiarioIntegrado
                            Me.DataGridView3.Rows(i).Cells(4).Value = .RFCEmpleado
                            Me.DataGridView3.Rows(i).Cells(5).Value = .NSS
                            Me.DataGridView3.Rows(i).Cells(6).Value = .CURP
                            Me.DataGridView3.Rows(i).Cells(7).Value = .FechaIPago
                            Me.DataGridView3.Rows(i).Cells(8).Value = .FechaFPago
                            Me.DataGridView3.Rows(i).Cells(9).Value = .DiasTrabajados
                            Me.DataGridView3.Rows(i).Cells(10).Value = .Departamento
                            Me.DataGridView3.Rows(i).Cells(11).Value = .Puesto
                            Me.DataGridView3.Rows(i).Cells(12).Value = .ClavePercepcion
                            Me.DataGridView3.Rows(i).Cells(13).Value = .ConceptoPercepcion
                            Me.DataGridView3.Rows(i).Cells(14).Value = .ImportePercepcionGravado
                            Me.DataGridView3.Rows(i).Cells(15).Value = .ImportePercepcionExento
                            Me.DataGridView3.Rows(i).Cells(16).Value = .Clavededuccion
                            Me.DataGridView3.Rows(i).Cells(17).Value = .Conceptodeduccion
                            Me.DataGridView3.Rows(i).Cells(18).Value = .ImportededuccionGravado
                            Me.DataGridView3.Rows(i).Cells(19).Value = .ImportededuccionExento
                            Me.DataGridView3.Rows(i).Cells(20).Value = .FolioFiscal
                            Me.DataGridView3.Rows(i).Cells(21).Value = .SelloDigitalCFDI
                            Me.DataGridView3.Rows(i).Cells(22).Value = .SelloDigitalSAT
                            Me.DataGridView3.Rows(i).Cells(23).Value = .NumeroCertificado
                            Me.DataGridView3.Rows(i).Cells(24).Value = .FechaTimbrado
                            Me.DataGridView3.Rows(i).Cells(25).Value = .LugarExpedicion
                            Me.DataGridView3.Rows(i).Cells(26).Value = .TipoPago
                            Me.DataGridView3.Rows(i).Cells(29).Value = .total
                            Me.DataGridView3.Rows(i).Cells(30).Value = .noCertificadoSAT


                            Me.Detallesarchivo(Me.DirectorioPrincipal & "\" & Me.DataGridView3.Rows(i).Cells(27).Value & ".xml", .FolioFiscal, .NumeroCertificado)
                        End With
                    End With

                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado 380: " & ex.Message)
        End Try

        ''nuevo
        Try
            'Me.arreDatos = Me.ListFiles.filesListBox_SelectedIndexChanged(Me.filesListBox())


            'If Me.arreArchivospdf.Count > 0 Then
            '    For i As Integer = 0 To Me.arreArchivospdf.Count - 1

            '        'Me.DataGridView3.Rows.Add()
            '        With CType(Me.arreArchivospdf(i), clsKiosco)


            '            Me.DataGridView3.Rows(i).Cells(28).Value = .RutaArchivopdf


            '        End With

            '    Next
            'End If
        Catch ex As Exception
            MsgBox("Error No Controlado 380: " & ex.Message)
        End Try


        ''nuevo


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If CheckBox1.Checked Then


            Dim EmpresaPadre As String
            Dim contador As Integer = 0


            Try
                For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                    With Me.DataGridView3.Rows(i)

                        'inicio
                        'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF

                        'AQUI PRIMERO BUSCO LA EMPRESA PADRE U ORGINAL
                        'EmpresaPadre = Me.BuscaSegundaEmpresa(.Cells(4).Value)
                        'If EmpresaPadre <> "" Then

                        '  Me.subirxml("DAS060320KQ5", .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, .Cells(27).Value, .Cells(28).Value)
                        Me.crearpdfh(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(4).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value, _
                                     "DAS060320KQ5")
                        contador = contador + 1
                        'End If
                    End With
                Next
                MsgBox("El total de archivos registrados fueron " & contador)

                'Application.Restart()
            Catch ex As Exception
                MsgBox("Error No Controlado 261: " & ex.Message)
            End Try

            ''haberes
        Else

            ''sueldos
            Dim contador As Integer = 0



            Try
                For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                    With Me.DataGridView3.Rows(i)

                        'inicio
                        'AQUI VA UNA VALIDACION SI EL USUARIO YA ESTA EN MY SQL SI NO, SE AGREGA
                        If Me.Validausuarioxml(.Cells(4).Value) = False Then
                            ''encontrar la empresa
                            If (.Cells(1).Value = "IRT150703HD0") Then
                                Dim correo As String
                                correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"

                                Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 9)

                                ''
                            ElseIf (.Cells(1).Value = "FOL1505208V8") Then
                                Dim correo As String
                                correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"

                                Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 14)

                            ElseIf (.Cells(1).Value = "GCO130624LY4") Then
                                Dim correo As String
                                correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
                                Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 10)

                                'nuevas empresas

                            ElseIf (.Cells(1).Value = "ITP070516TK8") Then
                                Dim correo As String
                                correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
                                Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 15)
                                'nuevas empresas
                            End If
                            ''encontrar la empresa
                        End If

                    End With
                Next

            Catch ex As Exception
                MsgBox("Error No Controlado 351: " & ex.Message)
            End Try
            ' ''nuevo ( usuario)

            ''subir a ftp

            Try
                For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                    With Me.DataGridView3.Rows(i)
                        'inicio
                        'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF
                        Me.subirxml(Me.DataGridView3.Rows(i).Cells(1).Value, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, .Cells(27).Value, .Cells(28).Value)
                        If (.Cells(1).Value = "COI130409EW6") Then
                            Me.crearpdf(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)

                        ElseIf (.Cells(1).Value = "FOL1505208V8") Then
                            Me.crearpdf3(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)



                        ElseIf (.Cells(1).Value = "GCO130624LY4") Then
                            Me.crearpdfconi(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)
                            ''nuevas empresas
                        ElseIf (.Cells(1).Value = "ITP070516TK8") Then
                            Me.crearpdfvirtual(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)

                            ''faltan los pdf de estas dos empresas
                        ElseIf (.Cells(1).Value = "CHO140221A4A") Then
                            Me.crearpdfvirtual(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)

                        ElseIf (.Cells(1).Value = "GMO150901R32") Then
                            Me.crearpdfvirtual(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value)

                            ''nuevas empresas
                        End If


                        contador = contador + 1

                    End With
                Next
                MsgBox("El total de archivos registrados fueron " & contador)

                'Application.Restart()
            Catch ex As Exception
                MsgBox("Error No Controlado 261: " & ex.Message)
            End Try


            ''subir a ftp

            ''sueldos
        End If

    End Sub

    ''nuevo usuario

    Public Function Validausuarioxml(ByVal RFCx As String) As Boolean
        Dim DBCon As OdbcConnection

        DBCon = New OdbcConnection(New OdbcConnectionStringBuilder("driver={MySQL ODBC 5.3 ANSI Driver};Server=ipp.com.mx; Database=ipp_kiosco; Connection Timeout=360000000; uid=ipp;pwd=43985yth3pi248y134p9ru8woqeu9r;").ToString) 'asstring'


        'Dim DBCon As OdbcConnection = New OdbcConnection("dsn=conexion; Connection Timeout=3600 ") 'asstring'


        Dim consulta As String
        Dim resultado As Integer
        consulta = "SELECT COUNT(*) FROM usuarios where rfc = '" & RFCx & "'"
        'Dim rfc As New OdbcParameter("@rfc", DbType.String)
        'rfc.Value = RFCx

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    '.Parameters.Add(rfc)
                End With

                DBCon.Open()

                resultado = comm.ExecuteScalar


            End Using
            ' MsgBox("Conecxion realizada satsfactoriamente")
            If resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Odbc.OdbcException
            'Se habilita el Timer 
            Timer1.Enabled = True
            'El intervalo es de 5 segundos 
            Timer1.Interval = 5000
            'Se muestra el MessageBox 
            'MsgBox("Este mensaje se cerrara en 5 segundos", MsgBoxStyle.OkOnly, "Mensaje de Prueba")
            'Si hubiese error en la conexión mostramos el texto de la descripción
            'MsgBox("Hubo una interrupción en la conexión, preciona 'Aceptar' o espere 5 segundos para restablecer automaticamente ")
            MsgBox("Error No Controlado 94: " & ex.Message)
        Finally
            DBCon.Close()
            DBCon.Dispose()

        End Try
    End Function



    'prueba
    'Public Function Validausuarioxml(ByVal RFCx As String) As Boolean
    '    Dim DBCon As MySQLConnection


    '    DBCon = New MySQLConnection(New MySQLConnectionString("ipp.com.mx", "ipp_kiosco", "ipp_kiosco", "Ajpb1Q02T9yF", 3306).AsString)

    '    Dim consulta As String
    '    Dim resultado As Integer
    '    consulta = "SELECT COUNT(*) FROM usuarios where rfc = @rfc"
    '    Dim rfc As New MySQLParameter("@rfc", DbType.String)
    '    rfc.Value = RFCx

    '    Try
    '        'Abrimos la conexión y comprobamos que no hay error
    '        Using comm As New MySQLCommand(consulta, DBCon)
    '            With comm
    '                .CommandType = CommandType.Text
    '                .Parameters.Add(rfc)
    '            End With
    '            DBCon.Open()
    '            resultado = comm.ExecuteScalar()
    '        End Using
    '        ' MsgBox("Conecxion realizada satsfactoriamente")
    '        If resultado > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As MySQLException
    '        'Si hubiese error en la conexión mostramos el texto de la descripción
    '        MsgBox(ex.Message.ToString)
    '    Finally
    '        DBCon.Close()
    '        DBCon.Dispose()
    '    End Try
    'End Function
    'prueba

    '    DBCon = New MySQLConnection(New MySQLConnectionString("ipp.com.mx", "ipp_kiosco", "ipp_kiosco", "Ajpb1Q02T9yF", 3306).AsString)

    Public Sub Agregausuarioxml(ByVal nombre As String, ByVal email As String, ByVal pass As String, ByVal rfc As String, ByVal rol As Integer, ByVal nempleado As Integer _
 , ByVal empresa As Integer)

        Timer1.Enabled = True
        Timer1.Start()
        Dim DBCon As OdbcConnection

        DBCon = New OdbcConnection(New OdbcConnectionStringBuilder("driver={MySQL ODBC 5.3 ANSI Driver};Server=ipp.com.mx; Database=ipp_kiosco; Connection Timeout=360000000; uid=ipp;pwd=43985yth3pi248y134p9ru8woqeu9r;").ToString) 'asstring'

        'Dim DBCon As OdbcConnection

        'DBCon = New OdbcConnection(New OdbcConnectionStringBuilder("driver={MySQL ODBC 5.3  Driver};Server=ipp.com.mx; Database=ipp_kiosco; Connection Timeout=60; uid=ipp_kiosco;pwd=43985yth3pi248y134p9ru8woqeu9r;").ToString) 'asstring'
        ''DBCon = New OdbcConnection(New OdbcConnectionStringBuilder("dsn=conexion").ToString) 'asstring'

        Dim consulta As String
        consulta = "insert into usuarios (nombre,email,password,rfc,rolId,noEmpleado,idEmpresa) " + _
                "values ('" & nombre & "','" & email & "','" & pass & "','" & rfc & "','" & rol & "','" & nempleado & "','" & empresa & "')"

        'Dim nombreu As New OdbcParameter("@nombre", DbType.String)
        'nombreu.Value = nombre
        'Dim emailu As New OdbcParameter("@email", DbType.String)
        'emailu.Value = email
        'Dim passu As New OdbcParameter("@password", DbType.String)
        'passu.Value = pass
        'Dim rfcu As New OdbcParameter("@rfc", DbType.String)
        'rfcu.Value = rfc
        'Dim rolu As New OdbcParameter("@rolId", DbType.Int32)
        'rolu.Value = rol
        'Dim noemp As New OdbcParameter("@noEmpleado", DbType.Int32)
        'noemp.Value = nempleado
        'Dim Empresau As New OdbcParameter("@idEmpresa", DbType.Int32)
        'Empresau.Value = empresa



        Try
            'Abrimos la conexión y comprobamos que no hay error

            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text

                    '.Parameters.Add(nombreu)
                    '.Parameters.Add(emailu)
                    '.Parameters.Add(passu)
                    '.Parameters.Add(rfcu)
                    '.Parameters.Add(rolu)
                    '.Parameters.Add(noemp)
                    '.Parameters.Add(Empresau)


                End With

                DBCon.Open()

                ' MsgBox("Conexion realizada satsfactoriamente")
                comm.ExecuteNonQuery()

            End Using
            '   MsgBox("Conecxion realizada satsfactoriamente")
        Catch ex As Odbc.OdbcException
            Timer1.Enabled = True
            'El intervalo es de 5 segundos 
            Timer1.Interval = 5000
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox("Error No Controlado 95: " & ex.Message)
            ' MsgBox("Hubo una interrupción en la conexión, preciona 'Aceptar' o espere 5 segundos para restablecer automaticamente ")
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub
    'nuevo usuario

    'nueva empresa

    Public Function Validaempresaxml(ByVal RFCx As String) As Boolean
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("dsn=conexion") 'asstring'

        Dim consulta As String
        Dim resultado As Integer
        consulta = "SELECT COUNT(*) FROM cat_empresas where rfc = @rfc"
        Dim rfc As New OdbcParameter("@rfc", DbType.String)
        rfc.Value = RFCx

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text
                    .Parameters.Add(rfc)
                End With
                DBCon.Open()
                resultado = comm.ExecuteScalar()
            End Using
            ' MsgBox("Conecxion realizada satsfactoriamente")
            If resultado > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Function

    Public Sub Agregaempresaxml(ByVal nombre As String, ByVal folder As String, ByVal rfc As String, ByVal razon As String)
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("dsn=conexion") 'asstring'

        Dim consulta As String
        consulta = "insert into cat_empresas (nombreEmpresa,folder,rfc,razonSocial) " + _
                "values (@nombre,@folder,@rfc,@razon)"


        Dim nombree As New OdbcParameter("@nombre", DbType.String)
        nombree.Value = nombre

        Dim foldere As New OdbcParameter("@folder", DbType.String)
        foldere.Value = folder
        Dim rfce As New OdbcParameter("@rfc", DbType.String)
        rfce.Value = rfc
        Dim razone As New OdbcParameter("@razon", DbType.String)
        razone.Value = razon

        Try
            'Abrimos la conexión y comprobamos que no hay error

            Using comm As New OdbcCommand(consulta, DBCon)
                With comm
                    .CommandType = CommandType.Text

                    .Parameters.Add(nombree)

                    .Parameters.Add(foldere)
                    .Parameters.Add(rfce)
                    .Parameters.Add(razone)




                    Dim clsRequest As System.Net.FtpWebRequest = _
DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/" & rfc & "/"), System.Net.FtpWebRequest)
                    clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "XyUkT5DwGl7F7sW")
                    clsRequest.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory
                    Try
                        Dim respuesta As FtpWebResponse
                        respuesta = CType(clsRequest.GetResponse(), FtpWebResponse)
                        respuesta.Close()
                        ' Si todo ha ido bien, se devolverá String.Empty

                    Catch ex As Exception
                        ' Si se produce algún fallo, se devolverá el mensaje del error
                        MsgBox(ex.Message.ToString)
                    End Try

                End With
                DBCon.Open()
                ''MsgBox("Conexion realizada satisfactoriamente")
                comm.ExecuteNonQuery()



            End Using
            '' MsgBox("Conecxion realizada satisfactoriamente")
        Catch ex As Odbc.OdbcException
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox(ex.Message.ToString)
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Sub
    ''nueva empresa



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


        If CheckBox1.Checked Then
            ''haberes
            Dim EmpresaPadre As String
            Dim contador As Integer = 0

            Dim contador1 As Integer = 0
            Try
                For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                    ProgressBar2.Minimum = 1
                    ProgressBar2.Maximum = Me.DataGridView3.Rows.Count
                    With Me.DataGridView3.Rows(i)
                        'inicio
                        'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF
                        EmpresaPadre = Me.BuscaSegundaEmpresa(.Cells(4).Value)
                        If EmpresaPadre <> "" Then
                            Me.subirxml2(EmpresaPadre, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, Me.DirectorioPrincipal, .Cells(27).Value)
                            contador1 = contador1 + 1

                            'ElseIf EmpresaPadre = "" Then
                            '    MsgBox("el usuario : " & (.Cells(2)).Value & "no se encontro")
                        End If

                    End With
                    My.Application.DoEvents()
                    If i = 0 Then
                        ProgressBar2.Value = 1
                    Else
                        ProgressBar2.Value = ProgressBar2.Value + 1
                    End If
                Next
                MsgBox("El total de archivos fueron" & contador1)
                MsgBox("Los archivos no ingresados al kiosco fueron " & Me.contadorfa)
                txtfal.Text = Me.faltantes

                'Application.Restart()
            Catch ex As Exception
                MsgBox("cierre inesperado de la aplicación, contacte con el proveedor")
            End Try


            ''haberes

        Else
            Timer1.Enabled = True
            Timer1.Start()
            Dim contador1 As Integer = 0



            ''sueldos


            '''nuevo ( usuario)
            'Try
            '    For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
            '        ProgressBar1.Minimum = 1
            '        ProgressBar1.Maximum = Me.DataGridView3.Rows.Count
            '        With Me.DataGridView3.Rows(i)

            '            'inicio
            '            'AQUI VA UNA VALIDACION SI EL USUARIO YA ESTA EN MY SQL SI NO, SE AGREGA
            '            If Me.Validausuarioxml(.Cells(4).Value) = False Then
            '                ''encontrar la empresa
            '                If (.Cells(1).Value = "IRT150703HD0") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 9)

            '                ElseIf (.Cells(1).Value = "FOL1505208V8") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 14)

            '                ElseIf (.Cells(1).Value = "GCO130624LY4") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo, .Cells(4).Value, .Cells(4).Value, 2, 0, 10)

            '                    'nuevas empresas    

            '                ElseIf (.Cells(1).Value = "ITP070516TK8") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 15)

            '                ElseIf (.Cells(1).Value = "CHO140221A4A") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 16)

            '                ElseIf (.Cells(1).Value = "GMO150901R32") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 17)


            '                ElseIf (.Cells(1).Value = "TDV080911-8T3" Or .Cells(1).Value = "DAS060320KQ5") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 18)

            '                    ''nuevo

            '                ElseIf (.Cells(1).Value = "CAT150318T89") Then
            '                    Dim correo As String
            '                    correo = Convert.ToString(.Cells(2).Value).Replace(" ", "").ToLower & "@nominas.com.mx"
            '                    Me.Agregausuarioxml(.Cells(2).Value, correo.ToString, .Cells(4).Value, .Cells(4).Value, 2, 0, 19)
            '                    ''nuevo


            '                    'nuevas empresas   


            '                End If
            '                ''encontrar la empresa
            '            End If

            '        End With
            '        My.Application.DoEvents()
            '        If i = 0 Then
            '            ProgressBar1.Value = 1
            '        Else
            '            ProgressBar1.Value = ProgressBar1.Value + 1

            '        End If
            '    Next

            'Catch ex As Exception
            '    MsgBox("cierre inesperado de la aplicación, contacte con el proveedor")
            'End Try
            '''nuevo ( usuario)

            Try
                For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                    ProgressBar2.Minimum = 1
                    ProgressBar2.Maximum = Me.DataGridView3.Rows.Count
                    With Me.DataGridView3.Rows(i)
                        'inicio
                        'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF
                        'Me.subirxml1(Me.DataGridView3.Rows(i).Cells(1).Value, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, .Cells(27).Value, .Cells(28).Value)
                        Me.SubirXmlYPDF(Me.DataGridView3.Rows(i).Cells(1).Value, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, Me.DirectorioPrincipal, .Cells(27).Value)

                        contador1 = contador1 + 1

                    End With
                    My.Application.DoEvents()
                    If i = 0 Then
                        ProgressBar2.Value = 1
                    Else
                        ProgressBar2.Value = ProgressBar2.Value + 1


                    End If

                Next
                MsgBox("El total de archivos fueron " & contador1)
                MsgBox("Los archivos no ingresados al kiosco fueron " & Me.contadorfa)
                txtfal.Text = Me.faltantes
                'Application.Restart()
            Catch ex As Exception
                MsgBox("cierre inesperado de la aplicación, contacte con el proveedor")
            End Try

            ''sueldos
        End If

    End Sub

    Public Function BuscaSegundaEmpresa(ByVal empleado As String) As String
        Dim DBCon As OdbcConnection


        DBCon = New OdbcConnection("dsn=conexion")
        Dim consulta As String
        Dim resultado As String
        consulta = "SELECT c.rfc FROM usuarios u " & _
            "inner join cat_empresas c " & _
            "on u.idEmpresa = c.idEmpresa " & _
            "where u.rfc = '" & empleado & "'"


        'Dim Bempleado As New OdbcParameter("@empleado", DbType.String)
        'Bempleado.Value = empleado

        Try
            'Abrimos la conexión y comprobamos que no hay error
            Using comm As New OdbcCommand(consulta, DBCon)
                With comm

                    .CommandType = CommandType.Text

                    '.Parameters.Add(Bempleado)
                End With

                DBCon.Open()
                resultado = comm.ExecuteScalar()

            End Using
            ' MsgBox("Conexion realizada satsfactoriamente")
            If resultado Is Nothing Then
                resultado = ""
            End If


            Return resultado.ToLower
        Catch ex As Odbc.OdbcException

            'Se habilita el Timer 
            Timer1.Enabled = True
            'El intervalo es de 5 segundos 
            Timer1.Interval = 5000
            'Se muestra el MessageBox 
            'MsgBox("Este mensaje se cerrara en 5 segundos", MsgBoxStyle.OkOnly, "Mensaje de Prueba")
            'Si hubiese error en la conexión mostramos el texto de la descripción
            MsgBox("Hubo una interrupción en la conexión, preciona 'Aceptar' para intentar conectar nuevamente")
        Finally
            DBCon.Close()
            DBCon.Dispose()
        End Try
    End Function





    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim EmpresaPadre As String
        Dim contador As Integer = 0

        Dim contador1 As Integer = 0
        Try
            For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                With Me.DataGridView3.Rows(i)
                    'inicio
                    'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF
                    EmpresaPadre = Me.BuscaSegundaEmpresa(.Cells(4).Value)
                    If EmpresaPadre <> "" Then

                        Me.subirxml2(EmpresaPadre, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, .Cells(27).Value, .Cells(28).Value)

                        contador1 = contador1 + 1
                    ElseIf EmpresaPadre = "" Then
                        MsgBox("el usuario : " & (.Cells(2)).Value & "no se encontro")
                    End If

                End With
            Next
            MsgBox("El total de archivos registrados fueron " & contador1)

            'Application.Restart()
        Catch ex As Exception
            MsgBox("Error No Controlado 261: " & ex.Message)
        End Try



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '  If (CheckBox1.Checked) Then
        'Si checo que es haberes en vez de poner la empresa del XML a recoerrer,buscara en MYSQL
        'cual es su empresa, si no existe avisara al usuario

        Dim EmpresaPadre As String
        Dim contador As Integer = 0
        'nuevo(empresa)
        'Try
        '    For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
        '        With Me.DataGridView3.Rows(i)

        '            inicio()
        '            AQUI VA UNA VALIDACION SI LA EMPRESA YA ESTA EN MY SQL SI NO, SE AGREGA
        '            If Me.Validaempresaxml(.Cells(1).Value) = False Then
        '                Me.Agregaempresaxml(.Cells(0).Value, .Cells(1).Value, .Cells(1).Value, .Cells(0).Value)
        '            End If

        '        End With
        '    Next

        'Catch ex As Exception
        '    MsgBox("Error No Controlado 351: " & ex.Message)
        'End Try
        'nuevo(empresa)



        ''subir a ftp

        Try
            For i As Integer = 0 To Me.DataGridView3.Rows.Count - 1
                With Me.DataGridView3.Rows(i)

                    'inicio
                    'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF

                    'AQUI PRIMERO BUSCO LA EMPRESA PADRE U ORGINAL
                    EmpresaPadre = Me.BuscaSegundaEmpresa(.Cells(2).Value)
                    If EmpresaPadre <> "" Then
                        Me.subirxml(EmpresaPadre, .Cells(24).Value, .Cells(4).Value, .Cells(8).Value, .Cells(27).Value, .Cells(28).Value)
                        Me.crearpdfh(Me.DataGridView3.Rows(i).Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(4).Value, .Cells(6).Value, .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(20).Value, .Cells(21).Value, .Cells(22).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(29).Value, .Cells(30).Value, _
                                     EmpresaPadre)
                        contador = contador + 1
                    End If
                End With
            Next
            MsgBox("El total de archivos registrados fueron " & contador)

            'Application.Restart()
        Catch ex As Exception
            MsgBox("Error No Controlado 261: " & ex.Message)
        End Try

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False
        SendKeys.Send("{ESC}")
    End Sub



    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If estimado1 >= 0 Then
            Label6.Text = "Ejecutar en: " & estimado1
            estimado1 = estimado1 - 1
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo


        End If
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        btnInsertarMYSQL.Enabled = True
        Me.MuestraDatosempleado(TextBox2.Text)
    End Sub


    Private Sub btngenrep_Click(sender As System.Object, e As System.EventArgs) Handles btngenrep.Click
        conexiont = CBXtimbrado.Text

        If conexiont = "AICEL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\AICEL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()


        End If

        If conexiont = "UPHETILOLI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\UPHETILOLI.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()


        End If



        If conexiont = "TALENTO Y DESARROLLO DEL VALLE" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\TALENTO Y DESARROLLO DEL VALLE.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If

        ''morget 

        If conexiont = "MORGET SEMANAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\1 MORGET SEMANAL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If

        If conexiont = "MORGET CATORCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\2 MORGET CATORCENAL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If

        If conexiont = "MORGET QUINCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\3  MORGET QUINCENAL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If

        If conexiont = "MORGET MENSUAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\4 MORGET MENSUAL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If
        ''morget


        If conexiont = "MORGET" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\MORGET.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If



        If conexiont = "IT TELECOM" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\IT RESOURCES TELECOM SA DE CV.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If

        If conexiont = "CONISAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\GRUPO CONISAL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If


        If conexiont = "WIPSI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\WIPSI A C.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        End If


        If conexiont = "ATALANTA" Then

            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
            ";PWD=8244Ata;DBNAME=192.168.2.21:C:\microsip datos\ATALANTA.fdb"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()

        ElseIf conexiont = "NEXTEL" Then


            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
      ";PWD=ata8244;DBNAME=192.168.2.83" & _
   ":C:\microsip datos\NEXTEL.FDB"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte3()


            '         Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
            '   ";PWD=ata8244;DBNAME=189.190.172.169" & _
            '":C:\microsip datos\NEXTEL.FDB"
            '         Me.cKiosco = New clsKioscoHandler(cadenaODBC)
            '         Me.MuestraNominas()

        End If

    End Sub

    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If CBXPS.Checked = True Then
            Dim stRuta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Seleccionar archivos"
                .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    stRuta = .FileName
                End If
            End With
            Try
                Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";")))
                Dim cnConex As New OleDbConnection(stConexion)
                Dim Cmd As New OleDbCommand("Select [CLIENTE],[CENTRO],[Fecha Inicial],[FECHA DE NOMINA],[Empleado],[NOMBRE DEL EMPLEADO],[RFC],[CURP],[REGIMEN DE PAGO],[PERIODO DE PAGO],[NSS],[SALARIO DIARIO INTEGRADO],[DEPARTAMENTO],[PUESTO],[Días trabajado],[SUELDOS, SALARIOS , RAYAS Y JORNALES ],[SUBSIDIO AL EMPLEO],[TOTAL PERCEPCIONES],[SEGURIDAD SOCIAL],[ISR],[INFONAVIT],[INFONACOT],[TOTAL DEDUCCIONES],[NETO A PAGAR] from [Hoja1$]")
                Dim Ds As New DataSet
                Dim Da As New OleDbDataAdapter
                Dim Dt As New DataTable
                cnConex.Open()
                Cmd.Connection = cnConex
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Dt = Ds.Tables(0)
                Me.DataGridView1.Columns.Clear()
                Me.DataGridView1.DataSource = Dt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If

        If CheckBox2.Checked = True Then

            Dim stRuta As String = ""
            Dim openFD As New OpenFileDialog()
            With openFD
                .Title = "Seleccionar archivos"
                .Filter = "Archivos Excel(*.xls;*.xlsx)|*.xls;*xlsx|Todos los archivos(*.*)|*.*"
                .Multiselect = False
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                If .ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    stRuta = .FileName
                End If
            End With
            Try
                Dim stConexion As String = ("Provider=Microsoft.ACE.OLEDB.12.0;" & ("Data Source=" & (stRuta & ";Extended Properties=""Excel 12.0;Xml;HDR=YES;IMEX=2"";")))
                Dim cnConex As New OleDbConnection(stConexion)
                Dim Cmd As New OleDbCommand("Select [CLIENTE],[CENTRO],[FechaInicial],[FECHA DE NOMINA],[Empleado],[NOMBRE DEL EMPLEADO],[RFC],[CURP],[PERIODO DE PAGO],[NSS],[SALARIO DIARIO INTEGRADO],[DEPARTAMENTO],[PUESTO],[Días trabajado],[JUBILACIONES],[TOTAL PERCEPCIONES],[TOTAL DEDUCCIONES],[NETO A PAGAR] from [Hoja1$]")
                Dim Ds As New DataSet
                Dim Da As New OleDbDataAdapter
                Dim Dt As New DataTable
                cnConex.Open()
                Cmd.Connection = cnConex
                Da.SelectCommand = Cmd
                Da.Fill(Ds)
                Dt = Ds.Tables(0)
                Me.DataGridView1.Columns.Clear()
                Me.DataGridView1.DataSource = Dt
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            End Try

        End If
    End Sub

  
 
    Private Sub BTNnotimbrados_Click(sender As System.Object, e As System.EventArgs) Handles BTNnotimbrados.Click
        conexionN = CBXnotimbrados.Text

        If conexionn = "AICEL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\AICEL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()


        End If


        If conexionn = "UPHETILOLI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\UPHETILOLI.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()


        End If


        If conexionn = "TALENTO Y DESARROLLO DEL VALLE" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\TALENTO Y DESARROLLO DEL VALLE.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If

        ''morget 

        If conexionn = "MORGET SEMANAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\1 MORGET SEMANAL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If

        If conexionn = "MORGET CATORCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\2 MORGET CATORCENAL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If

        If conexionn = "MORGET QUINCENAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\3  MORGET QUINCENAL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If

        If conexionn = "MORGET MENSUAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\4 MORGET MENSUAL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If
        ''morget


        If conexionn = "MORGET" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\MORGET.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If



        If conexionn = "IT TELECOM" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\IT RESOURCES TELECOM SA DE CV.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If

        If conexionn = "CONISAL" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\GRUPO CONISAL.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If


        If conexionn = "WIPSI" Then
            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
 ";PWD=ata8244;DBNAME=192.168.2.83" & _
":C:\microsip datos\WIPSI A C.FDB"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        End If


        If conexiont = "ATALANTA" Then

            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
            ";PWD=8244Ata;DBNAME=192.168.2.21:C:\microsip datos\ATALANTA.fdb"
            Me.ccalculos = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

        ElseIf conexionn = "NEXTEL" Then


            Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
              ";PWD=8244Ata;DBNAME=192.168.2.83:C:\microsip datos\NEXTEL.fdb"
            Me.ccalculosn = New reportehandler(cadenaODBC)
            Me.MuestraReporte4()

            

          
        End If


    End Sub

   
End Class