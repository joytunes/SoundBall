using UnityEngine;
using System.Collections;

public class VelocityEstimator : MonoBehaviour 
{
    private Vector3 lastVelocity;
    private Vector3 lastPosition;
	private Vector3 currentPosition;

	// Use this for initialization
	void Start () 
    {
        lastVelocity = Vector3.zero;
        lastPosition = transform.position;
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //TODO : Do something smarter
		currentPosition = transform.position;
        lastVelocity = (currentPosition - lastPosition) / Time.deltaTime;
        lastPosition = currentPosition;
	}

    public Vector3 velocity
    {
        get
        {
            return lastVelocity;
        }
    }
	
	public Vector3 position
	{
		get
		{
			return currentPosition;
		}
	}
}
