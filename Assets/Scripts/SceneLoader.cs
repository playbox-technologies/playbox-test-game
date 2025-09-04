using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
   [SerializeField]
   private string loadedScene;

   [SerializeField]
   Slider slider;
   
   [SerializeField]
   UnityEvent<string> consoleOutputError;
   
   [SerializeField]
   UnityEvent<string> consoleOutputLog;
   
   AsyncOperation asyncOperation;

   private void OnEnable()
   {
       Application.logMessageReceivedThreaded += (condition, trace, type) =>
       {
           if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
           {
               consoleOutputError?.Invoke(condition);
           }

           if (type == LogType.Log)
           {
               consoleOutputLog?.Invoke(condition);
           }
       };
   }

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
