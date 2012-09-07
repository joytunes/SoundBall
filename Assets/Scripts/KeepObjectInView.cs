using UnityEngine;
using System.Collections;

public class KeepObjectInView : MonoBehaviour 
{
    public Transform targetObject;
    public Vector3 verticalMovementDirection;
    public Vector3 horizontalMovementDirection;
    public float startMoveHeightDelta;
    public float startMoveWidthDelta;

    public float movementRatio = 1;
    public float movementRatio2 = 1;

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
        float deltaWidth = targetObject.position.x - targetStartPosition.x;
        if (deltaHeight > startMoveHeightDelta)
        {
            deltaHeight -= startMoveHeightDelta;
            transform.position = startPosition + verticalMovementDirection * deltaHeight * movementRatio;
        }
        else
        {
            transform.position = startPosition;
        }
		
		if (deltaWidth > startMoveWidthDelta)
		{
			deltaWidth -= startMoveWidthDelta;
			Vector3 tmp = transform.position;
			tmp = startPosition + horizontalMovementDirection * deltaWidth * movementRatio2;
			transform.position = tmp;
		} else {
			Vector3 tmp = transform.position;
			tmp.x = startPosition.x;
			transform.position = tmp;
		}
	}
}
