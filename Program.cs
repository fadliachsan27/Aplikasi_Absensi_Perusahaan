using Aplikasi_Absensi_Perusahaan.Services;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Mulai(); // gunakan Mulai, bukan TampilkanMenu langsung
namespace Aplikasi_Absensi_Perusahaan
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuService menuService = new MenuService();
            menuService.TampilkanMenu();
        }
    }
}
