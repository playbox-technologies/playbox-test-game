using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;

public class PlayboxMemoryProfiling : MonoBehaviour
{
    [SerializeField] UnityEvent<string> onMemoryProfilingFinished;
    
    public void ShowAllMemory()
    {
        onMemoryProfilingFinished?.Invoke($"Full memory: {ReportMemoryUsage()}");
    }
    
    string ReportMemoryUsage()
    {
        long textureMem = 0;
        long meshMem = 0;
        long materialMem = 0;
        long audioMem = 0;
        long animationMem = 0;

        foreach (var tex in Resources.FindObjectsOfTypeAll<Texture>())
            textureMem += Profiler.GetRuntimeMemorySizeLong(tex);

        foreach (var mesh in Resources.FindObjectsOfTypeAll<Mesh>())
            meshMem += Profiler.GetRuntimeMemorySizeLong(mesh);

        foreach (var mat in Resources.FindObjectsOfTypeAll<Material>())
            materialMem += Profiler.GetRuntimeMemorySizeLong(mat);

        foreach (var audio in Resources.FindObjectsOfTypeAll<AudioClip>())
            audioMem += Profiler.GetRuntimeMemorySizeLong(audio);

        foreach (var anim in Resources.FindObjectsOfTypeAll<AnimationClip>())
            animationMem += Profiler.GetRuntimeMemorySizeLong(anim);

        var sb = new StringBuilder();
        sb.AppendLine("=== Runtime Memory Usage (MB) ===");
        sb.AppendLine($"Textures:   {textureMem / (1024 * 1024f):F2} MB");
        sb.AppendLine($"Meshes:     {meshMem / (1024 * 1024f):F2} MB");
        sb.AppendLine($"Materials:  {materialMem / (1024 * 1024f):F2} MB");
        sb.AppendLine($"AudioClips: {audioMem / (1024 * 1024f):F2} MB");
        sb.AppendLine($"Animations: {animationMem / (1024 * 1024f):F2} MB");

        return sb.ToString();
    }
    
    public void CleanMemory()
    {
        StartCoroutine(ResourceCleanRoutine());
    }

    private IEnumerator ResourceCleanRoutine()
    {
        yield return Resources.UnloadUnusedAssets();
        System.GC.Collect();
    }
}
