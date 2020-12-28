using UnityEngine;
using UnityEngine.UI;

namespace TBeeD
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private GameData gameData;
        [SerializeField] private RectTransform plateGroup;
        [SerializeField] private GameObject platePrefab;
        private RectTransform[] plates;

        void Awake()
        {
            plates = new RectTransform[gameData.PlateCount];

            for (int i = 0; i < gameData.PlateCount; i++)
            {
                RectTransform plate = Instantiate(platePrefab, plateGroup).GetComponent<RectTransform>();
                plate.GetComponent<Image>().color = Color.black;
                plates[i] = plate;
            }
        }

        void Start()
        {
            UpdatePlates();
        }

        internal void UpdatePlates()
        {
            for (int i = 0; i < gameData.PlateCount; i++)
            {
                if (i < gameData.PlatesCompleted)
                {
                    plateGroup.GetChild(i).GetComponent<Image>().color = Color.white;
                }
            }
        }
    }
}
