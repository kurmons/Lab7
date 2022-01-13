using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PcContext())
            {
                // Galvenā programma
                while (true) {
                    Console.WriteLine("Izveleties darbibu: ");
                    Console.WriteLine("\t1. Izvadīt informāciju ");
                    Console.WriteLine("\t2. Pievienot ierakstu ");
                    Console.WriteLine("\t3. Rediģēt informāciju ");
                    Console.WriteLine("\t4. Dzēst ierakstu ");
                    Console.WriteLine("\t5. Atlasīt datoru ar konkrētu ID ");
                    Console.WriteLine("\t6. Atlasīt datorus pēc to nosaukuma ");
                    Console.WriteLine("\t7. Iziet ");
                    var input = Console.ReadKey();
                    int choice;

                    if (char.IsDigit(input.KeyChar))
                    {
                        choice = int.Parse(input.KeyChar.ToString());
                    }
                    else
                    {
                        Console.WriteLine("\nIevadiet korektu vērtību!");
                        continue;
                    }

                    switch (choice)
                    {
                        // Informācijas izvade
                        case 1:
                            Console.WriteLine("\n\t1. Izvadīt informāciju par datoriem");
                            Console.WriteLine("\t2. Izvadīt informāciju par procesoriem");
                            Console.WriteLine("\t3. Izvadīt informāciju par atmiņas diskiem");
                            input = Console.ReadKey();

                            if (char.IsDigit(input.KeyChar))
                            {
                                choice = int.Parse(input.KeyChar.ToString());
                            }
                            else
                            {
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                                continue;
                            }
                            if (choice == 1)
                                PrintPcs();
                            else if (choice == 2)
                                PrintCpus();
                            else if (choice == 3)
                                PrintDrives();
                            else
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                            break;

                        // Informācijas pievienošana
                        case 2:
                            Console.WriteLine("\n\t1. Pievienot datoru");
                            Console.WriteLine("\t2. Pievienot procesoru");
                            Console.WriteLine("\t3. Pievienot atmiņas disku");
                            input = Console.ReadKey();

                            if (char.IsDigit(input.KeyChar))
                            {
                                choice = int.Parse(input.KeyChar.ToString());
                            }
                            else
                            {
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                                continue;
                            }
                            if (choice == 1)
                                AddPc();
                            else if (choice == 2)
                                AddCpu();
                            else if (choice == 3)
                                AddDrive();
                            else
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                            break;

                        // Informācijas rediģēšana
                        case 3:
                            Console.WriteLine("\n\t1. Rediģēt datoru");
                            Console.WriteLine("\t2. Rediģēt procesoru");
                            Console.WriteLine("\t3. Rediģēt atmiņas disku");
                            input = Console.ReadKey();

                            if (char.IsDigit(input.KeyChar))
                            {
                                choice = int.Parse(input.KeyChar.ToString());
                            }
                            else
                            {
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                                continue;
                            }
                            if (choice == 1)
                                EditPc();
                            else if (choice == 2)
                                EditCpu();
                            else if (choice == 3)
                                EditDrive();
                            else
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                            break;

                        // Informācijas dzēšana
                        case 4:
                            Console.WriteLine("\n\t1. Dzest datoru");
                            Console.WriteLine("\t2. Dzest procesoru");
                            Console.WriteLine("\t3. Dzest atmiņas disku");
                            input = Console.ReadKey();

                            if (char.IsDigit(input.KeyChar))
                            {
                                choice = int.Parse(input.KeyChar.ToString());
                            }
                            else
                            {
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                                continue;
                            }
                            if (choice == 1)
                                DeletePc();
                            else if (choice == 2)
                                DeleteCpu();
                            else if (choice == 3)
                                DeleteDrive();
                            else
                                Console.WriteLine("\nIevadiet korektu vērtību!");
                            break;

                        // Ieraksta atlasisana
                        case 5:
                            Console.WriteLine("\nIevadiet datora Id");
                            var Id = int.Parse(Console.ReadLine());
                            var result = db.Pcs.FirstOrDefault(p => p.PcId == Id);
                            if (result != null) {
                                String data = String.Format("{0,-5} {1,-15} {2,-15}", result.PcId, result.Manufacturer, result.Name);
                                Console.WriteLine(data);
                            }
                            else
                            {
                                Console.WriteLine("Dators ar šādu ID netika atrasts!");
                            }
                            break;

                        // Vairaku ierakstu atlasisana
                        case 6:
                            Console.WriteLine("\nIevadiet dalu no datora nosaukuma!");
                            String StrInput = Console.ReadLine();
                            var results = db.Pcs.Where(p => p.Name.Contains(StrInput));
                            foreach (var item in results)
                            {
                                String data = String.Format("{0,-5} {1,-15} {2,-15}", item.PcId, item.Manufacturer, item.Name);
                                Console.WriteLine(data);
                            }
                            break;

                        case 7:
                            Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("\nIevadiet korektu vērtību!");
                            break;
                    }
                }

                // Funkcija jauna datora pievienošanai
                void AddPc() {
                    Console.WriteLine("Ievadiet jauna datora ražotāju: ");
                    var manufacturer = Console.ReadLine();
                    Console.WriteLine("Ievadiet jauna datora nosaukumu: ");
                    var name = Console.ReadLine();

                    var pc = new Pc { Name = name, Manufacturer=manufacturer };
                    db.Pcs.Add(pc);
                    db.SaveChanges();
                }

                // Funkcija jauna procesora pievienošanai
                void AddCpu()
                {
                    Console.WriteLine("Ievadiet jauna procesora ražotāju: ");
                    var manufacturer = Console.ReadLine();
                    Console.WriteLine("Ievadiet jauna procesora nosaukumu: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Ievadiet procesora kodolu skaitu: ");
                    var core = int.Parse(Console.ReadLine());

                    var cpu = new Cpu { Name = name, Manufacturer = manufacturer, CoreCount = core };
                    db.Cpus.Add(cpu);
                    db.SaveChanges();
                }

                // Funkcija jauna diska pievienošanai
                void AddDrive()
                {
                    Console.WriteLine("Ievadiet atmiņas diska nosaukumu: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Ievadiet atmiņas diska tipu: ");
                    var type = Console.ReadLine();
                    Console.WriteLine("Ievadiet atmiņas ietilpību: ");
                    var size = int.Parse(Console.ReadLine());

                    var drive = new Drive { Name = name, Type = type, Size = size };
                    db.Drives.Add(drive);
                    db.SaveChanges();
                }

                // Funkcija datoru izvadei
                void PrintPcs()
                {
                    Console.WriteLine("\nVisi pieejamie datori: ");
                    var query = from p in db.Pcs
                                orderby p.Name
                                select p;
                    String data = String.Format("{0,-5} {1,-15} {2,-15}","Id", "Razotajs", "Nosaukums");
                    Console.WriteLine(data);
                    foreach (var item in query)
                    {
                        data = String.Format("{0,-5} {1,-15} {2,-15}", item.PcId, item.Manufacturer, item.Name);
                        Console.WriteLine(data);
                    }
                }

                // Funkcija procesoru izvadei
                void PrintCpus()
                {
                    Console.WriteLine("\nVisi pieejamie procesori: ");
                    var query = from c in db.Cpus
                                orderby c.Name
                                select c;

                    String data = String.Format("{0,-5} {1,-15} {2,-15} {3,-10}", "Id", "Razotajs", "Nosaukums", "Kodoli");
                    Console.WriteLine(data);
                    foreach (var item in query)
                    {
                        data = String.Format("{0,-5} {1,-15} {2,-15} {3,-10}", item.CpuId, item.Manufacturer, item.Name, item.CoreCount);
                        Console.WriteLine(data);
                    }
                }

                // Funkcija procesoru izvadei
                void PrintDrives()
                {
                    Console.WriteLine("\nVisi pieejamie atmiņas diski: ");
                    var query = from d in db.Drives
                                orderby d.Name
                                select d;

                    String data = String.Format("{0,-5} {1,-15} {2,-10} {3,-10}", "Id", "Nosaukums", "Tips", "Ietilpiba");
                    Console.WriteLine(data);
                    foreach (var item in query)
                    {
                        data = String.Format("{0,-5} {1,-15} {2,-10} {3,-10}", item.DriveId, item.Name, item.Type, item.Size);
                        Console.WriteLine(data);
                    }
                }

                //Funkcija datoru rediģēšanai
                void EditPc()
                {
                    Console.WriteLine("\nIevadiet datora Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Pcs.FirstOrDefault(p => p.PcId == Id);
                    if (result != null)
                    {
                        Console.WriteLine("Ievadiet datora ražotāju: ");
                        var manufacturer = Console.ReadLine();
                        Console.WriteLine("Ievadiet datora nosaukumu: ");
                        var name = Console.ReadLine();
                        result.Manufacturer = manufacturer;
                        result.Name = name;
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Dators ar šādu ID netika atrasts!");
                    }
                }

                //Funkcija procesoru rediģēšanai
                void EditCpu()
                {
                    Console.WriteLine("\nIevadiet procesora Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Cpus.FirstOrDefault(c => c.CpuId == Id);
                    if (result != null)
                    {
                        Console.WriteLine("Ievadiet procesora ražotāju: ");
                        var manufacturer = Console.ReadLine();
                        Console.WriteLine("Ievadiet procesora nosaukumu: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Ievadiet kodolu skaitu: ");
                        var core = int.Parse(Console.ReadLine());
                        result.Manufacturer = manufacturer;
                        result.Name = name;
                        result.CoreCount = core;
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Procesors ar šādu ID netika atrasts!");
                    }
                }

                //Funkcija disku rediģēšanai
                void EditDrive()
                {
                    Console.WriteLine("\nIevadiet atmiņas diska Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Drives.FirstOrDefault(d => d.DriveId == Id);
                    if (result != null)
                    {
                        Console.WriteLine("Ievadiet atmiņas diska nosaukumu ");
                        var name = Console.ReadLine();
                        Console.WriteLine("Ievadiet diska tipu: ");
                        var type = Console.ReadLine();
                        Console.WriteLine("Ievadiet diska izmēru: ");
                        var size = int.Parse(Console.ReadLine());
                        result.Name = name;
                        result.Type = type;
                        result.Size = size;
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Atmiņas disks ar šādu ID netika atrasts!");
                    }
                }

                // Funkcija datora dzesanai
                void DeletePc()
                {
                    Console.WriteLine("\nIevadiet datora Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Pcs.FirstOrDefault(p => p.PcId == Id);
                    if (result != null)
                    {
                        db.Pcs.Remove(result);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Dators ar šādu ID netika atrasts!");
                    }
                }

                // Funkcija procesora dzesanai
                void DeleteCpu()
                {
                    Console.WriteLine("\nIevadiet procesora Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Cpus.FirstOrDefault(c => c.CpuId == Id);
                    if (result != null)
                    {
                        db.Cpus.Remove(result);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Procesors ar šādu ID netika atrasts!");
                    }
                }

                // Funkcija procesora dzesanai
                void DeleteDrive()
                {
                    Console.WriteLine("\nIevadiet diska Id: ");
                    var Id = int.Parse(Console.ReadLine());

                    var result = db.Drives.FirstOrDefault(d => d.DriveId == Id);
                    if (result != null)
                    {
                        db.Drives.Remove(result);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Atminas disks ar šādu ID netika atrasts!");
                    }
                }
            }

            

        }
    }
}
