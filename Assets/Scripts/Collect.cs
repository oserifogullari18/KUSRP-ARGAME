using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collect : MonoBehaviour
{
    public TMP_Text GemCollected;
    public ParticleSystem starHit;
    public float collectionTime = 2f; // Time in seconds for gem collection animation
    public float effectTime = 0.8f;

    private bool isCollected = false;
    private bool effectPlayed = false;

    public GemManager gemManager;

    void Start(){
        starHit.Stop();
        GemCollected.enabled = false;
    }

    void Update(){
        Triggered();
    }

    private void Triggered()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

               if (Physics.Raycast(ray, out hit))
            {
                    if(hit.collider.gameObject!=null && hit.collider.CompareTag("gem")){
                        Destroy(hit.collider.gameObject);
                        CollectGem(hit.collider.gameObject);
                        gemManager.CollectGem();
                    }
            }
        }
    }
}
private void CollectGem(GameObject gem){

    GemCollected.enabled = true;
    Invoke("DisableText", collectionTime);
    
    starHit.Play();
    Invoke("DisableParticleSystem", effectTime);
}

private void DisableParticleSystem(){
    starHit.Stop();
}

private void DisableText(){
    GemCollected.enabled=false;
}

    /*private void ShowCollectedText(Vector3 position)
    {
        if (GemCollected != null)
        {
            GemCollected.gameObject.SetActive(true);

            GameObject collectedText=GemCollected.gameObject;

            // Play the text animation (e.g., fade-in animation)
            Animation CollectedAnimation = collectedText.GetComponent<Animation>();

            if (CollectedAnimation != null)
            {
                CollectedAnimation.Play();

                // Disable the text object after the specified time (collectionTime)
                Destroy(collectedText, collectionTime);
            }
        }
    }

    private void PlayCollectionEffect(Vector3 position)
    {
        if (starHit != null)
        {
            starHit.gameObject.SetActive(true);
            Destroy(starHit.gameObject, effectTime);
        }
    }*/
}

