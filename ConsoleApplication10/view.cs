using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication10
{
    public class view : Model
    {
        public view()
            : base()
        {
            Setelements(3, 0);
            Setelements(1, 0);
            Setelements(2, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            try
            {
                foreach (DriveInfo d in GetallDrives())
                {

                   

                    Console.WriteLine("Drive {0}", d.Name);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
                    Console.WriteLine("__________________________________________________________________");
                    Setelements(3, Getelements()[3] + 1);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Устройство отсутствует");
            }
        }
        public void SelectDrive(int a)
        {
            //Setelements(1, 0);
            Setelements(2, 0);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            if ((a.Equals(0)) && (Getselected() + 1 <= Getelements()[3]))
                SetSelected(Getselected() + 1);
            else if ((a.Equals(1)) && ((Getselected() - 1) != 0))
                SetSelected(Getselected() - 1);
            try
            {
                foreach (DriveInfo d in GetallDrives())
                {
                    Setelements(2, Getelements()[2] + 1);/////////////
                    if (Getelements()[2].Equals(Getselected()))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.WriteLine("Drive {0}", d.Name);
                    Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);
                    Console.WriteLine("__________________________________________________________________");

                }
            }
            catch (Exception)
            {
                Setelements(2, Getelements()[2] - 1);
                Console.WriteLine("Устройство отсутствует"); 
            }
        }
        public void ShowFiles()
        {

            Setelements(0, 0);
            Setelements(1, 0);
            Setelements(2, 0);
            /////////////////////////////////////
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" 1-Back|" + " 2-Copy/Cut|" + " 3-Copy|" + " 4-Move|" + " 5-Rename|" + " 6-Delete|" + " Space-Open|" + "~-Exit");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;


            foreach (FileInfo f in Getfiles())
            {

                Setelements(0, Getelements()[0] + 1);/////////////
                String[] lng = new string[2];
                lng[0] = Convert.ToString(f);
                lng[1] = Convert.ToString(f.Length);
                Console.Write(f);
                for (int i = 0; i < 79 - Convert.ToInt32(lng[0].Length) - Convert.ToInt32(lng[1].Length); i++)
                    Console.Write(' ');
                Console.WriteLine(f.Length);
                //f.Delete();          delete files
                // f.MoveTo("./../../" + f.Name);
            }
            foreach (DirectoryInfo d in Getdir())
            {
                Setelements(0, Getelements()[0] + 1);
                Console.WriteLine(d);
                //d.Delete();        delete folders
            }
            //control = Console.ReadLine();
            //////////////////////////////////////



        }
        public void TOView(int a)
        {

            //Setelements(0, 0);
            Setelements(1, 0);
            Setelements(2, 0);

            if ((a.Equals(0)) && (Getselected() + 1 <= Getelements()[0]))
                SetSelected(Getselected() + 1);
            else if ((a.Equals(1)) && ((Getselected() - 1) != 0))
                SetSelected(Getselected() - 1);
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" 1-Back|" + " 2-Copy/Cut|" + " 3-Copy|" + " 4-Move|" + " 5-Rename|" + " 6-Delete|" + " Space-Open|" + "~-Exit");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (FileInfo f in Getfiles())
            {
                Setelements(2, Getelements()[2] + 1);/////////////
                Setelements(1, Getelements()[1] + 1);/////
                if (Getelements()[2].Equals(Getselected()))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                String[] lng = new string[2];
                lng[0] = Convert.ToString(f);
                lng[1] = Convert.ToString(f.Length);
                Console.Write(f);
                for (int i = 0; i < 79 - Convert.ToInt32(lng[0].Length) - Convert.ToInt32(lng[1].Length); i++)
                    Console.Write(' ');
                Console.WriteLine(f.Length);
                //f.Delete();          delete files
                // f.MoveTo("./../../" + f.Name);
            }
            foreach (DirectoryInfo d in Getdir())
            {
                Setelements(2, Getelements()[2] + 1);//////////////////
                //Setelements(1, Getelements()[1] + 1);/////////
                if (Getelements()[2].Equals(Getselected()))
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(d);
                //d.Delete();        delete folders

            }
        }
    }
}
