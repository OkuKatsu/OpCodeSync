using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpCodeSync
{
    public class OpCode
    {
        public string Time { get; set; }
        public string Server { get; set; }
        public string Opcode { get; set; }
    }

    public class OnlineOpCodes
    {
        public List<OpCode> OpCode { get; set; }

        public async Task<List<OpCode>> GetOnlineOpcodeAsync()
        {
            if (OpCode == null)
            {
                await LoadOnlineOpcodeJsonAsync();
            }
            return OpCode;
        }

        private async Task LoadOnlineOpcodeJsonAsync()
        {
            string url = "https://raw.githubusercontent.com/OkuKatsu/OpCodeSync/refs/heads/main/opcodes.json";

            try
            {
                OpCode = await FetchOpCodesFromUrl(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "ERROR");
            }
        }

        private async Task<List<OpCode>> FetchOpCodesFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                var opCodes = JsonConvert.DeserializeObject<List<OpCode>>(json);
                return opCodes;
            }
        }
    }
}
