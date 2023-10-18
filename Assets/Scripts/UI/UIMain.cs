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
        //popup.SetPopup("����", "������ ���ðڽ��ϱ�?", () => { UIManager_Test.Instance.OpenUI<UIShop>(); });
    }

    void OpenPopup_Inventory()
    {
        UIPopup popup = UIManager_Test.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("�κ��丮", "�κ��丮�� ���ðڽ��ϱ�?", () => { UIManager_Test.Instance.OpenUI<UIInventory>(); });
    }

    void OpenPopup_Stage()
    {
        UIPopup popup = UIManager_Test.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("��������", "���������� ���ðڽ��ϱ�?", () => { UIManager_Test.Instance.OpenUI<UIStage>(); });
    }
}
