using UnityEngine;

namespace TBeeD
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Bread rightBread;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                rightBread.Flip();
            }
        }
    }
}
