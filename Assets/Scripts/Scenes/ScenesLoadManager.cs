using Cubs;
using Spawn;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SwitchedScene();
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

        private void SwitchedScene()
        {
            if (_moveCubesManager.DistanceCubes < _loadNextScene)
            {
                SceneManager.LoadScene("Particles");
            }
        }
    }
}