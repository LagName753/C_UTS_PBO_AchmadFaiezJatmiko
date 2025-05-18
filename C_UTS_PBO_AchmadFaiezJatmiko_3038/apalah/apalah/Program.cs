using System;

public abstract class Template // Abstraction (yang ordal ordal aja)
{
    public string Nama { get; set; } // Encapsulation (Cuma get dan set, tapi get apa dan set apa tidak tahu)
}

public class Mahasiswa : Template // Turunan (Inheritance)
{
    public string NIM { get; set; }
    public string Jurusan { get; set; }
}

public class Gitulah
{
    private Mahasiswa[] data = new Mahasiswa[100];
    private int jumlah = 0;

    public void Create(Mahasiswa mahasiswa)
    {
        if (NimUnik(mahasiswa.NIM) != -1)
        {
            Console.WriteLine("NIM sudah ada, coba lagi");
            return;
        }

        data[jumlah++] = mahasiswa;
        Console.WriteLine("Data tersimpan");
    }

    public void Read()
    {
        if (jumlah == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        Console.WriteLine("\nDaftar Mahasiswa:");
        for (int i = 0; i < jumlah; i++)
        {
            Console.WriteLine($"NIM: {data[i].NIM}");
            Console.WriteLine($"Nama: {data[i].Nama}");
            Console.WriteLine($"Jurusan: {data[i].Jurusan}");
            Console.WriteLine("==============================");
        }
    }

    public void Update(string nim, string nama, string jurusan)
    {
        int index = NimUnik(nim);
        if (index == -1)
        {
            Console.WriteLine("pesan error");
            return;
        }

        data[index].Nama = nama;
        data[index].Jurusan = jurusan;
        Console.WriteLine("Data terupdate");
    }

    public void Delete(string nim)
    {
        int index = NimUnik(nim);
        if (index == -1)
        {
            Console.WriteLine("pesan error");
            return;
        }

        for (int i = index; i < jumlah - 1; i++)
        {
            data[i] = data[i + 1];
        }
        jumlah--;
        Console.WriteLine("Data terhapus");
    }

    private int NimUnik(string nim)
    {
        for (int i = 0; i < jumlah; i++)
        {
            if (data[i].NIM == nim)
            {
                return i;
            }
        }
        return -1;
    }
}

class MulaiDisini
{
    static void Main()
    {
        Gitulah PickMM = new Gitulah();
        bool jalan = true;

        while (jalan)
        {
            Console.WriteLine("\nS5 PickMM : Platform Integrasi Cerdas Kampus Management Mahasiswa");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih (1-5): ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\nNIM: ");
                    string nim = Console.ReadLine();
                    Console.Write("Nama: ");
                    string nama = Console.ReadLine();
                    Console.Write("Jurusan: ");
                    string jurusan = Console.ReadLine();

                    PickMM.Create(new Mahasiswa
                    {
                        NIM = nim,
                        Nama = nama,
                        Jurusan = jurusan
                    });
                    break;

                case "2":
                    PickMM.Read();
                    break;

                case "3":
                    Console.Write("\nNIM: ");
                    string nimBaru = Console.ReadLine();
                    Console.Write("Nama baru: ");
                    string namaBaru = Console.ReadLine();
                    Console.Write("Jurusan baru: ");
                    string jurusanBaru = Console.ReadLine();
                    PickMM.Update(nimBaru, namaBaru, jurusanBaru);
                    break;

                case "4":
                    Console.Write("\nNIM: ");
                    string nimHapus = Console.ReadLine();
                    PickMM.Delete(nimHapus);
                    break;

                case "5":
                    jalan = false;
                    break;

                default:
                    Console.WriteLine("1 sampai 5 aja, coba lagi");
                    break;
            }
        }
    }
}