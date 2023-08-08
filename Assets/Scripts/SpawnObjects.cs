using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnObjects : MonoBehaviour
{
    public AbstractMap map;
    public GameObject objectPrefab;
    public float circleRadius = 5f;
    public int numberOfObjects = 5;

    private ARRaycastManager arRaycastManager;

    private void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        PlaceRandomObjects();
    }

    private void PlaceRandomObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
    {
        float randomAngle = Random.Range(0f, 360f); // Generate a random angle in degrees
        float randomDistance = Random.Range(0f, circleRadius); // Generate a random distance within the circle radius

        // Convert polar coordinates to Cartesian coordinates
        float x = randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float z = randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        // Convert AR world position to geographic coordinates
        Vector3 arWorldPosition = transform.position + new Vector3(x, 0f, z);
        Vector2d geographicCoordinate = map.WorldToGeoPosition(arWorldPosition);

        // Create a ray from AR camera position and direction
        Ray arRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // Raycast to find a suitable plane in the real world
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(arRay, hits, TrackableType.PlaneWithinPolygon))
        {
            Instantiate(objectPrefab, hits[0].pose.position, hits[0].pose.rotation);
        }
    }
    }
    
}