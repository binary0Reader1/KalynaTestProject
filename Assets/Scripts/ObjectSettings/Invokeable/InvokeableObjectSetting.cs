using UnityEngine;

namespace ObjectSettings.Invokeable
{
    public abstract class InvokeableObjectSetting : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeSetting();
        }
        private void OnDisable()
        {
            UnsubscribeSetting();
        }

        /// <summary>
        /// Subscribing setting to selected action delegate.
        /// </summary>
        protected abstract void SubscribeSetting();

        /// <summary>
        /// Unsubscribing setting from selected action delegate.
        /// </summary>
        protected abstract void UnsubscribeSetting();

        /// <summary>
        /// Your setting code goes here.
        /// </summary>
        protected abstract void SettingDescription();
    }
}