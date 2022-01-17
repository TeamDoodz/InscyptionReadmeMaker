using System.Collections;
using BepInEx;
using BepInEx.Logging;
using UnityEngine;

namespace ReadmeMaker
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency("cyantist.inscryption.api", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
	    public const string PluginGuid = "jamesgames.inscryption.readmemaker";
	    public const string PluginName = "Readme Maker";
	    public const string PluginVersion = "0.1.0.0";

        public static string Directory;
        public static ManualLogSource Log;

        private void Awake()
        {
	        Log = Logger;
            Logger.LogInfo($"Loading {PluginName}...");
            Directory = this.Info.Location.Replace("ReadmeMaker.dll", "");
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private IEnumerator Start()
        {
	        // 5 seconds because too lazy to find out when all the mods are actually loaded to 
	        yield return new WaitForSeconds(5);

	        ReadmeDump.Dump();
        }
    }
}
