using System;

public class Movie
{
    public string TenPhim { get; set; }
    public string LinkAnh { get; set; }
    public string LinkChiTiet { get; set; }

    // Hàm khởi tạo để gán giá trị nhanh
    public Movie(string ten, string anh, string link)
    {
        TenPhim = ten;
        LinkAnh = anh;
        LinkChiTiet = link;
    }
}