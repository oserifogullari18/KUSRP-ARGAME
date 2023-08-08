using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class DrawLine : MonoBehaviour
{
    public AbstractMap map;
    public float destinationLatitude;
    public float destinationLongitude;

    void Start()
    {
        // Get the player's current location
        Location myLoc = LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation;
        Vector2d loc = new Vector2d(myLoc.LatitudeLongitude.x, myLoc.LatitudeLongitude.y);

        // Set the destination coordinates
        Vector2d dest = new Vector2d(destinationLatitude, destinationLongitude);

        // Create an array of points for the polyline
        Vector2d[] points = new Vector2d[2];
        points[0] = loc;
        points[1] = dest;

        // Create and add the polyline to the map
        var line = new GameObject("Line").AddComponent<LineRenderer>();
        line.transform.SetParent(map.transform);
        line.useWorldSpace = false;
        line.positionCount = points.Length;

        // Convert each point to a world position and add it to the LineRenderer
        Vector3[] positions = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            positions[i] = map.GeoToWorldPosition(points[i]);
        }
        line.SetPositions(positions);
    }
}
