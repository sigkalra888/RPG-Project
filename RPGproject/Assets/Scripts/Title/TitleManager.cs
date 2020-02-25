using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleManager : Singleton<TitleManager>
{
    private TitleObjct titleObjectSet;

    [SerializeField]
    private GameObject[] Canvases = new GameObject[2];

    public bool IsSelectMenu { get; set; } = false;

    [SerializeField]
    private float afkTime = 0;

    public enum MenuMode
    {
        StartScreen = 0,
        Continue,
        NewGame,
        Setting,
        Exit
    }

    [HideInInspector]
    public MenuMode menuMode;

    protected override void Awake()
    {
        titleObjectSet = Canvases[0].GetComponent<TitleObjct>();
    }

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuMode == MenuMode.StartScreen) { CheakKeyDownToStartScreen(); return; }
            if(Canvases[0].activeSelf && titleObjectSet.menuList.activeSelf) 
            {
                BackMenu();
                return;
            }
            Canvases[1].SetActive(false);
            Canvases[0].SetActive(true);
        }

        CheakKeyDownToStartScreen();
    }

    /// <summary>
    /// スタート画面でボタンを押したか
    /// </summary>
    private void CheakKeyDownToStartScreen()
    {
        if (Input.anyKeyDown)
        {
            afkTime = 0;
            if (IsSelectMenu || menuMode == MenuMode.NewGame || menuMode == MenuMode.Continue) { return; }

            titleObjectSet.announceText.enabled = false;
            titleObjectSet.menuList.SetActive(true);
            titleObjectSet.menuList.GetComponent<Menu>().ChangeTextSize(1);
            IsSelectMenu = true;
        }
    }

    /// <summary>
    /// Menuを閉じて待機画面に戻る
    /// </summary>
    private void BackMenu()
    {
        titleObjectSet.menuList.SetActive(false);
        titleObjectSet.announceText.enabled = true;
        IsSelectMenu = false;
        menuMode = MenuMode.StartScreen;
        afkTime = 0;
    }

    /// <summary>
    /// Canvasの切り替え
    /// </summary>
    /// <param name="index">MenuMode</param>
    public void SetMenuItemName(int index)
    {
        menuMode = (MenuMode)index + 1;
        if (menuMode == MenuMode.NewGame || menuMode == MenuMode.Continue) 
        {
            Canvases[0].SetActive(false);
            Canvases[1].SetActive(true) ;
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(TitleManager))]
public class TitleManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TitleManager titleManager = target as TitleManager;
        base.OnInspectorGUI();
        titleManager.menuMode = (TitleManager.MenuMode)EditorGUILayout.EnumPopup("SelectMenuItem", titleManager.menuMode);
    }
}
#endif
