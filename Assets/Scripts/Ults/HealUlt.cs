using UnityEngine;

public class HealUlt : BaseUlt 
{
    public int healAmount = 30;
    private CharacherAttributes player;

    void Start()
    {
        player = GetComponent<CharacherAttributes>();
    }

    public override void CastUltimate()
    {
        player.hp += healAmount;
        if(player.hp > 100) player.hp = 100;
        
    }

}