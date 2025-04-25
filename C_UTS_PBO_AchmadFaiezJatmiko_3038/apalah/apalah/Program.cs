
using System;
public class buatInheritance
{
    public string Nama;
}
public class mahasiswa : buatInheritance
{
    public string NIM;
    public string Jurusan;
}

public class programnya
{
    private mahasiswa[] dataList = new mahasiswa[10];
    private int count = 0;

    public void tambahData(mahasiswa dataBaru)
    {
        for (int i = 0; i < count; i++)
        {
            if (dataList[i].NIM == dataBaru.NIM){ 
                return;
            }
        }

        dataList[count++] = dataBaru;
        Console.WriteLine("Wee, udh Nambah datanya.");
    }

    public void lihatData()
    {
        if (count == 0)
        {
            Console.WriteLine("Nih isinya : Lorem ipsum dolor sit amet");
            return;
        }

        Console.WriteLine("\nList Data Mahasiswa : ");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"NIM : {dataList[i].NIM},     Nama : {dataList[i].Nama},  Jurusan : {dataList[i].Jurusan}");
        }
    }

    public void editData(string nim, string editNama, string editJurusan)
    {
        for (int i = 0; i < count; i++)
        {
            if (dataList[i].NIM == nim)
            {
                dataList[i].Nama = editNama;
                dataList[i].Jurusan = editJurusan;
                Console.WriteLine("Datanya udh keganti.");
                return;
            }
        }
    }

}

class mainProgram
{
    static void Main()
    {
        programnya list = new programnya();

        while (true)
        {
            Console.WriteLine("\nS5 PickMM : Platform Integrasi Cerdas Kampus Management Mahasiswa");
            Console.WriteLine("1. Tambah Data Mahasiswa");
            Console.WriteLine("2. Lihat List Data Mahasiswa");
            Console.WriteLine("3. Edit Data Mahasiswa");
            Console.WriteLine("4. Hapus Data Mahasiswa");
            Console.WriteLine("5. Keluar Program");
            Console.Write("Pilih sesuai angka yak : ");
            string pilihAngka = Console.ReadLine();

            switch (pilihAngka)
            {
                case "1":
                    Console.Write("\nNIM : ");
                    string nim = Console.ReadLine();
                    Console.Write("Nama : ");
                    string nama = Console.ReadLine();
                    Console.Write("Jurusan : ");
                    string jurusan = Console.ReadLine();

                    mahasiswa baru = new mahasiswa();
                    baru.NIM = nim;
                    baru.Nama = nama;
                    baru.Jurusan = jurusan;

                    list.tambahData(baru);
                    break;

                case "2":
                    list.lihatData();
                    break;

                case "3":
                    Console.Write("\nNim berapa yang di-edit? : ");
                    string nimBaru = Console.ReadLine();
                    Console.Write("Nama baru (klo sama ya masukin lagi) : ");
                    string namaBaru = Console.ReadLine();
                    Console.Write("Jurusan baru (klo sama ya masukin lagi) : ");
                    string jurusanBaru = Console.ReadLine();

                    list.editData(nimBaru, namaBaru, jurusanBaru);
                    break;

                case "4":
                    break;

                case "5":
                    break;

                default:
                    Console.WriteLine("Banh, 1 sampai 5 aja banh...");
                    break;
            }
        }
    }
}
