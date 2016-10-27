using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D []cursors;

    public CursorMode cursorMode = CursorMode.Auto;
    public bool menu;
    
    void Start()
    {
        if (menu)
        {
            Cursor.SetCursor(cursors[0], Vector2.zero, cursorMode);
        } else
        {
            int i = int.Parse(PlayerPrefs.GetString("mira", "1"));
            Cursor.SetCursor(cursors[i], Vector2.zero, cursorMode);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
