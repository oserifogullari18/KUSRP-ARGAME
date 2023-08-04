using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondObjectRandomPlacer : MonoBehaviour
{
    public GameObject prefabToPlace;
    public int numberOfObjectsToPlace = 5;
    private List<GameObject> gemObjects = new List<GameObject>();
    public float minDistanceFromCamera = 5f;
    public float maxDistanceFromCamera = 10f; // Adjust as needed

    private void Start()
    {
        PlaceRandomObjects();
    }

    private void Update()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        foreach (GameObject gemObject in gemObjects)
        {
            float distanceToCamera = Vector3.Distance(gemObject.transform.position, cameraPosition);
            float scaleFactor = Mathf.Clamp(1f / distanceToCamera, 0.5f, 1.5f);
            gemObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }

    private void PlaceRandomObjects()
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        for (int i = 0; i < numberOfObjectsToPlace; i++)
        {
            float angle = Random.Range(0f, 360f);
            float distance = Random.Range(minDistanceFromCamera, maxDistanceFromCamera);

            float x = cameraPosition.x + distance * Mathf.Cos(angle * Mathf.Deg2Rad);
            float z = cameraPosition.z + distance * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = cameraPosition.y;

            Vector3 gemPosition = new Vector3(x, y, z);
            GameObject newGem = Instantiate(prefabToPlace, gemPosition, Quaternion.identity);
            gemObjects.Add(newGem);

            // Calculate the initial scaling based on the object's distance from the camera
            float distanceToCamera = Vector3.Distance(newGem.transform.position, cameraPosition);
            float scaleFactor = Mathf.Clamp(1f / distanceToCamera, 0.5f, 1.5f);
            newGem.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }
}
