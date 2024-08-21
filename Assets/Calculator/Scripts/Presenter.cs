using Calculator.Model;
using Calculator.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : Calculator.Model.IPresenter, Calculator.View.IPresenter
{
    private UIRootView _uiRoot;
    private CalculatorModel _model;

    public void Init(UIRootView view, CalculatorModel model)
    {
        _uiRoot = view;
        _model = model;
    }

    public void ResultRequest(string input)
    {
        _model.GetResult(input);
    }

    public void ResultResponse(bool success, string output)
    {
        _uiRoot.AddResult(success, output);
    }

    public void SaveInputRequest(string input)
    {
        _model.SaveMomento(input);
    }

    public void RestoreMomento(CalculatorMomento calculatorMomento)
    {
        _uiRoot.RestoreMomento(calculatorMomento.inputText, calculatorMomento.resultHistory);
    }
}
