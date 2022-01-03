using API.Context;
using API.Model;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;   

namespace API.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, University, int> 
    {
        public UniversityRepository(MyContext myContext) : base (myContext)
        {

        }
    }
}
