using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PAS 
{
    class Program
    {
        enum tanya
        {
            y, n
        }

        struct menuMakan
        {
            public string namaMakan;
            public int harga;

         }
        struct menuminuman  
        {
            public string namaminum;
            public int harga;
        }

        static menuMakan[] daftarmakan = new menuMakan[7]
        {
            new menuMakan { namaMakan = "Nasi Goreng".PadRight(18), harga = 15000 },
            new menuMakan { namaMakan = "Ayam Suwir".PadRight(18), harga = 13000 },
            new menuMakan { namaMakan = "Ayam Geprek".PadRight(18), harga = 12000 },
            new menuMakan { namaMakan = "Pecel Lele".PadRight(18), harga = 10000 },
            new menuMakan { namaMakan = "Ayam Bakar".PadRight(18), harga = 22000 },
            new menuMakan { namaMakan = "Bebek Goreng".PadRight(18), harga = 20000 },
            new menuMakan { namaMakan = "Bebek Bakar".PadRight(18), harga = 25000 },
        };

        static menuminuman[] daftarminum = new menuminuman[8]
        {
            new menuminuman { namaminum = "ES Teh".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Teh Hangat".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Es jeruk".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Jeruk Hangat".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Kopi Hitam".PadRight(18),harga = 4000 },
            new menuminuman { namaminum = "Es Buah".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Mineral".PadRight(18),harga = 5000 },
            new menuminuman { namaminum = "Capuccino".PadRight(18),harga = 12000 },
        };

        static string[] strukMakan;
        static string[] strukminuman;
        static int total;
        static int total2;
        static int total3;
        static int totalHarga;
        static double totalBayar;
        static double tax;
        static string nama;
        static string alamat;
        static string telp;
        static string kasir;

        static string barAnimasi(int hitung)
        {
            string barAnime = "[";
            for (int i = 0; i < hitung; i++)
            {
                barAnime += "███";
            }
            barAnime += "]";
            return barAnime;
        }
        static void loadingAnime()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 11; i++)
            {
                Console.Write("\rLoading.... " + barAnimasi(i) + " " + i * 10 + "%");
                Thread.Sleep(150);
            }
        }

        static void tampilanMenu()
        {
            Console.Clear();
            header();
            Console.WriteLine("No.".PadRight(7) + "Nama Menu".PadRight(22) + "Harga");
            Console.WriteLine(new string('-', 38));
            for (int i = 0; i < daftarmakan.Length; i++)
            {
                Console.WriteLine((i + 1 + ".").ToString().PadRight(7) + daftarmakan[i].namaMakan.PadRight(22) + daftarmakan[i].harga.ToString("Rp #,##0"));
            }
            Console.WriteLine(new string('-', 38));

        }

        static void tampilanmenu2()
        {
            Console.Clear();
            header();
            Console.WriteLine("No.".PadRight(7) + "Nama Menu".PadRight(22) + "Harga");
            Console.WriteLine(new string('-', 38));
            for (int j = 0; j < daftarminum.Length; j++)
            {
                Console.WriteLine((j + 1 + ".").ToString().PadRight(7) + daftarminum[j].namaminum.PadRight(22) + daftarminum[j].harga.ToString("Rp #,##0"));
            }
            Console.WriteLine(new string('-', 38));
        }
        static void header()
        {

            DateTime today = DateTime.Now;
            string hari = today.ToString("dddd");
            string tanggal = today.ToString("dd/MMM/yyyy");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new string(' ', 12) + "Rumah Makan Kita\n" + new string(' ', 12) + "RM KITA - PURWOKERTO\n" + new string(' ', 11) + "Postal Code: 91974");
            Console.WriteLine(new string(' ', 9) + "91974 (0123)4567 - 89");
            Console.WriteLine();
            Console.WriteLine(tanggal.PadRight(30) + hari);
            Console.WriteLine(new string('=', 38));
        }

        static void headerstruk()
        {
            Console.ForegroundColor = ConsoleColor.White;
            DateTime today = DateTime.Now;
            string hari = today.ToString("dddd");
            string tanggal = today.ToString("dd/MMM/yyyy");
            string jam = today.ToString("H:m:s");


            Console.WriteLine(new string(' ', 16) + "Rumah Makan Kita\n" + new string(' ', 16) + "RM KITA - PURWOKERTO\n" + new string(' ', 15) + "Postal Code: 53147");
            Console.WriteLine(new string(' ', 13) + "53147 (0123)4567 - 89");
            Console.WriteLine(tanggal.PadRight(38) + hari);
            Console.WriteLine(jam.PadRight(37) + "Server: " + $"{kasir}".ToString().ToUpper());
            Random rnd = new Random();
            for (int j = 0; j < 1; j++)
            {
                Console.WriteLine(new string(' ', 16) + "ID Struk " + rnd.Next());
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string(' ', 23) + $"{nama}\n".ToString().ToUpper() + new string(' ', 19) + $"{telp}");
            Console.WriteLine(new string('-', 50));
        }

        static void pembelian()
        {
        reenter:
            bool valid = false;
            int noMenu;
            try
            {
                do
                {
                    Console.Write("Masukkan jenis makanan yang ingin dibeli: ");
                    noMenu = int.Parse(Console.ReadLine()) - 1;
                    if (noMenu >= 0 && noMenu < daftarmakan.Length)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Menu yang dipilih tidak tersedia, Silahkan input ulang");
                        Console.ReadKey();
                    }
                } while (!valid);
            }
            catch
            {
                Console.WriteLine("Silahkan input berupa angka!");
                goto reenter;
            }

        reenter1:
            try
            {
                Console.Write("Masukkan jumlah makanan yang dipilih: ");
                int jumlahMakan = int.Parse(Console.ReadLine());
                int jumlah = daftarmakan[noMenu].harga * jumlahMakan;

                Array.Resize(ref strukMakan, strukMakan.Length + 1);
                strukMakan[strukMakan.Length - 1] = $"{daftarmakan[noMenu].namaMakan} - {daftarmakan[noMenu].harga.ToString("Rp #,##0")} x {jumlahMakan}\t {jumlah.ToString("Rp #,##0")}";
                total += daftarmakan[noMenu].harga * jumlahMakan;
            }
            catch (Exception e)
            {
                Console.WriteLine("Kesalahan penginputan, Silahkan input berupa angka!");
                goto reenter1;
            }

        }
        static void tambahan()
        {
        returnd2:
            bool valid = false;
            int noMenu;

            try
            {
                do
                {
                    Console.Write("Masukkan jenis minuman yang ingin dibeli: ");
                    noMenu = int.Parse(Console.ReadLine()) - 1;
                    if (noMenu >= 0 && noMenu < daftarminum.Length)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Menu yang dipilih tidak tersedia, Silahkan input ulang");
                        Console.ReadKey();
                    }
                } while (!valid);
            }
            catch
            {
                Console.WriteLine("Silahkan input berupa angka!");
                goto returnd2;
            }

        returnd3:
            try
            {
                Console.Write("Masukkan jumlah minuman yang dipilih: ");
                int jumlahminuman = int.Parse(Console.ReadLine());
                int jumlah = daftarminum[noMenu].harga * jumlahminuman;

                Array.Resize(ref strukminuman, strukminuman.Length + 1);
                strukminuman[strukminuman.Length - 1] = $"{daftarminum[noMenu].namaminum} - {daftarminum[noMenu].harga.ToString("Rp #,##0")} x {jumlahminuman}\t {jumlah.ToString("Rp #,##0")}";
                total3 += daftarminum[noMenu].harga * jumlahminuman;
            }
            catch
            {
                Console.WriteLine("Kesalahan penginputan, Silahkan input berupa angka!");
                goto returnd3;
            }
        }

        static void cetakStruk()
        {
            totalHarga = total + total2 + total3;
            tax = totalHarga * 0.11;
            totalBayar = totalHarga + tax;
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var makan in strukMakan)
            {
                Console.WriteLine(makan);
            }
            Console.WriteLine(new string('-', 50));
            foreach (var minuman in strukminuman)
            {
                Console.WriteLine(minuman);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(new string(' ', 34) + "Total: " + totalHarga.ToString("Rp #,##0"));
            Console.WriteLine(new string(' ', 34) + "Pajak: " + tax.ToString("Rp #,##0"));
            Console.WriteLine(new string(' ', 40) + new string('-', 10));
            Console.WriteLine(new string(' ', 23) + "Total Pembayaran: " + totalBayar.ToString("Rp #,##0"));
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Alamat Pelanggan: " + alamat);
        }

        static void tny()
        {
            do
            {
                Console.Clear();
                tampilanMenu();
                pembelian();

                Console.Write("Apakah anda ingin menambah makanan lain? [Y/N]: ");
                tanya Tanya = (tanya)Enum.Parse(typeof(tanya), Console.ReadLine(), true);
                if (Tanya == tanya.n)
                {
                    break;
                }
            } while (true);
        }
        static void tny2()
        {
            do
            {
                Console.Clear();
                tampilanmenu2();
                tambahan();

                Console.Write("Apakah anda ingin menambah miunman lain? [Y/N]: ");
                tanya Tanya = (tanya)Enum.Parse(typeof(tanya), Console.ReadLine(), true);
                if (Tanya == tanya.n)
                {
                    break;
                }
                else if (Tanya == tanya.y)
                {
                    tny();

                }
            } while (true);
        }
        static void background()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Main(string[] args)
        {
            Console.Title = "Rumah Makan Kita";
            Console.WriteLine("Selamat datang di Rumah Makan Kita, Silahkan tunggu..");
            loadingAnime();
            Console.Clear();
        ulang:
            header();

            Console.Write("Masukkan Nama Anda: ");
            nama = Console.ReadLine();

            Console.Write("Masukkan Alamat Anda: ");
            alamat = Console.ReadLine();

            Console.Write("Masukkan Nama Kasir: ");
            kasir = Console.ReadLine();

            Console.Write("Masukkan Nomor Telepon Anda: ");
            telp = Console.ReadLine();
            if (telp.Length < 12 || telp.Length > 12)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Jumlah nomor telepon yang anda masukkan tidak sesuai/kurang, Silahkan input kembali!");
                Console.ReadKey();
                Console.Clear();

                goto ulang;
            }

            strukMakan = new string[0];
            total = 0;
            tny();

            strukminuman = new string[0];
            total2 = 0;
            tny2();
            Console.Clear();
            Console.WriteLine("Tunggu Sebentar, Struk sedang diproses!");
            loadingAnime();
            background();
            Console.Clear();

            headerstruk();
            cetakStruk();

            Console.ReadKey();
        }

    }
}

