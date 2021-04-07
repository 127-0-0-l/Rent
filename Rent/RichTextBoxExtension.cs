using System.Windows.Controls;
using System.Windows.Documents;

namespace Rent
{
    public static class RichTextBoxExtension
    {
        public static string GetText(this RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );

            return textRange.Text;
        }
    }
}
