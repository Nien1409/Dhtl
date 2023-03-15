namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Posts = new HashSet<Posts>();
        }

        public int UsersID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int Phone { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public bool Status { get; set; }

        public int? RolesID { get; set; }

        public int? ProfilesID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }

        public virtual Profiles Profiles { get; set; }

        public virtual Roles Roles { get; set; }
    }
}
