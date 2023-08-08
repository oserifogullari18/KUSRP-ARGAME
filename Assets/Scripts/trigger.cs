using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject screen;
    public GameObject healthbar;
    public HealthBar healthbar1;

    // Update is called once per frame
    void Update()
    {
    if(healthbar1.slider.value<=0){
        screen.SetActive(true);
    }    
    }
}
