using UnityEngine;

namespace Cubs
{
    public class MoveCubesManager : MonoBehaviour
    {
        [SerializeField] private GameObject _cubeRed;
        [SerializeField] private GameObject _cubeGreen;
        [SerializeField] private float _moveSpeed = 5f;

        private float _distanceCubes;

        public float DistanceCubes => _distanceCubes;

        private void Start()
        {
            _cubeRed = GameObject.Find("Cube_Red(Clone)");
            _cubeGreen = GameObject.Find("Cube_Green(Clone)");
        }

        private void Update()
        {
            MoveCube(_cubeRed, "Horizontal_Red", "Vertical_Red");
            MoveCube(_cubeGreen, "Horizontal_Green", "Vertical_Green");

            float distance = Vector3.Distance(_cubeRed.transform.position, _cubeGreen.transform.position);
            _distanceCubes = distance;
        }

        private void MoveCube(GameObject cube, string horizontalInput, string verticalInput)
        {
            float horizontal = Input.GetAxis(horizontalInput);
            float vertical = Input.GetAxis(verticalInput);

            Vector3 movement = new Vector3(horizontal, 0f, vertical) * _moveSpeed * Time.deltaTime;
            cube.transform.Translate(movement, Space.World);
        }
    }
}