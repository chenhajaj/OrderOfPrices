using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SessionData
/// </summary>
public class SessionData
{
    public List<SellerPrice> SortedSellerPrices;
    public int CurrentInteration;
    public int CurrentSetIndex;
    public TimeSpan LastUpdateTime;

	public SessionData()
	{
        SortedSellerPrices = new List<SellerPrice>();
        CurrentInteration = 0;
	}
    public void Add(SellerPrice item)
    {
        SortedSellerPrices.Add(item);
    }

}