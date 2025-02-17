﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2019_Fall_Assignment2
{
	class Program
	{
		public static void Main(string[] args)
		{
            Program xyz = new Program();
            int target = 5;
			int[] nums = { 1, 3, 5, 6 };
			Console.WriteLine("Position to insert {0} is = {1}\n", target, xyz.searchInsert(nums, target));

			int[] nums1 = { 1, 2, 2, 1 };
			int[] nums2 = { 2, 2 };
			int[] intersect = Intersect(nums1, nums2);
			Console.WriteLine("Intersection of two arrays is: ");
			DisplayArray(intersect);
			Console.WriteLine("\n");

			int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
			Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

			string keyboard = "abcdefghijklmnopqrstuvwxyz";
			string word = "cba";
			Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

			int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
			int[,] flipAndInvertedImage = xyz.FlipAndInvertImage(image);
			Console.WriteLine("The resulting flipped and inverted image is:\n");
			Display2DArray(flipAndInvertedImage);
			Console.Write("\n");

			int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
			int minMeetingRooms = xyz.MinMeetingRooms(intervals);
			Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

			int[] arr = { -4, -1, 0, 3, 10 };
			int[] sortedSquares = SortedSquares(arr);
			Console.WriteLine("Squares of the array in sorted order is:");
			DisplayArray(sortedSquares);
			Console.Write("\n");
           

			string s = "abca";
			if (ValidPalindrome(s))
			{
				Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
			}
			else
			{
				Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
			}
            Console.ReadLine();
        }

		public static void DisplayArray(int[] a)
		{
			foreach (int n in a)
			{
				Console.Write(n + " ");
			}
		}

		public static void Display2DArray(int[,] a)
		{// displays the inverted image
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
				{
					Console.Write(a[i, j] + "\t");
				}
				Console.Write("\n");
			}
		}

        public int searchInsert(int[] nums, int target)
        {//return index of the target value or index of where to insert the target value

            if (target > nums[nums.Length - 1])
            {

                return nums.Length;

            }
            int l = 0;
            int r = nums.Length - 1;
            while (l < r)
            {

                int m = l + (r - l) / 2;

                if (target > nums[m])
                {

                    l = m + 1;

                }
                else
                {

                    r = m;

                }

            }
            return l;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
		{
            //Index all entries from shorter array in a map
            var firstnumbers = new Dictionary<int, int>();

			foreach (var num in nums1)
			{
				if (firstnumbers.ContainsKey(num))
				{
					firstnumbers[num]++;
				}
				else
				{
					firstnumbers.Add(num, 1);
				}
			}
            //Find intersection between map and second array
            var answer = new List<int>();
			foreach (var num in nums2)
			{
				if (firstnumbers.ContainsKey(num))
				{
					answer.Add(num);
					if (firstnumbers[num] > 1)
					{
						firstnumbers[num]--;
					}
					else
					{
						firstnumbers.Remove(num);
					}

				}
			}

			return answer.ToArray();
		}

		public static int LargestUniqueNumber(int[] A)
		{
			try
			{
                int max = 0;
                Dictionary<int, int> InputArray = new Dictionary<int, int>();
                for (int i = 0; i <= A.Length - 1; i++)
                {
                    if (InputArray.ContainsKey(A[i]) == false)
                    {
                        InputArray.Add(A[i], 1);
                    }
                    else
                    {
                        InputArray[A[i]] = 2;
                    }
                }
                foreach (var pair in InputArray)
                {
                    if (pair.Key > max && pair.Value == 1)
                    {
                        max = pair.Key;
                        
                    }
                }
                if (max > 0)
                {
                    return max;
                }
                else
                {
                    return -1;
                }
            }
			catch
			{
				Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
			}

			return 0;
		}

		public static int CalculateTime(string keyboard, string word)
		{
			try
			{
                int count = 0;
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int i = 1; i <= keyboard.Length; i++)
                {
                    dict.Add(keyboard[i - 1], i);
                }
                int pv = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    int pk = 0;
                    pk = dict[word[i]];
                    count += Math.Abs(pk - pv);
                    pv = pk;
                }
                return count-1;
            }
			catch
			{
				Console.WriteLine("Exception occured while computing CalculateTime()");
			}

			return 0;
		}

        public int[,] FlipAndInvertImage(int[,] A)
        {//flips the array input
            try
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    int start = 0;
                    int end = A.GetLength(1) - 1;
                    while (start <= end)
                    {
                        int temp = A[i, start];
                        A[i, start] = A[i, end];
                        A[i, end] = temp;
                        if (start == end)
                        {
                            A[i, start] = A[i, start] == 0 ? 1 : 0;
                        }
                        else
                        {
                            A[i, start] = A[i, start] == 0 ? 1 : 0;
                            A[i, end] = A[i, end] == 0 ? 1 : 0;
                        }

                        start += 1;
                        end -= 1;
                    }
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return A;
        }

        public int MinMeetingRooms(int[,] A)
        {// Find minimum number of conference rooms required given meeting intervals
            int n = A.GetLength(0);
            int[] arr = getColumn(A, 0);
            int[] dep = getColumn(A, 1);
            Array.Sort(arr);
            Array.Sort(dep);

            int plat_needed = 1, result = 1;
            int i = 1, j = 0;

            while (i < n && j < n)
            {

                if (arr[i] <= dep[j])
                {
                    plat_needed++;
                    i++;

                    if (plat_needed > result)
                        result = plat_needed;
                }

                else
                {
                    plat_needed--;
                    j++;
                }
            }

            return result;
        }
        public int[] getColumn(int[,] matrix, int columnNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                    .Select(x => matrix[x, columnNumber])
                    .ToArray();
        }

        public static int[] SortedSquares(int[] A)
		{
			int[] result = new int[A.Length];

			int start = 0, end = A.Length - 1;
			int index = A.Length - 1;

			while (start <= end)
			{
				int frontSquare = A[start] * A[start];
				int rearSquare = A[end] * A[end];

				if (frontSquare < rearSquare)
				{
					result[index--] = rearSquare;
					end--;
				}
				else
				{
					result[index--] = frontSquare;
					start++;
				}

			}
			return result;
		}

        public static bool ValidPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            int numSkip = 0;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    if (numSkip == 0)
                    {
                        left += 1;
                        numSkip += 1;
                        continue;
                    }
                    else if (numSkip == 1)
                    {
                        left -= 1;     //trace back
                        right -= 1;
                        numSkip += 1;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                left += 1;
                right -= 1;
            }
            return true;
        }
    }
}