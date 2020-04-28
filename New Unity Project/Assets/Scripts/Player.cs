using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private PlayerParameter pParam;

    private void Start()
    {
        ParameterSet(pParam);
        Debug.Log(hp);
    }
}
