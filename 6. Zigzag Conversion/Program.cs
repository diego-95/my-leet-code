using System.Text;

var example1 = new
{
    s = "PAYPALISHIRING",
    rows = 3,
    output = "PAHNAPLSIIGYIR"
};

var example2 = new
{
    s = "AB",
    rows = 1,
    output = "AB"
};

var example3 = new
{
    s = "ABCD",
    rows = 2,
    output = "ACBD"
};

var solution = new Solution();

var output = solution.Convert(example1.s, example1.rows);

if (output != example1.output)
    throw new Exception();

output = solution.Convert(example2.s, example2.rows);

if (output != example2.output)
    throw new Exception();

output = solution.Convert(example3.s, example3.rows);

if (output != example3.output)
    throw new Exception();

public class Solution
{
    public string Convert(string s, int numRows)
    {
        var matrix = new StringBuilder[numRows];
        for (int i = 0; i < numRows; i++)
        {
            matrix[i] = new StringBuilder();
        }
        var y = 0;
        var isGoingDown = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (isGoingDown)
            {
                matrix[y].Append(s[i]);
                isGoingDown = y < numRows - 1;
                if (isGoingDown) y++;
                else if (!isGoingDown && numRows == 2)
                {
                    y = 0;
                    isGoingDown = true;
                }
            }
            else
            {
                matrix[numRows == 1 ? y : --y].Append(s[i]);
                isGoingDown = y <= 1;
                if (isGoingDown)
                {
                    y = 0;
                }
            }
        }
        var strBuilder = new StringBuilder();
        for (int i = 0; i < numRows; i++)
        {
            strBuilder.Append(matrix[i]);
        }
        return strBuilder.ToString();
    }
}