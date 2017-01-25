using UnityEngine;
using UnityEngine.SceneManagement;

namespace Undercurrent.Scripts.Scene
{
    public class StartGame : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("coordinator");
            }
        }
    }
}