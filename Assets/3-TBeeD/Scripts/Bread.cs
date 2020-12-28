using UnityEngine;

namespace TBeeD
{
    public class Bread : MonoBehaviour
    {
        private Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        internal void Flip()
        {
            animator.SetTrigger("Flip");
        }
    }
}