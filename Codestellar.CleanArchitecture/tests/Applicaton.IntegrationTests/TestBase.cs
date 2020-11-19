using NUnit.Framework;
using System.Threading.Tasks;

namespace Codestellar.CleanArchitecture.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
