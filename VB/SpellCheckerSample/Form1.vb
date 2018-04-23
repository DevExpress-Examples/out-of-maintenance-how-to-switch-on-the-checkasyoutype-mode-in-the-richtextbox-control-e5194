Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Globalization
Imports System.IO
#Region "#SampleCode"
Imports System.Reflection
Imports System.Windows.Forms
Imports DevExpress.XtraSpellChecker
Imports DevExpress.XtraSpellChecker.Parser

Namespace SpellCheckerSample
	Partial Public Class Form1
		Inherits Form
		Private controller As DevExpress.XtraSpellChecker.Native.RichTextBoxTextController

		Public Sub New()
			InitializeComponent()
			richTextBox1.LoadFile(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Data.SpellChecker.rtf"), RichTextBoxStreamType.RichText)
			controller = New DevExpress.XtraSpellChecker.Native.RichTextBoxTextController(richTextBox1)
			FindErrors(New IntPosition(0), New IntPosition(richTextBox1.TextLength))
			AddHandler richTextBox1.TextChanged, AddressOf OnTextChanged
		End Sub

		Private Sub FindErrors(ByVal startPos As Position, ByVal endPos As Position)
			Dim start As Position = startPos.Clone()
			Dim [end] As Position = endPos.Clone()
			Dim errorInfo As ISpellingErrorInfo = Nothing
			Do
				errorInfo = (CType(spellChecker1, ISpellChecker)).Check(richTextBox1, controller, start, [end])
				If errorInfo IsNot Nothing Then
					start = errorInfo.WordEndPosition
					HighlightText(errorInfo.WordStartPosition, errorInfo.WordEndPosition, Color.Red)
				Else
					HighlightText(start, [end], Color.Black)
				End If
			Loop While errorInfo IsNot Nothing
		End Sub
		Private Sub HighlightText(ByVal start As Position, ByVal [end] As Position, ByVal color As Color)
			Dim cachedSelectionStart As Integer = richTextBox1.SelectionStart
			controller.Select(start, [end])
			richTextBox1.SelectionColor = color

			richTextBox1.SelectionStart = cachedSelectionStart
			richTextBox1.SelectionLength = 0
		End Sub
		Private Overloads Sub OnTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			Dim currentPosition As Position = New IntPosition(richTextBox1.SelectionStart)
			Dim start As Position = GetPrevWordPosition(currentPosition)
			Dim [end] As Position = controller.GetNextPosition(currentPosition)
			FindErrors(start, [end])
		End Sub
		Private Function GetPrevWordPosition(ByVal pos As Position) As Position
			Return controller.GetPrevPosition(controller.GetPrevPosition(pos))
		End Function
	End Class
End Namespace
#End Region ' #SampleCode