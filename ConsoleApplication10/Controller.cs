using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
namespace ConsoleApplication10
{
    public class Controller : view
    {
        public Controller()
            : base()
        {

        }
        public void SelectDrv()
        {
            SetSelected(0);
            //view Vw=new view();
            SelectDrive(0);
            SetControl('0');
            while (GetControl() != '`')
            {
                if ((Getselected() % 26) == 0)
                    SetNewPageInMenu(Getselected());
                else if (Convert.ToInt32(Getselected()) < GetNewPageInMenu())
                    SetNewPageInMenu(Convert.ToInt32(Getselected() - Getselected() % 26));
                Console.SetCursorPosition(0, GetNewPageInMenu());
                SetControl(Console.ReadKey().KeyChar);
                System.Console.Clear();
                switch (GetControl())
                {
                    case 's':
                        {
                            SelectDrive(0);
                            break;
                        }
                    case 'w':
                        {
                            SelectDrive(1);
                            break;
                        }
                    case ' ':
                        {
                            if (Getselected() > 0)
                            {
                                InDir(Convert.ToString(GetallDrives()[Getselected() - 1]));
                                SetSelected(1);
                                Setelements(1, 0);
                                Setelements(2, 0);
                                ShowFiles();
                                run();
                            }
                            else
                            {
                                Console.WriteLine("Пожалуйста выберите диск");
                                SetSelected(0);
                            }
                            break;
                        }
                }
            };
        }
        public void run()
        {
            
            ShowFiles();
            while (GetControl() != '`')
            {
                // Getelements()[0] = 0;
                // Getelements()[1] = 0;
                if ((Getselected() % 26) == 0)
                    SetNewPageInMenu(Getselected());
                else if (Convert.ToInt32(Getselected()) < GetNewPageInMenu())
                    SetNewPageInMenu(Convert.ToInt32(Getselected() - Getselected() % 26));
                Console.SetCursorPosition(0, GetNewPageInMenu());
                SetControl(Console.ReadKey().KeyChar);
                System.Console.Clear();
                switch (GetControl())
                {
                    case 's':
                        {
                            TOView(0);
                            break;
                        }
                    case 'w':
                        {
                            TOView(1);
                            break;
                        }
                    case ' '://InDir/File
                        {
                            
                                if (Getselected() <= Getelements()[1])
                                {
                                    Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " + Convert.ToString(Getfiles()[Getselected() - 1]));
                                    ShowFiles();
                                }

                                else
                                {
                                    InDir(Convert.ToString(GetDi2()) + Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]));
                                    SetSelected(1);
                                    Setelements(1, 0);
                                    ShowFiles();
                                }
                            
                            //else SetDrive(string a)
                            break;
                        }
                    case '1'://Back
                        {
                            try
                            {
                                InDir(Convert.ToString(GetDi2()).Substring(0, (Convert.ToString(GetDi2()).Substring(0, Convert.ToString(GetDi2()).LastIndexOf('\\')).LastIndexOf('\\'))));
                                SetSelected(1);
                                Setelements(1, 0);
                                ShowFiles();
                            }
                            catch (Exception)
                            {
                                SelectDrv();
                                break;
                            }
                            break;
                        }
                    default:
                        {
                            ShowFiles();
                            break;
                        }
                    case '2'://Save inform for copy/move
                        {
                            if (Getselected() <= Getelements()[1])
                                SetFileForCopy(Convert.ToString(GetDi2()) + Convert.ToString(Getfiles()[Getselected() - 1]), Convert.ToString(Getfiles()[Getselected() - 1]), Getselected(), true);
                            else
                                SetFileForCopy(Convert.ToString(GetDi2()) + Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]), Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]), Getselected(), false);
                            ShowFiles();
                            break;
                        }
                    case '3'://Copy File/Folder
                        {
                            if (Convert.ToBoolean(GetFileForCopy()[3]).Equals(true))
                            {
                                File.Copy(GetFileForCopy()[0], Convert.ToString(GetDi2()) + GetFileForCopy()[1],true);
                                InDir(Convert.ToString(GetDi2()));
                                ShowFiles();
                            }
                            else
                            {
                                System.IO.Directory.CreateDirectory(Convert.ToString(GetDi2()) + GetFileForCopy()[1]);
                                // To copy a file to another location and sssssss
                                // overwrite the destination file if it already exists.
                                foreach (FileInfo f in new DirectoryInfo(GetFileForCopy()[0]).GetFiles())
                                {
                                   // Console.Write(f);
                                   // Console.WriteLine(f.Length);
                                    File.Copy(GetFileForCopy()[0]+"\\"+f, Convert.ToString(GetDi2()) +GetFileForCopy()[1]+"\\"+ f, true);
                                }
                               // while (Convert.ToInt32(GetFileForCopy()[2]) > 0)
                               // File.Copy(GetFileForCopy()[0], Convert.ToString(GetDi2()) + GetFileForCopy()[1], true);


                                //CopyDirectory(Convert.ToString(GetDi2()) + Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]), true);
                                      InDir(Convert.ToString(GetDi2()));
                                     ShowFiles();
                            }
                            break;
                        }
                    case '4'://Move File/Folder
                        {
                            if (Convert.ToBoolean(GetFileForCopy()[3]).Equals(true))
                            {
                                Console.WriteLine("File");
                                // File.Copy(GetPathForMove(),Convert.ToString(GetDi2()) + Convert.ToString(Getfiles()[Getselected() - 1]));//2 стринга старый путь, новый путь
                                File.Move(GetFileForCopy()[0], Convert.ToString(GetDi2()) + GetFileForCopy()[1]);
                                InDir(Convert.ToString(GetDi2()));
                                ShowFiles();
                            }
                            else
                            {
                               // Directory.Move(@"D:\1", @"D:\2");\\переименовали
                                Directory.Move(GetFileForCopy()[0], Convert.ToString(GetDi2() + GetFileForCopy()[1]));
                                InDir(Convert.ToString(GetDi2()));
                                ShowFiles();
                                //      InDir(Convert.ToString(GetDi2()));
                                //     ShowFiles();
                            }
                            break;
                        }
                    case '5'://rename
                        {
                            
                            if (Getselected() <= Getelements()[1])
                            {
                                Console.WriteLine("Введите новое имя файла и не забудьте указать расширение");
                                SetRename();
                                File.Move(Convert.ToString(GetDi2()) + Convert.ToString(Getfiles()[Getselected() - 1]), Convert.ToString(GetDi2()) + GetRename());
                            }
                            else
                            {
                                Console.WriteLine("Введите новое имя папки");
                                SetRename();
                                Directory.Move(Convert.ToString(GetDi2()) + Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]), Convert.ToString(GetDi2() + GetRename()));
                            }
                                InDir(Convert.ToString(GetDi2()));
                            ShowFiles();
                            
                            break;
                        }
                    case '6'://Delete File/Folder
                        {
                            //__________________________
                            if (Getselected() <= Getelements()[1])
                            {
                                File.Delete(Convert.ToString(GetDi2()) + Convert.ToString(Getfiles()[Getselected() - 1]));
                                InDir(Convert.ToString(GetDi2()));
                                ShowFiles();
                            }
                            else
                            {
                                Directory.Delete(Convert.ToString(GetDi2()) + Convert.ToString(Getdir()[Getselected() - Getelements()[1] - 1]), true);
                                InDir(Convert.ToString(GetDi2()));
                                ShowFiles();
                            }
                            //___________________________
                            //File.Delete(str);      //    delete files
                            //Console.WriteLine(GetPathForMove());
                            //Getfiles()[Getselected()].MoveTo("./../../" + f.Name);
                            break;
                        }
                }
            }
        }
    }
}
