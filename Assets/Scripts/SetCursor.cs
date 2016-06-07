using UnityEngine;
using System.Collections;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursor;
    public CursorMode cursorMode = CursorMode.Auto;

    // Use this for initialization
    void Start()
    {
        Cursor.SetCursor(cursor, Vector2.zero, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
