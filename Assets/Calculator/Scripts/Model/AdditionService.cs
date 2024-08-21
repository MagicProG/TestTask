using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Calculator.Model
{
    public class AdditionService
    {
        public string TryAddition(string input)
        {
            string number = "";
            int result = 0;
            int plusCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    number += input[i];
                }
                else if (input[i] == '+')
                {
                    plusCount++;
                    if (number.Length > 0)
                    {
                        result += int.Parse(number);
                        number = "";
                    }
                    else
                    {
                        throw new WrongEquationException();
                    }
                }
                else
                {
                    throw new WrongEquationException();
                }
            }

            if (number.Length > 0 && plusCount > 0)
            {
                result += int.Parse(number);
            }
            else
            {
                throw new WrongEquationException();
            }

            return result.ToString();
        }
    }
}
