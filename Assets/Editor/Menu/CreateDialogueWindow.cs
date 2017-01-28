using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class CreateDialogueWindow : EditorWindow
{
    public TextAsset Source;

    private string sceneName = "";
    private string baseScenePath = "Assets/Undercurrent/Scenes/";
    private string scenePath = "";

    [MenuItem("Undercurrent/Create Dialog Scene")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        GetWindow(typeof(CreateDialogueWindow));
    }

    private void OnGUI()
    {
        GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
        scenePath = EditorGUILayout.TextField("Scene", scenePath);

        Source = (TextAsset) EditorGUILayout.ObjectField("Dialogue Source", Source, typeof(TextAsset), allowSceneObjects: false);

        if (GUILayout.Button("Create"))
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);

            var dialogueResource = "Dialogue";
            var dialoguePrefab = Instantiate(Resources.Load<GameObject>(dialogueResource));

            if (dialoguePrefab == null)
            {
                Debug.LogErrorFormat("Tried to load resource {0} but got nothing", dialogueResource);
                return;
            }

            var dialogueRunner = dialoguePrefab.GetComponentInChildren<DialogueRunner>();
            dialogueRunner.sourceText = new[] {Source};

            SceneManager.MoveGameObjectToScene(dialoguePrefab, scene);

            EditorSceneManager.SaveScene(scene, baseScenePath + scenePath + ".unity");
        }
    }
}
