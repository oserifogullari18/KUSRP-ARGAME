using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float can, animasyonYavasligi;

    private float maxcan, gercekScale;

    // Start is called before the first frame update
    void Start()
    {
        maxcan = can;
    }

    // Update is called once per frame
    void Update()
    {
        gercekScale = can / maxcan;

        if (transform.localScale.x > gercekScale)
        {
            transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x - gercekScale) / animasyonYavasligi, transform.localScale.y, transform.localScale.z);
        }

        if (Input.GetKeyDown("a"))
        {
            can -= 10;
        }

        if (Input.GetKeyDown("s"))
        {
            can -= 5;
        }

        if (Input.GetKeyDown("d"))
        {
            can -= 1;
        }

        if (can < 0)
        {
            can = 0;
        }
    }
}
