using UnityEngine;
using UnityEngine.Events;

namespace TBeeD
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onWin;
        [SerializeField] private UnityEvent onLose;

        private void Start()
        {
            onStart.Invoke();
        }
        public void OnWin()
        {
            onWin.Invoke();
        }
        public void OnLose()
        {
            onLose.Invoke();
        }
    }
}
