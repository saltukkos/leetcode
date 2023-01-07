using System.Collections.Generic;

namespace Solutions
{
    /// <summary>
    /// Generate Parentheses
    /// https://leetcode.com/problems/generate-parentheses/
    /// </summary>
    public static class Problem22
    {
        private const char OpenSymbol = '(';
        private const char CloseSymbol = ')';

        public static IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            FillSubParenthesis(string.Empty, n, 0, result);
            return result;
        }

        private static void FillSubParenthesis(string state, int pairsToOpen, int openExceedCount, List<string> result)
        {
            if (pairsToOpen == 0)
            {
                if (openExceedCount == 0)
                {
                    result.Add(state);
                    return;
                }
                
                FillSubParenthesis(state + CloseSymbol, pairsToOpen, openExceedCount - 1, result);
                return;
            }

            if (pairsToOpen > 0)
            {
                FillSubParenthesis(state + OpenSymbol, pairsToOpen - 1, openExceedCount + 1, result);
            }

            if (openExceedCount > 0)
            {
                FillSubParenthesis(state + CloseSymbol, pairsToOpen, openExceedCount - 1, result);
            }
        }
    }
}