using UnityEngine;
using System.Collections;

public class KeepObjectInView : MonoBehaviour 
{
    public Transform targetObject;
    public Vector3 movementDirection;
    public float startMoveHeightDelta;
    public float movementRatio = 1;

    private Vector3 startPosition;
    private Vector3 targetStartPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        targetStartPosition = targetObject.position;
	}
	
	// Update is called once per frame
	void Update () {
        float deltaHeight = targetObject.position.y - targetStartPosition.y;
        if (deltaHeight > startMoveHeightDelta)
        {
            deltaHeight -= startMoveHeightDelta;
            transform.position = startPosition + movementDirection * deltaHeight * movementRatio;
        }
        else
        {
            transform.position = startPosition;
        }
	}
}
