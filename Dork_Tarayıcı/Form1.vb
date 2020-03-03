Imports System.IO
Public Class Form1
    Dim count As Integer = 0
    Dim metin As String = ""
    Dim site As Integer = 0
    Private Sub ınfluenceButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ınfluenceButton1.Click
        WebBrowser1.Navigate("https://www.google.com.tr/#q=" + ınfluenceTextBox1.Text.ToString + "3D&ei=PQyHWcySDcmOgAb9so1Y&start=10")
        ınfluenceListBox1.NewListBox()
        metin = ""
        site = Convert.ToInt32(ınfluenceComboBox1.Text.ToString)
        ınfluenceProgressBar1.Value = 0
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        Try
            count = 0
            'ınfluenceListBox1.NewListBox()
            Dim bilgi As HtmlElementCollection = WebBrowser1.Document.All
            For Each element As HtmlElement In bilgi
                If (element.GetAttribute("classname").Contains("_Rm")) Then
                    ınfluenceListBox1.AddItem(element.InnerText)
                    metin += element.InnerText + Environment.NewLine
                    count += 1
                End If
            Next

            site -= 10
            If (site <> 0) Then
                WebBrowser1.Navigate("https://www.google.com.tr/#q=" + ınfluenceTextBox1.Text.ToString + "3D&ei=PQyHWcySDcmOgAb9so1Y&start=" + (Convert.ToInt32(ınfluenceComboBox1.Text.ToString) - site).ToString)
                ınfluenceProgressBar1.Value = Convert.ToInt32(ınfluenceComboBox1.Text.ToString) - site
            End If
            If (site = 0) Then
                ınfluenceProgressBar1.Value = 100
                MessageBox.Show("Dork sonuçları listelendi", "Dork Tarayıcı", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString + Environment.NewLine + "Eğer bir sorunla karşılaşırsanız Sorun çöz seçeneğini deneyin", "Dork Tarayıcı", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ınfluenceButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ınfluenceButton2.Click
        If (metin <> "") Then
            Dim kaydet As SaveFileDialog = New SaveFileDialog
            kaydet.Title = "Kaydet"
            kaydet.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*"
            If (kaydet.ShowDialog() = DialogResult.OK) Then
                System.IO.File.CreateText(kaydet.FileName).Close()
                Dim yaz As System.IO.StreamWriter = New System.IO.StreamWriter(kaydet.FileName)
                yaz.Write("Dork tarayıcı | Powered By DeadSound" + Environment.NewLine + Environment.NewLine + metin)
                yaz.Close()
                MessageBox.Show("Dosya oluşturldu.", "Dork Tarayıcı", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://www.google.com.tr/#q=" + "Book.php?bookID=" + "3D&ei=PQyHWcySDcmOgAb9so1Y&start=10")
    End Sub

    Private Sub ınfluenceButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ınfluenceButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        WebBrowser1.ScriptErrorsSuppressed = True
    End Sub
End Class
