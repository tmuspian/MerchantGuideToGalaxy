namespace MerchantGuideToGalaxy.Core
{
    using System;
    using System.Collections;

    /// <summary>
    /// Classe de conversão de numeros romanos.
    /// </summary>
    public class Roman
    {
        /// <summary>
        /// Metodo responsavel por converter um numero romano em um numero inteiro.
        /// Data de criação: 07/05/2017
        /// </summary>
        /// <param name="romanNumber">Numero Romano</param>
        /// <returns>Numero inteiro</returns>
        public static int ConvertRomanToInteger(string romanNumber)
        {
            //Trata informação digitada
            romanNumber = romanNumber.ToUpper().Trim();
            if (romanNumber == "N")
                return 0;

            // Cria um Array contendo os valores
            var position = 0;
            var values = new ArrayList();
            var maximumDigit = 1000;
            while (position < romanNumber.Length)
            {
                // valor base do digito
                var numeral = romanNumber[position];
                var digit = Convert.ToInt32(Enum.Parse(typeof(RomanNumbers), numeral.ToString()));

                // proximo digito
                var nextDigit = 0;
                if (position < romanNumber.Length - 1)
                {
                    char nextNumber = romanNumber[position + 1];
                    nextDigit = Convert.ToInt32(Enum.Parse(typeof(RomanNumbers), nextNumber.ToString()));

                    if (nextDigit > digit)
                    {
                        maximumDigit = digit - 1;
                        digit = nextDigit - digit;
                        position += 1;
                    }
                }
                values.Add(digit);

                // proximo digito
                position += 1;
            }
            //Numero maior deve ser colocado sempre à esquerda dos números menores. 
            var total = 0;
            foreach (int digit in values)
            {
                total += digit;
            }
            return total;
        }
        /// <summary>
        /// Metodo responsavel por validar se o numero romano é um numero valido.
        /// Data de criação: 07/05/2017
        /// </summary>
        /// <param name="romanNumber">Numero Romano</param>
        /// <param name="return">Retorno</param>
        /// <returns></returns>
        public static bool ValidateRomanNumeral(string romanNumber, out string @return)
        {
            //Trata informação digitada
            romanNumber = romanNumber.ToUpper().Trim();

            //Valida se o numero romano informado, possui algarismos inválido. 
            if (romanNumber.Split('V').Length > 2 || romanNumber.Split('L').Length > 2 || romanNumber.Split('D').Length > 2)
            {
                @return = "Algarismos inválidos ! O número informado possui um algarismo V(Prok) ,L(Tegj) repetido.";
                return false;
            }
            //Valida se a letra foi digitada mais de 3 vezes. 
            var counter = 1;
            var last = 'Z';
            foreach (char number in romanNumber)
            {
                // Algarismo inválido ?
                if ("IVXLCDM".IndexOf(number) == -1)
                {
                    @return = "Algarismo inválido!";
                    return false;
                }
                // Duplicado?
                if (number == last)
                {
                    counter += 1;
                    if (counter == 4)
                    {
                        @return = "Algarismo não pode ser repetido mais de 3 vezes no mesmo número";
                        return false;
                    }
                }
                else
                {
                    counter = 1;
                    last = number;
                }
            }
            // Cria um Array contendo os valores
            var position = 0;
            var values = new ArrayList();
            var maximumDigit = 1000;
            while (position < romanNumber.Length)
            {
                // valor base do digito
                var numeral = romanNumber[position];
                var digit = Convert.ToInt32(Enum.Parse(typeof(RomanNumbers), numeral.ToString()));

                //Somente um digito de pequeno valor pode ser subtraído de qualquer símbolo de maior valor.
                if (digit > maximumDigit)
                {
                    @return = "Verifique a posição do algarismo digitado.";
                    return false;
                }
                //Proximo digito
                var nextDigit = 0;
                if (position < romanNumber.Length - 1)
                {
                    char nextNumber = romanNumber[position + 1];
                    nextDigit = Convert.ToInt32(Enum.Parse(typeof(RomanNumbers), nextNumber.ToString()));

                    if (nextDigit > digit)
                    {
                        if ("IXC".IndexOf(numeral) == -1 || nextDigit > (digit * 10) || romanNumber.Split(numeral).Length > 3)
                        {
                            @return = "Algarismo inválido.";
                            return false;
                        }
                        maximumDigit = digit - 1;
                        digit = nextDigit - digit;
                        position += 1;
                    }
                }
                values.Add(digit);

                //Proximo digito
                position += 1;
            }
            //Regra responsável por validar cada numero da esquerda para direita.  
            for (int i = 0; i <= values.Count - 2; i++)
            {
                if (Convert.ToInt32(values[i]) < Convert.ToInt32(values[i + 1]))
                {
                    @return = "Algarismo inválido. O algarismo não pode ser maior que valor anterior.";
                    return false;
                }
            }
            @return = "";
            return true;
        }
    }
}

