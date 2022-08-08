using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionProxy", menuName = "InteractionProxy")]
public class InteractionProxy : ScriptableObject
{
    public InteractionManager InteractionManager
    {
        get
        {
            if (interactionManager == null)
                interactionManager = FindObjectOfType<InteractionManager>();
            return interactionManager;
        }
    }

    private InteractionManager interactionManager;
}
