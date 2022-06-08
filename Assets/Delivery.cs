using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(141,0,250,255);
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);
    [SerializeField] float destroyDelay = 0.2f;
    //[SerializeField] Sprite carModel;

    bool hasPackage = false;
    
    SpriteRenderer spriteRenderer;
    
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("Trigger Ouch!");

        if(other.tag == "Package" && !hasPackage)
        {
            //Debug.Log("Package picked up");
            hasPackage = true;            
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        } 

        if(other.tag == "Customer" && hasPackage)
        {
            //Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            //spriteRenderer.sprite = carModel;
        } 

    }
}
