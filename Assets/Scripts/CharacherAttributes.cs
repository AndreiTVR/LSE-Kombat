using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacherAttributes : MonoBehaviour
{
    //atribute
 public int hp=100;
 
 public float maxUltimate=100f;

 public float enemyAttackUltCharge = 10f;
 public float myAttackUltCharge = 15f;

 public  int FistDamage=5;
 public  int FootDamage=7;
 //public int fireSphereDamage = 20;
 //public float fireSphereRange = 100;
 //public float invincibilityDuration = 5f;
 // bool isInvincible = false;
[SerializeField] BaseBasicAbilities baseabilities;
    public void FistDealDamage()
{
 
}
public void FootDealDamage()
{

}
public void CastUlt(){

}
/**public void CastFireSphereUlt() // Da dmg tuturor inamicilor in raza fireSphereRange
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, fireSphereRange);
        foreach (var hitCollider in hitColliders)
        {
            CharacherAttributes enemy = hitCollider.GetComponent<CharacherAttributes>();
            if (enemy != null && enemy != this)
            {
                enemy.TakeDamage(fireSphereDamage);
            }
        }
    }
*/
/**public void CastInvincibilityUlt()
    {
        StartCoroutine(InvincibilityRoutine(invincibilityDuration)); // x secunde de invincibilitate
    }

    IEnumerator InvincibilityRoutine(float duration)
    {
        
        isInvincible = true;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            yield return null;
            Debug.Log(timer);
        }

        isInvincible = false;
        
    }
*/
public void TakeDamage(int damage)
{
    hp -= damage;
}
}
