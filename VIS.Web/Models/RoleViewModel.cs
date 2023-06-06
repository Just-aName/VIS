using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIS.Models
{
    public class RoleViewModel
    {
        [Key]
        public int Role_ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Role_ID = role.Id;
            Name = role.Name;
            Description = role.Description;
        }
    }
}