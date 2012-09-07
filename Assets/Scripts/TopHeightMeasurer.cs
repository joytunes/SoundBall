using UnityEngine;
using System.Collections;

public class TopHeightMeasurer : MonoBehaviour {

    public Transform target;
    public GUIStyle textStyle;
    public Rect topHeightRect = new Rect(10, 10, 500, 40);
    internal float topHeight;

    private Vector3 initialTargetPosition;

	// Use this for initialization
	void Start () 
    {
        initialTargetPosition = target.position;
	}
	
	// Update is called once per frame
	void Update () {
        topHeight = Mathf.Max(topHeight, target.position.y - initialTargetPosition.y);    
	}

    void OnGUI()
    {
        GUI.Label(topHeightRect, "Top height : " + topHeight.ToString("0.00"), textStyle);
    }
}
