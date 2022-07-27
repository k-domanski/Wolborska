using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIAction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _image;

    [SerializeField] private InteractionController _interactionController;

    private void Awake()
    {
        _interactionController.onActionRange += HandleVisibility;
    }

    private void HandleVisibility(bool isActive, string message)
    {
        _text.text = $"Press [E] to {message}.";
        _text.gameObject.SetActive(!isActive);
        _image.gameObject.SetActive(!isActive);
    }
}
