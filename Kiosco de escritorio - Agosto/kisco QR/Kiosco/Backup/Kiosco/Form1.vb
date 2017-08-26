Imports System.Xml
Imports System.io
Imports System.Text

Public Class Form1

    Private cKiosco As clsKioscoHandler
    Private arreDatos As ArrayList
    Private arreDetalles As New ArrayList
    Private arrenominas As New ArrayList
    Private rptPDFXML As New crpPdfXml

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cadenaODBC As String = "DRIVER=Firebird/InterBase(r) driver;UID=SYSDBA" & _
        ";PWD=8244Ata;DBNAME=S2122-HP:C:\microsip datos\ATALANTA.fdb"
        Me.cKiosco = New clsKioscoHandler(cadenaODBC)
        Me.MuestraNominas()
    End Sub

    Private Sub MuestraNominas()
        Try
            Me.arreNominas = Me.cKiosco.ObtenNominas()
            Me.cbxNominasGeneradas.DataSource = Nothing
            Me.cbxNominasGeneradas.Items.Clear()
            If Me.arreNominas.Count > 0 Then
                With Me.cbxNominasGeneradas
                    .DisplayMember = "FechaNomina"
                    .DataSource = Me.arreNominas
                    .ValueMember = "IdNomina"
                End With
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Public Sub MuestraDatos()
        Try
            Me.arreDatos = Me.cKiosco.ObtenDatosArticulo(Me.cbxNominasGeneradas.SelectedValue())
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
                            Me.Detalles(CType(Me.arreDatos(i), clsKiosco).XML, .FolioFiscal, .NumeroCertificado)
                            'Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .RFCEmpresa, CType(Me.arreDatos(i), clsKiosco).FechaHoraTimbrado, .RFCEmpleado)
                            'Me.CreaPDFyFTP(c)
                        End With
                        
                    End With
                Next
            End If
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message)
        End Try
    End Sub

    Private Sub btnObtenerDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerDatos.Click
        Me.MuestraDatos()
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
                            Case "nomina:Nomina"
                                c.NSS = reader.GetAttribute("NumSeguridadSocial")
                                c.CURP = reader.GetAttribute("CURP")
                                c.FechaIPago = reader.GetAttribute("FechaInicialPago")
                                c.FechaFPago = reader.GetAttribute("FechaFinalPago")
                                c.DiasTrabajados = reader.GetAttribute("NumDiasPagados")
                                c.Departamento = reader.GetAttribute("Departamento")
                            Case "nomina:Percepcion"
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                            Case "nomina:Deduccion"
                                c.Clavededuccion = reader.GetAttribute("Clave")
                                c.Conceptodeduccion = reader.GetAttribute("Concepto")
                                c.ImportededuccionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportededuccionExento = reader.GetAttribute("ImporteExento")
                            Case "tfd:TimbreFiscalDigital"
                                c.FolioFiscal = reader.GetAttribute("UUID")
                                c.SelloDigitalCFDI = reader.GetAttribute("selloCFD")
                                c.SelloDigitalSAT = reader.GetAttribute("selloSAT")
                            Case "cfdi:Comprobante"
                                c.NumeroCertificado = reader.GetAttribute("noCertificado")
                                c.FechaTimbrado = reader.GetAttribute("fecha")
                                c.LugarExpedicion = reader.GetAttribute("LugarExpedicion")
                                c.TipoPago = reader.GetAttribute("formaDePago")
                        End Select
                End Select
            End While
            reader.Close()
            Return c
        Catch ex As Exception
            MsgBox(ex.Message)
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
                            Case "nomina:Percepcion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("Clave")
                                c.ConceptoPercepcion = reader.GetAttribute("Concepto")
                                c.ImportePercepcionGravado = reader.GetAttribute("ImporteGravado")
                                c.ImportePercepcionExento = reader.GetAttribute("ImporteExento")
                                c.Tipo = "Percepcion"
                                c.FolioFiscal = uuid
                                c.NumeroCertificado = nocert
                                Me.arreDetalles.Add(c)
                            Case "nomina:Deduccion"
                                Dim c As New clsXML
                                c.ClavePercepcion = reader.GetAttribute("Clave")
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
            MsgBox(ex.Message)
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
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub btnInsertarMYSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarMYSQL.Click
        Try
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                With Me.DataGridView1.Rows(i)
                    Dim c As clsXML
                    c = Me.Campo1(CType(Me.arreDatos(.Cells(30).Value), clsKiosco).XML)
                    'AQUI VA UNA VALIDACION SI EL FOLIO FISCAL YA ESTA EN MY SQL SI NO, SE AGREGA
                    If Me.cKiosco.ValidaFolioFiscal(.Cells(3).Value) = False Then
                        Me.cKiosco.AgregaDatos(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, _
                    .Cells(7).Value, .Cells(8).Value, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value, .Cells(12).Value, .Cells(13).Value, _
                    .Cells(14).Value, .Cells(23).Value, .Cells(24).Value, .Cells(25).Value, .Cells(26).Value, .Cells(27).Value, .Cells(28).Value, .Cells(29).Value)
                        'AQUI AGREGAMOS LOS DETALLES DE ESE FOLIO FISCAL
                        Me.InsertaDetalles(.Cells(3).Value)
                        'AQUI VAMOS A CREAR Y SUBIR EL XML Y EL PDF
                        Me.CreaXMLYFTP(Me.DataGridView1.Rows(i).Cells(1).Value, .Cells(6).Value, .Cells(2).Value, .Cells(7).Value)
                        Me.CreaPDFyFTP(c)
                    Else
                        '------
                        'SI YA ESTA EL FOLIO FISCAL NOTIFICAMOS QUE ESTE NO SE AGREGO PORQUE YA SE ENCUENTRA
                    End If
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

        End Try
    End Sub

    Private Sub CreaXMLYFTP(ByVal xml As String, ByVal RFCEmpresa As String, ByVal fecha As Date, ByVal rfcempleado As String)
        Try
            Dim año, mes, dia As String
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            Dim nombre As String = RFCEmpresa & "_" & "Pago de Nomina" & "_" & año & mes & dia & "_N_" & rfcempleado
            Dim xmldoc As New XmlDocument
            'Dim xmldecl As XmlDeclaration
            xmldoc.LoadXml(xml)

            'xmldecl = xmldoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
            'Dim root As XmlElement = xmldoc.DocumentElement
            'xmldoc.InsertBefore(xmldecl, root)
            xmldoc.Save(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".xml")

            Dim clsRequest As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/atalanta/2015/" & nombre & ".xml"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "Ajpb1Q02T9yF")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".xml")

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()

            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".xml")
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub

    Private Sub CreaPDFyFTP(ByVal c As clsXML)
        Try
            Me.DsPercepciones1.Clear()
            Me.rptPDFXML = Nothing
            Me.rptPDFXML = New crpPdfXml
            Me.rptPDFXML.Load(System.IO.Path.Combine(Environment.CurrentDirectory, Me.rptPDFXML.Name))

            If Me.arreDetalles.Count > 0 Then
                For i As Integer = 0 To Me.arreDetalles.Count - 1
                    With CType(Me.arreDetalles(i), clsXML)
                        If c.FolioFiscal = .FolioFiscal Then
                            If .Tipo = "Percepcion" Then
                                Me.DsPercepciones1.Percepcion.AddPercepcionRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal)
                            ElseIf .Tipo = "Deduccion" Then
                                Me.DsPercepciones1.Deducciones.AddDeduccionesRow(.ClavePercepcion, .ConceptoPercepcion, .ImportePercepcionExento, .ImportePercepcionGravado, .FolioFiscal)
                            End If
                        End If
                    End With
                Next
            End If

            Me.rptPDFXML.SetDataSource(Me.DsPercepciones1)
            Me.rptPDFXML.SetParameterValue("Empresa", c.Empresa)
            Me.rptPDFXML.SetParameterValue("RFCEmpresa", c.RFCEmpresa)
            Me.rptPDFXML.SetParameterValue("Empleado", c.NombreEmpleado)
            Me.rptPDFXML.SetParameterValue("RFCEmpleado", c.RFCEmpleado)
            Me.rptPDFXML.SetParameterValue("NSS", c.NSS)
            Me.rptPDFXML.SetParameterValue("CURP", c.CURP)
            Me.rptPDFXML.SetParameterValue("FechaIPago", c.FechaIPago)
            Me.rptPDFXML.SetParameterValue("FechaFPago", c.FechaFPago)
            Me.rptPDFXML.SetParameterValue("DiasTrabajados", c.DiasTrabajados)
            Me.rptPDFXML.SetParameterValue("Departamento", c.Departamento)
            Me.rptPDFXML.SetParameterValue("FolioFiscal", c.FolioFiscal)
            Me.rptPDFXML.SetParameterValue("SelloCFDI", c.SelloDigitalCFDI)
            Me.rptPDFXML.SetParameterValue("SelloSAT", c.SelloDigitalSAT)
            Me.rptPDFXML.SetParameterValue("NumCert", c.NumeroCertificado)
            Me.rptPDFXML.SetParameterValue("FechaTimbrado", c.FechaTimbrado)
            Me.rptPDFXML.SetParameterValue("LugarExpedicion", c.LugarExpedicion)
            Me.rptPDFXML.SetParameterValue("TipoPago", c.TipoPago)

            Dim año, mes, dia As String
            Dim nombre As String
            Dim fecha As Date = c.FechaTimbrado
            año = fecha.Year.ToString
            mes = fecha.Month.ToString
            dia = fecha.Day.ToString
            If mes.Length = 1 Then
                mes = "0" & mes
            End If
            nombre = c.RFCEmpresa & "_" & "Pago de Nomina" & "_" & año & mes & dia & "_N_" & c.RFCEmpleado

            Me.rptPDFXML.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & nombre & ".pdf")

            Dim clsRequest As System.Net.FtpWebRequest = _
    DirectCast(System.Net.WebRequest.Create("ftp://ipp.com.mx/atalanta/2015/" & nombre & ".pdf"), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("kiosco@ipp.com.mx", "Ajpb1Q02T9yF")
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
        Catch ex As Exception
            MsgBox("Error No Controlado: " & ex.Message, MsgBoxStyle.Critical, "Sistema")
        End Try
    End Sub



End Class
