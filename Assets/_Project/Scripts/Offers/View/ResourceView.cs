using _Project.Offers.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Offers.View
{
    internal class ResourceView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _amount;

        public void Draw(Resource resource, Sprite sprite)
        {
            gameObject.SetActive(true);
            _image.sprite = sprite;
            _amount.text = resource.Count.ToString();
        }

        public void Hide() => 
            gameObject.SetActive(false);
    }
}