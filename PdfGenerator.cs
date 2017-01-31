using System;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;
using System.IO;


namespace espaceNetSAV
{
    class PdfGenerator
    {
        BonReception bonObject; 
        FileStream fileStream;
        Document doc = new Document(PageSize.A4, _MARGIN, _MARGIN, _MARGIN, _MARGIN);
        PdfWriter write;

        const float CELL_BORDER_WIDTH = 1.5f;
        const int _MARGIN = 20;
        const float CELLS_MIN_HEIGHT = 120;
        /// <summary>
        /// This is the Pdf Generator paramitrized constructor
        /// </summary>
        /// <param name="bon"></param>
        /// <param name="fileName"></param>
        public PdfGenerator(BonReception bon, string fileName = "myPDF")
        {
            bonObject = bon; 
            fileStream = new FileStream(fileName + ".pdf", FileMode.Create);
            write  = PdfWriter.GetInstance(doc, fileStream);
            this.constructPdf("thatPDF");
        }
        /// <summary>
        /// This is responsible for building the actual pdf document 
        /// </summary>
        /// <param name="fielName">File of the name that will be generated</param>
        private void constructPdf(string fielName)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                //Opening the document before starting to write on it
                doc.Open();

                //I should experiment more with the tables an items aligning on this area down here
                //var headerText = this.headerTextChunkRefAchat();
                PdfPTable myTable = this.createTable(bonObject.designationReception.designation, bonObject.designationReception.probleme);
                var headingTable = this.createHeader(bonObject.client.nom);
                var footerSection = this.footerTable();
                ////var dateText = this.dateText();
                var dateText = this.dateAndRef(bonObject.ref_achat);
                //var refAchat = this.refAchatText();
                //Client table et logo
                doc.Add(headingTable);
                //"Bon" text && ref Achat 
                //doc.Add(headerText);
                //Date text
                doc.Add(dateText);
                doc.Add(myTable);
                doc.Add(footerSection);
                //doc.Add(refAchat);
                //Closing the document
                doc.Close();
            }
            //try
            //{
                
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    doc.Close();   
            //}
        }
        /// <summary>
        /// This is the date and ref achat text holder and placer on the pdf ALTERNATIVE SOLUTION
        /// </summary>
        /// <param name="refText">Réf achat text</param>
        /// <returns></returns>
        private PdfPTable dateAndRef(string refAchat)
        {
            PdfPTable table = new PdfPTable(2)
            {
                WidthPercentage = 100f,
                SpacingBefore = 10f, 
                SpacingAfter = 10f
            };

            PdfPCell dateCell = new PdfPCell()
            {
                BorderWidth = 0f,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Phrase = new Phrase(String.Format("Date: {0}", DateTime.Now.Date.ToString("dd/MM/yyyy")))
            };

            PdfPCell refCell = new PdfPCell()
            {
                BorderWidth = 0f,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Phrase = new Phrase(String.Format("Réf achat: {0}", refAchat))
            };


            table.AddCell(dateCell);
            table.AddCell(refCell);
            return table;
        }
        /// <summary>
        /// This is the Date holder, maybe ill just include the ref achat here and be done with that shit
        /// </summary>
        /// <returns></returns>
        /// 
        private Phrase dateText()
        {
            Phrase phrase = new Phrase("Date: " + DateTime.Now.ToString("dd/mm/yyyy"))
            {
                
            };

            return phrase;
        }
        /// <summary>
        /// This creates the very first table that holds the logo and the client name
        /// </summary>
        /// <param name="client">Client name</param>
        /// <returns></returns>
        private PdfPTable createHeader(string client)
        {
            /*##########################################################*/
            /* FIRST TABLE SECITON  */
            /*##########################################################*/
            PdfPTable table = new PdfPTable(3)
            {
                WidthPercentage = 100f
            };
            PdfPCell espaceNetLogo = new PdfPCell() { Border = 0 };

            PdfPCell clientCell = new PdfPCell(new Phrase(String.Format("Client: {0}", client)))
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
        /// <summary>
        /// This is the main table for designation and probleme 
        /// </summary>
        /// <param name="designation">String designation</param>
        /// <param name="probleme">String problème</param>
        /// <returns></returns>
        private PdfPTable createTable(string designation, string probleme)
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

            PdfPCell designationCell = new PdfPCell(new Phrase(designation)) { Padding = 8, BorderWidth = CELL_BORDER_WIDTH };
            PdfPCell problemeCell = new PdfPCell(new Phrase(probleme)) { Padding = 8, BorderWidth = CELL_BORDER_WIDTH };

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

        private PdfContentByte refAchatText(string refAchat)
        {
            PdfContentByte cb = write.DirectContent;
            cb.BeginText();
            cb.SetTextMatrix(475, 15);  //(xPos, yPos)
            cb.ShowText("Some text here and the Date: " + DateTime.Now.ToShortDateString());
            cb.EndText();
            return cb;
        }
        /// <summary>
        /// Ref Achat text holder or someshit, this is not yet used in the application 
        /// </summary>
        /// <param name="bon">Numero de Bon</param>
        /// <param name="refAchat">Réf Achat du mateial</param>
        /// <returns></returns>
        private Paragraph headerTextChunkRefAchat(string bon, string refAchat)
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, false);
            //iTextSharp.text.Font arial = new iTextSharp.text.Font(baseFont, 12f, 1, Color.Red);
            //Styles: 1=> BOLD
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 20, 1);
            Paragraph phrase = new Paragraph(bon, font);

            phrase.Alignment = Element.ALIGN_CENTER;

            return phrase;
        }
        /// <summary>
        /// This holds the very bottom table that has the rules of the company and such stuff
        /// </summary>
        /// <returns></returns>
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
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 9, 0, BaseColor.RED);
            iTextSharp.text.List myList = new List(List.UNORDERED)
            {
                Autoindent = true
            };

            myList.Add(new ListItem("Le délai de dépôt est fixé à 3 mois, au-delà ESPACENET se réserve le droit de le détruire.", font));
            myList.Add(new ListItem("Si le produit est sous garantie, le client doit déposer en même temps la facture d'achat.", font));
            myList.Add(new ListItem("Si le client refuse le Devis de réparation, un forfait de 90 DH sera facturé pour diagnostique.", font));

            mainCell.AddElement(new Phrase("IMPORTANT:"));

            mainCell.AddElement(myList);
            table.AddCell(mainCell);

            return table;
        }
    }
}
