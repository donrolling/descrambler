using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace descrambler
{
    public class Descrambler
    {
        public static Dictionary<int, List<string>> Descramble(string input)
        {

            var result = new Dictionary<int, List<string>>();
            var lines = input.Split('\n');
            var lineCount = lines.Count();
            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                var groups = line.Split(' ');
                var min = groups.Min(a => a.Count());
                var max = groups.Max(a => a.Count());
                if (min != max)
                {
                    throw new System.Exception($"Values have uneven number of characters - min: { min } / max: { max }");
                }
                var letterCount = max;
                var groupCount = groups.Count();
                var words = new List<string>();
                foreach (var group in groups)
                {
                    var limit = Enumerable.Range(1, group.Count()).Aggregate(1, (p, item) => p * item);
                    var groupPermutations = solve(group, limit);
                }
                result.Add(i, words);
                lineCount++;
            }
            return result;
        }

        private static string solve(string perm, int limit)
        {
            var count = 1;
            var n = perm.Length;

            while (count < limit)
            {
                var i = n - 1;
                while (perm[i - 1] >= perm[i])
                {
                    i = i - 1;
                }

                var j = n;
                while (perm[j - 1] <= perm[i - 1])
                {
                    j = j - 1;
                }

                // swap values at position i-1 and j-1
                perm = swap(perm, i - 1, j - 1);

                i++;
                j = n;
                while (i < j)
                {
                    perm = swap(perm, i - 1, j - 1);
                    i++;
                    j--;
                }
                count++;
            }

            var permNum = string.Join("", perm);
            return permNum;
        }

        private static string swap(string perm, int i, int j)
        {
            var cs = perm.ToCharArray();
            var k = cs[i];
            cs[i] = cs[j];
            cs[j] = k;
            return cs.ToString();
        }
    }
}
