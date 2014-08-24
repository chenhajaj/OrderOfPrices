using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Set
/// </summary>
public class Set
{
    public double Bonus;
    public int Count { get { return Items.Count; } }
    public int Index;
    public string ProductId;
    public List<SellerPrice> Items;//check

	public Set()
	{
		//
		// TODO: Add constructor logic here
		//
        Items = new List<SellerPrice>();
	}

    public void Add(SellerPrice item)
    {
        Items.Add(item);        
    }
}