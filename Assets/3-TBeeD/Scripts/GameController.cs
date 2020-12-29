using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace TBeeD
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onStart;

        private float gameLength = 4.8f;

        private void Start()
        {
            onStart.Invoke();
            MinigameManager.Instance.minigame.gameWin = false;
            StartCoroutine(GameTimer());
        }
        public void OnWin()
        {
            StopAllCoroutines();
            MinigameManager.Instance.PlaySound("WinGame");
            MinigameManager.Instance.minigame.gameWin = true;
        }
        public void OnLose()
        {
            MinigameManager.Instance.PlaySound("LoseGame");
        }

        IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(gameLength);
            OnLose();
        }
    }
}
