using Calculator.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Model
{
    public interface IPresenter
    {
        void RestoreMomento(CalculatorMomento momento);
        void ResultResponse(bool success, string result);
    }
}
