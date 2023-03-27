namespace BitwiseOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string FOLDER_PATH = @"C:\Users\rokas.cvirka\Documents\";
            const string ENCRYPTION_KEY_FILE = FOLDER_PATH + "key.txt";
            const string TEXT_FILE = FOLDER_PATH + "text.txt";
            const string ENCRYPTED_TEXT = FOLDER_PATH + "encrypted.txt";
            const string DECRYPTED_TEXT = FOLDER_PATH + "decrypted.txt";
            

            //Read
            string text = File.ReadAllText(TEXT_FILE);
            
            //Read encryption
            byte[] keyBytes = File.ReadAllBytes(ENCRYPTION_KEY_FILE);
            byte encryptionKey = keyBytes[0];

            //Encrypt
            byte[] textBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] encryptedText = new byte[textBytes.Length];

            for (int i = 0; i < textBytes.Length; i++)
            {
                encryptedText[i] = (byte)(textBytes[i] ^ encryptionKey);
            }

            //Write to file
            File.WriteAllBytes(ENCRYPTED_TEXT, encryptedText);

            //Read encrypted message
            byte[] encryptedBytes = File.ReadAllBytes(ENCRYPTED_TEXT);

            //Decrypt
            byte[] decryptedBytes = new byte[encryptedBytes.Length];
            
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedBytes[i] ^ encryptionKey);
            }

            string decryptedText = System.Text.Encoding.ASCII.GetString(decryptedBytes);

            //Write decrypted message
            File.WriteAllText(DECRYPTED_TEXT, decryptedText);
            Console.WriteLine("Decryption complete.");

        }
    }
}