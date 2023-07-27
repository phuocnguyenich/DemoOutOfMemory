using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Layout.Element;

namespace IncompleteTable
{
    public class Font
    {
        public PdfFont PdfFont { get; set; }
        public float Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public bool Underline { get; set; }
        public Color Color { get; set; }

        public Font(string fontName, float size, bool bold = false, bool italic = false, bool underline = false, Color color = null)
        {
            PdfFont = PdfFontFactory.CreateFont(fontName);
            Size = size;
            Bold = bold;
            Italic = italic;
            Underline = underline;
            Color = color;
        }

        public void Apply(Cell container)
        {
            container.SetFont(PdfFont);
            container.SetFontSize(Size);
            if (Bold) container.SetBold();
            if (Italic) container.SetItalic();
            if (Underline) container.SetUnderline();
            if (Color != null) container.SetFontColor(Color);
        }
    }
}