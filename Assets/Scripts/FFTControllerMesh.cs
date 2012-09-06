using UnityEngine;
using System.Collections;

public class FFTControllerMesh : MonoBehaviour {

    public FFTController sourceController;
    public MeshFilter targetMesh;
    public int boxWidth = 10;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        float[] samples = sourceController.ballPositions;
        targetMesh.mesh = CreateMeshFromSamples(samples);
	}

    private Mesh CreateMeshFromSamples(float[] samples)
    {
        Mesh samplesMesh = new Mesh();

        Vector3[] triangleVertices = new Vector3[samples.Length * 2];
        int[] triangleIndices = new int[(samples.Length - 1)*2*3];

        for (int i = 0; i < samples.Length ; i++)
        {
            triangleVertices[2 * i] = new Vector3(i, -boxWidth, 0);
            triangleVertices[2 * i + 1] = new Vector3(i, samples[i], 0);
        }

        for (int i = 0; i < (samples.Length-1) * 2; i++)
        {
            triangleIndices[3 * i] = i;
            triangleIndices[3 * i + 1] = i + 1;
            triangleIndices[3 * i + 2] = i + 2;
        }

        samplesMesh.vertices = triangleVertices;
        samplesMesh.triangles = triangleIndices;

        if (Time.frameCount % 60 == 0)
        {
            string[] intStrings = System.Array.ConvertAll<int, System.String>(samplesMesh.triangles, delegate(int input) { return input.ToString(); });
            //Debug.Log("triangles:" + string.Join(",", intStrings));
            //Debug.Log("samples len:" + samples.Length.ToString());
        }
        return samplesMesh;
    }
}
