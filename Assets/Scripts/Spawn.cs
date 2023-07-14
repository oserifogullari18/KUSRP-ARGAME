using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] balonlar;
    // Start is called before the first frame update
    void Start()
    {
                StartCoroutine(Spawning());

    }
    IEnumerator Spawning(){
        yield return new WaitForSeconds(4);

        for(int i = 0; i<3; i++){

            Instantiate(balonlar[i],SpawnPoints[i].position,Quaternion.identity);

        }
        StartCoroutine(Spawning());

    }

}
