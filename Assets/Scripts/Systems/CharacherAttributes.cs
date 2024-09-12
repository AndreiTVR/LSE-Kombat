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
