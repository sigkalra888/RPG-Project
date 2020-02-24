using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class CreateRenderTex : MonoBehaviour
{
    

    [MenuItem("CreateRenderTexture/SaveAssets")]
    private static void Create()
    {
        RenderTexture r = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        AssetDatabase.CreateAsset(r, "Assets/Textures/RenderTexture1.rendertexture");
        AssetDatabase.SaveAssets();
    }
    
}
