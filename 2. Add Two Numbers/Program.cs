var example1 = new {
    nodeA = ListNode.CreateFromInts(new int[] {2,4,3}),
    nodeB = ListNode.CreateFromInts(new int[] {5,6,4}),
    output = ListNode.CreateFromInts(new int[] {7,0,8})
};

var example2 = new
{
    nodeA = ListNode.CreateFromInts(new int[] { 0 }),
    nodeB = ListNode.CreateFromInts(new int[] { 0 }),
    output = ListNode.CreateFromInts(new int[] { 0 })
};

var example3 = new
{
    nodeA = ListNode.CreateFromInts(new int[] { 9,9,9,9,9,9,9 }),
    nodeB = ListNode.CreateFromInts(new int[] { 9,9,9,9 }),
    output = ListNode.CreateFromInts(new int[] { 8,9,9,9,0,0,0,1 })
};

var solution = new Solution();
var output = solution.AddTwoNumbers(example1.nodeA, example1.nodeB);
Check(output, example1.output);
output = solution.AddTwoNumbers(example2.nodeA, example2.nodeB);
Check(output, example2.output);
output = solution.AddTwoNumbers(example3.nodeA, example3.nodeB);
Check(output, example3.output);

void Check(ListNode output, ListNode expected)
{
    while(output != null && expected != null)
    {
        if (output.val != expected.val)
            throw new Exception("Error");
        output = output.next;
        expected = expected.next;
    }
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode CreateFromInts(int[] array){
        var node = new ListNode();
        var current = node;
        for(int i = 0; i < array.Length; i++){
            current.val = array[i];
            if (i < array.Length - 1){
                current.next = new ListNode();
                current = current.next;
            }
        }
        return node;
    }
}
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var sum = 0;
        if (l1.next != null && l2.next != null) {
            sum = l1.val + l2.val;
            if (sum >= 10) l1.next.val++; 
            return new ListNode(sum % 10, AddTwoNumbers(l1.next, l2.next));
        }
        if (l1.next != null)
        {  // l2 next is null
            sum = l1.val + l2.val;
            if (sum >= 10) l1.next.val++;
            return new ListNode(sum % 10, AddTwoNumbers(l1.next, new ListNode()));
        }
        if (l2.next != null)
        {  // l1 next is null
            sum = l1.val + l2.val;
            if (sum >= 10) l2.next.val++;
            return new ListNode(sum % 10, AddTwoNumbers(new ListNode(), l2.next));
        }
        sum = l1.val + l2.val;
        return new ListNode(sum % 10, sum >= 10 ? new ListNode(1) : null);
    }
}