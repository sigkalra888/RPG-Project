using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : Singleton<MainGameManager>
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private string sceneName;

    private bool[] isCreateCharacter = new bool[4];

    /// <summary>
    /// キャラクターが作成されているかの有無
    /// </summary>
    /// <param name="index">キャラクター番号</param>
    /// <param name="isChange">boolの変更をするか否か</param>
    /// <param name="changedBool">変更後のbool値</param>
    /// <returns></returns>
    public bool IsCreateCharacter(int index, bool isChange = true, bool changedBool = true)
    {
        if (isChange) { isCreateCharacter[index] = changedBool; }
        return isCreateCharacter[index];
    }

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
