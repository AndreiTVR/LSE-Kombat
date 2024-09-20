
using LSEKombat.Systems.Movement;
using UnityEngine;


public class FirstAbilityStunEffect : MonoBehaviour
{
     
 [SerializeField] private int damage = 10;
    
  void Update(){
    
  }
    void OnTriggerEnter2D(Collider2D other){
        CharacherAttributes characherAttributes = other.GetComponent<CharacherAttributes>();
      
        characherAttributes.FirstAbilityTakeDamage(damage);
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
       playerMovement.StunEffect();
        Destroy(gameObject);

    }
    


   
}
