namespace DevChallenge.Domain;

public class Messages
{
    public class InvalidInput
    {
        public const string NegativeIntegers = "Invalid input format. Please use only positive integers";
    }

    public class InvalidSheet
    {
        public const string TooSmall = "Invalid sheet size. Too small for producing at least one box";
    }
}