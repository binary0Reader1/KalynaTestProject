using System;
using UnityEngine;

namespace FactoryObjects
{
    ///<Summary>
    ///Base class for all objects from factories.
    ///</Summary>>
    public class FactoryObject : MonoBehaviour
    {

    }

    ///<Summary>
    ///Base class for all object types lists.
    ///Used as an abstract analogue of enum for object factories.
    ///</Summary>
    public class FactoryObjectType
    {
        public static bool operator ==(FactoryObjectType factoryObjectType1, FactoryObjectType factoryObjectType2)
        {
            if (factoryObjectType1 is null || factoryObjectType2 is null)
            {
                if (factoryObjectType1 is null && factoryObjectType2 is null)
                {
                    return true;
                }

                if (factoryObjectType1 is null && factoryObjectType2 is not null)
                {
                    return false;
                }

                if (factoryObjectType1 is not null && factoryObjectType2 is null)
                {
                    return false;
                }
            }

            return factoryObjectType1.Key == factoryObjectType2.Key;
        }

        public static bool operator !=(FactoryObjectType factoryObjectType1, FactoryObjectType factoryObjectType2)
        {
            if (factoryObjectType1 is null || factoryObjectType2 is null)
            {
                if (factoryObjectType1 is null && factoryObjectType2 is null)
                {
                    return false;
                }

                if (factoryObjectType1 is null && factoryObjectType2 is not null)
                {
                    return true;
                }

                if (factoryObjectType1 is not null && factoryObjectType2 is null)
                {
                    return true;
                }
            }

            return factoryObjectType1.Key != factoryObjectType2.Key;
        }

        public override bool Equals(object obj)
        {
            return obj is FactoryObjectType type &&
                   Key == type.Key;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Key);
        }

        public string Key { get; }

        protected FactoryObjectType(string key)
        {
            Key = key;
        }
    }
}