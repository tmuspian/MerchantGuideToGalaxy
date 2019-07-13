namespace MerchantGuideToGalaxy.Core
{
    /// <summary>
    /// Metais
    /// </summary>
    public class Metal
    {
        /// <summary>
        /// Função responsavel por retornar qual o metal de um input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Metal</returns>
        public static MetalType ReturnMetal(string input)
        {
            var words = input.ToUpper().Split(" ");
            foreach (var word in words)
            {
                switch (word)
                {
                    case "SILVER":
                        return MetalType.Silver;
                    case "GOLD":
                        return MetalType.Gold;
                    case "IRON":
                        return MetalType.Iron;
                    default:
                        break;
                }
            }
            return MetalType.None;
        }

    }
}
