using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
namespace PhamThiThuyQuynh_241230831.Models;

public class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<HangHoa> HangHoas { get; set; } = new List<HangHoa>();
}
