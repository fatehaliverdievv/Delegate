
using DelegateTask2.Models;
using System;
using System.ComponentModel;

namespace DelegateTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exam> examsforjanuary = new List<Exam>();
            Student Ramal = new Student("Ramal", "Fatullayev");
            Exam csharpexam = new Exam(Ramal, 90, "C#", new DateTime(2022, 12, 3, 14, 0, 0), new DateTime(2022, 12, 3, 17, 0, 0));
            Student Sahnaz = new Student("Sahnaz", "Memmedova");
            Exam sqlexam = new Exam(Sahnaz, 80, "Sql", new DateTime(2022, 12, 23, 10, 0, 0), new DateTime(2022, 12, 23, 13, 0, 0));
            Student Samil = new Student("Shamil", "Omarov");
            Exam dotnetexam = new Exam(Samil, 100, ".NET", new DateTime(2022, 12, 3, 9, 0, 0), new DateTime(2022, 12, 3, 14, 0, 0));
            examsforjanuary.Add(csharpexam);
            examsforjanuary.Add(sqlexam);
            examsforjanuary.Add(dotnetexam);
        newstudentinfo:
            while (true)
            {
                Console.Write("Adi daxil edin : ");
                string name = Console.ReadLine();
                Console.Write("Soyadi daxil edin : ");
                string surname = Console.ReadLine();
                Student student = new Student(name, surname);
                Console.Write("Telebenin balini daxil edin : ");
                byte point = Convert.ToByte(Console.ReadLine());
                Console.Write("Fenni daxil edin : ");
                string subject = Console.ReadLine();
                Console.Write("Ili daxil edin : ");
                int year = Convert.ToInt32(Console.ReadLine());
                if (year > DateTime.Now.Year && year>1900)
                {
                    throw new Exception("Gelecek tarix daxil edile bilmez");
                }
                Console.Write("Ayi daxil edin : ");
                byte month = Convert.ToByte(Console.ReadLine());
                if (month > 12 && month < 0 )
                {
                    throw new Exception("Ay sayi 12den cox ve ya 0dan kicik bilmez!!");
                }
                Console.Write("Gunu daxil edin : ");
                byte day = Convert.ToByte(Console.ReadLine());
                if (day > 31 && day<0)
                {
                    throw new Exception("Bir ayda 31den boyuk ve ya 0dan kicikkgun yoxdu !!!");
                }
                Console.Write("Saati daxil edin : ");
                byte hour = Convert.ToByte(Console.ReadLine());
                if(hour>=24 && hour < 0)
                {
                    throw new Exception("Duzgun saat daxil edin");
                }
                Console.Write("Deqiqeni daxil edin : ");
                byte minute = Convert.ToByte(Console.ReadLine());
                if(minute > 60 && minute<0)
                {
                    throw new Exception("Deqiqe 60dan boyuk ola ve ya 0dan kicik bilmez!! bilmez!!");
                }
                Console.Write("Bitme saatini daxil edin : ");
                byte endhour = Convert.ToByte(Console.ReadLine());
                if (endhour >= 24 && hour < 0)
                {
                    throw new Exception("Duzgun saat daxil edin");
                }
                Console.Write("Bitme deqiqesini daxil edin : ");
                int endminute = Convert.ToInt32(Console.ReadLine());
                if (endminute > 60 && endminute < 0)
                {
                    throw new Exception("Deqiqe 60dan boyuk ola ve ya 0dan kicik bilmez!!");
                }

                DateTime EndDate = new DateTime(year, month, day, endhour, endminute, 0);
                DateTime Startdate = new DateTime(year, month, day, hour, minute, 0);
                Exam exam = new(student, point, subject, Startdate, EndDate);
                if (exam.Enddate.Subtract(Startdate) < TimeSpan.Zero)
                {
                    throw new Exception("Bitis tarixi baslangic tarixinden evvel ola bilmez");
                }
                else if (exam.Enddate.Subtract(Startdate) > TimeSpan.FromHours(8))
                {
                    throw new Exception("8 saatdan cox imtahan ola bilmez !!");
                }
                examsforjanuary.Add(exam);
                Console.WriteLine("Yene telebe elave etmek isteyirsiniz? he/yox");
                addingstudentcommand:
                string addingnew = Console.ReadLine();
                addingnew = addingnew.ToLower().Trim();
                if (addingnew == "he")
                {
                    goto newstudentinfo;
                }
                else if (addingnew == "yox")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Duzgun command daxil edin !!");
                    goto addingstudentcommand;
                }
            }
            Console.WriteLine("Bali 50den yuxari olanlar : ");
                    foreach (Exam item in examsforjanuary.FindAll(exam => exam.Point >= 50))
                    {
                        Console.WriteLine(item.Student.StudentName + " " + item.Student.StudentSurname+ " " + item.Subject + " " + item.Point+" Duration - " + item.Enddate.Subtract(item.StartDate));
                    }
            Console.WriteLine("Son 7 gun erzinde olan imtahanlar :");
                    foreach (Exam item in examsforjanuary.FindAll(exam => DateTime.Now.Subtract(exam.Enddate) <= TimeSpan.FromDays(7) && DateTime.Now.Subtract(exam.Enddate)>TimeSpan.Zero))
                    {
                        Console.WriteLine(item.Student.StudentName + " " + item.Student.StudentSurname + " " + item.Subject + " " + item.Point + " Duration - " + item.Enddate.Subtract(item.StartDate));
                    }
            Console.WriteLine("1 saatdan uzun ceken imtahanlar : ");
                    foreach(Exam item in examsforjanuary.FindAll(exam=> exam.Enddate.Subtract(exam.StartDate) > TimeSpan.FromMinutes(60)))
                    {
                        Console.WriteLine(item.Student.StudentName + " " + item.Student.StudentSurname + " " + item.Subject + " " + item.Point + " Duration - " + item.Enddate.Subtract(item.StartDate));
                    }
            }
        }
    }