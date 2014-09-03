using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using FluentNHibernatePracticeOneToManyToMany;

namespace FluentNHibernatePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize(); 
          //  FirstPractice.DoPractice();
           // SecondPractice.SecondPractice.DoPractice();
          //  OneToMany.Do();
        //    Linq2Nhibernate.Do();
            OneToManyToMany.Do();
            ;
        }

       
    }
}


