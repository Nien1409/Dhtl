namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts_Categorys
    {
        [Key]
        public int PCID { get; set; }

        public int? CategorysID { get; set; }

        public int? PostsID { get; set; }

        public virtual Categorys Categorys { get; set; }

        public virtual Posts Posts { get; set; }
    }
}
