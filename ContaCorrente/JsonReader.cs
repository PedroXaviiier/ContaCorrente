using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContaCorrente
{
    public class JsonReader
    {
        

        public List<Conta> JsonFileReader(string filePath)
        {
            List<Conta> contasCadastradas = new List<Conta>();

            var jsonFile = File.ReadAllText(filePath);
            contasCadastradas.Add(JsonConvert.DeserializeObject<Conta>(jsonFile));

            return contasCadastradas;

        }
    }
}
