using System;
using System.Collections.Generic;

namespace Sugar
{
    public class CollectionOperations
    {
        public static void CompleteObjectCollectionActions<T>(Action<T> requestedAction, List<T> requestedCollection)
        {
            for (int i = 0; i < requestedCollection.Count; i++)
            {
                requestedAction?.Invoke(requestedCollection[i]);
            }
        }

        public static void CompleteObjectCollectionActions<T>(Action<T> requestedAction, T[] requestedCollection)
        {
            for (int i = 0; i < requestedCollection.Length; i++)
            {
                requestedAction?.Invoke(requestedCollection[i]);
            }
        }
    }
}