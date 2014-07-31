﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace FluentNHibernatePractice
{
    class DepartmentMap : ClassMap<Department>
    {
        //Constructor
        public DepartmentMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.PhoneNumber);
            Table("Department");
        }
    }
}
