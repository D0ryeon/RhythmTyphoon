using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadStartScene();
        }
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}







