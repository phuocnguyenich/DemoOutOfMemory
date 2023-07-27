using iText.Layout.Element;

namespace IncompleteTable
{
    public static class Extension
    {
        public static Cell AddParagraph(this Cell cell, string text, Action<Paragraph> with = null)
        {
            var paragraph = new Paragraph(text);
            with?.Invoke(paragraph);
            cell.Add(paragraph);
            return cell;
        }
        public static Cell UseFont(this Cell container, Font font)
        {
            font.Apply(container);
            return container as Cell;
        }
    }
}