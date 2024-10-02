using System.IO;
using System.Reflection;
using UnityEngine;

namespace EternalWarsWasBetterDiplomacyRandomEventsFix_NativeModloader
{
    public class WorldBoxMod : MonoBehaviour
    {
        public void Awake()
        {
            Debug.Log($"{MethodBase.GetCurrentMethod().DeclaringType.Namespace} loading...");
            string path = Path.Combine(Application.streamingAssetsPath, "Mods");
            path = Path.Combine(path, "stuffthatjeansmodsuse");
            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directoryInfo.Create();
                directoryInfo.Attributes |= FileAttributes.Hidden;
            }

            if (!File.Exists(Path.Combine(path, "0Harmony.dll"))) { File.WriteAllBytes(Path.Combine(path, "0Harmony.dll"), Assemblies.Resource._0Harmony); }
            if (!File.Exists(Path.Combine(path, "Mono.Cecil.dll"))) { File.WriteAllBytes(Path.Combine(path, "Mono.Cecil.dll"), Assemblies.Resource.Mono_Cecil); }
            if (!File.Exists(Path.Combine(path, "MonoMod.Utils.dll"))) { File.WriteAllBytes(Path.Combine(path, "MonoMod.Utils.dll"), Assemblies.Resource.MonoMod_Utils); }
            if (!File.Exists(Path.Combine(path, "MonoMod.RuntimeDetour.dll"))) { File.WriteAllBytes(Path.Combine(path, "MonoMod.RuntimeDetour.dll"), Assemblies.Resource.MonoMod_RuntimeDetour); }

            Assembly.LoadFrom(Path.Combine(path, "0Harmony.dll"));

            Debug.Log($"{MethodBase.GetCurrentMethod().DeclaringType.Namespace} loaded!");
            GameObject gameObject = new GameObject(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
            DontDestroyOnLoad(gameObject);
            gameObject.AddComponent<Main>();
        }
    }
}
