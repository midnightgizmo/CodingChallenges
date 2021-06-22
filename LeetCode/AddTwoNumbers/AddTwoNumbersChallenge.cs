using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.AddTwoNumbers
{
    /// <summary>
    /// solution to the coding challenge at https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    public class AddTwoNumbersChallenge
    {
        ListNode l1;
        ListNode l2;
        public AddTwoNumbersChallenge()
        {
            // this is to create the test input data
            l1 = this.CreateReverseLinkedList(9);
            l2 = this.CreateReverseLinkedList(9999999991);
        }
        

        public ListNode SolveProblem()
        {
            BigInteger firstNumber = this.GetNumber(l1);
            BigInteger secondNumber = this.GetNumber(l2);
            BigInteger sumOfNumbers = firstNumber + secondNumber;
            
            ListNode answer = CreateReverseLinkedList(sumOfNumbers);
            return answer;
        }
        private BigInteger GetNumber(ListNode ln)
        {
            StringBuilder sb = new StringBuilder();
            ListNode currentNode = ln;

            do
            {
                sb.Insert(0, currentNode.val);
                currentNode = currentNode.next;
            } while (currentNode != null);

            //return decimal.Parse(sb.ToString());
            return BigInteger.Parse(sb.ToString());
        }

        private ListNode CreateReverseLinkedList(BigInteger number)
        {
            char[] numberAsChars = number.ToString().ToCharArray();
            ListNode head = new ListNode(0, null);
            ListNode currentNode =  head;
            for (int index = numberAsChars.Length - 1; index >= 0; index--)
            {
                currentNode.val = int.Parse(numberAsChars[index].ToString());

                if (index > 0)
                {
                    currentNode.next = new ListNode(0, null);

                    currentNode = currentNode.next;
                }
                

            }

            return head;
        }
    }


    
 
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }
 
}
