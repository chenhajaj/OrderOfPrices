using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SellerPrice
/// </summary>
public class SellerPrice : IComparable 
{
    public string Seller;
    public double Price;
	public SellerPrice()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SellerPrice(string name, double price)
    {
        Seller = name;
        Price = price;
    }
    public int CompareTo(object obj)
    {        
        if (obj == null) 
            return 1;

        var otherSeller = obj as SellerPrice;

        //validation
        if (otherSeller == null)
            throw new ArgumentException("Object is not a Seller price");

        //compare
        var compare = this.Price.CompareTo(otherSeller.Price);
        return compare;
    }
    public override string ToString()
    {
        return string.Format("{0}: {1}", Seller, Price);
    }
}