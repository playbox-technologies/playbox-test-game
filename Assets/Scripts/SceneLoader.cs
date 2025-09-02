using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   [SerializeField]
   private string loadedScene;

   public void loadScene()
   {
      Debug.Log("loading scene");
      
      SceneManager.LoadScene(loadedScene);
   }
   
}
