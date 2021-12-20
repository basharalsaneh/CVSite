﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    //public class ProjectDBContext : DbContext
    //{
    //    public DbSet<Project> Projects { get; set; }

    //    //public System.Data.Entity.DbSet<CVSiteGrupp15.Models.Project> Projects { get; set; }
    //}
}
