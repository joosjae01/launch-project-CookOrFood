using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _slotName;
    [SerializeField] private TextMeshProUGUI _slotDesc;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _button;
    public EnhanceBase enhance;

    private void OnDisable() => UnBindButton();

    public void RefreshName(string name) => _slotName.text = name;
    public void RefreshDesc(string desc) => _slotDesc.text = desc;
    public void RefreshImage(Sprite image) => _icon.sprite = image;
    public void RefreshButton() => _button.onClick.AddListener(BindButton);
    private void BindButton()
    {
        EnhanceManager.Instance.ApplyEnhance(enhance);
        //GameManager.Instance.ResumeGame();
    }

    private void UnBindButton()
    {
        _button.onClick.RemoveAllListeners();
    }
}
