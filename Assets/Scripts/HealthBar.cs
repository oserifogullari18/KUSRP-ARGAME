using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
	public Transform cam;
    public GameObject a;
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void TakeDamage(int damage)
    {
        slider.value -= damage;
        if (slider.value <= 0)
        {
        }
    }


     /*void LateUpdate()
     {
	 	transform.LookAt(transform.position + cam.forward);
     }
     */
    //Deniz burayı telefondan dene sonra herekirse silelim
    //Saçmalaşıyor uzuyor ve kısalıyor.
}
