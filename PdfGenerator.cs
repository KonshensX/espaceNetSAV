using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;
using System.IO;


namespace espaceNetSAV
{
    class PdfGenerator
    {
        FileStream fileStream;
        Document doc = new Document(PageSize.A4, _MARGIN, _MARGIN, _MARGIN, _MARGIN);
        PdfWriter write;

        const float CELL_BORDER_WIDTH = 1.5f;
        const int _MARGIN = 20;
        const float CELLS_MIN_HEIGHT = 120;

        public PdfGenerator(string fileName = "myPDF")
        {
            fileStream = new FileStream(fileName + ".pdf", FileMode.Create);
            write  = PdfWriter.GetInstance(doc, fileStream);
            this.constructPdf("thatPDF");
        }

        private void constructPdf(string fielName)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {

                    //Opening the document before starting to write on it
                    doc.Open();

                    //I should experiment more with the tables an items aligning on this area down here
                    var headerText = this.headerTextChunkRefAchat();
                    PdfPTable myTable = this.createTable();
                    var headingTable = this.createHeader();
                    var footerSection = this.footerTable();
                    var dateText = this.dateText();
                    //var refAchat = this.refAchatText();
                    //Client table et logo
                    doc.Add(headingTable);
                    //"Bon" text && ref Achat 
                    doc.Add(headerText);
                    //Date text
                    doc.Add(dateText);
                    doc.Add(myTable);
                    doc.Add(footerSection);
                    //doc.Add(refAchat);
                    //Closing the document
                    doc.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                doc.Close();   
            }
        }

        private Phrase dateText()
        {
            Phrase phrase = new Phrase("Date: " + DateTime.Now.ToString("dd/mm/yyyy"))
            {
                
            };

            return phrase;
        }

        private PdfPTable createHeader()
        {
            /*##########################################################*/
            /* FIRST TABLE SECITON  */
            /*##########################################################*/
            PdfPTable table = new PdfPTable(3)
            {
                WidthPercentage = 100f
            };
            PdfPCell espaceNetLogo = new PdfPCell() { Border = 0 };

            PdfPCell clientCell = new PdfPCell(new Phrase("Client: Insert value here"))
            {
                FixedHeight = 50,
                Right = 0,
                BorderWidth = CELL_BORDER_WIDTH,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER
            };

            table.AddCell(espaceNetLogo);
            table.AddCell(new PdfPCell() { Border = 0 });
            table.AddCell(clientCell);

            return table;
        }

        private PdfPTable createTable()
        {

            /*##########################################################*/
            /* SECOND TABLE SECITON  */
            /*##########################################################*/
            const float HEADINGS_HEIGHT = 40;
            PdfPTable table = new PdfPTable(2) { SpacingBefore = 5, WidthPercentage = 100f };
            PdfPCell cell = new PdfPCell(new Phrase("This is a heading text")) { BorderWidth = CELL_BORDER_WIDTH };
            //cell.MinimumHeight = 50;
            //cell.Colspan = 3;
            //cell.HorizontalAlignment = 1;
            //table.AddCell(cell);
            //Heading texts 
            PdfPCell designationHeadingCell = new PdfPCell(new Phrase("Désignation"))
            {
                BorderWidth = CELL_BORDER_WIDTH,
                FixedHeight = HEADINGS_HEIGHT,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER
            };

            PdfPCell problemeHeadingCell = new PdfPCell(new Phrase("Problème"))
            {
                BorderWidth = CELL_BORDER_WIDTH,
                FixedHeight = HEADINGS_HEIGHT,
                VerticalAlignment = PdfPCell.ALIGN_MIDDLE,
                HorizontalAlignment = PdfPCell.ALIGN_CENTER
            };

            table.AddCell(designationHeadingCell);
            table.AddCell(problemeHeadingCell);

            PdfPCell designationCell = new PdfPCell(new Phrase("This is a phrase for testing purposes, this field should be filled programatically")) { Padding = 8, BorderWidth = CELL_BORDER_WIDTH };
            PdfPCell problemeCell = new PdfPCell(new Phrase("This is a phrase for testing purposes, this field should be filled programatically")) { Padding = 8, BorderWidth = CELL_BORDER_WIDTH };

            designationCell.MinimumHeight = CELLS_MIN_HEIGHT;
            problemeCell.MinimumHeight = CELLS_MIN_HEIGHT;

            table.AddCell(designationCell);
            table.AddCell(problemeCell);

            //This is the empty cell beside the Signature cell
            table.AddCell(new PdfPCell()
            {
                Border = 0
            });

            PdfPCell signatureCell = new PdfPCell(new Phrase("Signature Client: .................................................."))
            {
                BorderWidth = CELL_BORDER_WIDTH,
                FixedHeight = HEADINGS_HEIGHT,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE,
            };

            table.AddCell(signatureCell);
            //table.TotalWidth = 144f;
            //table.LockedWidth = true;
            //table.HorizontalAlignment = 0;
            //PdfPCell left = new PdfPCell(new Paragraph("Rotated"));
            //left.Rotation = 90;
            //table.AddCell(left);
            //PdfPCell middle = new PdfPCell(new Paragraph("Rotated"));
            //middle.Rotation = -90;
            //table.AddCell(middle);
            //table.AddCell("Not Rotated");

            return table;
        }

        private PdfContentByte refAchatText(string refAchat = "EXMP215")
        {
            PdfContentByte cb = write.DirectContent;
            cb.BeginText();
            cb.SetTextMatrix(475, 15);  //(xPos, yPos)
            cb.ShowText("Some text here and the Date: " + DateTime.Now.ToShortDateString());
            cb.EndText();
            return cb;
        }

        private Paragraph headerTextChunkRefAchat(string text = "Bon N° 006542", string refAchat = "Acbgd554654")
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            //iTextSharp.text.Font arial = new iTextSharp.text.Font(baseFont, 12f, 1, Color.Red);
            //Styles: 1=> BOLD
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20, 1);
            Paragraph phrase = new Paragraph(text, font);

            phrase.Alignment = Element.ALIGN_CENTER;

            return phrase;
        }

        private PdfPTable footerTable()
        {
            PdfPTable table = new PdfPTable(1)
            {
                WidthPercentage = 100f,
                SpacingBefore = 10
            };

            PdfPCell mainCell = new PdfPCell()
            {
                BorderWidth = 2,
                PaddingLeft = 10f,
                PaddingRight = 10f,
                PaddingTop = 5f,
                PaddingBottom = 10f
            };

            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12, 0, BaseColor.RED);
            iTextSharp.text.List myList = new List(List.UNORDERED)
            {
                IndentationLeft = 15f,
            };

            myList.Add(new ListItem("Lorem ipsum doloçr and shit", font));
            myList.Add(new ListItem("Lorem ipsum doloçr and shit", font));
            myList.Add(new ListItem("Lorem ipsum doloçr and shit", font));

            mainCell.AddElement(new Phrase("IMPORTANT!"));

            mainCell.AddElement(myList);
            table.AddCell(mainCell);

            return table;
        }
    }
}
