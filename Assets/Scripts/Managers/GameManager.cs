using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public GameManager Instance => _instance;

        private void Start()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(this);
            }

            CallMethods();
        }

        private void CallMethods()
        {
            
        }
    }
}