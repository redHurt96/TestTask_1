using System;
using _Project.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Offers.View
{
    public class OfferView : MonoBehaviour
    {
        public event Action<int> BuyButtonClicked;
        
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _image;
        [SerializeField] private ResourceView[] _resourceViews;
        [SerializeField] private Button _buy;
        [SerializeField] private TextMeshProUGUI _price;
        [SerializeField] private TextMeshProUGUI _fakePrice;
        [SerializeField] private GameObject _discount;
        [SerializeField] private TextMeshProUGUI _discountAmount;
        
        private int _offerKey;

        public void Initialize() => 
            _buy.onClick.AddListener(Buy);

        public void Dispose() => 
            _buy.onClick.RemoveListener(Buy);

        public void Draw(int pairKey, Offer offer, Sprite[] resourcesSprites, Sprite sprite)
        {
            _offerKey = pairKey;
            _title.text = offer.Title;
            _description.text = offer.Description;
            _image.sprite = sprite;

            for (int i = 0; i < _resourceViews.Length; i++)
            {
                if (offer.Resources.Length > i)
                    _resourceViews[i].Draw(offer.Resources[i], resourcesSprites[i]);
                else
                    _resourceViews[i].Hide();
            }

            _price.text = $"{offer.Price}$";
            _discount.SetActive(offer.HasDiscount);
                
            if (offer.HasDiscount)
            {
                _fakePrice.text = $"{offer.FakePrice}$";
                _discountAmount.text = $"-{offer.Discount:P}";
            }
        }

        private void Buy() => 
            BuyButtonClicked?.Invoke(_offerKey);
    }
}