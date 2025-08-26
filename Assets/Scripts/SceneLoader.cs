using System;
using InspectorButton;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   [SerializeField]
   private AssetReference loadedScene;

   private void Start()
   {
      Debug.Log(loadedScene.SubObjectName);
   }

   public void loadScene()
   {
      Debug.Log("loading scene");
      
      loadedScene.LoadSceneAsync(LoadSceneMode.Single,true);
   }
   
}
