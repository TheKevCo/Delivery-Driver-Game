using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
   [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
   [SerializeField] Color32 hasNoPackageColor = new Color32 (1, 1, 1, 1);
   [SerializeField] float delayDestroy = 0f;
   bool hasPackage;
   
   SpriteRenderer spriteRenderer;

   void Start() 
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   void OnCollisionEnter2D(Collision2D other) 
   {
      if (other.gameObject.tag == "Customer" && hasPackage)
      {
         Debug.Log("Packaged dropped off to customer!");
         hasPackage = false;
         spriteRenderer.color = hasNoPackageColor;
      }       
   }
   
   void OnTriggerEnter2D(Collider2D other) 
   {
      if (other.tag == "Package" && hasPackage == false)
      {
         Debug.Log("Package picked up!");
         hasPackage = true;
         spriteRenderer.color = hasPackageColor;
         Destroy(other.gameObject, delayDestroy);
      }
   }
}
