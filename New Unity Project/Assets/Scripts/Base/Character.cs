using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected string characterName;
    protected int maxHp;
    protected int hp;
    protected int maxAtk;
    protected int atk;
    protected int maxAtk_m;
    protected int atk_m;
    protected int maxDef;
    protected int def;
    protected int maxDef_m;
    protected int def_m;
    protected int maxAgility;
    protected int agility;

    /// <summary>
    /// HP回復処理(現状すべての回復行動を処理)
    /// </summary>
    /// <param name="healPoint"></param>
    public void HealHP(int healPoint) 
    {
        if(hp + healPoint > maxHp) { hp = maxHp; }
        else { hp += healPoint; }
    }

    /// <summary>
    /// ダメージ処理(現状すべてのダメージを処理)
    /// </summary>
    /// <param name="damagePoint"></param>
    public void DamageHP(int damagePoint)
    {
        if(hp - damagePoint < 0) { hp = 0; }
        else { hp -= damagePoint; }
    }

    /// <summary>
    /// プレイヤーのパラメーターを設定
    /// </summary>
    /// <param name="pp"></param>
    public void ParameterSet(PlayerParameter pp)
    {
        characterName = pp.characterName;
        maxHp = pp.maxHp;
        hp = pp.hp;
        maxAtk = pp.maxAtk;
        atk = pp.atk;
        maxAtk_m = pp.maxAtk_m;
        atk_m = pp.atk_m;
        maxDef = pp.maxDef;
        def = pp.def;
        maxDef_m = pp.maxDef_m;
        def_m = pp.def_m;
        maxAgility = pp.maxAgility;
        agility = pp.agility;
    }
}
