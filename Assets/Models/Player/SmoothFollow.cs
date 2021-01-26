using UnityEngine;
using static UnityEngine.Screen;

public class SmoothFollow : MonoBehaviour
{
    public float distance = 6.0f;
    public float height = 2.0f;
    public float heightDamping = 10.0f;
    //public float rotationDamping = 0.0f;
    public float sensitivity = 10f;
    public Transform target;

    private Vector3 _mousePos;
    private float _cameraRotation = 0f;

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = Input.mousePosition;
            _cameraRotation = ((_mousePos.x - (width / 2)) / width)*sensitivity;
            print(_cameraRotation);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _cameraRotation = 0f;
        }
        
        // Early out if we don't have a target
        if (!target)
        {
            return;
        }

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        //float currentRotationAngle = i;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, _cameraRotation, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        var pos = transform.position;
        pos = target.position - currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;
        transform.position = pos;

        // Always look at the target
        transform.LookAt(target);
    }
}