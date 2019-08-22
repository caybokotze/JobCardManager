using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InvoiceService
{

    //Code: Done By Caybo. (The entire class.)

    public class Generate
    {
        #region Declare
        private int _totalColumn = 5;
        private Document _document;
        private iTextSharp.text.Font _fontStyle;
        private iTextSharp.text.Font _fontStyleNormal;
        private PdfPTable _pdfPTable;
        private PdfPCell _pdfPCell;
        private MemoryStream _memoryStream;
        private PdfWriter writer;
        private PdfPTable paymentTable;
        private Invoice _invoice;
        public Generate()
        {
            paymentTable = new PdfPTable(2);
            _pdfPTable = new PdfPTable(_totalColumn);
            _memoryStream = new MemoryStream();

        }
        #endregion

        //Code: Caybo Kotze The get invoice method.

        public byte[] GetInvoice(Invoice invoice)
        {
            _invoice = invoice;
            #region page
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            writer = PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 40f, 150f, 80f, 80f, 80f });

            paymentTable.WidthPercentage = 100;
            paymentTable.HorizontalAlignment = Element.ALIGN_LEFT;
            paymentTable.SetWidths(new float[] { 100f, 100f });

            this.reportHeader();
            this.reportBody();

            _pdfPTable.HeaderRows = 2;
            _document.Add(paymentTable);
            _document.Add(_pdfPTable);
            _document.Close();

            return _memoryStream.ToArray();

            #endregion
        }

        private void reportHeader()
        {
            if (_invoice.Business.LogoRootPath != null)
            {
                string imageUrl = _invoice.Business.LogoRootPath;
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(new Uri(imageUrl));
                img.ScaleToFit(100f, 100f);
                img.SpacingAfter = 10f;
                img.SpacingAfter = 5f;
                img.Alignment = Element.ALIGN_LEFT;
                _document.Add(img);
            }

            #region Gap

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            #endregion


            _fontStyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(_invoice.Business.CompanyName, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("(e): " + _invoice.Business.EmailAddress, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("(w): " + _invoice.Business.WebsiteAddress, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("(t): " + _invoice.Business.PhoneNumber, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("(a): " + _invoice.Business.PhysicalAddress, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("TO : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("INVOICE :  ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Company Name: " + _invoice.Client.CompanyName, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Invoice Number: " + _invoice.InvoiceNumber, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Tel: " + _invoice.Client.PhoneNumber, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Date: " + _invoice.Date.ToShortDateString(), _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

        }

        private void reportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("PRODUCT LIST PURCHASED BY CUSTOMER", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();




            #region TableHeader



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Item No", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Item", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Unit Price", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Quantity", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Total", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfPTable.AddCell(_pdfPCell);


            _pdfPTable.CompleteRow();
            #endregion

            #region Table body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);

            double invoiceSubTotal = 0;
            int i = 0;
            foreach (var item in _invoice.InvoiceItems)
            {
                ++i;
                _pdfPCell = new PdfPCell(new Phrase(i.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(item.Name, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + item.Price, _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(item.Quantity.ToString(), _fontStyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + (item.Price * item.Quantity), _fontStyle));
                //Calc Total
                invoiceSubTotal += (item.Price * item.Quantity);
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfPTable.AddCell(_pdfPCell);

                _pdfPTable.CompleteRow();
            }

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Sub Total :", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Colspan = 4;
            _pdfPCell.Border = 0;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + invoiceSubTotal, _fontStyle));
            _pdfPCell.Border = 0;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Discount :", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Colspan = 4;
            _pdfPCell.Border = 0;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            //Bug: Discount should be initialized to zero before this check.

            if (_invoice.Discount == 0)
            {
                _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + "00.00", _fontStyle));
            }
            else
            {
                _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + _invoice.Discount, _fontStyle));
            }

            _pdfPCell.Border = 0;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Total :", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Colspan = 4;
            _pdfPCell.Border = 0;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            double invoiceTotal = invoiceSubTotal - _invoice.Discount;
            _pdfPCell = new PdfPCell(new Phrase(_invoice.Currency + invoiceTotal, _fontStyle));
            _pdfPCell.Border = 0;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Status :", _fontStyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            _pdfPCell.Colspan = 4;
            _pdfPCell.Border = 0;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_invoice.Status, _fontStyle));
            _pdfPCell.Border = 0;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPTable.AddCell(_pdfPCell);

            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();


            #endregion


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_invoice.Notes, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 10f;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(_invoice.Terms, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 5;
            _pdfPCell.Border = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 10f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Payable To: ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            //
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_invoice.Business.CompanyName, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();
            //
            _pdfPCell = new PdfPCell(new Phrase("Bank Account: " + _invoice.Business.BankAccountNumber, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Branch Code: " + _invoice.Business.BankBranchCode, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Swift Code: " + _invoice.Business.SwiftCode, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Reference: " + _invoice.Business.BankReferenceNumber, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();

        }
    }
}
