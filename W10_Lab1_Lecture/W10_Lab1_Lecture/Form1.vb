Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'AddressBookDataSet.user' table. You can move, or remove it, as needed.
        Me.UserTableAdapter.Fill(Me.AddressBookDataSet.user)

    End Sub

    Private Sub btnUploadPhoto_Click(sender As Object, e As EventArgs) Handles btnUploadPhoto.Click
        Dim openphoto As New OpenFileDialog

        openphoto.Filter = ("Picture File|*.jpg; *.gif; *.png; *.jpeg; *.bmp")
        openphoto.ShowDialog()
        picProfile.ImageLocation = openphoto.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Me.UserBindingSource.MovePrevious()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Me.UserBindingSource.MoveNext()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        txtFullName.Enabled = True
        txtNickname.Enabled = True
        txtPhone.Enabled = True
        txtEmail.Enabled = True
        txtFB.Enabled = True

        Me.UserBindingSource.AddNew()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.UserBindingSource.RemoveCurrent()
        Me.UserTableAdapter.Update(Me.AddressBookDataSet.user)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.Validate()
        Me.UserBindingSource.EndEdit()
        Me.UserTableAdapter.Update(Me.AddressBookDataSet.user)
        Me.UserTableAdapter.Fill(Me.AddressBookDataSet.user)
        MsgBox("Data Saved")
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Dim strFind As String
        strFind = txtFind.Text.ToUpper

        'Dim find_record = From user In AddressBookDataSet.user
        '                  Where user.FullName.ToUpper = strFind
        '                  Select user


        Dim find_record = From user In AddressBookDataSet.user
                          Where user.FullName.ToUpper Like strFind & "*"
                          Select user
        UserBindingSource.DataSource = find_record.AsDataView
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtFind.Clear()
        Me.UserTableAdapter.Fill(Me.AddressBookDataSet.user)
    End Sub
End Class
