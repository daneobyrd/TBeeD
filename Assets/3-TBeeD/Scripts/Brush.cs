using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TBeeD
{
    public class Brush : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Transform bee;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            bee = FindObjectOfType<BeeController>().transform;
        }

        void Update()
        {
            spriteRenderer.transform.position = bee.position;
        }

        void OnCollisionStay2D(Collision2D other)
        {
            spriteRenderer.enabled = true;
        }


    }
}