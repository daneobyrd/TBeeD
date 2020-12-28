using UnityEngine;
using System.Collections;

namespace TBeeD
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private Bread rightBread;
        [SerializeField] private float duration = 0f;
        [SerializeField] private float moveSpeed = 0f;
        [SerializeField] private float enterPositionX = 0f;
        [SerializeField] private float exitPositionX = 0f;
        private float timer;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                rightBread.Flip();
            }
        }

        IEnumerator OnEnter()
        {
            yield return null;
        }

        IEnumerator OnExit()
        {
            while (transform.position.x > exitPositionX)
            {
                transform.Translate(Vector2.left * moveSpeed);
            }

            transform.position = new Vector2(enterPositionX, transform.position.y);
            yield return null;
        }
    }
}