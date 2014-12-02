//using Achievments.AchievmentProperties;
using Achievments;
using DataLayer;

namespace CreateDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var a = AchievmentsRepository.GetInstance().GetObjects();

        }
    }
}
