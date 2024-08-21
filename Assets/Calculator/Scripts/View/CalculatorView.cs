using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Calculator.View
{
    public class CalculatorView : MonoBehaviour
    {
        [SerializeField] private Button resultButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private HistoryView historyView;

        private IPresenter _presenter;

        private void Awake()
        {
            resultButton.onClick.AddListener(ResultRequest);
            inputField.onSubmit.AddListener(ResultRequest);
        }

        public void Init(IPresenter presenter)
        {
            _presenter = presenter;
        }

        private void ResultRequest()
        {
            ResultRequest(inputField.text);
        }

        private void ResultRequest(string result)
        {
            _presenter.ResultRequest(result);
        }

        public void RestoreMomento(string input, List<string> history)
        {
            historyView.SetHistory(history);
            inputField.text = input;
        }

        public void AddResult(bool success,string output)
        {
            if (success)
            {
                inputField.text = "";
            }
            historyView.AddResult(output);
        }

        private void OnApplicationQuit()
        {
            _presenter.SaveInputRequest(inputField.text);
        }
    }
}
