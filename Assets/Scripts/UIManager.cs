using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoText;
    [SerializeField] private GameObject _coinImage;

    public void UpdateAmmo(int count)
    {
       _ammoText.text = count.ToString();
    }

    public void UpdateCoin()
    {
        _coinImage.SetActive(true);
    }

    public void RemoveCoin()
    {
       _coinImage.SetActive(false);
    }
}//Class
