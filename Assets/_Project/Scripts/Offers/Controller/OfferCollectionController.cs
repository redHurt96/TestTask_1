using _Project.Model;
using _Project.Offers.View;

namespace _Project.Offers.Controller
{
    public class OfferCollectionController
    {
        private readonly OffersCollection _offers;
        private readonly OffersCollectionView _offersCollectionView;

        public OfferCollectionController(OffersCollection offers, OffersCollectionView offersCollectionView)
        {
            _offers = offers;
            _offersCollectionView = offersCollectionView;
        }

        public void Initialize()
        {
            _offersCollectionView.Draw(_offers);
            _offersCollectionView.BuyOfferButtonClicked += RemoveOffer;
        }

        public void Dispose()
        {
            _offersCollectionView.BuyOfferButtonClicked -= RemoveOffer;
            _offersCollectionView.Dispose();
        }

        private void RemoveOffer(int key) => 
            _offers.Remove(key);
    }
}
