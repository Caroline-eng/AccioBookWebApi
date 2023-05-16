using AccioBook.CrossCutting.Criptografy;
using AccioBook.WepApi.Models;

namespace AccioBook.CrossCutting.Criptografy.Test
{
    public class CriptografyClient
    {
        private static string ENCRYPT_KEY = UserModel.PASS_KEY;

        public void Start()
        {
            bool clientOn = true;

            Console.WriteLine("****************************");
            Console.WriteLine("*					   Sistema de Criptografia AES	        	               ");
            Console.WriteLine("*                        Caroline Rangel Barbosa                              ");
            Console.WriteLine("****************************");

            while (clientOn)
            {
                Console.WriteLine("Entre com a Opção: \n  1 - Criptografar Texto \n  2 - Descriptografar Texto \n  9 - Sair");
                string? option = Console.ReadLine();

                if (option != null)
                    clientOn = RunMainMenuOption(option);

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }

            Console.WriteLine("Saindo da Aplicação... good bye!");
        }

        private bool RunMainMenuOption(string option)
        {
            option = option.Trim();

            if ("9".Equals(option))
                return false;

            if ("1".Equals(option))
                return GetUserTextEncryptAndShow();
            else if ("2".Equals(option))
                return GetUserTextDecryptAndShow();

            Console.WriteLine("OPÇÃO INVÁLIDA! [{0}]", option);
            return true;
        }

        private bool GetUserTextEncryptAndShow()
        {
            Console.WriteLine("Entre com o Texto para ser CRIPTOGRAFADO:");
            string? textToEncrypt = Console.ReadLine();
            if (!string.IsNullOrEmpty(textToEncrypt))
                Console.WriteLine("CRIPTOGRAFADO: [{0}]", textToEncrypt.Encrypt(ENCRYPT_KEY));
            else
                Console.WriteLine("Etre um Valor não Nulo!");

            return true;
        }

        private bool GetUserTextDecryptAndShow()
        {
            Console.WriteLine("Entre com o Texto para ser DESCRIPTOGRAFADO (VALOR;IV):");
            string? textToDecrypt = Console.ReadLine();
            if (!string.IsNullOrEmpty(textToDecrypt))
                Console.WriteLine("DESCRIPTOGRAFADO: [{0}]", textToDecrypt.Decrypt(ENCRYPT_KEY));
            else
                Console.WriteLine("Etre um Valor não Nulo!");

            return true;
        }
    }
}