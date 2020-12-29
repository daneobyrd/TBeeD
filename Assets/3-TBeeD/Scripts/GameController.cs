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

        [SerializeField] private float gameLength = 4.8f;

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
            MinigameManager.Instance.minigame.gameWin = true;
        }

        public void OnLose()
        {
            onLose.Invoke();
            MinigameManager.Instance.PlaySound("LoseGame");
            rightBread.GetComponent<Bread>().Flip();
            Destroy(FindObjectOfType<Brush>().gameObject);
            Destroy(FindObjectOfType<BeeController>().gameObject);
            Destroy(paintSurface);
        }

        private void OnWinAfterTimer()
        {
            MinigameManager.Instance.PlaySound("WinGame");
            rightBread.sortingOrder = 4;
            rightBread.GetComponent<Bread>().Flip();
            Destroy(FindObjectOfType<Brush>().gameObject);
            Destroy(FindObjectOfType<BeeController>().gameObject);
            Destroy(paintSurface);
        }

        IEnumerator GameTimer()
        {
            yield return new WaitForSeconds(gameLength);
            if (MinigameManager.Instance.minigame.gameWin)
            {
                OnWinAfterTimer();
            }
            else
            {
                OnLose();
            }
        }
    }
}
