using System.Collections.Generic;

namespace Calculator.Model
{
    public class CalculatorMomento
    {
        public string inputText;
        public List<string> resultHistory;

        public CalculatorMomento()
        {
            inputText = "";
            resultHistory = new List<string>();
        }
    }
}
