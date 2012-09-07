using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour {

    private bool goingUp = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!!!!!!" + goingUp.ToString());

        if ((!audio.isPlaying) && goingUp)
        {
            Debug.Log("Woohoo!!!!!!");
            audio.Play();
            goingUp = false;
        }
        else
        {
            goingUp = true;
        }
    }
}
