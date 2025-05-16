using System;
using TMPro;
using UnityEngine;

public class FartUi : MonoBehaviour
{
    [SerializeField] private TMP_Text _fartAmountText;
    private string _template;
    private IFarter _farter;

    public void Init(IFarter farter)
    {
        _farter = farter;

        _farter.OnFart += UpdateText;
        _farter.OnReloadComplete += UpdateText;
        _template = _fartAmountText.text;
        UpdateText();
    }

    private void OnDestroy()
    {
        _farter.OnFart -= UpdateText;
        _farter.OnReloadComplete -= UpdateText;
    }

    private void UpdateText()
    {
        _fartAmountText.text = string.Format(_template, _farter.CurrentFartAmount.ToString(), _farter.FartAmount.ToString());
    }
}
