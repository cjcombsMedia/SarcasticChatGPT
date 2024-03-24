Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Xml.Linq
Imports Newtonsoft.Json
Imports System.Text
Imports Microsoft.Web.WebView2.WinForms


Public Class Form1

    Private apiKey As String = "<YOUR CHATGPT KEY>"
    'Private isDarkMode As Boolean = True


    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInput.Focus()
        Me.BackColor = Color.FromArgb(30, 30, 30)
        rtbConversation.BackColor = Color.FromArgb(30, 30, 30)
        rtbConversation.ForeColor = Color.White
        txtInput.BackColor = Color.FromArgb(30, 30, 30)
        txtInput.ForeColor = Color.White
        btnSend.BackColor = Color.FromArgb(30, 30, 30)
        btnSend.ForeColor = Color.White
        btnToggleTheme.BackColor = Color.FromArgb(30, 30, 30)
        btnToggleTheme.ForeColor = Color.White
        btnSave.BackColor = Color.FromArgb(30, 30, 30)
        btnSave.ForeColor = Color.White
        btnToggleTheme.Text = "Light Mode"
        Try
            Dim modelName As String = "text-davinci-003"
            Dim connectedSuccessfully As Boolean = Await CheckConnection(apiKey)


            If connectedSuccessfully Then
                Label1.Text = $"Connected to {modelName}"
                Me.Text = $"Support ChatGPT v1.0.0 is Connected to {modelName}"
                'MessageBox.Show($"Connected to {modelName}", "Connected Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"Failed to connect to {modelName}", "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error connecting to ChatGPT API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function CheckConnection(apiKey As String) As Task(Of Boolean)
        Try
            Dim modelName As String = Await GetModelName(apiKey)

            ' Send initial prompt to set up conversation
            Dim initialPrompt As String = "Hello, I need you to be an expert in sarcasm, memes, comedy. If you understand, just reply with What do you want today dude?"
            Dim chatGPTResponse As String = Await CallChatGPTAsync(initialPrompt, apiKey)

            ' Display ChatGPT's response only in conversation history
            rtbConversation.AppendText($"{chatGPTResponse}" & Environment.NewLine)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub ToggleTheme()
        Dim isDarkMode As Boolean = Not Me.BackColor.Equals(Color.FromArgb(240, 240, 240))

        If isDarkMode Then
            Me.BackColor = Color.FromArgb(240, 240, 240)
            rtbConversation.BackColor = Color.FromArgb(240, 240, 240)
            rtbConversation.ForeColor = Color.Black
            txtInput.BackColor = Color.FromArgb(240, 240, 240)
            btnSend.BackColor = Color.FromArgb(240, 240, 240)
            btnToggleTheme.BackColor = Color.FromArgb(240, 240, 240)
            btnToggleTheme.ForeColor = Color.Black
            btnSave.BackColor = Color.FromArgb(240, 240, 240)
            btnSave.ForeColor = Color.Black
            btnToggleTheme.Text = "Dark Mode"
        Else
            Me.BackColor = Color.FromArgb(30, 30, 30)
            rtbConversation.BackColor = Color.FromArgb(30, 30, 30)
            rtbConversation.ForeColor = Color.White
            txtInput.BackColor = Color.FromArgb(30, 30, 30)
            txtInput.ForeColor = Color.White
            btnSend.BackColor = Color.FromArgb(30, 30, 30)
            btnSend.ForeColor = Color.White
            btnToggleTheme.BackColor = Color.FromArgb(30, 30, 30)
            btnToggleTheme.ForeColor = Color.White
            btnSave.BackColor = Color.FromArgb(30, 30, 30)
            btnSave.ForeColor = Color.White
            btnToggleTheme.Text = "Light Mode"
        End If

        rtbConversation.SelectionStart = rtbConversation.TextLength
        rtbConversation.ScrollToCaret()
    End Sub

    Private Async Function GetModelName(apiKey As String) As Task(Of String)
        Dim httpClient As New HttpClient()
        httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey)

        Dim response As HttpResponseMessage = Await httpClient.GetAsync("https://api.openai.com/v1/models")

        If response.IsSuccessStatusCode Then
            Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
            Dim responseObj As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonResponse)
            Dim models As JArray = responseObj("data")
            Dim latestModel As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(models(0).ToString())
            Return latestModel("id").ToString()
        Else
            Return $"Error: {response.StatusCode}"
        End If
    End Function

    Private conversationHistory As String = ""
    Private Sub AddTextToConversation(text As String)
        Dim formattedText As String = ""

        ' Check if the text contains quotes
        If text.Contains("""") Then
            ' Split the text into parts based on the quotes
            Dim parts As String() = text.Split("""")

            For i As Integer = 0 To parts.Length - 1
                If i Mod 2 = 0 Then ' Text outside the quotes
                    formattedText &= parts(i)
                Else ' Text inside the quotes
                    formattedText &= $"<font face=""Consolas"">{parts(i)}</font>"
                End If
            Next
        Else ' No quotes, use regular font
            formattedText = text
        End If

        ' Add the formatted text to the conversation
        rtbConversation.SelectionStart = rtbConversation.TextLength
        rtbConversation.SelectionLength = 0
        rtbConversation.SelectionFont = New Font("Segoe UI", 10, FontStyle.Regular)
        rtbConversation.AppendText(formattedText & Environment.NewLine)
        rtbConversation.SelectionStart = rtbConversation.TextLength
        rtbConversation.ScrollToCaret()
    End Sub
    Private Async Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ' Show a progress dialog while the chatbot is processing the message
        Dim progressDialog As New ProgressDialog()
        'progressDialog.Show(Me)

        Dim prompt As String = ""
        btnSend.Enabled = False
        ' Check if a prompt is selected in the combobox
        If cbPrompt.SelectedIndex <> -1 Then
            prompt = cbPrompt.SelectedItem.ToString()
        ElseIf cbPrompt.SelectedIndex = -1 And txtInput.Text = "" Then
            MessageBox.Show("Um.. yeah I am going to need you to either select a template or type a question. Ok? GREAT...", "Gimme Somethin!", MessageBoxButtons.OK, MessageBoxIcon.Question)
            btnSend.Enabled = True
            Exit Sub
        Else
            prompt = txtInput.Text
        End If

        rtbConversation.AppendText(Environment.NewLine & $"Mere Mortal: {prompt}" & Environment.NewLine)

        Dim chatGPTResponse As String = Await CallChatGPTAsync(prompt, apiKey)

        ' Hide the progress dialog
        'progressDialog.Hide()

        rtbConversation.AppendText($"EC - ChatGPT: {chatGPTResponse}" & Environment.NewLine)
        txtInput.Clear()

        cbPrompt.SelectedIndex = -1
        btnSend.Enabled = True

        ' Save the conversation to the listview
        'Dim item As New ListViewItem(DateTime.Now.ToString())
        'item.SubItems.Add(prompt)
        'item.SubItems.Add(chatGPTResponse)
        'lvOlderConversations.Items.Add(item)

        ' Autoscroll the conversation history
        rtbConversation.ScrollToCaret()
    End Sub

    Private Async Function CallChatGPTAsync(prompt As String, apiKey As String) As Task(Of String)
        Try
            Dim httpClient As New HttpClient()
            httpClient.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey)

            ' Set up the request body
            Dim requestBody As New Dictionary(Of String, Object) From {
            {"prompt", prompt},
            {"model", "text-davinci-003"},
            {"max_tokens", 1000},
            {"temperature", 1}
        }

            Dim jsonContent As String = JsonConvert.SerializeObject(requestBody)
            Dim content As New StringContent(jsonContent, Encoding.UTF8, "application/json")

            Dim response As HttpResponseMessage = Await httpClient.PostAsync("https://api.openai.com/v1/completions", content)

            If response.IsSuccessStatusCode Then
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim responseObj As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonResponse)
                Dim choices As JArray = responseObj("choices")
                Dim firstChoice As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(choices(0).ToString())
                Return firstChoice("text").ToString()
            Else
                Return $"Error: {response.StatusCode}"
            End If
        Catch ex As Exception
            Return $"Error: {ex.Message}"
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Create a new XML document
        Dim xmlDoc As New XDocument()

        ' Create a root element for the document
        Dim rootElement As New XElement("conversation")

        ' Add the root element to the XML document
        xmlDoc.Add(rootElement)

        ' Save the XML document to a file
        xmlDoc.Save("conversation.xml")

        ' Show a message box to indicate the conversation was saved
        MessageBox.Show("Conversation saved to conversation.xml", "Conversation Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnToggleTheme_Click(sender As Object, e As EventArgs) Handles btnToggleTheme.Click
        ToggleTheme()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub


    Private snapDistance As Integer = 10 ' Adjust this value to set the snap distance
    Private taskbarSize As Integer = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height
    Private isDragging As Boolean = False
    Private mouseOffset As Point
    Private startDraggingPoint As Point
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startDraggingPoint = e.Location
        End If
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If isDragging Then
            Dim newX As Integer = Me.Left + e.X - startDraggingPoint.X
            Dim newY As Integer = Me.Top + e.Y - startDraggingPoint.Y

            ' Snap to screen edges
            If newX < snapDistance Then
                newX = 0
            ElseIf newX + Me.Width > Screen.PrimaryScreen.Bounds.Width - snapDistance Then
                newX = Screen.PrimaryScreen.Bounds.Width - Me.Width
            End If

            If newY < snapDistance Then
                newY = 0
            ElseIf newY + Me.Height > Screen.PrimaryScreen.Bounds.Height - taskbarSize - snapDistance Then
                newY = Screen.PrimaryScreen.Bounds.Height - taskbarSize - Me.Height
            End If

            ' Set the new location of the form
            Me.Location = New Point(newX, newY)
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
        End If
    End Sub
End Class
