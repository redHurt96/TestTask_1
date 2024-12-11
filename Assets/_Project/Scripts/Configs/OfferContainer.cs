using UnityEngine;

namespace _Project.Model
{
    [CreateAssetMenu(menuName = "Create OfferContainer", fileName = "OfferContainer", order = 0)]
    public class OfferContainer : ScriptableObject
    {
        [field:SerializeField] public Offer Value { get; private set; }
    }
}