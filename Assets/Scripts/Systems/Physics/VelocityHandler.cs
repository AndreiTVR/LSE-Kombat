using UnityEngine;

namespace LSEKombat.Systems.Physics
{
    public class VelocityHandler : MonoBehaviour
    {
        //debug
        private Vector2 m_velocityVector;

        /*
            This class takes velocities from other scripts and applies them to the GameObject with transform.Translate();
        */

        // Start is called before the first frame update
        private void Start()
        {
            m_velocityVector = new Vector2();
        }

        // Update is called once per frame
        private void Update()
        {
            MoveCurrentTransform();
        }

        private void MoveCurrentTransform()
        {
            transform.Translate(m_velocityVector * Time.deltaTime);

            //reset velocity after applying to prevent bugs
            m_velocityVector = Vector2.zero;
        }

        public void AddVelocity(Vector2 VelocityVector)
        {
            m_velocityVector += VelocityVector;
        }

    }

}
