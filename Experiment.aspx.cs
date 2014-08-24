using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;

public partial class Experiment : System.Web.UI.Page
{
    static Random rand = new Random();
    public static double time = rand.NextDouble() + 0.5 * (1.5 - 0.5);
    public static TimeSpan MinimumInterval = TimeSpan.FromSeconds(0.5);
    private const int NumberOfSets = 5;
    public static readonly string[] Sellers = new string[] { 
        "Clarences shop", "Daryls shop", "Shirleys shop", "Letties shop", "Sadyes shop", "Claudias shop", "Nanettes shop", "Scotties shop", "Columbuss shop", "Lakeshias shop", "Cindies shop", "Meris shop", "Rasheedas shop", "Karoles shop", "Delenas shop", "Daras shop", 
        "Tonys shop", "Antonys shop", "Tressas shop", "Yukikos shop", "Joies shop", "Alphonsos shop", "Earthas shop", "Lahomas shop", "Lauryns shop", "Ressies shop", "Elliots shop", "Anabels shop", "Horacios shop", "Ellans shop", "Lanettes shop", "Calebs shop", 
        "Leopoldos shop", "Clementes shop", "Kennys shop", "Lavernes shop", "Laras shop", "Trangs shop", "Amoss shop", "Lilliams shop", "Leidas shop", "Svetlanas shop", "Letishas shop", "Shans shop", "Melodees shop", "Vicentas shop", "Roxys shop", "Destinys shop", 
        "Libbies shop", "Horaces shop", "Hildreds shop", "Jeanmaries shop", "Celestinas shop", "Lakitas shop", "Kallies shop", "Shaynas shop", "Tamelas shop", "Tatums shop", "Penelopes shop", "Emmies shop", "Erasmos shop", "Chuns shop", "Douglass shop", "Heaths shop", 
        "Franks shop", "Mathas shop", "Matthews shop", "Khalilahs shop", "Lynnettes shop", "Lavinas shop", "Carlis shop", "Charlas shop", "Marnis shop", "Fernandes shop", "Edwins shop", "Terras shop", "Bennys shop", "Kaseys shop", "Kieras shop", "Tarahs shop", 
        "Erlindas shop"
     };
    private static Set[] Sets;

    protected void OnAgainButton_Click(object sender, EventArgs e)
    {
        int currentInteration = this.UserData.CurrentInteration;
        int currentSetIndex = this.UserData.CurrentSetIndex;
        int count = this.UserData.SortedSellerPrices.Count;
        int[] numArray = this.Session["Sampling"] as int[];
        numArray[currentInteration] = 0;
        this.Session["Sampling"] = numArray;
        SessionData userData = this.UserData;
        userData.CurrentInteration++;
        userData.CurrentSetIndex++;
        this.UserData.CurrentSetIndex = this.UserData.CurrentSetIndex % 5;
        Random random = new Random();
        double bonus = (random.NextDouble() * 0.06) - 0.03;
        if (bonus < 0.0)
        {
            bonus = 0.0;
        }
        this.Session["bonus"] = Convert.ToDouble(this.Session["Bonus"])*0.75 + bonus;
        string str = string.Concat(new object[] { "VALUES ('", currentSetIndex, "','", count, "','", 3, "','", 0, "','", (string)this.Session["userId"], "','", (string)this.Session["turkAss"], "','", Math.Round(bonus, 2), "')" });
        string str2 = "INSERT INTO Results (Product, GivenPrices, PopPrices, Sample, UserID, AssID, Bonus) " + str;
        using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ToString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = str2;
            command.ExecuteNonQuery();
        }
        if (this.UserData.CurrentInteration < 5)
        {
            base.Response.Redirect("NextProd.aspx");
        }
        else
        {
            base.Response.Redirect("Details.aspx");
        }
    }

    protected void OnNextButton_Click(object sender, EventArgs e)
    {
        int currentInteration = this.UserData.CurrentInteration;
        int currentSetIndex = this.UserData.CurrentSetIndex;
        int count = this.UserData.SortedSellerPrices.Count;
        double price = this.UserData.SortedSellerPrices[0].Price;
        double num4 = Math.Round(Sets[this.UserData.CurrentSetIndex].Bonus, 2);
        this.Session["bonus"] = Convert.ToDouble(this.Session["Bonus"]) + Math.Round(Sets[this.UserData.CurrentSetIndex].Bonus, 2);
        string str = string.Concat(new object[] { "VALUES ('", currentSetIndex, "','", count, "','", 3, "','", 1, "','", (string)this.Session["userId"], "','", (string)this.Session["turkAss"], "','", num4, "')" });
        string str2 = "INSERT INTO Results (Product, GivenPrices, PopPrices, Sample, UserID, AssID, Bonus) " + str;
        using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ToString()))
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = str2;
            command.ExecuteNonQuery();
        }
        int[] numArray = this.Session["Sampling"] as int[];
        numArray[currentInteration] = 1;
        this.Session["Sampling"] = numArray;
        SessionData userData = this.UserData;
        userData.CurrentInteration++;
        //SessionData data2 = this.UserData;
        userData.CurrentSetIndex++;
        this.UserData.CurrentSetIndex = this.UserData.CurrentSetIndex % 5;
        if (this.UserData.CurrentInteration < 5)
        {
            base.Response.Redirect("NoNextProd.aspx");
        }
        else
        {
            base.Response.Redirect("Details.aspx");
        }
    }

    protected void Buy_Click(object sender, EventArgs e)
    {
        this.Session["Procced"] = 0;
        this.Buy.Visible = false;
        this.Label2.Visible = true;
        this.Label6.Visible = true;
        this.Label6.Font.Bold = false;
        double num = Math.Round(Sets[this.UserData.CurrentSetIndex].Bonus, 2);
        double num2 = this.UserData.SortedSellerPrices[0].Price;
        this.Label6.Font.Size = 12;
        this.Label2.Font.Size = 12;
        Random random = new Random();
        double num3 = Math.Round((double)((1.0 + random.NextDouble()) * num), 2);
        this.Label6.Text = string.Concat(new object[] { "and try another random comparison shopping website for this product?<br> If you do find a better price (the current minimum price is $", num2, "), you will get the difference as a bonus for this step.<br> For example, if you find a price of $", (num2 - num) - num3, ", you will get ", num + num3, "$ as a bonus, but if you find a price of $", num2 + 0.1, ", you will not get a bonus.<br>Based on the current prices, would you like to use the additional random web-site?" });
        this.Label2.Text = "Great! you just got a bonus of $" + num + " for completing this step.<br> Would you like to <b>give away this bonus";
        this.Again.Visible = true;
        this.Next.Visible = true;
        StringBuilder builder = new StringBuilder();
        foreach (SellerPrice price in this.UserData.SortedSellerPrices)
        {
            builder.AppendFormat("<span>{0}</span></br>", price);
        }
        (this.sellerPricesTextBox.Controls[0] as LiteralControl).Text = builder.ToString();
        this.minPriceLabel.Text = num2.ToString();
        this.minSellerLabel.Text = this.UserData.SortedSellerPrices[0].Seller;
    }

    public static void LoadSets()
    {
        lock (typeof(Set))
        {
            if (Sets == null)
            {
                Sets = new Set[5];
                int num = 0;
                for (int i = 0; i < Sets.Length; i++)
                {
                    int num3 = i + 1;
                    string line = "SamP" + num3;
                    string prices = ConfigurationManager.ConnectionStrings[line].ToString();
                    string order = ConfigurationManager.ConnectionStrings[line + "O"].ToString();
                    Set set = new Set
                    {
                        Index = i,
                        ProductId = num3 + "_H"
                    };
                    string[] pricesArr = prices.Split(new char[] { ' ' });
                    foreach (string str4 in order.Split(new char[] { ' ' }))
                    {
                        int index = int.Parse(str4) - 1;
                        string seller = Sellers[(index + num) % Sellers.Length];
                        double num5 = double.Parse(pricesArr[index]);
                        SellerPrice item = new SellerPrice(seller, num5);
                        set.Add(item);
                    }
                    num += pricesArr.Length;
                    set.Bonus = 0.08 + ((set.Count * 4.8) / 3600.0);
                    Sets[i] = set;
					
                }
            }
        }
    }

    [WebMethod]
    public static object OnNewPrice()
    {
        SessionData data = HttpContext.Current.Session["SessionData"] as SessionData;
        TimeSpan timeOfDay = DateTime.Now.TimeOfDay;
        time = rand.NextDouble() + 0.25 * (1.75 - 0.25);
        MinimumInterval = TimeSpan.FromSeconds(0.5);
        if ((timeOfDay - data.LastUpdateTime) < MinimumInterval)
        {
            return string.Empty;
        }
        data.LastUpdateTime = timeOfDay;
        int count = data.SortedSellerPrices.Count;
        Set set = Sets[data.CurrentSetIndex];
        if (data.SortedSellerPrices.Count >= set.Count)
        {
            return string.Empty;
        }
        SellerPrice item = set.Items[count];
        data.SortedSellerPrices.Add(item);
        data.SortedSellerPrices.Sort();

        var json = new {
            Index = data.SortedSellerPrices.IndexOf(item),
            Price = item.Price, 
            Seller = item.Seller.Replace("'", ""),
            IsLast = count == (set.Count - 1) 
        };
        return json;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
			if (Sets==null)
				this.UserData.CurrentSetIndex=rand.Next(0, 4);
            LoadSets();
            this.interationLabel.Text = (this.UserData.CurrentInteration + 1).ToString();
            Set set1 = Sets[this.UserData.CurrentSetIndex];
            this.UserData.SortedSellerPrices = new List<SellerPrice>();
        }
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