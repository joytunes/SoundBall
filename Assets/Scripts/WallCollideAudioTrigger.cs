using UnityEngine;
using System.Collections;

public class WallCollideAudioTrigger : MonoBehaviour {

    public float soundHeightThreshold = 4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.localPosition.y >= soundHeightThreshold)
        {
            audio.Play();
        }
    }
}
