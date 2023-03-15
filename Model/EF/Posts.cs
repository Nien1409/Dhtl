namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            Posts_Categorys = new HashSet<Posts_Categorys>();
        }

        public int PostsID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Sumary { get; set; }

        public DateTime Published { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Content { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public int? UsersID { get; set; }

        public bool Status { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts_Categorys> Posts_Categorys { get; set; }
    }
}
