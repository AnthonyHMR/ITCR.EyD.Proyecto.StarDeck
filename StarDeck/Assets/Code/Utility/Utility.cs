using System;
using System.Text;

public class Utility
{
    public static string ToAlphaNumeric(string input)
    {
        StringBuilder result = new StringBuilder();
        foreach (char c in input)
        {
            if (Char.IsLetterOrDigit(c))
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
}
