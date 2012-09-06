using UnityEngine;
using System.Collections;

public class FFTControllerMesh : MonoBehaviour {

    public FFTController sourceController;
    public MeshFilter targetMesh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        float[] samples = sourceController.spectrumSamples;
        targetMesh.mesh = CreateMeshFromSamples(samples);
	}

    private Mesh CreateMeshFromSamples(float[] samples)
    {
        //TODO : Implement algorithm
        Mesh targetMesh = new Mesh();
        targetMesh.vertices = new Vector3[1];
        targetMesh.triangles = new int[3];
        return targetMesh;
    }
}
