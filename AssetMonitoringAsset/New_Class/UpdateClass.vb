Public Class UpdateClass

    '------------------------------------------------------------------------------------
    'Update Status of Request Procurement
    '------------------------------------------------------------------------------------
    Public Shared Sub UpdateState(ByVal id As Integer, ByVal stat As String)

        Try
            Dim updateStat = (From p In db.GetTable(Of tblRequestDetail)()
                              Where (p.id = id)
                              Select p).FirstOrDefault()
            updateStat.State = stat
            db.SubmitChanges()

        Catch ex As Exception
            MsgBox("Invalid Data. update")
        End Try

    End Sub

End Class
