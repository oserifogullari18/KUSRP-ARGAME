using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

public GameObject arCamera;


public void Shoott() {
RaycastHit hit;
if (Physics.Raycast (arCamera.transform.position, arCamera.transform.forward, out hit)) {
Destroy(hit.transform.gameObject);
//if (hit.transform.name == "Props_Cap") {
print("222");
//}
}
print("111");
}
}


