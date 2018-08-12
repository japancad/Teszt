using FamilyPhotos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Data
{
    public class FamilyPhotosContext : DbContext
    {
        public FamilyPhotosContext(DbContextOptions<FamilyPhotosContext> option) : base(option)
        {

        }

        public DbSet<PhotoModel> Photos { get; set; }

    }
}
