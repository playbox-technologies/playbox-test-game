using UnityEditor;
using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
    [MenuItem("Playbox/Clear PlayerPrefs")]
    static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
