using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace ConsoleApplication10
{
  public  class Model
    {
       DriveInfo[] allDrives;
       private DirectoryInfo di2;
       private FileInfo[] files;
       private DirectoryInfo[] dir;
       char control;
       int selected;
       int[] elements;
       int NewPageInMenu;
       //string PathForMove;
       string[] FileForCopy;
       string rename;
       string Drive;
       bool isDriveSelected;
        public Model()
        {
            isDriveSelected = false;
            allDrives = DriveInfo.GetDrives();
            di2 = new DirectoryInfo("D:\\");
            files = di2.GetFiles();
            dir = di2.GetDirectories();
            control = '0';
            selected = 0;
            elements = new int[4];//[0]-кол-во элементов(файлов+папок) в директории при первом вхождении(необходимо для задания границ),[1] кол-во файлов в директории,[2]-кол-во элементов(файлов+папок) в директории в данный момент,[3]-количество дисков
            FileForCopy = new string[4];
            NewPageInMenu = 0;
        }
            public bool GetisDriveSelected()
            {
                return isDriveSelected;
            }
            public string GetDrive()
            {
            return Drive;
            }
            public DriveInfo[] GetallDrives()
            {
            return allDrives;
            }
            public string[] GetFileForCopy()
            {
            return FileForCopy;
            }
            public int GetNewPageInMenu()
            {
                return NewPageInMenu;
            }
            public DirectoryInfo GetDi2()
            {
                return di2;
            }
            public FileInfo[] Getfiles()
            {
                return files;
            }
            public DirectoryInfo[] Getdir()
            {
                return dir;
            }
            public char GetControl()
            {
                return control;
            }
            public int[] Getelements()
            {
                return elements;
            }
            public int Getselected()
            {
                return selected;
            }
            //public string GetPathForMove()
            //{
            //    return PathForMove;
            //}
            public string GetRename()
            {
                return rename;
            }
      public void SetGetisDriveSelected(bool a)
      {
          isDriveSelected=a;
      }
      public void SetSelected(int a)
      {
          selected = a;
      }
      public void SetControl(char ch)
      {
          control = ch;
      }
      public void Setelements(int a,int b)
      {
          elements[a] = b;
      }
      public void SetNewPageInMenu(int a)
      {
          NewPageInMenu = a;
      }
      public void InDir(string a)
      {
             
              di2 = new DirectoryInfo(a+"\\");
        //  files = new DirectoryInfo(a).GetFiles();
        //  dir = new DirectoryInfo(a).GetDirectories();
          files = di2.GetFiles();
          dir = di2.GetDirectories();
          //    //Console.WriteLine(Convert.ToString(files) + a);
          //}
          //else
          //    files = new DirectoryInfo(a).GetFiles();
      }
      //public void SetPathForMove(string a)
      //{
      //    PathForMove = a;
      //}
      public void SetFileForCopy(string a,string b,int c,bool isFile)
      {
          FileForCopy[0] = a;//path of file/dir
          FileForCopy[1] = b;//name of file/dir
          FileForCopy[2] = Convert.ToString(c);//количество элементов или файлов(не помню)
          FileForCopy[3] = Convert.ToString(isFile);
      }
      public void SetRename()
      {
          rename =Console.ReadLine();
      }
      public void SetDrive(string a)
      {
          Drive =a;
      }
    }
}
