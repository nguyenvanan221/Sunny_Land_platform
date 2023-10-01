using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformCameraManager : MonoBehaviour
{
    public static PlatformCameraManager sharedInstance = null;

    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }

        GameObject virualCameraOb = GameObject.FindWithTag("VirtualCamera");
        virtualCamera = virualCameraOb.GetComponent<CinemachineVirtualCamera>();
    }
}
