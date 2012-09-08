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

        Vector3 nextPosition = startPosition;
        if (deltaHeight > startMoveHeightDelta)
        {
            deltaHeight -= startMoveHeightDelta;
            nextPosition += verticalMovementDirection * deltaHeight * movementRatio;
        }
		
		if (deltaWidth > startMoveWidthDelta)
		{
			deltaWidth -= startMoveWidthDelta;
			nextPosition += horizontalMovementDirection * deltaWidth * movementRatio2;
		}

        transform.position = nextPosition;
	}

    void FinishedFarJump()
    {
        Destroy(this, 1f);
    }
}
