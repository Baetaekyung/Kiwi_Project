using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Arena_Position : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCam;

    private void Update()
    {

        transform.position = new Vector3(virtualCam.transform.localPosition.x, 
            virtualCam.transform.localPosition.y - 1.4f, 0f);
    }
}
