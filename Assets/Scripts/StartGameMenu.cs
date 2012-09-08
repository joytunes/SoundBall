using UnityEngine;
using System.Collections;

public class StartGameMenu : MonoBehaviour {

    public GUIStyle textStyle;
    public Rect textRect = new Rect(200,200,500,50);
    public Rect buttonRect = new Rect(200, 260, 500, 100);

    void OnGUI()
    {
        GUI.Label(textRect, "VC Ball", textStyle);
        if (GUI.Button(buttonRect, "Play"))
        {
            animation.Play();
            enabled = false;
        }
    }
}
