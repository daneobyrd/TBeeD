using UnityEngine;
using System.Collections;

namespace TBeeD
{
    public class Plate : MonoBehaviour
    {
        [SerializeField] private Bread rightBread;
        [SerializeField] private float rightBreadOffsetX = 0f;
        [SerializeField] private float moveSpeed = 0f;
        [SerializeField] private float enterPositionX = 0f;
        [SerializeField] private float exitPositionX = 0f;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                rightBread.Flip();
            }

            if (rightBread.CompletedFlip)
            {
                StartCoroutine(OnExit());
            }
        }

        IEnumerator OnEnter()
        {
            rightBread.transform.localPosition = new Vector3(rightBreadOffsetX, rightBread.transform.localPosition.y);

            while (transform.position.x >= 0f)
            {
                transform.Translate(Vector2.left * moveSpeed);
                yield return null;
            }

            transform.position = new Vector3(0f, transform.position.y, transform.position.z);
        }

        IEnumerator OnExit()
        {
            rightBread.CompletedFlip = false;

            while (transform.position.x > exitPositionX)
            {
                transform.Translate(Vector2.left * moveSpeed);
                yield return null;
            }

            transform.position = new Vector2(enterPositionX, transform.position.y);
            rightBread.Unflip();
            StartCoroutine(OnEnter());
        }
    }
}