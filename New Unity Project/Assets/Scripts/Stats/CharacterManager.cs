using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

public class CharacterManager : Singleton<CharacterManager>
{

    [SerializeField,Tooltip("初期化用パラメーター")]
    private ParamData defaultParam;
    [SerializeField]
    private GameObject obj;
    void Update()
    {
    }

    /// <summary>
    /// キャラクターの作成とステータスの初期化
    /// </summary>
    /// <param name="param"></param>
    public void CreateCharacter()
    {
        GameObject o = Instantiate(obj);
        o.name = "Player";
        o.transform.localPosition = new Vector3(5,0,0);
        o.AddComponent<TestParam>().myParam = defaultParam.param;
    }
}
