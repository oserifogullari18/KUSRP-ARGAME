using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectRandomPlacer : MonoBehaviour
{
    public GameObject prefabToPlace;
    public int numberOfObjectsToPlace;
    public int i=0;
    public float areaRadius = 10f;
    private List<Vector3> gemPositions = new List<Vector3>();
    public float centerLatitude=38.506336f;
    public float centerLongitude=43.378115f;

    public float minDistanceBetweenGems=3f;
    private bool tooClose;
    
    private void Start()
    {
        Debug.Log("Center Latitude: " + centerLatitude);
        Debug.Log("Center Longitude: " + centerLongitude);
        
        PlaceRandomObjects();
        
    }

    /*private void InitializeLocationServices()
    {
        Input.location.Start(5f, 5f);
    }

    private void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            // Access real-time GPS data
            float latitude = Input.location.lastData.latitude;
            float longitude = Input.location.lastData.longitude;
            float altitude = Input.location.lastData.altitude;

            // Update the positions of existing objects based on the new GPS data
            foreach (GameObject gemObject in gemObjects)
            {
                Vector3 newPosition = CalculateGemPosition(gemObject.transform.position, latitude, longitude, altitude);
                gemObject.transform.position = newPosition;
            }

            // Check if we need to place new objects
            if (i < numberOfObjectsToPlace && gemObjects.Count < numberOfObjectsToPlace)
            {
                PlaceRandomObjects(latitude, longitude, altitude);
            }
        }
    }

    private Vector3 CalculateGemPosition(Vector3 oldPosition, float latitude, float longitude, float altitude)
    {
        const float EARTH_RADIUS = 6378137f; // Earth's radius in meters

    // Convert latitude and longitude to radians
    float latitudeRad = latitude * Mathf.Deg2Rad;
    float longitudeRad = longitude * Mathf.Deg2Rad;

    // Convert GPS coordinates to world positions using Mercator projection
    float x = EARTH_RADIUS * longitudeRad;
    float z = EARTH_RADIUS * Mathf.Log(Mathf.Tan(latitudeRad / 2f + Mathf.PI / 4f));

    // Shift the positions relative to the player's location
    x -= transform.position.x;
    z -= transform.position.z;

    // Calculate new position based on updated GPS data
    Vector3 newPosition = new Vector3(x, altitude, z);
    return newPosition;
    }*/

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

    /*private void OnDisable()
    {
        Input.location.Stop();
    }*/
}

