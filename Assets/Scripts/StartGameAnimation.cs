using UnityEngine;
using System.Collections;

public class StartGameAnimation : MonoBehaviour 
{
    public GameObject[] objectsToEnableOnFinish;
    public Behaviour[] componentsToEnableOnFinish;

	// Use this for initialization
	void Start () {
        foreach (GameObject go in objectsToEnableOnFinish)
        {
            go.active = true;
        }
        foreach (Behaviour b in componentsToEnableOnFinish)
        {
            b.enabled = true;
        }
	}
}
