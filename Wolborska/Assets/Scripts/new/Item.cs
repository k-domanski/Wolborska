using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

namespace New
{
    public class Item : AInteract
    {
        void Awake()
        {
            message = "Test item";
        }
        public override void Interact()
        {
            base.Interact();
            Debug.Log("Interact");
            isComplete = true;
        }
    }
}
