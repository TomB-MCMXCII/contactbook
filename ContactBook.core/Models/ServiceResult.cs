using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.core
{
    public class ServiceResult
    {
        public int Id { get; set; }
        public bool Succeded { get; set; }
        public string err { get; set; }
        

        public ServiceResult(bool succeeded, int id)
        {       
            Succeded = succeeded;
            Id = id;
        }
        public ServiceResult(string err)
        {
            this.err = err;
        }
       
    }
}
