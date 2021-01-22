using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace CardUtilities
{
    public class CardBuilder
    {

        //private List<Card> Build(string cardValue) 
        //{
        //    List<Card> cardsList = new List<Card>();

        //    return cardsList;
        //}
        private const string PATTERN_NUMBER = @"\b([2-9]|10|[JQKA])";
        private const string PATTERN_SUIT = @"[CDHS]\b";
        public void Build(string cardValue) 
        {
            //Regex cardRegex = new Regex(PATTERN_CARD);
            //foreach()

            //Working for getting the numbers only
            //var testMatch = Regex.Matches(cardHolder, PATTERN_NUMBER);
            //foreach (Match match in testMatch)
            //{
            //    Console.WriteLine(match.Value);
            //}
        }
    }
}
