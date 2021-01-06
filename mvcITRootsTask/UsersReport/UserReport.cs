using iTextSharp.text;
using iTextSharp.text.pdf;
using mvcITRootsTask.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace mvcITRootsTask.UsersReport
{
    public class UserReport
    {
        //decleration
        int _totalColumn = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfPTable = new PdfPTable(3);
        PdfPCell _pdfpCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<ApplicationUser> _users = new List<ApplicationUser>();

        //functions
        
        public byte[] PrepareReport(List<ApplicationUser> users)
        {
            _users = users;
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 100f, 100f, 100f });


            this.ReportHeader();
            this.ReportBody();
            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();

            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Report", _fontStyle));
            _pdfpCell.Colspan = _totalColumn;
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.Border = 0;
            _pdfpCell.BackgroundColor = BaseColor.WHITE;
            _pdfpCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfpCell);
            _pdfPTable.CompleteRow();
        }

        private void ReportBody()
        {
            //table header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfpCell = new PdfPCell(new Phrase("UserName", _fontStyle));
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.GRAY;
            _pdfPTable.AddCell(_pdfpCell);

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfpCell = new PdfPCell(new Phrase("Phone Number", _fontStyle));
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.GRAY;
            _pdfPTable.AddCell(_pdfpCell);

            _pdfpCell = new PdfPCell(new Phrase("Email", _fontStyle));
            _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfpCell.BackgroundColor = BaseColor.GRAY;
            _pdfPTable.AddCell(_pdfpCell);
            _pdfPTable.CompleteRow();

            //table body

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            foreach(ApplicationUser users in _users)
            {
                _pdfpCell = new PdfPCell(new Phrase(users.UserName, _fontStyle));
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.GRAY;
                _pdfPTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(users.PhoneNumber, _fontStyle));
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.GRAY;
                _pdfPTable.AddCell(_pdfpCell);

                _pdfpCell = new PdfPCell(new Phrase(users.Email, _fontStyle));
                _pdfpCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfpCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfpCell.BackgroundColor = BaseColor.GRAY;
                _pdfPTable.AddCell(_pdfpCell);
                _pdfPTable.CompleteRow();
            }
        }
    }
}