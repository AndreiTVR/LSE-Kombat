using UnityEngine;

public class FireSphereUlt : BaseUlt 
{
    public int fireSphereDamage = 20;
    public float fireSphereRadius = 25f;

    public override void CastUltimate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, fireSphereRadius);
        foreach (var hitCollider in hitColliders)
        {
            CharacherAttributes enemy = hitCollider.GetComponent<CharacherAttributes>();
            if(enemy != null && enemy != this)
            {
                enemy.TakeDamage(fireSphereDamage);
            }
        }
    }



}