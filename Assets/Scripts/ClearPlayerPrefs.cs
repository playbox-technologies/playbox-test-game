#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class ClearPlayerPrefs : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Playbox/Clear PlayerPrefs")]
#endif
    static void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    
}