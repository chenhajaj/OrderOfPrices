using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserInfo
/// </summary>
public class UserInfo
{
    public String userId { get; set; }
    public String assId { get; set; }
    public String bonus { get; set; }
    public UserInfo(string Id, string Ass) { userId = Id; assId = Ass; bonus = null; }
    public UserInfo(string Id, string Ass, string Bonus) { userId = Id; assId = Ass; bonus = Bonus; }
}
