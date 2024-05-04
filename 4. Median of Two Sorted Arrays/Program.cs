var example1 = new
{
    nums1 = new int[] { 1, 3 },
    nums2 = new int[] { 2 },
    output = 2.00
};

var example2 = new
{
    nums1 = new int[] { 1, 2 },
    nums2 = new int[] { 3, 4 },
    output = 2.50
};

var solution = new Solution();

var output = solution.FindMedianSortedArrays(example1.nums1, example1.nums2);
Check(output, example1.output);

output = solution.FindMedianSortedArrays(example2.nums1, example2.nums2);
Check(output, example2.output);

void Check(double output, double expected)
{
    if (output != expected)
        throw new Exception("Error");
}

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var len1 = nums1.Length;
        var len2 = nums2.Length;
        var len = len1 + len2;
        var isEven = len % 2 == 0;
        var position = (isEven ? len : len + 1) / 2;
        var index1 = 0;
        var index2 = 0;
        var array = new int[len];
        for(var i = 0; i < len; i++)
        {
            if (index1 >= nums1.Length && index2 >= nums2.Length)
            {
                throw new Exception("Error");
            }
            if(index1 >= nums1.Length)
            {
                array[i] = nums2[index2++];
            }
            else if(index2 >= nums2.Length)
            {
                array[i] = nums1[index1++];
            }
            else if (nums1[index1] > nums2[index2])
            {
                array[i] = nums2[index2++];
            }
            else if (nums1[index1] < nums2[index2])
            {
                array[i] = nums1[index1++];
            }
            else
            {
                array[i] = nums1[index1++];
                index2++;
            }
            if (i == position)
                if (isEven)
                    return (array[i - 1] + array[i]) / 2.0;
                else
                    return array[i - 1];
        }
        throw new Exception("Error");
    }
}