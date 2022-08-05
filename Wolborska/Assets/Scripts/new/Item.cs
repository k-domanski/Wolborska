using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace New
{
    public class Item : AInteract
    {
        public string ItemName => _itemName;
        [SerializeField] private GameObject _itemModel;
        [SerializeField] private string _itemName;
        [SerializeField] private FollowPath _indicator;

        void Awake()
        {
            message = "pick up";
        }

        public override void Interact()
        {
            base.Interact();
            _itemModel.SetActive(false);
            _indicator?.Activate();
        }

        public void Place(Vector3 position)
        {
            transform.position = position;
            _itemModel.SetActive(true);
        }
    }
}
