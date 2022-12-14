Dim connection As MySqlConnection
Dim Query As String = ""
Dim SQLCmd As MySqlCommand
Dim sqlReader As MySqlDataReader

Private results As String
Function ccc_newAccount(ByVal firstName As String, ByVal lastName As String) As String

    Dim newAccountName As String
    Dim fn As String = firstName
    Dim ln As String = lastName
    Dim initialLogin As String
    Dim totalLen As Integer
    Dim ii As Integer = 1
    Dim yy As Integer = 7
    Dim i As Integer = 0


    firstName = Regex.Replace(firstName, "[^a-zA-Z0-9]", "")
    lastName = Regex.Replace(lastName, "[^a-zA-Z0-9]", "")

    totalLen = firstName.Length + lastName.Length

    If String.IsNullOrEmpty(firstName) AndAlso String.IsNullOrEmpty(lastName) Then
        Return String.Empty
    End If

    If firstName.Length > 0 And lastName.Length > 0 Then
        If totalLen >= 8 Then
            firstName = Left(firstName, 1)
            lastName = Left(lastName, 7)
            newAccountName = String.Join("", firstName, lastName)
        ElseIf totalLen <= 7 Then
            newAccountName = String.Join("", firstName, lastName)
        End If
    ElseIf firstName.Length > 0 Then
        newAccountName = Left(firstName, 8)
    Else
        newAccountName = Left(lastName, 8)
    End If

    ' initialLogin could be used if we are out of available index 
    ' then we add next available index at the end of login
    initialLogin = newAccountName

    ' load collection of all persons having the same account

    ' put them in a list of centralaccounts
    Dim listOfExisting As New List(Of String)
    listOfExisting.Add("jballant")
    listOfExisting.Add("jballant1")
    listOfExisting.Add("jballant2")
    listOfExisting.Add("joballan")
    listOfExisting.Add("jonballa")
    listOfExisting.Add("JONABALL")
    listOfExisting.Add("JONATBAL")
    listOfExisting.Add("JONATHBA")
    listOfExisting.Add("JONATHAB")
    listOfExisting.Add("JONATHAN")
    listOfExisting.Add("lipi")
    listOfExisting.Add("lipi1")
    listOfExisting.Add("tomlee")

    ' check if centralaccount is already in use, if yes
    ' start adding an index ii & yy until we found a free centralaccount
    While True
        If Not listOfExisting.Contains(newAccountName, StringComparer.InvariantCultureIgnoreCase) Then
            Console.WriteLine("PROPOSED ACCOUNT: " & newAccountName.ToUpperInvariant())
            Exit While
        End If

        If ii <> 0 Then
            ii = ii + 1
        ElseIf yy <> 0 Then
            yy = yy - 1
        End If
        firstName = Left(fn, ii)
        lastName = Left(ln, yy)

        newAccountName = Left(String.Join("", firstName, lastName), 8)
        If totalLen <= 7 Or totalLen >= 8 Then
            i = i + 1
            newAccountName = initialLogin & CStr(i)
        End If

    End While

    Return String.Empty

End Function
Sub Main(args As String())

    ccc_newAccount("tom", "lee")

End Sub
