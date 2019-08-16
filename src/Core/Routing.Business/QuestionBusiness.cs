using System;
using Routing.Business.Interfaces;

namespace Routing.Business
{
    public class QuestionBusiness : IQuestionBusiness
    {
        public string AskLocation()
        {
            Console.WriteLine("Please enter the route [EMPTY TO EXIT]:");
            return Console.ReadLine();
        }
    }
}
