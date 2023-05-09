using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class Dept
    {
        public int DEPTNO { get; set; }
        public String DNAME { get; set; }
        public String LOC { get; set; }
        public List<Employee> employees { get; set; }
    }
}