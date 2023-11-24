using System.Collections.Generic;
using UnityEngine;

namespace Spawn
{
    public class SpawnFigures : MonoBehaviour
    {
        [SerializeField] private GameObject _spawnParent;

        [Header("Cubes Spawn")] [SerializeField]
        private GameObject _cubeRed;

        [SerializeField] private GameObject _cubeGreen;
        [SerializeField] private Transform _transformRed;
        [SerializeField] private Transform _transformGreen;

        [Header("Spheres Spawn")] [SerializeField]
        private GameObject _spherePrefab;

        [SerializeField] private int _numberOfSpheres = 10;
        [SerializeField] private float _radius = 5f;
        [SerializeField] private float _centerX = 0f;
        [SerializeField] private float _centerZ = 0f;
        [SerializeField] private float _avoidRadius = 2f;

        private List<GameObject> _spheres = new List<GameObject>();

        private void Awake()
        {
            SpawnedSpheres();
            SpawnedCubes();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new Vector3(_centerX, 0f, _centerZ), _radius);

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(new Vector3(_centerX, 0f, _centerZ), _avoidRadius);
        }

        private void SpawnedSpheres()
        {
            float angleInterval = 360f / _numberOfSpheres;

            for (int i = 0; i < _numberOfSpheres; i++)
            {
                float angle = i * angleInterval * Mathf.Deg2Rad;
                Vector3 spawnPosition = GetPointOnCircle(_radius, angle, _centerX, _centerZ);
                Instantiate(_spherePrefab, spawnPosition, Quaternion.identity, _spawnParent.transform);

                _spheres.Add(_spherePrefab);
            }

            foreach (var spheres in _spheres)
            {
                spheres.SetActive(false);
            }
        }

        private Vector3 GetPointOnCircle(float radius, float angle, float centerX, float centerZ)
        {
            float x = centerX + radius * Mathf.Cos(angle);
            float z = centerZ + radius * Mathf.Sin(angle);

            return new Vector3(x, 0f, z);
        }

        private void SpawnedCubes()
        {
            Quaternion rotationGreen = _transformGreen.rotation;
            Instantiate(_cubeGreen, _transformGreen.position, rotationGreen, _spawnParent.transform);

            Quaternion rotationRed = _transformRed.rotation * Quaternion.Euler(0f, 180f, 0f);
            Instantiate(_cubeRed, _transformRed.position, rotationRed, _spawnParent.transform);
        }
    }
}