using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTask2.Models
{
    internal class Student
    {
        string _studentName;
        string _studentSurname;
        public string StudentName { get { return _studentName; } 
            set 
            {
                value = value.Trim();
                if (value != null && value != "")
                {
                    _studentName = value;
                }
                else
                {
                    throw new Exception("Ad null ve ya bos ola bilmez");
                }
            } 
        }
        public string StudentSurname { get { return _studentSurname; } 
            set 
            {
                value = value.Trim();
                if (value != null && value != "")
                {
                    _studentSurname = value;
                }
                else
                {
                    throw new Exception("Soyad null ve ya bos ola bilmez");
                }
            } 
        }

        public Student(string studentname, string studentsurname)
        {
            StudentName = studentname;
            StudentSurname = studentsurname;
        }
        }
    }
