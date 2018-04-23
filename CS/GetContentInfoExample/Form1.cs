#region #Reference
using System;
using System.Windows.Forms;
using DevExpress.Pdf;
// ...
#endregion #Reference


namespace GetContentInfoExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

#region #Code
private void Form1_Load(object sender, EventArgs e) {
    this.pdfViewer.LoadDocument(@"..\..\Demo.pdf");
    this.pdfViewer.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.FitToWidth;
}

private void pdfViewer_MouseMove(object sender, MouseEventArgs e) {
    PdfDocumentContent content = pdfViewer.GetContentInfo(e.Location);
    if (content != null) {
        string contentTypeText = content.IsSelected ? "Selected " : "Unselected ";
        switch (content.ContentType) {
            case PdfDocumentContentType.Text:
                contentTypeText = contentTypeText + "text";
                break;
            case PdfDocumentContentType.Image:
                contentTypeText = contentTypeText + "image";
                break;
            default:
                contentTypeText = "The content is empty";
                break;
        }
        bsiContentType.Caption = contentTypeText;
    }
}
#endregion #Code

    }
}
