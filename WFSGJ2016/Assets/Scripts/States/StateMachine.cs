﻿using UnityEngine;

namespace Assets.Scripts.States
{
    public abstract class State : MonoBehaviour
    {
        public static State currentState = null;

        public void Start()
        {
            currentState = this;
            Init();
        }

        public void Update()
        {
            UpdateLoop();

            if (currentState != this)
            {
                Destroy(this);
            }
        }

        public abstract void Init();

        public abstract void UpdateLoop();

        public void ChangeState<T>() where T : MonoBehaviour
        {
            Destroy(this);
            gameObject.AddComponent<T>();
        }
    }
}
