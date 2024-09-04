using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour
{
    public Texture2D frontMouseCursor;
    public Texture2D leftMouseCursor;
    public Texture2D rightMouseCursor;

    #region About Mouse Cursor 
    private void OnMouseEnter()
    {
        if (gameObject.CompareTag("FrontDoor"))
        {
            Cursor.SetCursor(frontMouseCursor, Vector2.zero, CursorMode.Auto);
        }
            
        else if (gameObject.CompareTag("LeftDoor"))
        {
            Cursor.SetCursor(leftMouseCursor, Vector2.zero, CursorMode.Auto);
        }
            
        else if (gameObject.CompareTag("RightDoor"))
        {
            Cursor.SetCursor(rightMouseCursor, Vector2.zero, CursorMode.Auto);
        }
            
    }

    private void OnMouseOver()
    {
        if (gameObject.CompareTag("FrontDoor"))
            Cursor.SetCursor(frontMouseCursor, Vector2.zero, CursorMode.Auto);
        else if (gameObject.CompareTag("LeftDoor"))
            Cursor.SetCursor(leftMouseCursor, Vector2.zero, CursorMode.Auto);
        else if (gameObject.CompareTag("RightDoor"))
            Cursor.SetCursor(rightMouseCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    #endregion

}
