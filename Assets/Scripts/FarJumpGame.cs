using UnityEngine;
using System.Collections;

public class FarJumpGame : MonoBehaviour {
    
    public Transform target;
    public GameObject[] objectsToDisable;
    public float timeToStart = 10;
    public float minHeightForThrow = -10;
    public GUIStyle textStyle;
    public Rect maxXDistanceRect = new Rect(50,50,500,50);

    private Vector3 startPosition;
    private float maxDistance;
    private bool startedFarJump;
    private bool finishedFarJump;

	// Use this for initialization
	void Start () {
        startPosition = target.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!startedFarJump && Time.time > timeToStart)
        {
            StartFarJump();
        }
        if (startedFarJump && !finishedFarJump)
        {
            float xDistance = Mathf.Abs(target.position.x - startPosition.x);
            maxDistance = Mathf.Max(maxDistance, xDistance);
            float yDistance = target.position.y - startPosition.y;
            if (yDistance < minHeightForThrow)
            {
                finishedFarJump = true;
            }
        }
	}

    private void StartFarJump()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActiveRecursively(false);
        }
        startedFarJump = true;
    }

    void OnGUI()
    {
        if (startedFarJump)
        {
            GUI.Label(maxXDistanceRect, "Max distance : " + maxDistance.ToString("0.00"), textStyle);
        }
        else
        {
            GUI.Label(maxXDistanceRect, "Time until jump : " + (timeToStart - Time.time).ToString("0.00"), textStyle);
        }
        
    }
}
