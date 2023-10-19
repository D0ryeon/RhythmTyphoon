using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField] private GameObject _SetName;
    [SerializeField] private GameObject _SetGmaeDifficulty;
    [SerializeField] private GameObject _Popup;
    [SerializeField] private Button _btnNameConfirm;
    [SerializeField] private Button _btnNormal;
    [SerializeField] private Button _btnHard;
    [SerializeField] private Button _btnHardCore;
    private SetPlayerStatus _SetPlayerStatus;
    [SerializeField] private EScene _nextSceneName;
    private UIPopup _uiPopup;

    private void Start()
    {
        _uiPopup = GetComponent<UIPopup>();
        _SetPlayerStatus = GetComponent<SetPlayerStatus>();
        _btnNameConfirm.onClick.AddListener(OpenPopup_SetPlayerName);
        _btnNormal.onClick.AddListener(OpenPopup_SetGmaeDifficulty);
        _btnNormal.onClick.AddListener(() => { _SetPlayerStatus.SetGmaeDifficulty(EGameDifficulty.Normal); });
        _btnHard.onClick.AddListener(OpenPopup_SetGmaeDifficulty);
        _btnHard.onClick.AddListener(() => { _SetPlayerStatus.SetGmaeDifficulty(EGameDifficulty.Hard); });
        _btnHardCore.onClick.AddListener(OpenPopup_SetGmaeDifficulty);
        _btnHardCore.onClick.AddListener(() => { _SetPlayerStatus.SetGmaeDifficulty(EGameDifficulty.HardCore); });
    }   

    void OpenPopup_SetPlayerName()
    {
        _Popup.SetActive(true);
        _uiPopup.SetPopup("확인", "정말 결정하시겠습니까?", SetPlayerName_Event);
    }

    void OpenPopup_SetGmaeDifficulty()
    {
        _Popup.SetActive(true);
        _uiPopup.SetPopup("확인", "정말 결정하시겠습니까?", () => { _SetPlayerStatus.SetPlayerData(); LoadNextScene(); });
        
    }

    void SetPlayerName_Event()
    {
        _SetPlayerStatus.SetPlayerName();
        _SetName.SetActive(false);
        _SetGmaeDifficulty.SetActive(true);
    }

    private void LoadNextScene()
    {
        try
        {
            SceneManager.LoadScene(_nextSceneName.ToString());
        }
        catch
        {
            Debug.Log("GameManager에 있는 EScene가 Scene이름과 같아야 됩니다. 수정해 주세요.");
        }
    }
}
