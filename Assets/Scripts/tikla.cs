using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tikla : MonoBehaviour
{
    //public GameObject gemPrefab;
    public bool touched;
    private int numberOfGemsCollected = 0;

    public float collectionTime = 1f;
    public float effectTime = 0.8f;

    void Start(){
        StarHitManager.Instance.StopStarHit();
        GemCollectedManager.Instance.HideGemCollected();
        gembar.Instance.EnableButton();
        gembar2.Instance.Enable2Button();

    }

    void Update(){
        Triggered();
    }

    private void Triggered()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touched=true;
                Vector3 touchPosition = touch.position;
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

               if (Physics.Raycast(ray, out hit))
            {
                        if(touched){
                            touched=false;
                            numberOfGemsCollected++;
                            if(hit.collider.CompareTag("diamond")){
                                gembar.Instance.UpdateGemCount(numberOfGemsCollected);
                            }
                            if(hit.collider.CompareTag("diamond2")){
                                gembar2.Instance.UpdateGem2Count(numberOfGemsCollected);
                            }

                            Debug.Log(numberOfGemsCollected);
                        }
                        
                        Destroy(hit.collider.gameObject);
                        CollectGem(hit.point);
            }
            }
        }
    }
    private void CollectGem(Vector3 position){

    GemCollectedManager.Instance.ShowGemCollected(1f);
    Invoke("DisableText", collectionTime);

    StarHitManager.Instance.PlayStarHit(position);
    Invoke("DisableParticleSystem", effectTime);
    }

    private void DisableParticleSystem(){
        StarHitManager.Instance.StopStarHit();
    }

    private void DisableText(){
        GemCollectedManager.Instance.HideGemCollected();
    }
}
