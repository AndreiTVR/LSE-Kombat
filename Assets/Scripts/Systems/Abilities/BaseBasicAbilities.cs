using System.Collections;
using System.Collections.Generic;
using LSEKombat.Systems.Input;
using UnityEngine;



public class BaseBasicAbilities : MonoBehaviour
{
     /* -------------------------------------------------------           */
    InputHandler inputHandler;
    
    [SerializeField] GameObject Player;
    
   
 

    /* -------------------------------------------------------     cooldown          */
    public float CooldownAbility=0f;
    public bool isOnCooldown=false;
     /* -------------------------------------------------------     Ability               */
    public Transform initialPosition;
    public GameObject abilityPreFab;
    public float abilitySpeed = 10.0f;

private void Awake(){
     /* -------------------------------------------------------    Subscribe to inputHandler           */
        inputHandler = Player.GetComponent<InputHandler>();  
   
    }
     private void Start()
        {
             
          inputHandler.OnCastFirstUpdate += CastFirstAbility;
        }
    private void CastFirstAbility(bool CastFirst){
       if (CastFirst && !isOnCooldown)
        {
             /* -------------------------------------------------------    Debug           */
            Debug.Log("Casting first ability!");
             /* -------------------------------------------------------               */
            var abilityF = Instantiate(abilityPreFab, initialPosition.position, initialPosition.rotation );
            float facingDirection = transform.localScale.x < 0 ? -1 : 1;
            Debug.Log(facingDirection);
              abilityF.GetComponent<Rigidbody2D>().velocity = new Vector2(facingDirection * abilitySpeed, 0);
             

            StartCoroutine(AbilityCooldown());
        }
        
        else if (CastFirst && isOnCooldown)
        {
             /* -------------------------------------------------------     Debug          */
            Debug.Log("Ability is on cooldown.");
        }
    }

     private IEnumerator AbilityCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(CooldownAbility);  
        isOnCooldown = false;
    }
    
 
}
