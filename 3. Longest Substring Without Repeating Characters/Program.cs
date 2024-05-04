var example1 = new
{
    str = "abcabcbb",
    output = 3
};
var example2 = new
{
    str = "bbbbb",
    output = 1
};
var example3 = new
{
    str = "pwwkew",
    output = 3
};

var solution = new Solution();

var output = solution.LengthOfLongestSubstring(example1.str);
Check(output, example1.output);
output = solution.LengthOfLongestSubstring(example2.str);
Check(output, example2.output);
output = solution.LengthOfLongestSubstring(example3.str);
Check(output, example3.output);

Console.ReadLine();

void Check(int output, int expected)
{
    if (output != expected)
        throw new Exception("Error");
}

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var result = 0;
        var dictionary = new Dictionary<char, char>();
        var response = new List<char>();
        for(int i = 0; i < s.Length; i++)
        {
            for(int j = i; j < s.Length; j++)
            {
                if (!dictionary.TryAdd(s[j], s[j])) break;
            }
            if (dictionary.Count > result)
            {
                result = dictionary.Count;
                response = dictionary.Values.ToList();
            }
            dictionary.Clear();
        }
        response.ToList().ForEach(v => Console.Write(v));
        Console.WriteLine();
        return result;
    }
}