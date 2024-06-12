using System.Security.Cryptography;
using System.Text;

namespace Application.Utils;

public static class StringUtils
{
    public static string Hash(this string input)
    {
        using (var sha = SHA256.Create())
        {
            var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    //Convert from "StringString" to "String String"
    public static string GenerateStringFormat(this string input)
    {
        var arr = input.ToCharArray();
        var result = "";

        foreach (var c in arr)
            if (c >= 'A' && c <= 'Z')
                result += " " + c;
            else
                result += c + "";

        return result;
    }

    //Convert from "String String" to "StringString"
    public static string RegenerateStringFormat(this string input)
    {
        while (input.Contains(" ")) input = input.Replace(" ", "");
        return input;
    }
}