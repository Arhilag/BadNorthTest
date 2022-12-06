using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 2.5f;
    
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float horizontal = Input.GetAxis("Mouse X");
            transform.RotateAround(Vector3.zero, Vector3.up, horizontal * _mouseSens * 300 * Time.deltaTime);    
        }
    }
}
