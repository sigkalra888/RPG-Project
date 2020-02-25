using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField,Tooltip("Menu項目の参照")]
    private Text[] menuItem;
    [SerializeField,Tooltip("現在選択しているMenuItem")]
    private int menuNumber = 1;

    private bool keyDownCheack = false;

    void Update()
    {
        ChangeMenu();
        ConfirmMenuItem();
    }

    /// <summary>
    /// MenuItemの選択
    /// </summary>
    private void ChangeMenu()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            keyDownCheack = true;
            if(menuNumber == 1) { menuNumber = menuItem.Length - 1; return; }
            menuNumber--;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            keyDownCheack = true;
            if (menuNumber == 3) { menuNumber = 1; return; }
            menuNumber++;
        }

        if (!keyDownCheack) { return; }
        ChangeTextSize(menuNumber);
    }

    /// <summary>
    /// MenuItemのテキストサイズ変更
    /// </summary>
    /// <param name="num"></param>
    public void ChangeTextSize(int num)
    {
        for (int i = 0; i < menuItem.Length; i++)
        {
            if(i == 0) { continue; }
            menuItem[i].rectTransform.localScale = Vector2.one;
            menuItem[i].color = new Color(0.195f,0.195f,0.195f,1);
        }
        menuItem[num].rectTransform.localScale = new Vector2(1.2f,1.2f);
        menuItem[num].color = Color.red;
        keyDownCheack = false;
    }

    /// <summary>
    /// Menuの選択処理
    /// </summary>
    private void ConfirmMenuItem()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TitleManager.Instance.SetMenuItemName(menuNumber);
        }
    }
}
