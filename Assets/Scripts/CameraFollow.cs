using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target GameObject to follow (in this case, the "CameraFollowTarget").

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y+50, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f); // Adjust the '5f' value to control camera follow speed.
        }
    }
}
