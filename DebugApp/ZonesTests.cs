using System.Threading.Tasks;
using WCL_Api_Library;

namespace DebugApp
{
    public static class ZonesTests
    {
        public static async Task RunTests()
        {
            var wclApi = new WCL_Api();
            var zones = await wclApi.GetZonesAsync();
            var classes = await wclApi.GetClassesAsync();
            var classicClasses = await wclApi.GetClassicClassesAsync();
            var rankings = await wclApi.GetRankingsAsync(616);
            var warriorRankings = await wclApi.GetRankingsAsync(616,11);
            
            var end = true;
        }
    }
}