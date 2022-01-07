using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Goal : MonoBehaviour, IInteractable
{
    public ButtonTrigger buttonTrigger => _buttonTrigger;

    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private Item _item;
    private ButtonTrigger _buttonTrigger;
    private bool _isActive = true;


    public void Interact()
    {
        if(!_item.isPickedUp)
        { 
            return;
        }
        else if(_isActive)
        {
            _playableDirector.Play();
            _item.Place(transform.position);
            _isActive = false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _buttonTrigger = GetComponent<ButtonTrigger>();
        _buttonTrigger.onButtonPressed += Interact;
    }
}
