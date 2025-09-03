using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
   [SerializeField]
   private string loadedScene;

   [SerializeField]
   Slider slider;
   
   AsyncOperation asyncOperation;
   
   public void loadScene()
   {
      Debug.Log("loading scene");
      
      asyncOperation = SceneManager.LoadSceneAsync(loadedScene);
      
   }

   private void Update()
   {
       if (asyncOperation != null)
       {
           slider.value = asyncOperation.progress;
       }
   }
}
