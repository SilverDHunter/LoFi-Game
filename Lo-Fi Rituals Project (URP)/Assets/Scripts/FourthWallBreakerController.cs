using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FourthWallBreakerController : MonoBehaviour
{
    void Start ()
    {
        DontDestroyOnLoad (this); // Prevents the script from getting eliminated, and thus will always be present.

        userName = System.Environment.UserName; // Grabs the player username and asigns it to the string.
        ShowUserName ();

        #region For DisplayName

        /* ProcessStartInfo displaynameExe = new ProcessStartInfo ();
         * displaynameExe.FileName = Application.streamingAssetsPath + @"\dn.exe";
         * displaynameExe.WorkingDirectory = Application.streamingAssetsPath;
         * 
         * try
         * { using (Process exeProcess = Process.Star (dnExe))
         * { exeProcess.WaitForExit ();}
         * }
         * catch
         * {
         * 
         * }
         * 
         * if (File.Exists (Application.streamingAssetsPath + @"\dn.exe"))
         * {
         * displayName = File.ReadAllText (Application.streamingAssetsPath + @"\dn.exe");
         * }
         */

        #endregion For DisplayName

        rawImage.texture = LoadTextureFromPath (GetCurrentDesktopWallpaperPath ());
        //interactiveColor = LoadMainColorFromPath(GetCurrentDesktopColorPath());
        //uIDisplayName.text ("" + GetCurrentUserDisplayName());
    }
    
    #region Accessing Username

    [Header ("Username Controls")]
 
    /// <summary>
    /// The username of the player.
    /// </summary>
    public string userName;

    /// <summary>
    /// The UI Text where the username is going to be presented.
    /// </summary>
    public TextMeshProUGUI UiUserName;


    /// <summary>
    /// Function that takes the username and puts it on screen.
    /// </summary>
    public void ShowUserName ()
    {
        UiUserName.text = userName;
    }

    #endregion Accessing Username
    /*
    #region Accessing Displayname

    [Header ("Displayname Controls")]

    [Space(10f)]

    public TextMeshProUGUI uIDisplayName;

    /*private string LoadDisplayNameFromPath (string path)
    {
        UnityEngine.Debug.Log(path);
        string displayName;
        displayName. (System.IO.File.ReadAllBytes(path));
        return displayName;
    }

    private string GetCurrentUserDisplayName()
    {
        byte[] displayNameByteStream = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\").GetValue("LastLoggedOnDisplayName") as byte[];
        return System.Text.Encoding.Unicode.GetString(SliceByteArray(displayNameByteStream, 48)).TrimEnd("\0".ToCharArray());
    }

    #endregion Accessing Displayname
    */
    #region Accessing Windows Colors

    [Header ("Color Controls")]

    [Space (10f)]

    /// <summary>
    /// The material used to change the color of the apartment walls.
    /// </summary>
    public Material wallMaterial;

    /// <summary>
    /// The material used to change the color of the bedsheets.
    /// </summary>
    public Material sheetsMaterial;

    /// <summary>
    /// The color the 
    /// </summary>
    public Color interactiveColor;


    /// <summary>
    /// Function that changes the color of several materials based on the colors used in Windows.
    /// </summary>
    public void ChangingColors ()
    {
        // sheetsMaterial.color = interactiveColor;
        wallMaterial.color = interactiveColor;
    }

    /*
    private Color LoadMainColorFromPath (string path)
    {
        UnityEngine.Debug.Log(path);
        Color color = new Color (1, 1, 1);
        color.Equals (System.IO.File.ReadAllBytes(path));
        return color;
    }

    
    private string GetCurrentDesktopColorPath ()
    {
        byte[] path = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\CurrentVersion\Themes\Personalize").GetValue("ColorPrevalence") as byte[];
        return System.Text.Encoding.Unicode.GetString(SliceByteArray(path, 24)).TrimEnd("\0".ToCharArray());
    }*/

    #endregion Accessing Windows Colors
    
    #region Accessing Wallpaper

    [Header ("Wallpaper Controls")]

    [Space (10f)]

    public RawImage rawImage;
    

    private Texture2D LoadTextureFromPath(string path)
    {
        UnityEngine.Debug.Log(path);
        Texture2D texture = new Texture2D (2, 2);
        texture.LoadImage (System.IO.File.ReadAllBytes(path));
        return texture;
    }

    private string GetCurrentDesktopWallpaperPath()
    {
        byte [] path = Microsoft.Win32.Registry.CurrentUser.OpenSubKey (@"Control Panel\Desktop").GetValue ("TranscodedImageCache") as byte [];
        return System.Text.Encoding.Unicode.GetString (SliceByteArray (path, 24)).TrimEnd ("\0".ToCharArray ());
    }

    private static byte [] SliceByteArray (byte [] input, int index)
    {
        byte [] output = new byte [input.Length - index];
        System.Array.Copy (input, index, output, 0, output.Length);
        return output;
    }

    #endregion Accessing Wallpaper

    void Update()
    {
        ChangingColors ();
    }
}