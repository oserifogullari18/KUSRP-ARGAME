using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    void Update()
    {
        //Touch input var mi bakiyoruz.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Touch inputun oldugu yerden raycast yapiyoruz. Yani bir isin gonderiyoruz.
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    //Gonderdigimiz isin 'gem' tagi olan herhangi bir seye carpmis mi bakiyoruz.
                    if (hit.collider.CompareTag("gem"))
                    {
                        //Carptiysa objeyi yok ediyoruz.
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }   
    }
}
