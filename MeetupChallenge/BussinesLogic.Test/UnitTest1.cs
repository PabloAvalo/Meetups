using BussinesLogic.Controllers;
using Meetup.BussinesLogic.APIManager;
using System;
using Xunit;

namespace BussinesLogic.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            OrganizadorMeetup org = new OrganizadorMeetup();

           string identity = await org.ObtenerIdentity();

            Console.WriteLine(identity);

            Assert.NotNull(identity);
        }
    }
}
