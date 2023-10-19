using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtContent;

    [SerializeField] private Button _btnBack;
    [SerializeField] private Button _btnConform;
    [SerializeField] private Button _btnCancel;
    [SerializeField] private GameObject Popup;

    private Action _onConfirm;

    void Start()
    {
        _btnBack.onClick.AddListener(Close);
        _btnCancel.onClick.AddListener(Close);
        _btnConform.onClick.AddListener(Confirm);
    }

    public void SetPopup(string title, string content, Action onConfirm)
    {
        txtTitle.text = title;
        txtContent.text = content;

        _onConfirm = onConfirm;
    }

    void Confirm()
    {
        _onConfirm?.Invoke();
        _onConfirm = null;
        Close();
    }

    void Close()
    {
        Popup.SetActive(false);
    }
}
