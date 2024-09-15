using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



    }
}
