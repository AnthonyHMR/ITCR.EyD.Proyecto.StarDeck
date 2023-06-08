using System;
using System.Linq;
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

    public static string GenerateRandomID()
    {
        // Define the characters that can be used in the ID
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        // Generate a random 12-character string from the characters above
        string randomString = new string(Enumerable.Repeat(chars, 12)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        // Insert the "U" at the beginning of the string
        randomString = "U-" + randomString;

        // Make sure the string does not contain any consecutive characters
        for (int i = 0; i < randomString.Length - 1; i++)
        {
            if (randomString[i] == randomString[i + 1])
            {
                // Replace the consecutive characters with a new random character
                char[] charsArray = randomString.ToCharArray();
                charsArray[i + 1] = chars[random.Next(chars.Length)];
                randomString = new string(charsArray);
            }
        }

        // Return the final random ID
        return randomString;
    }
}
