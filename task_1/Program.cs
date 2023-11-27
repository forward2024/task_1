/*public class Solution
{
    public string FindDifferentBinaryString(string[] nums)
    {
        char[] unique = new[] { '0', '1' };
        char[] result = new char[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = unique[0];
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (Array.Exists(nums, v => v == new string(result)))
            {
                result[i] = unique[1];
                continue;
            }
            else
            {
                break;
            }
        }
        Console.WriteLine(new string(result));
        return new string(result);
    }
}*/
/*public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> numIndices = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (numIndices.TryGetValue(complement, out int index))
            {
                return new int[] { index, i };
            }
            numIndices[nums[i]] = i;
        }
        return new int[] { };
    }
}*/
/*public class Solution
{
    public int CountPairs(IList<int> nums, int target)
    {
        int result = 0;

        for (int i = 0; i < nums.Count; i++)
        {
            for (int j = i + 1; j < nums.Count; j++)
            {
                if (nums[i] + nums[j] < target)
                {
                    result++;
                }
            }
            if (i + 2 == nums.Count - 1)
            {
                if (nums[i + 2] + nums[i + 1] < target)
                {
                    result++;
                    GC.Collect();
                    Console.WriteLine(result);
                    return result;
                }
            }
        }
        Console.WriteLine(result);
        GC.Collect();
        return result;
    }
}*/
/*public class Solution
{
    public long CountFairPairs(int[] nums, int lower, int upper)
    {
        int count = 0;
        Array.Sort(nums);

        int left = 0;
        int right = 0;
        while (right < nums.Length)
        {
            if (nums[right] - nums[left] > upper)
            {
                left++;
            }
            else if (nums[right] - nums[left] < lower)
            {
                right++;
            }
            else
            {
                count += right - left;
                right++;
            }
        }
        Console.WriteLine(count);
        return count;//no
    }
}*/
/*int BinarySearch(int[] arr, int x)
{
    Array.Reverse(arr);
    int low = 0, high = arr.Length - 1;
    while (low <= high)
    {
        int mid = low + (high - low) / 2;
        if (arr[mid] == x)
        {
            return mid;
        }
        if (arr[mid] < x)
        {
            low = mid + 1;
        }
        else
        {
            high = mid - 1;
        }
    }
    return -1;
}*/
/*public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<TreeNode> AllPossibleFBT(int n)
    {
        if (n % 2 == 0) return new List<TreeNode>();

        var allTrees = new Dictionary<int, List<TreeNode>>
        {
            { 1, new List<TreeNode>() { new TreeNode() } }
        };

        for (int m = 3; m <= n; m += 2)
        { // m - кількість вузлів у дереві
            allTrees[m] = new List<TreeNode>();

            for (int leftNodes = 1; leftNodes < m; leftNodes += 2)
            { // Перебір для лівих піддерев
                int rightNodes = m - 1 - leftNodes; // Визначаємо кількість вузлів для правих піддерев
                foreach (var left in allTrees[leftNodes])
                { // Перебір усіх лівих піддерев
                    foreach (var right in allTrees[rightNodes])
                    { // Перебір усіх правих піддерев
                        TreeNode root = new TreeNode(0); // Створюємо корінь для нового дерева
                        root.left = left;
                        root.right = right;
                        allTrees[m].Add(root);
                    }
                }
            }
        }

        return allTrees[n];
    }
}*/
/*public class Solution
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);
        int left = 0;
        int maxWidth = 0;
        long totalIncrement = 0;
        for (int right = 0; right < nums.Length; right++)
        {
            totalIncrement += nums[right];

            Console.WriteLine("\nІтерація {0}", right);
            PrintArray(nums, left, right);
            Console.WriteLine("Загальна сума змін (totalIncrement): " + totalIncrement + ", left: " + left + ", right: " + right);

            while (totalIncrement + k < nums[right] * (right - left + 1))
            {
                Console.WriteLine("Потрібно змінити більше, ніж дозволено k, щоб вирівняти вікно до " + nums[right]);
                totalIncrement -= nums[left];
                Console.WriteLine("Зсув left: " + left + ", Видаляємо " + nums[left] + " з загальної суми змін");
                left++;
                Console.WriteLine("Новий left: " + left + ", Загальна сума змін після зсуву: " + totalIncrement);
            }

            int currentWidth = right - left + 1;
            Console.WriteLine($"Math.Max({maxWidth}, {currentWidth})");
            maxWidth = Math.Max(maxWidth, currentWidth);
            Console.WriteLine($"maxWidth: {maxWidth}");
            Console.WriteLine("Ширина вікна на цьому кроці: " + currentWidth);
        }

        Console.WriteLine("\nМаксимальна ширина вікна: " + maxWidth);
        return maxWidth;
    }

    private void PrintArray(int[] nums, int left, int right)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == left) Console.Write("| ");
            Console.Write(nums[i] + " ");
            if (i == right) Console.Write("| ");
        }
        Console.WriteLine();
    }
}*/
/*public class Solution
{
    public int ReductionOperations(int[] nums)
    {
        Array.Sort(nums);

        int result = 0;
        int operations = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                operations++;
            }
            result += operations;
        }

        return result;
    }
}*/
/*public class Solution
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int G = 0, P = 0, M = 0;
        int PG = 0, PP = 0, PM = 0;


        for (int i = 0; i < garbage.Length; i++)
        {
            for (int j = 0; j < garbage[i].Length; j++)
            {
                switch (garbage[i][j])
                {
                    case 'G':
                        while (true)
                        {
                            if (PG == i)
                            {
                                G++;
                                break;
                            }
                            else
                            {
                                G += travel[PG];
                                PG++;
                            }
                        }
                        break;
                    case 'P':
                        while (true)
                        {
                            if (PP == i)
                            {
                                P++;
                                break;
                            }
                            else
                            {
                                P += travel[PP];
                                PP++;
                            }
                        }
                        break;
                    case 'M':
                        while (true)
                        {
                            if (PM == i)
                            {
                                M++;
                                break;
                            }
                            else
                            {
                                M += travel[PM];
                                PM++;
                            }
                        }
                        break;
                }
            }
        }
        return G + P + M;
    }
}*/
/*public class Solution
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        int sum = travel.Sum();
        int min = 0;
        HashSet<char> set = new();
        for (int i = garbage.Length - 1; i >= 1; i--)
        {
            min += garbage[i].Length;
            int count = set.Count;
            if (count != 3)
            {
                foreach (var c in garbage[i])
                    set.Add(c);
                min += (set.Count - count) * sum;
            }
            sum -= travel[i - 1];
        }
        return min + garbage[0].Length;
    }
}*/
/*
public class Solution
{
    public int Rev(int x)
    {
        int reverse = 0;
        while (x > 0)
        {
            reverse = reverse * 10 + x % 10;
            x /= 10;
        }
        return reverse;
    }
    public int CountNicePairs(int[] nums)
    {
        int result = 0;
        Dictionary<int, int> map = new Dictionary<int, int>();
        int mod = 1000000007;

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = nums[i] - Rev(nums[i]);

            if (map.ContainsKey(diff))
            {
                result = (result + map[diff]) % mod;
                map[diff]++;
            }
            else
            {
                map[diff] = 1;
            }
        }
        return result;
    }
}*/



/*var main = new Task();
main.MinPathSum(new int[3][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } });


class Task
{
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,] dp = new int[m, n];

        dp[0, 0] = grid[0][0];

        // Ініціалізуємо перший рядок
        for (int i = 1; i < m; i++)
        {
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }

        // Ініціалізуємо перший стовпець
        for (int j = 1; j < n; j++)
        {
            dp[0, j] = dp[0, j - 1] + grid[0][j];
        }

        // Обчислюємо мінімальний шлях для решти сітки
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        return dp[m - 1, n - 1];
    }

}*/



/*public class Solution
{

    bool foo(int a)
    {
        for (int i = 2; i <= Math.Sqrt(a); i++)
        {
            if (a % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public int DiagonalPrime(int[][] nums)
    {
        int m = nums.Length;
        int n = nums[0].Length;
        int max = 0;


        for (int i = 0, j = 0; i < n; i++, j++)
        {
            if (foo(nums[i][j]))
            {
                max = Math.Max(nums[i][j], max);
            }
        }

        for (int i = nums[0].Length - 1, j = 0; j < n; i--, j++)
        {
            if (foo(nums[j][i]))
            {
                max = Math.Max(nums[j][i], max);
            }
        }
        Console.WriteLine(max);
        return max;
    }
}*/

var task = new Solution();
task.UniquePathsIII(new int[][]
{
    new int[] { 1, 0, 0, 0 },
    new int[] { 0, 0, 0, 0 },
    new int[] { 0, 0, 2, -1 }
});

public class Solution
{
    public int UniquePathsIII(int[][] grid)
    {


        return 1;
    }
}