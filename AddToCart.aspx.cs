using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;
using WingtipToys.Models;

namespace WingtipToys
{
  public partial class AddToCart : System.Web.UI.Page
  {
    private ProductContext _db = new ProductContext();

    protected void Page_Load(object sender, EventArgs e)
    {
      string rawId = Request.QueryString["ProductID"];
      int intRawId = Convert.ToInt16(rawId);
      var productItem = _db.Products.SingleOrDefault(
                 c => c.ProductID == intRawId);

      if (productItem.Inventory > 0)
      {
          productItem.Inventory = productItem.Inventory - 1;
          _db.SaveChanges();

          int productId;
          if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
          {
              using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
              {
                  usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
              }

          }
          else
          {
              Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
              throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
          }
          Response.Redirect("ShoppingCart.aspx");
      }
      else
          Response.Redirect("NoInventory.aspx");

    }
  }
}