using BepInEx;
using UnityEngine;
using Utilla.Attributes;
using System.Collections.Generic;
using GorillaLocomotion;

namespace bp15_modding_template
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version), ModdedGamemode]
    public class Plugin : BaseUnityPlugin
    {
        public bool inModded = false;
        public List<GameObject> spheres = new List<GameObject>();

        public bool destroyed = false;

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
            float gripFloat = ControllerInputPoller.instance.rightControllerGripFloat;
            if (gripFloat > 0.7f)
            {
                //what happens if something else occurs (ex. button press)
                CreateSphere();
            }
            float triggerFloat = ControllerInputPoller.instance.rightControllerIndexFloat;
            if (triggerFloat > 0.7f && !destroyed)
            {
                //what happens if something else occurs (ex. button press)
                DestroySpheres();
            }
        }

        void CreateSphere()
        {
            GameObject sphere = new GameObject("Sphere");
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            sphere.transform.localPosition = GTPlayer.Instance.RightHand.controllerTransform.position;
            Destroy(sphere.GetComponent<Collider>());
            Destroy(sphere.GetComponent<Rigidbody>());
            sphere.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            sphere.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
            spheres.Add(sphere);
        
            destroyed = false;
        }
        
        void DestroySpheres()
        {
            foreach (GameObject sphere in spheres)
            {
                Destroy(sphere);
            }
            spheres.Clear();
            destroyed = true;
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


