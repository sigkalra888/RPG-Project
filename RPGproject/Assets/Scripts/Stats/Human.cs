using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [System.Serializable]
    public struct Parameter
    {
        public int HP;         //体力値
        public float STA;      //持久力
        public int ATK;        //攻撃力
        public int DEF;        //防御力
        public int DEX;        //素早さ
        public int jumpPow;    //跳躍力
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
