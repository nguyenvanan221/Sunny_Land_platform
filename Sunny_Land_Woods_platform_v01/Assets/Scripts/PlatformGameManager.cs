using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformGameManager : MonoBehaviour
{
    public static PlatformGameManager sharedInstance = null;
    public PlatformCameraManager cameraManager;

    public SpawnPoint playerSpawnPoint;

    private void Awake()
    {
        //singleton
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();
            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

}
