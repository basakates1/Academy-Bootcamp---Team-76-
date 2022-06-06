using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
    private Animator _anim;

    private void Start() {
        _anim=gameObject.GetComponent<Animator>();
    }   

   private void OnTriggerEnter(Collider other) {
       if (other.gameObject.tag=="Animal"){
            StartCoroutine(Trap(other));
        }
   }


   IEnumerator Trap(Collider other){
       _anim.SetBool("isTriggered", true);
        yield return new WaitForSeconds(1);
        _anim.SetBool("isTriggered", false);
            
   }
    
  
   
 
   
}
