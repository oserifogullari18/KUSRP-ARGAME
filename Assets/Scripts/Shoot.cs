using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Shoot : MonoBehaviour
{

public GameObject arCamera;


public void Shoott() {
RaycastHit hit;
if (Physics.Raycast (arCamera.transform.position, arCamera.transform.forward, out hit)) {
//if ((hit.transform.name == "TurtleShellWithBar" )) {
// Destroy(hit.transform.gameObject);
            Player playerScript =   (Player)hit.transform.gameObject.GetComponent<Player>();
                if (playerScript != null)
            {
                playerScript.TakeDamage(20);

            }
        }
    }
}
//}

