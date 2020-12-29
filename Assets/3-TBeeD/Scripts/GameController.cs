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
        [SerializeField] private GameObject paintSurface;
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
            Destroy(paintSurface);
        }

        public void OnLose()
        {
            onLose.Invoke();
            MinigameManager.Instance.PlaySound("LoseGame");
            rightBread.GetComponent<Bread>().Flip();
            Destroy(paintSurface);
        }

        IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(gameLength);
            OnLose();
        }
    }
}
