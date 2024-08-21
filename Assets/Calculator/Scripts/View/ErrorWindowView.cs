using UnityEngine;
using UnityEngine.UI;

namespace Calculator.View
{
    public class ErrorWindowView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        public void Init()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            closeButton.onClick.AddListener(Close);
        }

        private void Close()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }
    }
}
