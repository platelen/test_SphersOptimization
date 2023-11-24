using Cubs;
using Spawn;
using UnityEngine;

namespace Scenes
{
    public class ScenesLoadManager : MonoBehaviour
    {
        [SerializeField] private SpawnFigures _spawnFigures;
        [SerializeField] private MoveCubesManager _moveCubesManager;
        [SerializeField] private float _activatedSphere = 2f;
        [SerializeField] private float _loadNextScene = 1f;

        private void Update()
        {
            EnabledDisabledSphere();
        }

        private void EnabledDisabledSphere()
        {
            if (_moveCubesManager.DistanceCubes < _activatedSphere)
            {
                foreach (var sphere in _spawnFigures.Spheres)
                {
                    sphere.SetActive(true);
                }
            }
            else
            {
                foreach (var sphere in _spawnFigures.Spheres)
                {
                    sphere.SetActive(false);
                }
            }
        }
    }
}