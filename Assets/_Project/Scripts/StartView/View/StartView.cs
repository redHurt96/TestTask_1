using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.StartView.View
{
    public class StartView : MonoBehaviour
    {
        public event Action<int> InputFieldChanged;
        public event Action ShowButtonClicked;
        
        [SerializeField] private TMP_InputField _input;
        [SerializeField] private Button _show;

        public void Initialize()
        {
            _input.onValueChanged.AddListener(FireInputEvent);
            _show.onClick.AddListener(FireButtonEvent);
        }

        private void FireInputEvent(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                _show.interactable = false;
                return;
            }

            _show.interactable = true;
            
            if (!int.TryParse(value, out int parsed))
                throw new Exception($"Something wrong with input!");
            
            InputFieldChanged?.Invoke(parsed);
        }

        private void FireButtonEvent() => 
            ShowButtonClicked?.Invoke();
    }
}