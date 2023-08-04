using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemObjectRandomPlacer : MonoBehaviour
{
    public GameObject prefabToPlace;
    public int numberOfObjectsToPlace = 50;
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

    /*public GameObject prefabToPlace;
    public int numberOfObjectsToPlace;
    public int i=0;
    //public float areaRadius = 10f;
    private List<Vector3> gemPositions = new List<Vector3>();
    //public float centerLatitude=38.506336f;
    //public float centerLongitude=43.378115f;

    public float minDistanceBetweenGems=3f;
    //private bool tooClose;
    
    private void Start()
    {
        Debug.Log("Center Latitude: " + centerLatitude);
        Debug.Log("Center Longitude: " + centerLongitude);
        
        PlaceRandomObjects();
        
    }


    void PlaceRandomObjects()
    {

        if(prefabToPlace.CompareTag("gem")){
            numberOfObjectsToPlace=5;
        }
        else if(prefabToPlace.CompareTag("horn")){
            numberOfObjectsToPlace=3;
        }

        while (i < numberOfObjectsToPlace)
        {
        tooClose = false;

        float angle = Random.Range(0f, 360f); // Random angle in degrees
        float distance = Random.Range(0f, areaRadius);

        float x = transform.position.x + distance * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = transform.position.z + distance * Mathf.Sin(angle * Mathf.Deg2Rad);

        // Convert latitude, longitude, and height to world position
        Vector3 gemPosition = new Vector3(x, transform.position.y, z);

        foreach (Vector3 existingGemPosition in gemPositions)
        {
            Vector3 distanceVector = gemPosition - existingGemPosition;
            if (distanceVector.magnitude < minDistanceBetweenGems)
            {
                tooClose = true;
                break;
            }
        }

        if (!tooClose)
        {
            Instantiate(prefabToPlace, gemPosition, Quaternion.identity);
            gemPositions.Add(gemPosition);
            i++;
        }
    }
}
}*/

