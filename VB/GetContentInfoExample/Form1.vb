Imports Microsoft.VisualBasic
#Region "#Reference"
Imports System
Imports System.Windows.Forms
Imports DevExpress.Pdf
' ...
#End Region ' #Reference


Namespace GetContentInfoExample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

#Region "#Code"
Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
	Me.pdfViewer.LoadDocument("..\..\Demo.pdf")
	Me.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth
End Sub

Private Sub pdfViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles pdfViewer.MouseMove
	Dim content As PdfDocumentContent = pdfViewer.GetContentInfo(e.Location)
	If content IsNot Nothing Then
		Dim contentTypeText As String = If(content.IsSelected, "Selected ", "Unselected ")
		Select Case content.ContentType
			Case PdfDocumentContentType.Text
				contentTypeText = contentTypeText & "text"
			Case PdfDocumentContentType.Image
				contentTypeText = contentTypeText & "image"
			Case Else
				contentTypeText = "The content is empty"
		End Select
		bsiContentType.Caption = contentTypeText
	End If
End Sub
#End Region ' #Code

	End Class
End Namespace
