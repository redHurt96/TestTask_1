using System;
using System.Collections.Generic;

namespace _Project.Model
{
    [Serializable]
    public class OffersCollection
    {
        public readonly Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();

        public OffersCollection(Offer[] offers)
        {
            for (int i = 0; i < offers.Length; i++) 
                Offers.Add(i, offers[i]);
        }

        public void Remove(int key) => 
            Offers.Remove(key);
    }
}