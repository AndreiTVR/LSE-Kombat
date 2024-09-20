using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAbilityPoisonEffect : MonoBehaviour
{
    
  void Update(){
    
  }
    void OnTriggerEnter2D(Collider2D other){
        CharacherAttributes characherAttributes = other.GetComponent<CharacherAttributes>();
      characherAttributes.PoisonEffect();
       
        
      
        Destroy(gameObject);

    }
}
