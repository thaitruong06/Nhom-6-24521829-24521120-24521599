using System;

public class MonAn
{
    public string id { get; set; }
    public string ten_mon_an { get; set; }
    public double gia { get; set; }
    public string dia_chi { get; set; }
    public string dong_gop { get; set; } // Tên người đóng góp
    public string hinh_anh { get; set; } // URL ảnh
    public string mo_ta { get; set; }
}

// Class phụ để hứng cục data phân trang trả về từ API
public class PaginationResponse
{
    public MonAn[] data { get; set; } // Danh sách món ăn
    public int total { get; set; }    // Tổng số món
    public int page { get; set; }     // Trang hiện tại
    public int page_size { get; set; } // Kích thước trang
}