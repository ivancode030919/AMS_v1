Public Class Home

    Public UserID As Integer
    Public Branch As String = ""
    Public Department As String = ""
    Public Section As String = ""
    Public noti1 As Integer
    Public UserType As String = ""

    Public EmployeeID As Integer
    Public DepartmentID As Integer
    Public BranchID As Integer
    Public SectionID As Integer



    Private Sub AccordionControlElement4_Click(sender As Object, e As EventArgs) Handles AccordionControlElement4.Click
        AssetType.ShowDialog()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim EmployeeName As String = FetchClass.fetchRequestor(EmployeeID)
        Label1.Text = "Hello! " & EmployeeName & " || " & Date.Now.ToString("MM-dd-yyyy") & " || " & Department & " || " & Section & " || " & UserType
    End Sub

    Private Sub AccordionControlElement5_Click(sender As Object, e As EventArgs) Handles AccordionControlElement5.Click
        AssetCategory.ShowDialog()
    End Sub

    Private Sub AccordionControlElement6_Click(sender As Object, e As EventArgs) Handles AccordionControlElement6.Click
        AssetCondition.ShowDialog()
    End Sub

    Private Sub AccordionControlElement7_Click(sender As Object, e As EventArgs) Handles AccordionControlElement7.Click
        AssetSection.ShowDialog()
    End Sub

    Private Sub AccordionControlElement8_Click(sender As Object, e As EventArgs) Handles AccordionControlElement8.Click
        AssetBranch.ShowDialog()
    End Sub

    Private Sub AccordionControlElement9_Click(sender As Object, e As EventArgs) Handles AccordionControlElement9.Click
        AssetDepartment.ShowDialog()
    End Sub

    Private Sub AccordionControlElement10_Click(sender As Object, e As EventArgs) Handles AccordionControlElement10.Click
        AssetPosition.ShowDialog()
    End Sub

    Private Sub AccordionControlElement11_Click(sender As Object, e As EventArgs) Handles AccordionControlElement11.Click
        AssetDocumentType.ShowDialog()
    End Sub

    Private Sub AccordionControlElement12_Click(sender As Object, e As EventArgs) Handles AccordionControlElement12.Click
        Vendor.ShowDialog()
    End Sub

    Private Sub AccordionControlElement13_Click(sender As Object, e As EventArgs) Handles AccordionControlElement13.Click
        Employee.ShowDialog()
    End Sub

    Private Sub AccordionControlElement14_Click(sender As Object, e As EventArgs) Handles AccordionControlElement14.Click
        User.ShowDialog()
    End Sub

    Private Sub AccordionControlElement25_Click(sender As Object, e As EventArgs) Handles AccordionControlElement25.Click
        NewAsset.ShowDialog()
    End Sub

    Private Sub AccordionControlElement17_Click(sender As Object, e As EventArgs) Handles AccordionControlElement17.Click
        BuildAsset.ShowDialog()
    End Sub

    Private Sub AccordionControlElement28_Click(sender As Object, e As EventArgs) Handles AccordionControlElement28.Click
        NewAssetRegister.ShowDialog()
    End Sub

    Private Sub AccordionControlElement29_Click(sender As Object, e As EventArgs) Handles AccordionControlElement29.Click
        MasterDataList.ShowDialog()
    End Sub

    Private Sub AccordionControlElement30_Click(sender As Object, e As EventArgs) Handles AccordionControlElement30.Click
        Reference.ShowDialog()
    End Sub

    Private Sub Home_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
        Login.Show()
    End Sub

    Private Sub AccordionControlElement39_Click(sender As Object, e As EventArgs) Handles AccordionControlElement39.Click
        InventoryList.ShowDialog()
    End Sub

    Private Sub AccordionControlElement35_Click(sender As Object, e As EventArgs) Handles e.Click

        Me.IsMdiContainer = True
        Assignment1.MdiParent = Me
        PictureBox1.SendToBack()
        Assignment1.BringToFront()
        Assignment1.WindowState = WindowState.Maximized

        With Assignment1
            .Text = String.Empty
            .allowtoaddrow = True
            .winstatemax = True
            .Show()
        End With


    End Sub


    Private Sub AccordionControlElement45_Click(sender As Object, e As EventArgs) Handles AccordionControlElement45.Click
        importmasterlist.ShowDialog()
    End Sub

    Private Sub AccordionControlElement38_Click(sender As Object, e As EventArgs) Handles AccordionControlElement38.Click

        Me.IsMdiContainer = True
        Request.MdiParent = Me
        PictureBox1.SendToBack()
        Request.BringToFront()
        Request.Show()


    End Sub

    Private Sub AccordionControlElement46_Click(sender As Object, e As EventArgs) Handles AccordionControlElement46.Click

        Me.IsMdiContainer = True
        RequestRegister.MdiParent = Me
        PictureBox1.SendToBack()
        RequestRegister.BringToFront()
        RequestRegister.Show()







    End Sub

    Private Sub AccordionControlElement56_Click(sender As Object, e As EventArgs) Handles AccordionControlElement56.Click

        Me.IsMdiContainer = True
        ProcureRegister.MdiParent = Me
        PictureBox1.SendToBack()
        ProcureRegister.BringToFront()
        ProcureRegister.Show()

    End Sub

    Private Sub AccordionControlElement19_Click(sender As Object, e As EventArgs) Handles AccordionControlElement19.Click
        BuildAssetImport.ShowDialog()
    End Sub

    Private Sub AccordionControlElement31_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AccordionControlElement48_Click(sender As Object, e As EventArgs) Handles AccordionControlElement48.Click

    End Sub

    Private Sub AccordionControlElement36_Click(sender As Object, e As EventArgs) Handles AccordionControlElement36.Click

        Me.IsMdiContainer = True
        AssignemntRegister.MdiParent = Me
        PictureBox1.SendToBack()
        AssignemntRegister.BringToFront()
        AssignemntRegister.Show()

    End Sub


    Private Sub AccordionControlElement53_Click(sender As Object, e As EventArgs) Handles AccordionControlElement53.Click

        Me.IsMdiContainer = True
        BorrowMain.MdiParent = Me
        PictureBox1.SendToBack()
        BorrowMain.BringToFront()
        BorrowMain.Show()

    End Sub
End Class