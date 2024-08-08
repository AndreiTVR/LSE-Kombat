using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class CharacherAttributes : MonoBehaviour
{
    //atribute
 public int hp=100;
 
 public float maxUltimate=100f;

 public float enemyAttackUlt = 10f;
 public float myAttackUlt = 15f;

 public  int FistDamage=5f;
 public int FootDamage=7f;
[SerializeField] BaseBasicAbilities baseabilities;
 
public void FistDealDamage()
{
 
}
public void FootDealDamage()
{

}
public void CastUlt(){

}
public void TakeDamage(int damage)
{
    hp -= damage;
}
}
