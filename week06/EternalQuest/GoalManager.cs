using System;

namespace EternalQuest
{
    public class GoalManager
    {
        // Declare the private fields
        private int _score;
        private List<string> _goals;

        // Constructor to initialize variables
        public GoalManager()
        {
            _score = 0;
            _goals = new List<string>();
        }

        // A public method to get the score
        public int GetScore()
        {
            return _score;
        }

        // A public method to add a goal
        public void AddGoal(string goal)
        {
            _goals.Add(goal);
        }

        // A method to check if a goal exists
        public bool CheckGoal(string goal)
        {
            return _goals.Contains(goal);
        }

        // A method to update the score
        public void UpdateScore(int points)
        {
            _score += points;
        }

        // The Start method, which was declared but never used
        public void Start()
        {
            // You can implement the method or remove it if unnecessary
            Console.WriteLine("Game Started!");
        }
    }
}
