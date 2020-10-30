using System;
using VigenereAlgoritm;

class Program
{
    static void Main(string[] args)
    {
        
        var cipher = new VigenereCipher();
        Console.Write("Enter your text: ");
        var inputText = Console.ReadLine().ToUpper();
        Console.Write("Enter your keyword: ");
        var password = Console.ReadLine().ToUpper();
        var encryptedText = cipher.Encrypt(inputText, password);
        Console.WriteLine("Decoding: {0}", encryptedText);
        Console.WriteLine("Encode: {0}", cipher.Decrypt(encryptedText, password));
        Console.ReadLine();
    }
}