using Sugar;
using System;
using UnityEngine;

namespace Level.Objects
{
    public abstract class LevelObject : MonoBehaviour
    {
        public abstract int InitializeOrder { get; protected set; }

        private bool _isInitialized = false;
        private bool _isLevelEndInstructionCompleted = false;

        public void Initialize(LevelManagement levelManagement)
        {
            if (_isInitialized) throw new Exception(StringConstants.ObjectHasAlreadtBeenInitializedExcpetionTitle);
            InitializeInstruction(levelManagement);
            _isInitialized = true;
        }

        public void OnLevelEnded()
        {
            if (_isLevelEndInstructionCompleted) throw new Exception(StringConstants.ObjectHasAlreadtBeenInitializedExcpetionTitle);
            OnLevelEndedInstuction();
            _isLevelEndInstructionCompleted = true;
        }

        protected abstract void InitializeInstruction(LevelManagement levelManagement);
        protected abstract void OnLevelEndedInstuction();
    }
}