using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIAction : MonoBehaviour
{
    #region Properties
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _image;

    [SerializeField] private InteractionController _interactionController; 
    #endregion

    #region Messages
    private void OnEnable()
    {
        _interactionController.onActionInRange += HandleVisibility;
    }

    private void OnDisable()
    {
        _interactionController.onActionInRange -= HandleVisibility;
    }
    #endregion

    #region Private Methods
    private void HandleVisibility(bool isActive, string message)
    {
        _text.text = $"Press [E] to {message}.";
        _text.gameObject.SetActive(isActive);
        _image.gameObject.SetActive(isActive);
    } 
    #endregion
}
