using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxRegisterImport.Models;

namespace TaxRegisterImport
{
    public class TaxOpenDocParsers
    {
        public static async Task<RegisterTax[]> ParseEdPod(Stream stream)
        {            var streamReader = new StreamReader(stream);
            var result = new List<RegisterTax>();
            if (streamReader.EndOfStream) return result.ToArray();
            // skip firs line 
            var line = await streamReader.ReadLineAsync();
            while (!streamReader.EndOfStream)
            {
                line = await streamReader.ReadLineAsync();
                int pos = 0;
                var value = new RegisterTax();
                // name
                var delimiterPos = line.IndexOf("\";", pos);
                if (delimiterPos == -1) continue;



            }
            return result.ToArray();
        }
    }
}
