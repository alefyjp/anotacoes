using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace IXC_Facil
{
    internal class IXCAPI
    {
        public IXCAPI()
        { 
            Usuario = new UsuarioIXC();
        }

        public UsuarioIXC Usuario;

        public void Teste()
        {
            Console.WriteLine("Tudo ok :)!");
        }

        // RADIUS -> CONEXÕES RADIUS
        public async Task ConexoesRadius()
        {
            string host = Usuario.Host;
            string url = $"https://{host}/webservice/v1/radacct";

            // Token igual ao seu código Python
            string token = Usuario.Token;
            string base64Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));

            // Headers
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("ixcsoft", "listar");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", base64Token);

            // payload form-data (como o requests faz com data=)
            var payload = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("qtype", "acctstoptime"),
                new KeyValuePair<string,string>("query", "2025/12/05 10:00:21"),
                new KeyValuePair<string,string>("oper",  ">"),
                new KeyValuePair<string,string>("page",  "1"),
                new KeyValuePair<string,string>("rp",    "2000"),
                new KeyValuePair<string,string>("sortname", "acctstoptime"),
                new KeyValuePair<string,string>("sortorder", "asc")
            });

            try
            {
                var response = await client.PostAsync(url, payload);
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
