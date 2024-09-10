using UnityEngine;

public class HealUlt : BaseUlt 
{
    public int healAmount = 30;
    private CharacterAttributes player;

    void Start()
    {
        player = GetComponent<CharacterAttributes>();
    }

    public override void CastUltimate()
    {
        player.hp += healAmount;
        if(player.hp > 100) player.hp = 100;
        
    }

}