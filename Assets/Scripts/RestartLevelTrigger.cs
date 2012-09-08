using UnityEngine;
using System.Collections;

public class RestartLevelTrigger : MonoBehaviour {

    public float delay = 1f;
   
    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(delay);
        Application.LoadLevel(Application.loadedLevelName);
    }
}
