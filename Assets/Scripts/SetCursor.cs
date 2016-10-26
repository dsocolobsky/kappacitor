using UnityEngine;
using System.Collections;
using System.IO;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public bool auto = false;

    // Use this for initialization
    void Start()
    {
        if (!auto)
        {
            Cursor.SetCursor(cursor, Vector2.zero, cursorMode);
        } else
        {
            string cursorindex = PlayerPrefs.GetString("mira", "1");
            string path = "Assets/Images/mira_" + cursorindex + ".png";
            cursor = LoadPNG(path);
            Cursor.SetCursor(cursor, Vector2.zero, cursorMode);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}
