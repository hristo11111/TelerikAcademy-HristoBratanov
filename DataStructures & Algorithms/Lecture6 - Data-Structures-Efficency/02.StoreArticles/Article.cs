using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Article : IComparable
{
    private double price;
    private long barcode;
    private string vendor;
    private string title;

    public Article(string title, string vendor,
        long barcode, double price)
    {
        this.title = title;
        this.vendor = vendor;
        this.barcode = barcode;
        this.price = price;
    }

    public double Price
    {
        get { return this.price; }
    }

    public int CompareTo(object obj)
    {
        Article objAsArticle = obj as Article;
        return this.price.CompareTo(objAsArticle.price);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Title: " + this.title);
        sb.Append(", vendor: " + this.vendor);
        sb.Append(", barcode: " + this.barcode);
        sb.Append(", price: " + this.price);

        return sb.ToString();
    }
}