using System;
using Microsoft.Extensions.DependencyInjection;
using Project0.UI;

namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            MainPage mainPage = new MainPage();
            Project0.DataAccess.SampleData sample = new DataAccess.SampleData();
            //sample.addSamples();
            mainPage.display();
        }
    }
}
