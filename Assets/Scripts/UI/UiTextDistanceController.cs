using Cubs;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UiTextDistanceController : MonoBehaviour
    {
        [SerializeField] private MoveCubesManager _moveCubesManager;
        [SerializeField] private TextMeshProUGUI _textDistance;

        private string _textDescription = "Расстояние между сферами: ";

        private void Update()
        {
            int roundedDistance = Mathf.FloorToInt(_moveCubesManager.DistanceCubes);
            _textDistance.text = $"{_textDescription}{roundedDistance}м";
        }
    }
}