
namespace CardUtilities
{
    static class Constants 
    {
        public const int MIN_CARD = 5;
        //paterns
        public const string PATTERN_CARD = @"\b([2-9]|10|[JQKA])[CDHS]\b";
        public const string PATTERN_VALUE = @"\b([2-9]|10|[JQKA])";
        public const string PATTERN_SUIT = @"[CDHS]\b";
    }
}
