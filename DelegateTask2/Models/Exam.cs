using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTask2.Models
{
    internal class Exam
    {
        public Student Student { get; set; }
        byte _point;
        public byte Point 
        {
            get { return _point; }
            set 
            { 
                if(value<=100 &&value>=0)
                {
                    _point = value;
                }
                else
                {
                    throw new Exception("Bal 0dan kicik ve ya 100den boyuk ola bilmez");
                }
            }
        }
        string _subject;
        public string Subject 
        { 
            get { return _subject; }
            set
            {
                value= value.Trim();
                if(value!=null && value != "")
                {
                    _subject = value;
                }
                else
                {
                    throw new Exception("subject null ve ya bos ola bilmez");
                }
            }
        }
        DateTime _startdate;
        public DateTime StartDate 
        {
            get
            {
                return _startdate;
            }
            set
            {
                if (value != null)
                {
                    _startdate = value;
                }

                else
                {
                    throw new Exception("Datetime null ola bilmez !!");
                }
            } 
        }
        DateTime _enddate;
        public DateTime Enddate
        {
            get
            {
                return _enddate;
            }
            set
            {
                if (value != null)
                {
                    _enddate = value;
                }

                else
                {
                    throw new Exception("Datetime null ola bilmez !!");
                }
            }
        }
        public Exam(Student student,byte point , string subject, DateTime  startdate, DateTime enddate )
        {
            Student=student;
            Point = point;
            Subject=subject;
            StartDate=startdate;
            Enddate=enddate;    
        }

    }
}
