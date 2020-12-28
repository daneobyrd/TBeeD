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
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                timer = 0f;
                StartCoroutine(OnExit());
            }
        }

        IEnumerator OnEnter()
        {
            yield return null;
        }

        IEnumerator OnExit()
        {
            rightBread.Flip();

            while (transform.position.x > exitPositionX)
            {
                transform.Translate(Vector2.left * moveSpeed);
                yield return null;
            }

            transform.position = new Vector2(enterPositionX, transform.position.y);

            while (transform.position.x >= 0f)
            {
                transform.Translate(Vector2.left * moveSpeed);
                yield return null;
            }

            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }
    }
}