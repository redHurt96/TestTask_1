using System;
using _Project.Offers.Model;
using UnityEngine;

namespace _Project.Model
{
    [Serializable]
    public class Offer
    {
        [field:SerializeField] public string Title { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field:SerializeField] public Resource[] Resources { get; private set; }
        [field:SerializeField] public float Price { get; private set; }
        [field:SerializeField, Range(0f,1f)] public float Discount { get; private set; }
        [field:SerializeField] public string SpriteId { get; private set; }

        public bool HasDiscount => Discount > 0f;
        public float FakePrice => Price * (1 + Discount);
    }
}
