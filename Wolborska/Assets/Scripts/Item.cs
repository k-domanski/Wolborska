using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Item : AInteract
    {
        public string ItemName => _itemName;
        [SerializeField] private GameObject _itemModel;
        [SerializeField] private string _itemName;
        
        private FollowPath _indicator;

        void Awake()
        {
            message = "pick up";
            _indicator = GetComponentInChildren<FollowPath>();
        }

        public override void Interact()
        {
            base.Interact();
            _itemModel.SetActive(false);
            _indicator?.Activate();
        }

        public void Place(Vector3 position)
        {
            _itemModel.transform.position = position;
            _itemModel.SetActive(true);
            _indicator?.Deactivate();
        }
    }
