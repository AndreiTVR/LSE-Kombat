using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacherAttributes : MonoBehaviour
{
    //atribute
 public float hp=100;
 
 public float maxUltimate=100f;

 public float enemyAttackUltCharge = 10f;
 public float myAttackUltCharge = 15f;

 public  int FistDamage=5;
 public  int FootDamage=7;

 [SerializeField] private float poisonDuration = 4.0f;
 [SerializeField] private bool isPoisoned = false;
 [SerializeField] private float poisonDmg = 5.0f;
 

    public void FistDealDamage()
{
 
}
public void FootDealDamage()
{

}
public void CastUlt(){

}
public void FirstAbilityTakeDamage(float damage){
    hp -= damage;
}
private void PoisonDamage(float dmg){
    hp-=dmg;
}
public void PoisonEffect(){
    if(isPoisoned == false){
       
        StartCoroutine(PoisonEffectTime());
    }
}
private IEnumerator PoisonEffectTime(){
     isPoisoned = true;
        float time = 0;

        while (time < poisonDuration)
        {
            hp-=poisonDmg;
           
             Debug.Log("Poison damage applied. HP: " + hp);
           
            yield return new WaitForSeconds(1.0f);

            time += 1.0f; 
        }

        isPoisoned = false;  
}
public void TakeDamage(int damage)
{
    hp -= damage;
}
}
