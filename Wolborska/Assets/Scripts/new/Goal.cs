using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace New
{
    public class Goal : MonoBehaviour
    {

        public static Action onGoalCompleted;

        public void Complete()
        {
            onGoalCompleted?.Invoke();
        }
    } 
}
