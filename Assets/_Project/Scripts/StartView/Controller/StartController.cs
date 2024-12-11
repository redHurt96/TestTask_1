using System;

namespace _Project.StartView.View
{
    public class StartController
    {
        public event Action ShowCollectionIntent;
        
        private readonly StartModel _model;
        private readonly StartView _view;

        public StartController(StartModel model, StartView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _view.InputFieldChanged += UpdateModel;
            _view.ShowButtonClicked += ShowOffersCollection;
            _view.Initialize();
        }

        public void Dispose()
        {
            _view.InputFieldChanged -= UpdateModel;
            _view.ShowButtonClicked -= ShowOffersCollection;
        }

        public void Hide() => 
            _view.gameObject.SetActive(false);

        private void UpdateModel(int offersCount) => 
            _model.OffersCount = offersCount;

        private void ShowOffersCollection() =>
            ShowCollectionIntent?.Invoke();
    }
}