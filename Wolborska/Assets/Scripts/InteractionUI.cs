using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InteractionUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Image _image;

    private List<ButtonTrigger> _triggers;

    private void Start()
    {
        _triggers = FindObjectsOfType<ButtonTrigger>().ToList();
        //Debug.Log(_triggers.Count);

        foreach (var trigger in _triggers)
        {
            trigger.onTriggerEnter += Show;
            trigger.onTriggerExit += Hide;
            trigger.onButtonPressed += Hide;
        }
    }

    public void Show(InteractableType type)
    {
        _text.text = GetUIText(type);
        _text.gameObject.SetActive(true);
        _image.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _image.gameObject.SetActive(false);
        _text.gameObject.SetActive(false);
    }

    private string GetUIText(InteractableType type)
    {
        string text = "";
        switch (type)
        {
            case InteractableType.PICKUP:
                text = "Press [E] to pick up.";
                break;
            case InteractableType.GOAL:
                text = "Press [E] to interact.";
                break;
            case InteractableType.DOOR:
                break;
            default:
                break;
        }
        return text;
    }
}
