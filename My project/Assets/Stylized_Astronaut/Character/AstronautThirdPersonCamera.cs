using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AstronautThirdPersonCamera
{

  public class AstronautThirdPersonCamera : MonoBehaviour
  {

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, distance, 0);
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
  }
}
