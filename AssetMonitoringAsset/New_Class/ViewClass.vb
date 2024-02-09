Public Class ViewClass

    '------------------------------------------------------------------------------------
    'Display in Detail In Request Register
    '------------------------------------------------------------------------------------
    Public Shared Function FetchRegisterDetail(ByVal HeaderID As Integer, ByVal RequestType As String) As Object

        If RequestType = "Procure" Then

            With Rqregister
                .dgv.DataSource = db.ShowAssetAvailability(HeaderID)
            End With

        ElseIf RequestType = "Borrow" Then

        ElseIf RequestType = "Transfer Ownership" Then

        End If

    End Function

End Class
