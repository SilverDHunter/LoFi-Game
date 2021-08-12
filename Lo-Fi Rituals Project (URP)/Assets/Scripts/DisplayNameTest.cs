using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayNameTest : MonoBehaviour
{
    void Start()
    {
        print ("-----------------------------------------------");
        print ("Display Name Read from Registry: " + GetCurrentUserDisplayName());
        print ("-----------------------------------------------");
    }

    /// <summary>
    /// The displayname of the player.
    /// </summary>
    public string displayName;

    /// <summary>
    /// The UI Text where the username is going to be presented.
    /// </summary>
    public TextMeshProUGUI UiDisplayName;

    private string GetCurrentUserDisplayName()
    {
        // HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\SessionData\1
        // Value Name LoggedOnDisplayName
        // LocalMachine
        // RegistryKey reg = Registry.LocalMachine;
        // RegistryKey subKey = reg.OpenSubKey(@"Software\Microsoft", true);  

        byte[] displayNameByteStream = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI").GetValue("LastLoggedOnDisplayName") as byte[];
        return System.Text.Encoding.Unicode.GetString(SliceByteArray(displayNameByteStream, 48)).TrimEnd("\0".ToCharArray());
    }

    private static byte[] SliceByteArray(byte[] input, int index)
    {
        byte[] output = new byte[input.Length - index];
        System.Array.Copy(input, index, output, 0, output.Length);
        return output;
    }


    /*private string LoadDisplayNameFromPath (string path)
    {
        UnityEngine.Debug.Log(path);
        string texture;
        texture = System.IO.File.ReadAllBytes(path);
        return null;
    }*/


    void Update ()
    {
        
    }
}