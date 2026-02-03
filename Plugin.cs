using BepInEx;
using UnityEngine;
using Utilla.Attributes;

namespace bp15_modding_template
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version), ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        public bool inModded = false;

        void Start()
        {
            // put whatever you want here

            // example
            Debug.Log($"{PluginInfo.Name} Loaded!");
        }

        void Update()
        {
            // put whatever you want here

            // example
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                Debug.Log("Controller Clicked: A");
        }

        [ModdedGamemodeJoin]
        void OnJoin()
        {
            // put whatever you want here

            // example
            inModded = true;
            Debug.Log("Joined Modded!");
        }

        [ModdedGamemodeLeave]
        void OnLeave()
        {
            // put whatever you want here

            // example
            inModded = false;
            Debug.Log("Left Modded!");
        }
    }
}
