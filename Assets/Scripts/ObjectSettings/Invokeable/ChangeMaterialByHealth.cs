using ObjectSettings.General;
using Sugar;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectSettings.Invokeable
{
    public class ChangeMaterialByHealth : InvokeableObjectSetting
    {
        [SerializeField] private Color _targetColor;
        [SerializeField] private MeshRenderer _meshRenerer;

        private IHealthChangeable _healthChangeableObject;

        protected override void SettingDescription()
        {
            Color newColor = Color.Lerp(_meshRenerer.material.color, _targetColor, 1 - (_healthChangeableObject.Health / _healthChangeableObject.MaxHealth));

            for (int i = 0; i < _meshRenerer.materials.Length; i++)
            {
                _meshRenerer.materials[i].color = newColor;
            }
        }

        protected override void SubscribeSetting()
        {
            if (TryGetComponent(out IHealthChangeable healthChangeableObject))
            {
                _healthChangeableObject = healthChangeableObject;
                _healthChangeableObject.OnHealthChanged += SettingDescription;

                return;
            }

            throw new Exception(StringConstants.ThereIsNoNeededEllementOnObject + typeof(IHealthChangeable).Name);
        }

        protected override void UnsubscribeSetting()
        {
            if (TryGetComponent(out IHealthChangeable healthChangeableObject))
            {
                _healthChangeableObject.OnHealthChanged -= SettingDescription;

                return;
            }

            throw new Exception(StringConstants.ThereIsNoNeededEllementOnObject + typeof(IHealthChangeable).Name);
        }
    }
}