using System;

namespace ObjectSettings.General
{
    public interface IDestructable
    {
        public Action OnDestruct { get; set; }
        public void Destruct();
    }
}

