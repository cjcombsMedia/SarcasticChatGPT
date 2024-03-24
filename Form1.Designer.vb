<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        rtbConversation = New RichTextBox()
        txtInput = New TextBox()
        btnSend = New Button()
        btnSave = New Button()
        Label1 = New Label()
        btnToggleTheme = New Button()
        Panel1 = New Panel()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        cbPrompt = New ComboBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' rtbConversation
        ' 
        rtbConversation.BorderStyle = BorderStyle.None
        rtbConversation.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point)
        rtbConversation.Location = New Point(9, 134)
        rtbConversation.Margin = New Padding(2)
        rtbConversation.Name = "rtbConversation"
        rtbConversation.ReadOnly = True
        rtbConversation.Size = New Size(1609, 584)
        rtbConversation.TabIndex = 4
        rtbConversation.Text = ""
        ' 
        ' txtInput
        ' 
        txtInput.Location = New Point(14, 806)
        txtInput.Margin = New Padding(2)
        txtInput.Multiline = True
        txtInput.Name = "txtInput"
        txtInput.ScrollBars = ScrollBars.Vertical
        txtInput.Size = New Size(1484, 78)
        txtInput.TabIndex = 0
        ' 
        ' btnSend
        ' 
        btnSend.Location = New Point(1501, 806)
        btnSend.Margin = New Padding(2)
        btnSend.Name = "btnSend"
        btnSend.Size = New Size(115, 78)
        btnSend.TabIndex = 1
        btnSend.Text = "Go"
        btnSend.UseVisualStyleBackColor = True
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(1348, 738)
        btnSave.Margin = New Padding(2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(268, 36)
        btnSave.TabIndex = 3
        btnSave.Text = "Save Conversation"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(1375, 782)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(205, 21)
        Label1.TabIndex = 5
        Label1.Text = "Connecting to GPT Model..."
        ' 
        ' btnToggleTheme
        ' 
        btnToggleTheme.Location = New Point(14, 738)
        btnToggleTheme.Margin = New Padding(2)
        btnToggleTheme.Name = "btnToggleTheme"
        btnToggleTheme.Size = New Size(256, 36)
        btnToggleTheme.TabIndex = 2
        btnToggleTheme.Text = "Toggle Dark-Light Mode"
        btnToggleTheme.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(184), CByte(24), CByte(28))
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(1, 1)
        Panel1.Margin = New Padding(2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1621, 128)
        Panel1.TabIndex = 7
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(25, 36)
        Label2.Name = "Label2"
        Label2.Size = New Size(435, 45)
        Label2.TabIndex = 1
        Label2.Text = "ChatGPT A.K.A. Emeric Cathal"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.CloseHOVER
        PictureBox1.Location = New Point(1585, 2)
        PictureBox1.Margin = New Padding(2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(31, 31)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' cbPrompt
        ' 
        cbPrompt.FormattingEnabled = True
        cbPrompt.Items.AddRange(New Object() {"How do I add a user in Microsoft 365 Admin tool? Please provide step by step.", "How do I add an auto-attendant to Avaya PBX? Please provide step by step.", "How do I create a Microsoft Automate flow to add a user to Microsoft 365 Admin from a Google Form. Please provide step by step including the google form process.", "Define world domination in 3 words."})
        cbPrompt.Location = New Point(358, 740)
        cbPrompt.Margin = New Padding(2)
        cbPrompt.Name = "cbPrompt"
        cbPrompt.Size = New Size(935, 33)
        cbPrompt.TabIndex = 8
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1625, 892)
        Controls.Add(cbPrompt)
        Controls.Add(Panel1)
        Controls.Add(btnToggleTheme)
        Controls.Add(Label1)
        Controls.Add(btnSave)
        Controls.Add(btnSend)
        Controls.Add(txtInput)
        Controls.Add(rtbConversation)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(2)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Support ChatGPT v1.0.0"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents rtbConversation As RichTextBox
    Friend WithEvents txtInput As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnToggleTheme As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cbPrompt As ComboBox
    Friend WithEvents Label2 As Label
End Class
