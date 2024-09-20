using UnityEngine;


namespace LSEKombat.Systems.Input
{
    [CreateAssetMenu(fileName = "InputData", menuName = "LSEKombat/InputActionsScriptableObject", order = 1)]
    public class InputActionsScriptableObject : ScriptableObject
    {
        /*
            This class holds the input keys necessary for the player to do in-game actions
        */

        public KeyCode MoveLeft_Key;
        public KeyCode MoveRight_Key;
        public KeyCode Jump_Key;
        public KeyCode Crouch_Key;


        public KeyCode Punch_Key;
        public KeyCode Kick_Key;


        public KeyCode FirstAbility_Key;
        public KeyCode SecondAbility_Key;
        public KeyCode Ultimate_Key;
    }
}
