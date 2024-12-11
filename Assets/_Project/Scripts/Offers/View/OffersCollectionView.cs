using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Model;
using UnityEngine;

namespace _Project.Offers.View
{
    public class OffersCollectionView : MonoBehaviour
    {
        public event Action<int> BuyOfferButtonClicked;
        
        [SerializeField] private OfferView _prefab;
        [SerializeField] private Transform _parent;

        private readonly Dictionary<int, OfferView> _views = new Dictionary<int, OfferView>();
        
        private ISpritesLoader _spritesLoader;

        public void Initialize(ISpritesLoader spritesLoader) => 
            _spritesLoader = spritesLoader;

        public void Draw(OffersCollection collection)
        {
            foreach (KeyValuePair<int,Offer> pair in collection.Offers)
            {
                OfferView instance = Instantiate(_prefab, _parent);
                Sprite[] resourcesSprites = _spritesLoader.Execute(pair.Value.Resources);
                Sprite main = _spritesLoader.Execute(pair.Value.SpriteId);
                instance.Draw(pair.Key, pair.Value, resourcesSprites, main);

                _views.Add(pair.Key, instance);
                instance.Initialize();
                instance.BuyButtonClicked += OnBuyButtonClicked;
            }
        }

        public void Dispose()
        {
            foreach (OfferView offerView in _views.Values)
                DisposeView(offerView);
        }

        private void OnBuyButtonClicked(int key)
        {
            BuyOfferButtonClicked?.Invoke(key);

            OfferView offerView = _views[key];
            DisposeView(offerView);
            _views.Remove(key);
            Destroy(offerView.gameObject);
        }

        private void DisposeView(OfferView offerView)
        {
            offerView.Dispose();
            offerView.BuyButtonClicked -= OnBuyButtonClicked;
        }
    }
}