using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    [SerializeField] private Button _btnShop;
    [SerializeField] private Button _btnInventory;
    [SerializeField] private Button _btnStage;

    private void Start()
    {
        _btnShop.onClick.AddListener(OpenPopup_Shop);
        _btnInventory.onClick.AddListener(OpenPopup_Inventory);
        _btnStage.onClick.AddListener(OpenPopup_Stage);
    }

    void OpenPopup_Shop()
    {
        UIPopup popup = UIManager_Test.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("상점", "상점을 여시겠습니까?", () => { UIManager_Test.Instance.OpenUI<UIShop>(); });
    }

    void OpenPopup_Inventory()
    {
        UIPopup popup = UIManager_Test.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("인벤토리", "인벤토리을 여시겠습니까?", () => { UIManager_Test.Instance.OpenUI<UIInventory>(); });
    }

    void OpenPopup_Stage()
    {
        UIPopup popup = UIManager_Test.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("스테이지", "스테이지을 여시겠습니까?", () => { UIManager_Test.Instance.OpenUI<UIStage>(); });
    }
}
