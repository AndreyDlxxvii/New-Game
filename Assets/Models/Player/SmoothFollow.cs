using UnityEngine;
using static UnityEngine.Screen;

public class SmoothFollow : MonoBehaviour
{
    public float Distance = 6.0f;
    public float Height = 2.0f;
    public float HeightDamping = 10.0f;
    //public float rotationDamping = 0.0f;
    public float Sensitivity = 10f;
    public Transform Target;

    private Vector3 _mousePos;
    private float _cameraRotation = 0f;

    private void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = Input.mousePosition;
            _cameraRotation = ((_mousePos.x - (width / 2)) / width)*Sensitivity;
            print(_cameraRotation);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            _cameraRotation = 0f;
        }
        
        // Early out if we don't have a Target
        if (!Target)
        {
            return;
        }

        // Calculate the current rotation angles
        float wantedRotationAngle = Target.eulerAngles.y;
        float wantedHeight = Target.position.y + Height;

        //float currentRotationAngle = i;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        //currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the Height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, _cameraRotation, 0);

        // Set the position of the camera on the x-z plane to:
        // Distance meters behind the Target
        var pos = transform.position;
        pos = Target.position - currentRotation * Vector3.forward * Distance;
        pos.y = currentHeight;
        transform.position = pos;

        // Always look at the Target
        transform.LookAt(Target);
    }
}