Public Class ViewClass

    '------------------------------------------------------------------------------------
    'Display in Detail In Request Register
    '------------------------------------------------------------------------------------
    Public Shared Sub FetchRegisterDetail1(ByVal HeaderID As Integer, ByVal RequestType As String)

        If RequestType = "Procure" Then

            With Rqregister
                .dgv.DataSource = db.ShowAssetAvailability(HeaderID)
            End With

        ElseIf RequestType = "Borrow" Then

        ElseIf RequestType = "Transfer Ownership" Then

        End If

    End Sub

    '------------------------------------------------------------------------------------
    'Display in Assignmet1 form for datagridview
    '------------------------------------------------------------------------------------
    Public Shared Function FetchRegisterDetail(ByVal headerid As Integer) As Object

        With Assignment1
            .dgv.DataSource = db.ShowAssetAvailability2(headerid)
        End With


    End Function

End Class
