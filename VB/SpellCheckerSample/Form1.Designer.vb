Imports Microsoft.VisualBasic
Imports System
Namespace SpellCheckerSample
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim optionsSpelling1 As New DevExpress.XtraSpellChecker.OptionsSpelling()
			Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.spellChecker1 = New DevExpress.XtraSpellChecker.SpellChecker(Me.components)
			Me.SuspendLayout()
			' 
			' richTextBox1
			' 
			Me.richTextBox1.BackColor = System.Drawing.SystemColors.Control
			Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.richTextBox1.Location = New System.Drawing.Point(0, 0)
			Me.richTextBox1.Name = "richTextBox1"
			Me.spellChecker1.SetShowSpellCheckMenu(Me.richTextBox1, False)
			Me.richTextBox1.Size = New System.Drawing.Size(831, 535)
			Me.spellChecker1.SetSpellCheckerOptions(Me.richTextBox1, optionsSpelling1)
			Me.richTextBox1.TabIndex = 0
			Me.richTextBox1.Text = ""
			' 
			' spellChecker1
			' 
			Me.spellChecker1.Culture = New System.Globalization.CultureInfo("en-US")
			Me.spellChecker1.ParentContainer = Nothing
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(831, 535)
			Me.Controls.Add(Me.richTextBox1)
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "SpellChcker Sample"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private richTextBox1 As System.Windows.Forms.RichTextBox
		Private spellChecker1 As DevExpress.XtraSpellChecker.SpellChecker
	End Class
End Namespace

