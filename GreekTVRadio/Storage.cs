using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace GreekTVRadio
{
    /// <summary>
    /// http://www.livetvgreece.com/
    /// </summary>    
    public class Storage
    {
        public async Task<List<Station>> GetStations()
        {
            var uri = new Uri($"ms-appx:///appdata/stations.json");
            var file = await StorageFile.GetFileFromApplicationUriAsync(uri);
            var content = await FileIO.ReadTextAsync(file);
            return JsonConvert.DeserializeObject<List<Station>>(content);
        }
    }
}
