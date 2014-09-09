using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InterviewQuestions
{
    public class FindIntersectionOf2SortedArrays
    {
        public static void Test()
        {
            var A = new int[] {3, 4, 8, 10, 13};
            var B = new int[] {1, 2, 8, 10, 18 };
            var interSections = FindIntersection(A, B);
            //Int32[] intValues = (Int32[])interSections.ToArray(typeof(Int32));
            Int32[] intValues = new Int32[interSections.Count];
            interSections.CopyTo(intValues);

            Console.WriteLine(interSections.ToArray());
            Console.WriteLine(intValues);

            Console.WriteLine(string.Concat(interSections.Select(p=>p+ " "))); //using System.Linq;
            Console.WriteLine(string.Concat(intValues.ToArray())); //using System.Linq;

            foreach (var c in interSections)
            {
                Console.WriteLine(c);
            }

            Console.ReadKey();
        }

        private static List<int> FindIntersection(int[] A, int[] B)
        {
            int n1 = A.Length;
            int n2 = B.Length;
            int length = n1 > n2 ? n1 : n2;
            var intersection = new List<int>(); 

            int i = 0, j = 0, k=0;
            while (i < n1 && j < n2)
            {
                if (A[i] > B[j])
                {
                    j++;
                }
                else if (B[j] > A[i])
                {
                    i++;
                }
                else
                {
                    intersection.Add(A[i]);
                    i++;
                    j++;
                    k++;
                }
            }
            return intersection;
        }
    }
}
