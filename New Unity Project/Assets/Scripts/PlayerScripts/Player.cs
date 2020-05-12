using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private PlayerParameter pParam;

    private void Start()
    {
        PlayerInit();
    }

    /// <summary>
    /// プレイヤーステータスの初期化
    /// </summary>
    private void PlayerInit()
    {
        if (!pParam) { pParam = (PlayerParameter)ScriptableObject.CreateInstance("PlayerParameter"); }
        ParameterSet(pParam);
    }
}
