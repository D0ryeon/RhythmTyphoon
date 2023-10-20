using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{
    public void SceneChangeStart()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void SceneChangeSetting()
    {
        SceneManager.LoadScene("SettingScene");
    }

    public void SceneChangeStory()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void SceneChangeClear()
    {
        SceneManager.LoadScene("ClearScene");
    }

    public void SceneChangeGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void SceneChangeBattle()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
