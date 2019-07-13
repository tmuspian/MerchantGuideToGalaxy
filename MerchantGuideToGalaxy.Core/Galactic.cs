namespace MerchantGuideToGalaxy.Core
{
    using System.Text;

    /// <summary>
    /// Classe de conversão Galactica
    /// </summary>
    public class Galactic
    {
        /// <summary>
        /// Metodo responsavel por converter numero galactico para romano.
        /// Data de Criação: 07/05/2017
        /// </summary>
        /// <param name="input">Entrada em texto do usuário</param>
        /// <returns></returns>
        private static string ConvertGalacticToRoman(string comands)
        {
            string[] arrayGalacticNumber = comands.ToUpper().Split(' ');
            var romanNumber = "";
            foreach (string number in arrayGalacticNumber)
            {
                switch (number)
                {
                    case "GLOB":
                        romanNumber += "I";
                        break;
                    case "PROK":
                        romanNumber += "V";
                        break;
                    case "PISH":
                        romanNumber += "X";
                        break;
                    case "TEGJ":
                        romanNumber += "L";
                        break;
                }
            }
            return romanNumber;
        }
        /// <summary>
        /// Metodo responsavel por calcular o numero de credito galactico.
        /// Data de Criação: 07/05/2017
        /// </summary>
        /// <param name="metalType">Tipo de Metal</param>
        /// <param name="romanNumber">Numero em Romano</param>
        /// <returns></returns>
        private static double CalculateGalacticCredit(MetalType metalType, string romanNumber)
        {
            var integer = Roman.ConvertRomanToInteger(romanNumber);
            switch (metalType)
            {
                case MetalType.None:
                    return integer;
                case MetalType.Iron:
                    return (195.5 * integer);
                case MetalType.Gold:
                    return (14450 * integer);
                case MetalType.Silver:
                    return (17 * integer);
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Retorna lista de Comandos 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string ReturnComands(string input)
        {
            var comands = new StringBuilder();
            var words = input.ToUpper().Split(" ");
            foreach (var word in words)
            {
                switch (word)
                {
                    case "PISH":
                    case "TEGJ":
                    case "GLOB":
                    case "PROK":
                        comands.Append(word + " ");
                        break;
                    default:
                        break;
                }
            }
            return comands.ToString();
        }

        /// <summary>
        /// Consulta a bibloteca de calculo galactico e retorna para o usuario a resposta da pergunta.
        /// </summary>
        /// <param name="input">Frase digitada pelo usuário</param>
        public static string ToAsk(string input)
        {
            input = input.Replace("?", " ?");
            if (input.Contains("?"))
            {
                var comands = ReturnComands(input);
                var romanNumbers = ConvertGalacticToRoman(comands);
                var metal = Metal.ReturnMetal(input);
                var credit = CalculateGalacticCredit(metal, romanNumbers);
                if (credit > 0)
                {
                    if (metal == MetalType.None)
                        return string.Concat(comands.ToLower(), "is ", credit.ToString());
                    else
                        return string.Concat(comands.ToLower(), metal, " is ", credit.ToString(), " Credits");
                }
                else
                    return "I have no idea what you are talking about";
            }
            else
                return string.Empty;
        }
    }
}
