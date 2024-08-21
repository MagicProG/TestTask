using System;
using UnityEditor;
using UnityEngine;

namespace Calculator.View
{
    public interface IPresenter
    {
        public void ResultRequest(string result);

        public void SaveInputRequest(string input);
    }
}