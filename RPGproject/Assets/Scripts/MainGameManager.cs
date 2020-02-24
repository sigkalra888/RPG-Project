using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : Singleton<MainGameManager>
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private string sceneName;

    void Start()
    {
        ChangeCameraProjection(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void ChangeCameraProjection(string name)
    {
        if (name == "CharacterSelect")
        {
            mainCamera.orthographic = true;
        }
    }
}
