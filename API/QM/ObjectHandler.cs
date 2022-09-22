using System;
using UnityEngine;

namespace Eclipse.API.QM
{
    public class ObjectHandler : MonoBehaviour // https://github.com/PlagueVRC/PlagueButtonAPI/blob/new-ui/PlagueButtonAPI/PlagueButtonAPI/Main/ButtonAPI.cs#L151
    {
        private bool IsEnabled;
        public Action<GameObject> OnDestroyed = null;
        public Action<GameObject> OnDisabled = null;

        public Action<GameObject> OnEnabled = null;
        public Action<GameObject, bool> OnUpdate = null;
        public Action<GameObject, bool> OnUpdateEachSecond = null;
        private float UpdateDelay = 0f;

        public ObjectHandler(IntPtr instance) : base(instance)
        {
        }

        private void OnEnable()
        {
            OnEnabled?.Invoke(gameObject);
            IsEnabled = true;
        }

        private void OnDisable()
        {
            OnDisabled?.Invoke(gameObject);
            IsEnabled = false;
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(gameObject);
        }

        private void Update()
        {
            OnUpdate?.Invoke(gameObject, IsEnabled);

            if (UpdateDelay < Time.time)
            {
                UpdateDelay = Time.time + 1f;

                OnUpdateEachSecond?.Invoke(gameObject, IsEnabled);
            }
        }
    }
}
