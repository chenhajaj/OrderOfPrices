using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ASP;

using System.Configuration;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.Services;

public partial class Example : System.Web.UI.Page
{
    private static Set[] Eset;
    public static readonly TimeSpan MinimumInterval = TimeSpan.FromSeconds(1.0);
    private const int NumberOfSets = 1;
    public static readonly string[] Sellers = new string[] { 
        "Clarences shop", "Daryls shop", "Shirleys shop", "Letties shop", "Sadyes shop", "Claudias shop", "Nanettes shop", "Scotties shop", "Columbuss shop", "Lakeshias shop", "Cindies shop", "Meris shop", "Rasheedas shop", "Karoles shop", "Delenas shop", "Daras shop", 
        "Tonys shop", "Antonys shop", "Tressas shop", "Yukikos shop", "Joies shop", "Alphonsos shop", "Earthas shop", "Lahomas shop", "Lauryns shop", "Ressies shop", "Elliots shop", "Anabels shop", "Horacios shop", "Ellans shop", "Lanettes shop", "Calebs shop", 
        "Leopoldos shop", "Clementes shop", "Kennys shop", "Lavernes shop", "Laras shop", "Trangs shop", "Amoss shop", "Lilliams shop", "Leidas shop", "Svetlanas shop", "Letishas shop", "Shans shop", "Melodees shop", "Vicentas shop", "Roxys shop", "Destinys shop", 
        "Libbies shop", "Horaces shop", "Hildreds shop", "Jeanmaries shop", "Celestinas shop", "Lakitas shop", "Kallies shop", "Shaynas shop", "Tamelas shop", "Tatums shop", "Penelopes shop", "Emmies shop", "Erasmos shop", "Chuns shop", "Douglass shop", "Heaths shop", 
        "Franks shop", "Mathas shop", "Matthews shop", "Khalilahs shop", "Lynnettes shop", "Lavinas shop", "Carlis shop", "Charlas shop", "Marnis shop", "Fernandes shop", "Edwins shop", "Terras shop", "Bennys shop", "Kaseys shop", "Kieras shop", "Tarahs shop", 
        "Erlindas shop"
     };

    protected void Buy_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Questions.aspx");
    }

    public static void LoadSet()
    {
        lock (typeof(Set))
        {
            Eset = new Set[1];
            int num = 10;
            for (int i = 0; i < 1; i++)
            {
                int num3 = i + 1;
                string str = "SamP" + num3 + "_E";
                string str2 = ConfigurationManager.ConnectionStrings[str].ToString();
                Set set = new Set
                {
                    Index = i,
                    ProductId = num3 + "_H"
                };
                string[] strArray = str2.Split(new char[] { ' ' });
                for (int j = 0; j < strArray.Length; j++)
                {
                    string seller = Sellers[(j + num) % Sellers.Length];
                    double num5 = double.Parse(strArray[j]);
                    SellerPrice item = new SellerPrice(seller, num5);
                    set.Add(item);
                }
                set.Bonus = 0.08 + ((set.Count * 4.8) / 3600.0);
                Eset[i] = set;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSet();
        Set set = Eset[0];
        if (!base.IsPostBack)
        {
            this.UserData.SortedSellerPrices = new List<SellerPrice>();
            this.UserData.CurrentSetIndex = 0;
        }
    }

    [WebMethod]
    public static object OnNewPrice()
    {
        SessionData data = HttpContext.Current.Session["SessionData"] as SessionData;
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        if ((timeOfDay - data.LastUpdateTime) < MinimumInterval)
        {
            return string.Empty;
        }
        data.LastUpdateTime = timeOfDay;
        int count = data.SortedSellerPrices.Count;
        Set set = Eset[data.CurrentSetIndex];
        if (data.SortedSellerPrices.Count >= set.Count)
        {
            return string.Empty;
        }
        SellerPrice item = set.Items[count];
        data.SortedSellerPrices.Add(item);
        data.SortedSellerPrices.Sort();
        return new { 
            Index = data.SortedSellerPrices.IndexOf(item),
            Price = item.Price, 
            Seller = item.Seller.Replace("'", ""), 
            IsLast = count == (set.Count - 1)
        };
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    }

    public SessionData UserData
    {
        
        get
        {
            return (SessionData)this.Session["SessionData"];
        }
    }
}