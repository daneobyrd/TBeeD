using UnityEngine;

namespace TBeeD
{
    [CreateAssetMenu(fileName = "New Game Data", menuName = "TBeeD/Game Data")]
    public class GameData : ScriptableObject
    {
        public int PlateCount;
        public int PlatesCompleted { get; set; }

        void OnEnable()
        {
            PlatesCompleted = 0;
        }
    }
}
