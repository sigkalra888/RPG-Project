using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour
{
    public void PushSelectButton()
    {
        int index = int.Parse(gameObject.name.Substring(name.Length - 1));
        CharacterManager.Instance.CreateCharacter(index);
    }
}
