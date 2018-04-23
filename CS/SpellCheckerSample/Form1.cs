using System.Drawing;
using System.Globalization;
using System.IO;
#region #SampleCode
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraSpellChecker;
using DevExpress.XtraSpellChecker.Parser;

namespace SpellCheckerSample {
    public partial class Form1 : Form {
        DevExpress.XtraSpellChecker.Native.RichTextBoxTextController controller;

        public Form1() {
            InitializeComponent();
            richTextBox1.LoadFile(Assembly.GetExecutingAssembly().GetManifestResourceStream("SpellCheckerSample.Data.SpellChecker.rtf"), RichTextBoxStreamType.RichText);
            controller = new DevExpress.XtraSpellChecker.Native.RichTextBoxTextController(richTextBox1);
            FindErrors(new IntPosition(0), new IntPosition(richTextBox1.TextLength));
            richTextBox1.TextChanged += OnTextChanged;
        }

        void FindErrors(Position startPos, Position endPos) {
            Position start = startPos.Clone();
            Position end = endPos.Clone();
            ISpellingErrorInfo errorInfo = null;
            do {
                errorInfo = ((ISpellChecker)spellChecker1).Check(richTextBox1, controller, start, end);
                if (errorInfo != null) {
                    start = errorInfo.WordEndPosition;
                    HighlightText(errorInfo.WordStartPosition, errorInfo.WordEndPosition, Color.Red);
                }
                else
                    HighlightText(start, end, Color.Black);
            } while (errorInfo != null);
        }
        void HighlightText(Position start, Position end, Color color) {
            int cachedSelectionStart = richTextBox1.SelectionStart;
            controller.Select(start, end);
            richTextBox1.SelectionColor = color;

            richTextBox1.SelectionStart = cachedSelectionStart;
            richTextBox1.SelectionLength = 0;
        }
        void OnTextChanged(object sender, System.EventArgs e) {
            Position currentPosition = new IntPosition(richTextBox1.SelectionStart);
            Position start = GetPrevWordPosition(currentPosition);
            Position end = controller.GetNextPosition(currentPosition);
            FindErrors(start, end);
        }
        Position GetPrevWordPosition(Position pos) {
            return controller.GetPrevPosition(controller.GetPrevPosition(pos));
        }
    }
}
#endregion #SampleCode