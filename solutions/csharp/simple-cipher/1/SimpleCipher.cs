using System.Text;
using System.Linq;

public class SimpleCipher
{
    private static readonly Random _random = new Random();
    
    public SimpleCipher(): this(GenerateRandomKey()) { }
    /*{
        Key = GenerateRandomKey();
    }*/

    public SimpleCipher(string key)
    {
        Key = key; 
    }
    
    public string Key { get; }

    public string Encode(string plaintext) => 
        Shift(plaintext, (p, k) => (p + k) % 26);

    public string Decode(string ciphertext) => 
        Shift(ciphertext, (c, k) => (c - k + 26) % 26);

    //shiftFunc is a function delegate (a parameter of type Func<int, int, int>).
    //That means it’s just a function you can pass into Transform to decide how the shifting works.
    private string Shift(string text, Func<int, int, int> shiftFunc) =>
        new string(text.Select((ch, i) =>
        {
            int textIndex = ch - 'a';
            int keyIndex = Key[i % Key.Length] - 'a';
            int shifted = shiftFunc(textIndex, keyIndex);
            return (char)('a' + shifted);
        }).ToArray());

    public static string GenerateRandomKey(int length = 100) =>
        new string(Enumerable.Range(0, length)
            .Select(_ => (char)('a' + _random.Next(26)))
            .ToArray());

    /*public string Encode(string plaintext)
    {
        StringBuilder encoded = new StringBuilder();
        
        for (int i = 0; i < plaintext.Length; i++)
        {
            int plaintextCharIndex = plaintext[i] - 'a';
            int keyCharIndex = Key[i % Key.Length] - 'a';

            int shiftedIndex = (plaintextCharIndex + keyCharIndex) % 26;
            encoded.Append((char)('a' + shiftedIndex));
        }
        return encoded.ToString();
    }*/

    /*public string Decode(string ciphertext)
    {
        StringBuilder decoded = new StringBuilder();
        
        for (int i = 0; i < ciphertext.Length; i++)
        {
            int ciphertextCharIndex = ciphertext[i] - 'a';
            int keyCharIndex = Key[i % Key.Length] - 'a';

            // Use the formula (a - b + 26) % 26 to handle negative results correctly
            int shiftedIndex = (ciphertextCharIndex - keyCharIndex + 26) % 26;
            decoded.Append((char)('a' + shiftedIndex));
        }
        return decoded.ToString();
    }*/

    /*public static string GenerateRandomKey()
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 100; i++)
        {
            sb.Append((char)('a' + random.Next(0, 26)));
        }

        return sb.ToString();
    }*/
}