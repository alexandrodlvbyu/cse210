using System;  // Make sure the System namespace is referenced
using EternalQuest;  // Add the using directive for the namespace where GoalManager is located

namespace EternalQuest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create an instance of GoalManager
            GoalManager goalManager = new GoalManager();

            // Call any methods or properties of GoalManager here
            goalManager.DisplayGoals();
        }
    }
}
