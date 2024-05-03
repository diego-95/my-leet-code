var example1 = new { 
   Nums = new int[] { 2, 7, 11, 15 },
   Target = 9,
   Output = new int[] {0, 1}
};

var example2 = new
{
    Nums = new int[] { 3, 2, 4 },
    Target = 6,
    Output = new int[] { 1, 2 }
};

var example3 = new
{
    Nums = new int[] { 3, 3 },
    Target = 6,
    Output = new int[] { 0, 1 }
};

var solution = new Solution();
var output = solution.TwoSum(example1.Nums, example1.Target);
Check(output, example1.Output);
Console.WriteLine("Example 1 OK");

output = solution.TwoSum(example2.Nums, example2.Target);
Check(output, example2.Output);
Console.WriteLine("Example 2 OK");

output = solution.TwoSum(example3.Nums, example3.Target);
Check(output, example3.Output);
Console.WriteLine("Example 3 OK");

Console.WriteLine("---");
Console.WriteLine("Optimized Algorithm");

output = solution.TwoSumOptimized(example1.Nums, example1.Target);
Check(output, example1.Output);
Console.WriteLine("Example 1 OK");

output = solution.TwoSumOptimized(example2.Nums, example2.Target);
Check(output, example2.Output);
Console.WriteLine("Example 2 OK");

output = solution.TwoSumOptimized(example3.Nums, example3.Target);
Check(output, example3.Output);
Console.WriteLine("Example 3 OK");

void Check(int[] output, int[] expected)
{
    if (output.Length != expected.Length)
        throw new Exception("Error");
    if (output[0] != expected[0])
        throw new Exception("Error");
    if (output[1] != expected[1])
        throw new Exception("Error");
}

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        for (int i = 0; i < nums.Length; i++)
        {
            for(int j = 0; j < nums.Length; j++)
            {
                if (j == i) continue;
                if (nums[i] + nums[j] == target)
                    return new int[] { i, j };
            }
        }
        throw new Exception("Error on input");
    }

    public int[] TwoSumOptimized(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++)
        {
            var value = target - nums[i];
            if (dict.ContainsKey(value))
                return new int[] { dict[value], i };

            dict.Add(nums[i], i);
            
        }
        throw new Exception("Error on input");
    }
};
