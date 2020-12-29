using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace TBeeD
{
    public class GameController : MonoBehaviour
    {
        public int TotalSplotches { get; set; }
        public int SplotchesCovered { get; set; }

        [SerializeField] private UnityEvent onStart;
        [SerializeField] private UnityEvent onLose;
        [SerializeField] private SpriteRenderer rightBread;
        private bool callWin = false;

        private float gameLength = 4.8f;

        private void Start()
        {
            onStart.Invoke();
            MinigameManager.Instance.minigame.gameWin = false;
            StartCoroutine(GameTimer());
        }

        void Update()
        {
            if (SplotchesCovered == TotalSplotches)
            {
                if (!callWin)
                {
                    OnWin();
                    callWin = true;
                }
            }
        }

        public void OnWin()
        {
            StopAllCoroutines();
            MinigameManager.Instance.PlaySound("WinGame");
            MinigameManager.Instance.minigame.gameWin = true;
            rightBread.sortingOrder = 4;
            rightBread.GetComponent<Bread>().Flip();
        }

        public void OnLose()
        {
            onLose.Invoke();
            MinigameManager.Instance.PlaySound("LoseGame");
            rightBread.GetComponent<Bread>().Flip();
        }

        IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(gameLength);
            OnLose();
        }
    }
}
