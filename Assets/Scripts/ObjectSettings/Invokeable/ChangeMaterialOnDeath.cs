using ObjectSettings.General;
using Sugar;
using System;
using UnityEngine;

namespace ObjectSettings.Invokeable
{
    public class ChangeMaterialOnDeath : InvokeableObjectSetting
    {
        [SerializeField] private Material _requestedMaterial;
        [SerializeField] private MeshRenderer _meshRenerer;

        protected override void SubscribeSetting()
        {
            if (TryGetComponent(out IDestructable destructableObject))
            {
                destructableObject.OnDestruct += SettingDescription;
                return;
            }

            throw new Exception(StringConstants.ThereIsNoNeededEllementOnObject + typeof(IDestructable).Name);
        }

        protected override void UnsubscribeSetting()
        {
            if (TryGetComponent(out IDestructable destructableObject))
            {
                destructableObject.OnDestruct -= SettingDescription;
                return;
            }

            throw new Exception(StringConstants.ThereIsNoNeededEllementOnObject + typeof(IDestructable).Name);
        }

        protected override void SettingDescription()
        {
            if (_meshRenerer != null)
            {
                _meshRenerer.material = _requestedMaterial;
                return;
            }

            throw new Exception(StringConstants.ThereIsNoNeededEllementOnObject + typeof(MeshRenderer).Name);
        }
    }
}