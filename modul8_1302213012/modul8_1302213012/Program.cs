using modul8_1302213012;
internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();

        if (config.BT.lang.Contains("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.BT.lang.Contains("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer");
        }

        string transfer = Console.ReadLine();
        int jumlahTransfer = (int)Convert.ToInt32(transfer);

        int biayaTransfer = 0;
        if (jumlahTransfer <= config.BT.transfer.threshold)
        {
            biayaTransfer = config.BT.transfer.low_fee;
        }
        else if (jumlahTransfer > config.BT.transfer.threshold)
        {
            biayaTransfer = config.BT.transfer.high_fee;
        }

        if (config.BT.lang.Contains("en"))
        {
            Console.WriteLine("Transfer fee = " + biayaTransfer + "\nTotal amount = " + (jumlahTransfer + biayaTransfer));
        }
        else if (config.BT.lang.Contains("id"))
        {
            Console.WriteLine("Biaya Transfer = " + biayaTransfer + "\nTotal biaya = " + (jumlahTransfer + biayaTransfer));
        }

        if (config.BT.lang.Contains("en"))
        {
            Console.WriteLine("Select transfer method : ");
        }
        else if (config.BT.lang.Contains("id"))
        {
            Console.WriteLine("Pilih metode transfer : ");
        }

        for (int i = 0; i < config.BT.methods.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + config.BT.methods[i]);
        }

        Console.Write("Pilih: ");
        string metode = Console.ReadLine();
        int metodeTransfer = (int)Convert.ToInt32(transfer);

        if (config.BT.lang.Contains("en"))
        {
            Console.WriteLine("Please type " + config.BT.confirmation.en + " to confirm the transaction:");
        }
        else if (config.BT.lang.Contains("id"))
        {
            Console.WriteLine("Ketik " + config.BT.confirmation.id + " untuk mengkonfirmasi transaksi:");
        }

        string inputKonfirmasi = Console.ReadLine();

        if (config.BT.lang.Contains("en"))
        {
            if (inputKonfirmasi.Contains(config.BT.confirmation.en))
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        }
        else if (config.BT.lang.Contains("id"))
        {
            if (inputKonfirmasi.Contains(config.BT.confirmation.id))
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}