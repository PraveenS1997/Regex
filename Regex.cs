using System.Text.RegularExpressions;

public sealed class Program
{
    // Regex stands for Regular expressions
    // Regular expressions are a way to search for patterns in datasets
    // Regular expression is a feature, that is supported in almost all programming languages
    // Use cases of Regular expressions
        // Password check in google while creating an account (password should've 8 characters with mix of numbers or special character
        // Search using RegEx mode in notepad++
    public static void Main()
    {
        SingleCharacter();
        ZeroOrMoreOccurencesOfAParticularCharacter();
        ZeroOrMoreOccurencesOfAnyCharacters();
        ZeroOrMoreOccurencesOfWhitespace();
        CharacterClass_Positive();
        CharacterClass_Negative();
        CharacterClass_With_Range_Postive_And_Negative();
        CharacterClass_Combination_Of_Range_And_Individual_Characters();
        CharacterClass_With_Multiple_Ranges_And_Individual_Characters();
        EscapeCharacters_In_Regex_Pattern();
        ShouldStartWith_Certain_Characters();
        ShouldEndWith_Certain_Characters();
        ShouldHaveOnlyOneWord();
        MatchThreeDigitNumbers();
        MatchEither_4_Or_5_Or_6_Letter_Words();
        Match_Group_Of_Letters_More_Than_4_Times();
        OneOrMoreOccurencesOfAParticularCharacter();
        ZeroOrOneOccurenceOfACharacter();
        PipeSymbol_To_Match_Either_A_or_B();
    }

    private static void SingleCharacter()
    {
        // "." should match that, the given input should have one character which can be anything
        // "foo.bar" regex matches all the inputs that contains word "foo" followed by exactly one
        // single character which can be anything after "foo" & followed by the word "bar" anywhere in the input string.

        var input = "foobar doofooabardoo foocbar fooaaaabar barfoo foosbar foovbar fooacbar";
        var pattern = "foo.bar";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void ZeroOrMoreOccurencesOfAParticularCharacter()
    {
        // "*" should match the given character appears zero or more times
        // "a*" should match if the string contains only character "a" zero or more times
        // "fooa*bar" matches all the inputs that contains the word "foo" followed by zero or more occurrences of
        // only letter "a" , then followed by the word "bar"

        var input = "foobar fooabar fooaabar fooaaaabar barfoo foosbar foovbar fooacbar";
        var pattern = "fooa*bar";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void ZeroOrMoreOccurencesOfAnyCharacters()
    {
        // "*" should match the given character appears zero or more times
        // "foo.*bar" matches all the inputs that contains the word "foo" followed by zero or more occurrences of
        // any character, then followed by the word "bar"

        var pattern = "foo.*bar";
        var input = "foobar fooabar fooabbar fooaaaabar barfoo foosbar foovdbar fooactbar";

        PatternMatch(input.Split(' '), pattern);
    }
    
    private static void ZeroOrMoreOccurencesOfWhitespace()
    {
        // "\s" represents a single whitespace
        // "foo\s*bar" matches all the inputs that contains zero or more occurrences of whitespaces
        // between "foo" and "bar" words

        var input = new string[]
        {
            "foobar",
            "foo bar",
            "foo  bar",
            "bar foo",
            "foo abar"
        };
        var pattern = @"foo\s*bar";

        PatternMatch(input, pattern);
    }

    private static void CharacterClass_Positive()
    {
        // Regex should match all the words which contains the suffix "oo" and start with character "a" or "b" or "c"
        // "[abc]" matches one character position & the possible values for that position could be either "a" or "b" or "c"

        var input = "aoo boo coo doo eoo foo goo hoo ioo joo";
        var pattern = "[abc]oo";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void CharacterClass_Negative()
    {
        // Regex should match all the words which contains the suffix "oo" and doesn't start with character "a" or "b" or "c"
        // [^abc] matches one character position & the possible value for that position should not be either a or b or c.

        var input = "aoo boo coo doo eoo foo goo hoo ioo joo";
        var pattern = "[^abc]oo";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void CharacterClass_With_Range_Postive_And_Negative()
    {
        // Regex should match all the words which contains the suffix "oo" and start with character
        // in the range [d, e, f] or "d" to "f"
        // [d-f] matches one character position & the possible values for that position should be
        // in the range "d" to "f"

        var input = "aoo boo coo doo eoo foo goo hoo ioo joo";
        var pattern = "[d-f]oo";

        PatternMatch(input.Split(' '), pattern);

        // [^d-f] matches one character position & the possible values for that position shouldn't be
        // in the range "d" to "f"

        Console.WriteLine("Negative Character class Range example");
        pattern = "[^d-f]oo";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void CharacterClass_Combination_Of_Range_And_Individual_Characters()
    {
        // Regex should match all the words which contains the suffix "oo" and starting character should be
        // in the range [d, e, f] or "d" to "f" or any of the other choices given in the square bracket
        // [d-fz] matches one character position & the possible values for that position should be in the range
        // "d" to "f" or it could be "z"

        var input = "aoo boo coo doo eoo foo goo hoo ioo joo zoo";
        var pattern = "[d-fz]oo";

        PatternMatch(input.Split(' '), pattern);

        // [^d-fz] matches one character position & the possible values for that position shouldn't be in the range
        // "d" to "f" and "z"

        Console.WriteLine("Negative Character class Range with individual characters example");
        pattern = "[^d-fz]oo";
        PatternMatch(input.Split(' '), pattern);
    }

    private static void CharacterClass_With_Multiple_Ranges_And_Individual_Characters()
    {
        // Regex should match all the words which contains the suffix "oo" and the prior character should be
        // in the range [d, e, f] or ["D", "E", "F"] or any of the other choices given in the square bracket
        // [d-fD-Fz] matches one character position & the possible values for that position should be in the range
        // "d" to "f" or "D" to "F" or it could be "z"

        var input = "aoo boo coo doo Eoo foo goo hoo ioo joo zoo";
        var pattern = "[d-fD-Fz]oo";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void EscapeCharacters_In_Regex_Pattern()
    {
        // The character "." has a special meaning to Regex engine (it represents any single character)
        // In the below case, we have the character "." as part of the input string, we need to create a pattern which matches
        // the character "." itself
        // Zero or more occurrences of "x" followed by "." followed by Zero or more occurrences of "y"

        var input = "xx.yyyy x.y xxx.yy xxxx.yyyyy y.x yyxx xx&yyy x^yy";
        var pattern = @"x*\.y*";

        PatternMatch(input.Split(' '), pattern);

        // character "." doesn't need to be escaped if its used inside character class [#:.]
        // but few characters like "^", "-" needs to escaped with backslash "\" if we need to match those character as literals.

        input = "x:y x#y x.y x&y x*y y#x";
        pattern = "x[#:.]y";

        PatternMatch(input.Split(' '), pattern);

        // match only "x" followed by either ":" or "#" or "^" followed by "y"
        input = "x:y x#y x^y x&y x*y y#x";
        pattern = @"x[#:\^]y";

        PatternMatch(input.Split(' '), pattern);

        // if we have "\" in the string & want to match it, we need to escape it, since "\" is a escape character (ie. \. \^)
        // "\" can be escaped with adding another "\" before it to treat it as "\" literal
        input = @"x\y x#y x^y x&y x*y y#x";
        pattern = @"x[\^#\\]y";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void ShouldStartWith_Certain_Characters()
    {
        // If we want to pick few words out of all, which starts with "foo"
        // We can use "^" to achieve that, "^" is used as a negation inside the "[ ]" character class
        // But outside the character class "[ ]", its used as a placeholder that signifies the beginning of the word

        var input = new string[]
        {
            "foo bar baz",
            "bar foo baz",
            "foo baz bar",
            "baz bar foo",
            "bar bar foo"
        };

        // I want to match all the words starts with "foo", after "foo" it can contain anything
        // "^" will match at the beginning not anywhere in the middle of the string
        var pattern = "^foo.*";

        PatternMatch(input, pattern);
    }

    private static void ShouldEndWith_Certain_Characters()
    {
        // If we want to pick few words out of all, which ends with "bar"
        // We can use "$" to achieve that, its used as a placeholder that signifies the end of the word or line

        var input = new string[]
        {
            "foo bar baz",
            "bar foo baz",
            "foo baz bar",
            "baz foo bar",
            "bar bar foo"
        };

        // I want to match all the words ends with "bar", before "bar" it can contain anything
        // "$" will match at the end & not anywhere in the middle of the string
        var pattern = ".*bar$";

        PatternMatch(input, pattern);
    }

    private static void ShouldHaveOnlyOneWord()
    {
        // If we want to match exactly one word like "foo"
        // Combine both "^" & "$" symbol for it, the word should start with "foo" & ends with "foo"

        var input = new string[]
        {
            "foo",
            "foo bar",
            "bar baz",
            "foo foo",
            "foofoo"
        };

        var pattern = "^foo$";
        PatternMatch(input, pattern);
    }

    private static void MatchThreeDigitNumbers()
    {
        // If we want to pick up all the 3 digit numbers out of all numbers
        // one way is to use this pattern -> "^[0-9][0-9][0-9]$" (this option would be hard if we want to match 10 digit number)
        // "^" & "$" anchor symbols are used so that, the regex engine will
        // match the entire string, instead of matching it in the middle of a string

        var input = new string[]
        {
            "123",
            "12",
            "879",
            "1",
            "134",
            "8765"
        };

        // Using anchors "^" & "$" at the start & end of the string to match the entire string
        // instead of a portion of a string.
        // "a{3}" matches all the string which contains 3 consecutive "a"'s in the string
        // "^[0-9]{3}$" in the input string, from the start to end, there should be only 3 characters & the
        // possible values for all those 3 digits are from [0-9]
        var pattern = "^[0-9]{3}$";

        PatternMatch(input, pattern);
    }

    private static void MatchEither_4_Or_5_Or_6_Letter_Words()
    {
        // If we want to pick all the words which have either 4 letters
        // Or 5 letters Or 6 letters in the entire string
        // "^[a-z]{4,6}$" inside the repition curly braces first digit represent
        // the min number of repition and the second digit after comma represents the max number of repition

        var input = new string[]
        {
            "lion",
            "tiger",
            "leopard",
            "fox",
            "kangaroo",
            "deer",
            "cuckoo"
        };

        var pattern = "^[a-z]{4,6}$";

        PatternMatch(input, pattern);
    }

    private static void Match_Group_Of_Letters_More_Than_4_Times()
    {
        // Match all the strings which has the word "ha" repeated more than 4 times
        // Use parantheses to consider group of letters combined together as a single entity
        // And apply repetition on that single entity (ha)

        var input = new string[]
        {
            "ha",
            "hahaha",
            "haha",
            "hahahahahahaha",
            "hahahahahaha",
            "hahahahahahahahahaha",
            "hahahaha",
            "hahahahaha"
        };

        // If we want to match all the words which have "ha" repeated more than 4 times
        // mention the minimum number inside the curly brace repeater

        var pattern = "^(ha){4,}$"; // minimum 4 "ha" should be repeated & max can be any number

        PatternMatch(input, pattern);

        // If we want to match all the words which have "ha" repeated <= 2 times
        // mention the maximum number inside the curly brace repeater

        pattern = "^(ha){0,2}$"; // maximum 2 "ha" should be repeated, minimum can be any number <= 2

        PatternMatch(input, pattern);
    }

    private static void OneOrMoreOccurencesOfAParticularCharacter()
    {
        // "+" should match the given character appears 1 or more times
        // "a+" should match if the string contains only character "a" one or more times
        // "fooa+bar" matches all the inputs that contains the word "foo" followed by one or more occurrences of
        // only letter "a" , then followed by the word "bar"

        var input = "foobar fooabar fooaabar fooaaaabar barfoo foosbar foovbar fooacbar";
        var pattern = "fooa+bar";

        PatternMatch(input.Split(' '), pattern);
    }

    private static void ZeroOrOneOccurenceOfACharacter()
    {
        // If we want to match something either 0 ot 1 time exactly using "?" binary wildcard
        // "a?" matches the character "a" zero or 1 time

        var input = new string[]
        {
            "https://website",
            "http://website",
            "httpss://website",
            "httpx://website"
        };

        var pattern = "https?://website";

        PatternMatch(input, pattern);
    }

    private static void PipeSymbol_To_Match_Either_A_or_B()
    {
        // If we want to match either (a | b) using pipe symbol

        var input = new string[]
        {
            "logwood",
            "sandwood",
            "plywood",
            "teakwood",
            "peakwood"
        };

        var pattern = "(log|ply)wood";

        PatternMatch(input, pattern);
    }

    private static void PatternMatch(string[] inputs, string pattern)
    {
        var regex = new Regex(pattern);
        foreach (var input in inputs)
        {
            Console.Write(regex.IsMatch(input) ? $"'{input}' " : "");
        }
        Console.WriteLine();
    }
}
