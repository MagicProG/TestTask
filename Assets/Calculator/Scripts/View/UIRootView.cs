using System.Collections.Generic;
using UnityEngine;

namespace Calculator.View
{
    public class UIRootView: MonoBehaviour
    {
        [SerializeField] CalculatorView calculatorView;
        [SerializeField] ErrorWindowView errorWindowView;

        protected IPresenter _presenter;

        public void Init(IPresenter presenter)
        {
            _presenter = presenter;

            calculatorView.Init(presenter);
            errorWindowView.Init();
        }

        public void AddResult(bool success, string output)
        {
            if (!success)
            {
                errorWindowView.Open();
            }
            calculatorView.AddResult(success, output);
        }

        public void RestoreMomento(string input, List<string> history)
        {
            calculatorView.RestoreMomento(input, history);
        }
    }
}
