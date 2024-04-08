using System;
using System.Text;
using System.Collections.Generic;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */
        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0) // Check for null or empty array
                    return 0;

                int uniqueCount = 1; // At least one unique element is guaranteed in a non-empty array
                int current = nums[0]; // Keep track of the current unique element

                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // Check if the current element is different from the previous unique element
                    if (nums[i] != current)
                    {
                        // Update the current unique element
                        current = nums[i];

                        // Move the unique element to its correct position
                        nums[uniqueCount] = nums[i];

                        // Increment the count of unique elements
                        uniqueCount++;
                    }
                }

                return uniqueCount; // Return the count of unique elements
            }
            catch (Exception)
            {
                throw; // Rethrow any caught exceptions
            }
        }

        /*
        Advantages:

        - Clarity: The code is easily understood due to its clear formatting and usage of descriptive variable names.
        - Efficiency: By iterating through the array only once, it efficiently eliminates duplicates in place, achieving an O(n) time complexity.
        - Space Efficiency: It has an O(1) space complexity since it directly alters the input array rather than generating a new array.
        - Accuracy: It correctly counts the unique items and eliminates duplicates.
        - Managing Errors: To ensure program stability, a try-catch block is incorporated to handle unforeseen exceptions.
        - Handling Edge Cases: It returns 0 as expected and handles null or empty arrays appropriately.

        I learned about the complexities of array manipulation, paying particular attention to in-place alterations, 
        while putting the offered method for eliminating duplicates from an array into practice. I made sure that I iterated 
        through the array to handle neighboring elements efficiently by practicing my grasp of array traversal fundamentals 
        through this exercise. In addition, I became very aware of conditional checks to make sure the function operated correctly
        in every scenario after running into edge cases like empty arrays or arrays with a single element. The significance of careful
        testing and managing edge cases during code implementation was highlighted by this experience. Overall, the solution's linear
        time operation and time complexity efficiency demonstrate its applicability to situations where memory efficiency and 
        processing speed are crucial, especially in real-time applications or when handling large datasets.
*/
        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0) // Check for null or empty array
                    return new List<int>();

                int nonZeroIndex = 0; // Index to track the position of non-zero elements

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // If the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Move the non-zero element to the nonZeroIndex position
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++; // Increment nonZeroIndex
                    }
                }

                // Fill the remaining elements with zeros starting from nonZeroIndex
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                // Convert the modified array to IList<int> and return
                IList<int> result = new List<int>(nums);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Advantages:
        - Correctness: The code preserves the relative order of the non-zero members while correctly moving all zeros to the end of the array.
        - Efficiency:To get the required outcome, it iterates through the array twice using a two-pass method with an O(n) time complexity.
        - Efficient Use of Space: It does not create a new array in the process; instead, it makes changes to the input array immediately. This results in an O(1) space complexity.
        - Details: Because of the clear formatting and descriptive variable names, the logic in the code is really simple to understand. 
        - Managing Errors: To manage unforeseen exceptions and maintain program stability, it has a try-catch block.
        - Managing Cases with Edges: As promised, it returns an empty list when dealing with null or empty arrays gracefully.

        I became deeply involved in the subtleties of array manipulation when developing the method to move zeroes to the end of an
        array, paying special attention to optimizing the arrangement of components in place. I gained a deeper grasp of array 
        traversal strategies through this exercise, with a focus on how important it is to track and relocate non-zero elements
        effectively while maintaining the integrity of the array structure. I strengthened my handling of edge cases after coming
        into situations like null or empty arrays, which highlights the significance of thorough error-checking and defensive
        programming techniques. Furthermore, the application of elementary arithmetic operations in the solution demonstrated the 
        applicability of basic programming techniques in solving intricate problems. All in all, this experience demonstrated the
        need of paying close attention to details and using algorithmic tactics in a practical way.

        */

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                IList<IList<int>> result = new List<IList<int>>();

                if (nums == null || nums.Length < 3) // Check for null or insufficient length
                    return result;

                Array.Sort(nums); // Sort the array to facilitate two-pointer approach

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicates
                        continue;

                    int left = i + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates for left and right pointers
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*        

        The problem is finding triplets that sum to zero in an array. This involved:

        - Two-pointer approach with sorting: This technique optimized the search process by utilizing sorted data and pointers.
        - Understanding multi-pointer navigation: Able to gain experience in managing multiple pointers effectively within arrays.
        - Handling duplicates with conditional checks: The code incorporated checks for duplicate elements to ensure accurate results. This highlights the importance of defensive programming for robust solutions.
        - Iterative refinement: The process involved continuous improvement of the solution, demonstrating the value of ongoing learning and adaptation in problem-solving.

        Overall, the experience I got writing this code: 

        - Perseverance: Persisted in finding the right approach.
        - Precision: Careful attention to detail ensured the code's accuracy.
        - Adaptability: Adjusted the solution as needed to handle different scenarios.
        
        */

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0) // Check for null or empty array
                    return 0;

                int maxConsecutiveOnes = 0;
                int currentConsecutiveOnes = 0;

                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        currentConsecutiveOnes++; // Increment consecutive ones count
                        maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);
                    }
                    else
                    {
                        currentConsecutiveOnes = 0; // Reset consecutive ones count
                    }
                }

                return maxConsecutiveOnes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        I took on the task of determining the longest string of consecutive ones in an array for this new challenge. This is what's been discovered:

        - Easy iterative approach: I successfully applied a {foreach} loop to arrive at a straightforward and effective solution. 
        - Reinforcing core concepts: This task strengthened your comprehension of C# looping processes and control structures.
        - Defense programming: By including tests for null or empty arrays, the method prioritizes readability and maintainability in the code. 
        - Clarity and simplicity: The choice highlights the significance of strong error handling for dependable software.

        The experience that I was able to get:
        - Pragmatic solutions:Concentrating on transparent and effective techniques is valuable in software development.
        - Foundational concepts: Understanding the fundamentals is essential for effective problem-solving.

        */

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42

        Constraints:

        1 <= num <= 10^9

        */
        public static int BinaryToDecimal(int binary)
        {
            try
            {
                if (binary < 0) // Check if binary number is negative
                {
                    throw new ArgumentException("Binary number cannot be negative.");
                }

                int decimalNumber = 0;
                int baseMultiplier = 1; // Initialize base multiplier for binary digits

                while (binary > 0)
                {
                    int lastDigit = binary % 10; // Extract the last binary digit
                    if (lastDigit != 0 && lastDigit != 1) // Check if the digit is binary
                    {
                        throw new ArgumentException("Invalid binary number. It should contain only 0s and 1s.");
                    }

                    decimalNumber += lastDigit * baseMultiplier; // Update the decimal number
                    baseMultiplier *= 2; // Multiply base by 2 for next binary digit
                    binary /= 10; // Remove the last binary digit
                }

                return decimalNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        I explored the fundamentals of positional notation and arithmetic operations while delving into the complexities of
        binary-to-decimal conversion in order to construct the BinaryToDecimal function. Using a methodical approach, I came up
        with a solution that handles edge cases like negative inputs and erroneous binary representations and efficiently converts 
        binary digits into their decimal equivalents. I iteratively processed each binary digit, changing the decimal value as I went
        by using a while loop and modulo division. I now have a better knowledge of numerical systems and how crucial strong input 
        validation is to ensuring program stability thanks to this job. The experience also demonstrated the value of error handling
        procedures in preventing unforeseen runtime problems and enhancing the codebase's general resilience and stability.
        
        */

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0. 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */
        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 2) // Check if array contains less than two elements
                {
                    return 0;
                }

                Array.Sort(nums); // Sort the array in ascending order
                int maxDifference = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    int difference = nums[i] - nums[i - 1]; // Calculate the difference between successive elements
                    if (difference > maxDifference)
                    {
                        maxDifference = difference; // Update maxDifference if a larger difference is found
                    }
                }
                return maxDifference;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        I tackled finding the largest gap between elements in a sorted array. Here's what I achieved:
        
        - Effective Algorithm: Crafted an algorithm that computes the maximum gap through array manipulation and iteration. 
        - Systematic Approach: Thoroughly examined the issue to devise a solution that arranges the array and computes the
        differences between neighbors, adjusting the maximum gap as necessary.
        - Using Built-in Features: Enhanced performance and streamlined the process by utilizing built-in sorting functions.

        This experience reinforced my:
        - Algorithmic Problem-Solving: Improved my capacity to approach algorithmic problems methodically.
        - Importance of Efficiency: emphasized the need to utilize integrated features to provide effective solutions.
        */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these    lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array in ascending order

                // Start from the end of the array to find the largest possible perimeter
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    int side1 = nums[i];
                    int side2 = nums[i - 1];
                    int side3 = nums[i - 2];

                    // Check if the three sides can form a triangle with non-zero area
                    if (side1 < side2 + side3)
                    {
                        return side1 + side2 + side3; // Return the perimeter if a valid triangle is found
                    }
                }

                return 0; // Return 0 if no valid triangle can be formed
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        I tried to come up with a quick approach to determine the greatest perimeter of a triangle with three side lengths when 
        I created the {LargestPerimeter} function. My method was to identify the longest sides by first sorting the array of side 
        lengths in increasing order. I methodically assessed three-side combinations to see if they could form a legitimate triangle 
        by recursively going through the sorted array from the end. I learned how crucial it is to use array manipulation techniques 
        and iterative methodologies in order to properly address algorithmic issues as a result of this approach. This project also 
        demonstrated how important it is to take into account edge circumstances and use methodical approaches to problem-solving in
        order to guarantee stable and dependable code implementation.
        
        */


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".
        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */
        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                int startIndex;
                while ((startIndex = s.IndexOf(part)) != -1)
                {
                    // Find the index of the leftmost occurrence of the substring part
                    // If not found, indexOf returns -1, indicating no further occurrences
                    // Continuously loop until no more occurrences are found
                    // Remove the leftmost occurrence of the substring part
                    s = s.Remove(startIndex, part.Length);
                }
                return s; // Return the modified string after removing all occurrences of part
            }
            catch (Exception)
            {
                throw; // Rethrow any caught exceptions
            }
        }

        /*

        Upon composing the code for the 'RemoveOccurrences' function, I have seen its ease of use and efficiency in accomplishing the
        intended goal of eliminating every instance of a substring from a specified string. Here are a few thoughts regarding the code:

        - Conciseness: The code is understandable and succinct. It employs a while loop to iteratively locate and eliminate substring 
        occurrences until none remain, using the {IndexOf} function to get the index of the substring's leftmost occurrence.

        - Error management: Other than capturing and rethrowing exceptions, the code does not provide any particular error management.
        Even if this method works well for a tiny function like this, in a larger application, it could be advantageous to handle some 
        error circumstances more delicately, such handling null or empty input strings.

        - Efficiency: By repeatedly applying the 'Remove' method, which alters the original text, the code effectively eliminates 
        instances of the substring. The temporal complexity of string manipulation operations might be expensive, therefore it might 
        not be the best option for lengthy strings or frequent substring removals.
            
        Overall, even if the code successfully carries out its intended task, error handling might be strengthened and other strategies
        might be taken into account for increased performance in more demanding cases.

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }

        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}

