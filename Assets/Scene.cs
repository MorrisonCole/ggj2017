using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class Scene : MonoBehaviour
{
    public string[] Encounters;

    [YarnCommand("switch")]
    public void SwitchScene(string sceneName)
    {
        if (sceneName.Equals("encounter"))
        {
            var encounter = Random.Range(0, Encounters.Length);

            var chosenEncounter = Encounters[encounter];
            Debug.LogFormat("Loading encounter {0}", chosenEncounter);
            SceneManager.LoadScene(chosenEncounter);
        }
        else
        {
            Debug.LogErrorFormat("Asked to load scene {0} but I don't know what to do with it!", sceneName);
        }
    }
}
