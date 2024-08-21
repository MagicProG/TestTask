using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Model
{
    public class CalculatorModel
    {
        private const string ERROR_TEXT = "ERROR";
        private const string MOMENTO_SAVE_LABEL = "MOMENTO";

        private string ErrorText => ERROR_TEXT;

        private IPresenter _presenter;
        private ISaveLoad _saveLoad;
        private AdditionService _additionService;

        private CalculatorMomento _momento;

        public CalculatorModel(IPresenter presenter, ISaveLoad saveLoad, AdditionService additionService)
        {
            _presenter = presenter;
            _saveLoad = saveLoad;
            _additionService = additionService;
        }

        public void Init()
        {
            _momento = _saveLoad.Load<CalculatorMomento>(MOMENTO_SAVE_LABEL);

            if (_momento == null)
            {
                _momento = new CalculatorMomento();
            }

            _presenter.RestoreMomento(_momento);
        }

        public void GetResult(string input)
        {
            var result = input + "=";
            try
            {
                var response = _additionService.TryAddition(input);
                result += response;
                _presenter.ResultResponse(true, result);
            }
            catch (Exception ex)
            {
                result += ErrorText;
                _presenter.ResultResponse(false, result + ErrorText);
            }
            finally
            {
                _momento.resultHistory.Add(result);
                _saveLoad.Save(MOMENTO_SAVE_LABEL, _momento);
            }
        }

        public void SaveMomento(string input)
        {
            _momento.inputText = input;
            _saveLoad.Save(MOMENTO_SAVE_LABEL, _momento);
        }
    }
}
