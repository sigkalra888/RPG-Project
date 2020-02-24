using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreate : MonoBehaviour
{
    public void PushSelectButton()
    {
        CharacterManager.Instance.CreateCharacter();
    }
}
