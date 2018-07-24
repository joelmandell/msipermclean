Imports Microsoft.Win32

Module Module1

    Sub Main()

        Console.WriteLine("Ange värde att söka efter:")
        Dim path = Console.ReadLine()

        Dim deletedFiles = 0

        Dim s = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)

        Dim HKLM = s.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Installer").OpenSubKey("UserData").OpenSubKey("S-1-5-18").OpenSubKey("Components", True)

        For Each h In HKLM.GetSubKeyNames
            Dim item = HKLM.OpenSubKey(h.ToString)

            Dim str = item.GetValue(item.GetValueNames(0))
            Dim name = item.GetValueNames(0)

            If (str.Contains(path)) Then

                If name.Contains("0000000000000000000") Then
                    HKLM.DeleteSubKey(h.ToString)
                    Console.WriteLine("Raderat nyckel:" & h.ToString)
                    deletedFiles += 1
                End If

            End If
        Next

        Console.WriteLine("")
        Console.WriteLine("Inläsning klart. Antal raderade registerposter som haft värdet perm:" & deletedFiles)
        Console.ReadLine()
    End Sub

End Module

