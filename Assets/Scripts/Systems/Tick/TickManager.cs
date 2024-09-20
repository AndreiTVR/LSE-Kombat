using UnityEngine;

namespace LSEKombat.Systems.Tick
{
    public class TickManager : MonoBehaviour
    {
        /*
            This class is a Singleton that invokes a "Tick" every "TickTime" seconds.
        */

        public static TickManager Instance = null;

        [SerializeField][Range(0.1f , 60)][Tooltip("How often (in seconds) do we call a Tick event?")] private float TickTime;

        private float m_currentTickTime;

        //event delegates
        public delegate void TickInvokeHandler ();

        //events
        public event TickInvokeHandler OnTickInvoke;



        private void Awake() 
        {
            if(Instance == null)
            {
                Instance = this;
            }else
            {
                Destroy(this.gameObject);
            }
        }   

        // Start is called before the first frame update
        private void Start()
        {
            m_currentTickTime = 0;
        }

        // Update is called once per frame
        private void Update()
        {
            m_currentTickTime += Time.deltaTime;

            if(m_currentTickTime >= TickTime)
            {
                OnTickInvoke?.Invoke();
                m_currentTickTime = 0;
            }
        }
    }
}
