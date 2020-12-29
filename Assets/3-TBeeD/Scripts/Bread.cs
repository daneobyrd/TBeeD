using UnityEngine;

namespace TBeeD
{
    public class Bread : MonoBehaviour
    {
        public bool CompletedFlip { get; set; }

        private Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        internal void Flip()
        {
            animator.SetTrigger("Flip");
        }

        internal void Unflip()
        {
            animator.SetTrigger("Unflip");
        }

        internal void OnCompleteFlip()
        {
            CompletedFlip = true;
        }
    }
}