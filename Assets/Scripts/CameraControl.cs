
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothness = 0.125f;
    [SerializeField]
    private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 dersiredPosition = target.position + offset;
        Vector3 smoothPosition = 
           Vector3.Lerp(transform.position, dersiredPosition,smoothness* Time.deltaTime);
        transform.position = smoothPosition;        
    }
}
