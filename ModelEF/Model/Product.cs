namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int IDProduct { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống!")]
        [Display(Name = "Tên Sản Phẩm")]
        public string NameProduct { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống!")]
        [Display(Name = "Đơn Giá")]
        public int UnitCost { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống!")]
        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống!")]
        [StringLength(250)]
        [Display(Name = "Mô Tả")]
        public string DescriptionProduct { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool Status { get; set; }
       
        [Display(Name = "Danh Mục")]
        public int? CategoryNO { get; set; }

        public virtual Category Category { get; set; }
    }
}
