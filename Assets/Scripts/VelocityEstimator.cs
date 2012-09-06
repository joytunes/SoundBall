using UnityEngine;
using System.Collections;

public class VelocityEstimator : MonoBehaviour 
{
    private Vector3 lastVelocity;
    private Vector3 lastPosition;

	// Use this for initialization
	void Start () 
    {
        lastVelocity = Vector3.zero;
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //TODO : Do something smarter
        lastVelocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
	}

    public Vector3 velocity
    {
        get
        {
            return lastVelocity;
        }
    }
}
