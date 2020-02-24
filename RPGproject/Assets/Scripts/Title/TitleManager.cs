using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singleton<TitleManager>
{
    [SerializeField]
    private TitleObjct TitleObjectSet;
    public bool IsSelectMenu { get; set; } = false;

    [SerializeField]
    private float afkTime = 0;

    void Update()
    {
        Debug.Log(IsSelectMenu);
        CheakKeyDown();

        if (!IsSelectMenu) { return; }

        afkTime += Time.deltaTime;

        if(afkTime > 10)
        {
            BackMenu();
        }
    }

    /// <summary>
    /// ボタンを押したか
    /// </summary>
    private void CheakKeyDown()
    {
        if (Input.anyKeyDown)
        {
            afkTime = 0;
            if (IsSelectMenu) { return; }

            TitleObjectSet.announceText.enabled = false;
            TitleObjectSet.menuList.SetActive(true);
            TitleObjectSet.menuList.GetComponent<Menu>().ChangeTextSize(0);
            IsSelectMenu = true;
        }
    }

    private void BackMenu()
    {
        TitleObjectSet.menuList.SetActive(false);
        TitleObjectSet.announceText.enabled = true;
        IsSelectMenu = false;
        afkTime = 0;
    }
}
