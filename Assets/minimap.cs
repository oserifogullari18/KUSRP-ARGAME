using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


void Start(){
    public ARPointCloudManager pointCloudManager;
    public Material minimapPointMaterial;
    pointCloudManager = FindObjectOfType<ARPointCloudManager>();
    MeshRenderer minimapRenderer = gameObject.AddComponent<MeshRenderer>();
    minimapRenderer.material = minimapPointMaterial;
}

void UpdateMinimap()
{
    ARPointCloud arPointCloud = pointCloudManager.trackables[0];
    Vector3[] points = arPointCloud.positions;

    // Create a new mesh to represent the point cloud on the minimap
    Mesh minimapMesh = new Mesh();
    minimapMesh.vertices = points;

    int[] indices = new int[points.Length];
    for (int i = 0; i < points.Length; i++)
    {
        indices[i] = i;
    }
    minimapMesh.SetIndices(indices, MeshTopology.Points, 0);

    // Assign the mesh to the minimap GameObject
    MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
    if (meshFilter == null)
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
    }
    meshFilter.mesh = minimapMesh;
}


void Update()
{
    UpdateMinimap();
}
