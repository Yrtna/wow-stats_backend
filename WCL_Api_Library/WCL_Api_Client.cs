using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WCL_Api_Library.DTO;

namespace WCL_Api_Library
{
    public class WCL_Api
    {
        static readonly HttpClient _httpClient = new HttpClient();

        #region Zones

        public async Task<ICollection<Zone>> GetZonesAsync()
        {
            List<Zone> zones = null;
            var url = $"{WCL_ConnectionInfo.base_url}/zones?api_key={WCL_ConnectionInfo.api_key}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
                zones = JsonConvert.DeserializeObject<List<Zone>>(await response.Content.ReadAsStringAsync());
            return zones;
        }

        #endregion

        #region Classes

        public async Task<ICollection<Class>> GetClassesAsync()
        {
            List<Class> classes = null;
            var url = $"{WCL_ConnectionInfo.base_url}/classes?api_key={WCL_ConnectionInfo.api_key}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
                classes = JsonConvert.DeserializeObject<List<Class>>(await response.Content.ReadAsStringAsync());
            return classes;
        }

        public async Task<ICollection<Class>> GetClassicClassesAsync()
        {
            var blacklist = new List<string> {"Death Knight", "Monk", "Demon Hunter"};
            var classes = await GetClassesAsync();
            return classes.Where(s => !blacklist.Contains(s.Name)).ToList();
        }

        #endregion

        #region Rankings

        public async Task<ICollection<Ranking>> GetRankingsAsync(int encounterId, int classId = 0, int page = 0)
        {
            List<Ranking> rankings = null;
            // class = 11 is Warrior (this is a hack and needs to become generic)
            var url = $"{WCL_ConnectionInfo.base_url}/rankings/encounter/{encounterId}?api_key={WCL_ConnectionInfo.api_key}";
            if (classId > 0)
                url += $"&class={classId}";
            if (page > 0)
                url += $"&page={page}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var rootRanking = JsonConvert.DeserializeObject<RootRanking>(await response.Content.ReadAsStringAsync());
                rankings = rootRanking.Rankings;
                rankings = AddMissingSlotsToGear(rankings);
            }

            return rankings;
        }

        private List<Ranking> AddMissingSlotsToGear(List<Ranking> rankings)
        {
            var rankingsCopy = rankings.ToList();
            foreach (var ranking in rankingsCopy)
            {
                for (var i = 0; i < ranking.Gear.Count; i++)
                {
                    ranking.Gear[i].Slot = (Slot)i;
                }
            }

            return rankingsCopy;
        }

        #endregion
    }
}