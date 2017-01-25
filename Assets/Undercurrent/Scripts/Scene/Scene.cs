﻿using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace Undercurrent.Scripts.Scene
{
    public class Scene : MonoBehaviour
    {
        public string[] Encounters;
        public string[] InitialScenes = {"sea_night", "prologue"};

        private void Start()
        {
            foreach (var initialScene in InitialScenes)
            {
                SceneManager.LoadScene(initialScene, LoadSceneMode.Additive);
            }
            var dialogRunner = FindObjectOfType<DialogueRunner>();
            if (dialogRunner == null)
            {
                Debug.LogErrorFormat("Require object of type {0}, but found no GameObject in the scene.", typeof(DialogueRunner));
            }
            else
            {
                dialogRunner.StartDialogue();
            }
        }

        [YarnCommand("switch")]
        public void SwitchScene(string sceneName)
        {
            UnloadActiveScenes();

            switch (sceneName)
            {
                case "encounter":
                    var encounter = Random.Range(0, Encounters.Length);

                    var chosenEncounter = Encounters[encounter];
                    Debug.LogFormat("Loading encounter {0}", chosenEncounter);
                    SceneManager.LoadScene("sea_day", LoadSceneMode.Additive);
                    SceneManager.LoadScene(chosenEncounter, LoadSceneMode.Additive);
                    break;
                case "navigation":
                    Debug.LogFormat("Loading scene {0}", sceneName);

                    SceneManager.LoadScene("sea_day", LoadSceneMode.Additive);
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                    break;
            }
        }

        private void UnloadActiveScenes()
        {
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (!scene.name.Equals("coordinator"))
                {
                    SceneManager.UnloadSceneAsync(scene);
                }
            }
        }
    }
}
