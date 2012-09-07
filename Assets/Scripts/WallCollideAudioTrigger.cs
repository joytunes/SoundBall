using UnityEngine;
using System.Collections;

public class WallCollideAudioTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        audio.Play();
    }
}
