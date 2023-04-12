using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302213012
{
    public class BankTransferConfig
    {
        public BankTransfer BT;
        private const string loc = ".";
        private const string path = loc + "\\" + @"bank_transfer_config.json";
        public transfer TF;
        public confirmation confirm;

        public BankTransferConfig()
        {
            try
            {
                readConfig();
            }
            catch
            {
                setDefault();
                writeBankTransferConfig();
            }
        }

        public void setDefault()
        {
            BT = new BankTransfer("en", new transfer(25000000, 6500, 15000),
                new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" },
                new confirmation("yes", "ya"));
        }

        public void writeBankTransferConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(BT, options);
            File.WriteAllText(path, json);
        }

        public void readConfig()
        {
            string read = File.ReadAllText(path);
            BT = JsonSerializer.Deserialize<BankTransfer>(read);
        }
    }
    public class BankTransfer
    {
        public string lang { get; set; }
        public transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public confirmation confirmation { get; set; }

        public BankTransfer() { }
        public BankTransfer(string lang, transfer transfer, List<string> methods, confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

    public class transfer
    {
        public int threshold { get; set;}
        public int low_fee { get; set;}
        public int high_fee { get; set;}

        public transfer(int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }

        public transfer() { }
    }

    public class confirmation
    {
        public string en { get; set; }
        public string id { get; set; }

        public confirmation(string en, string id)
        {
            this.en = en;
            this.id = id;
        }

        public confirmation() { }
    }
}
