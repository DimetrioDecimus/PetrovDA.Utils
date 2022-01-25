using System;
using System.Collections.Generic;
using UnityEngine;

namespace PetrovDA.Utils
{
    [Serializable]
    public struct RelationStruct<T, K>
    {
        [SerializeField]
        private int id;
        [SerializeField]
        private T sender;
        [SerializeField]
        private K adress;

        public readonly int Id { get => id; }
        public readonly T Sender { get => sender; }
        public readonly K Adress { get => adress; }

        
    }
}
