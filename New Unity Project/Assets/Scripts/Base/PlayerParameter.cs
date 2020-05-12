using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu( menuName ="ScriptableObject/CreatePlayerParameter", fileName ="PlayerParameter")]
public class PlayerParameter : ScriptableObject
{
    public string characterName;
    public int level = 1;
    public int exp = 100;
    public int maxHp;
    public int hp;
    public int maxAtk;
    public int atk;
    public int maxAtk_m;
    public int atk_m;
    public int maxDef;
    public int def;
    public int maxDef_m;
    public int def_m;
    public int maxAgility;
    public int agility;
}
