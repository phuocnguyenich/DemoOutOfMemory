using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.IO;

namespace IncompleteTable
{
    public class IncompleteTable
    {
        private Font DefaultFont => new Font(StandardFonts.COURIER, 10, true, false, false, ColorConstants.BLACK);

        public static readonly string DEST = "C:/Users/ICH-PC/Desktop/Test12/incomplete_table7.pdf"; // please change the path accordingly
        private readonly int ColumnWidth = 90;
        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            var bytes = new IncompleteTable().ManipulatePdf();
            File.WriteAllBytes(DEST, bytes);
        }

        private byte[] ManipulatePdf()
        {
            var stream = new MemoryStream();
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(stream));
            Document doc = new Document(pdfDoc, PageSize.A3, true);

            // The second argument determines 'large table' functionality is used
            // It defines whether parts of the table will be written before all data is added.
            Table table = new Table(new float[9] { 60, ColumnWidth, ColumnWidth, ColumnWidth, ColumnWidth, ColumnWidth, ColumnWidth, ColumnWidth, ColumnWidth }, true);

            for (int i = 0; i < 9; i++)
            {
                table.AddHeaderCell(new Cell().SetKeepTogether(true).Add(new Paragraph("Header " + i)));
            }
            doc.Add(table);

            // For the "large tables" they shall be added to the document before its child elements are populated
            for (int i = 0; i < 10_000; i++)
            {
                Console.WriteLine(i);


                table
                    .SetWidth(PageSize.A3.GetWidth() - 50)
                    .SetMargins(0, 0, 10, 0)
                    .SetHorizontalAlignment(HorizontalAlignment.CENTER)

                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))

                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))

                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont))
                .AddCell(new Cell().SetKeepTogether(true).AddParagraph(("Test " + i)).UseFont(DefaultFont));
            }
            doc.Add(table);
            // Flushes the rest of the content and indicates that no more content will be added to the table
            table.Complete();

            doc.Close();
            return stream.ToArray();
        }

    }
}