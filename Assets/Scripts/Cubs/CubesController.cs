using UnityEngine;

namespace Cubs
{
    public class CubesController : MonoBehaviour
    {
        public float _moveSpeed = 5f;

        private void Update()
        {
            if (gameObject.name == "Cube_Red(Clone)")
            {
                MoveRedCube();
            }
            else if (gameObject.name == "Cube_Green(Clone)")
            {
                MoveGreenCube();
            }
        }

        private void MoveRedCube()
        {
            float horizontal = Input.GetAxis("Horizontal_Red");
            float vertical = Input.GetAxis("Vertical_Red");

            Vector3 movement = new Vector3(horizontal, 0f, vertical) * _moveSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }

        private void MoveGreenCube()
        {
            float horizontal = Input.GetAxis("Horizontal_Green");
            float vertical = Input.GetAxis("Vertical_Green");

            Vector3 movement = new Vector3(horizontal, 0f, vertical) * _moveSpeed * Time.deltaTime;
            transform.Translate(movement, Space.World);
        }
    }
    
}
