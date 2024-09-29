using System.Linq;
using System.Text;

namespace ProblemSolving_LeetCode
{
    public static class ArrayStringProblems
    {

        #region Merge Two Array
        //Link To the Problem : https://leetcode.com/problems/merge-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150   
        /*
         * Solved using two pointers at the end of both arrays according to the given m , n 
         * why from the end not the start?
         * because empty places in nums1 is in the end, thats why we will check from the end and place the larger value
         * from nums1[] and nums2[] in the actual end of nums1[].
         *                                                                 ___
         * Thank you, Good luck and see you next day with another problem (^_^) 
         */
        #endregion
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            int i1 = m - 1,
                i2 = n - 1,
                res = n + m - 1;

            for (int i = 0; i < n + m; i++)
            {
                if (i1 == -1)
                    nums1[res--] = nums2[i2--];

                else if (i2 == -1)
                    return;

                else if (nums1[i1] <= nums2[i2])
                    nums1[res--] = nums2[i2--];

                else
                    nums1[res--] = nums1[i1--];
            }

        }

        #region Remove Duplicates from Sorted Array
        //Link To the Problem : https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150
        /*
         * a loop on this array and check only different consecutive values can solve this problem thats it
         */
        #endregion
        public static int RemoveDuplicates(int[] nums)
        {
            int counter = 1;

            for (int i = 1; i < nums.Count(); i++)
                if (nums[i] != nums[i - 1])
                    nums[counter++] = nums[i];

            return counter;
        }

        public static int RemoveDuplicatesSecondVersion(int[] nums)
        {
            int counter = 0, occurences = 0;

            for (int i = 0; i < nums.Count() - 1; i++)
                if (nums[i] != nums[i + 1])
                {
                    nums[counter++] = nums[i];
                    if (occurences > 0)
                    {
                        nums[counter++] = nums[i];
                        occurences = 0;
                    }
                    if (i == nums.Length - 2)
                    {
                        nums[counter++] = nums[i + 1];
                    }
                }
                else
                    occurences++;

            return counter;
        }

        public static int Candy(int[] ratings)
        {
            int TotalCandies = ratings.Length;

            if (ratings[ratings.Length - 1] > ratings[ratings.Length - 2])
                TotalCandies++;

            if (ratings[0] > ratings[1])
                TotalCandies++;


            for (int i = 1; i < ratings.Length - 1; i++)
                if (ratings[i] > ratings[i + 1] || ratings[i] > ratings[i - 1])
                    TotalCandies++;

            return TotalCandies;
        }

        public static IList<string> FizzBuzz(int n)
        {
            List<string> res = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                switch (i % 15)// switch goes directly to the res so it must be faster than using if statement
                {
                    case 0:
                        res.Add("FizzBuzz");
                        break;

                    case 3:
                    case 6:
                    case 9:
                        res.Add("Fizz");
                        break;

                    case 5:
                    case 10:
                        res.Add("Buzz");
                        break;

                    default:
                        res.Add($"{i}");
                        break;
                }

            }

            return res;
        }

        public static string MergeAlternately(string word1, string word2)
        {
            int len1 = word1.Length, len2 = word2.Length, min = Math.Min(len1, len2);
            StringBuilder res = new StringBuilder(len1 + len2);
            for (int i = 0; i < min; i++)
            {
                res.Append(word1[i]);
                res.Append(word2[i]);
            }
            res.Append(len1 > len2 ? word1.Substring(min) : word2.Substring(min));

            return res.ToString();
        }

        public static string GcdOfStrings(string str1, string str2)
        {
            int len1 = str1.Length, len2 = str2.Length;

            List<int> Divisors = new List<int>();

            for (int i = 1; i <= Math.Min(len1, len2); i++)
                if (len1 % i == 0 && len2 % i == 0) Divisors.Add(i);

            for (int i = Divisors.Count - 1; i >= 0; i--)
            {
                var temp1 = str1.Split(str1.Substring(0, Divisors[i]));
                var temp2 = str2.Split(str1.Substring(0, Divisors[i]));
                if (temp1.All(e => e.Length == 0) && temp2.All(e => e.Length == 0))
                    return str1.Substring(0, Divisors[i]);

            }

            return "";
        }

    }
}
