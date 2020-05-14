using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using RPS_Game.Models;
using RPS_Game;

namespace XUnitTestRPS
{
    public class UnitTest1
    {
        [Fact]
        public void Test1(){
            var options = new DbContextOptionsBuilder<RPS_DbContext>()
                .UseInMemoryDatabase(databaseName:"Test1");

            using (var db = new RPS_DbContext(options)) ;
        }

        [Fact]
        public void Test2() { 
        
        }
    }
}
