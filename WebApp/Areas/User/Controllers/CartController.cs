using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Data;
using WebApp.Models;

namespace WebApp.Areas.User.Controllers
{
    [Area("User")]
    public class CartController : Controller
    {
        private readonly DPContext _context;
        public CartController(DPContext context)
        {
            _context = context;
        }
        public const string CARTKEY = "cart";
        public IActionResult Index()
        {
            ViewModel model = new ViewModel();
            model.Carts = GetCartItems();
            model.ProductTypes = _context.ProductType.ToList();
            model.Categories = _context.Categories.ToList();
            return View(model);
        }
        // Lấy cart từ Session (danh sách CartItem)
        List<Cart> GetCartItems()
        {

            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<Cart>>(jsoncart);
            }
            return new List<Cart>();
        }
        // Xóa cart khỏi session
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(List<Cart> ls)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(ls);
            session.SetString(CARTKEY, jsoncart);
        }
        public async Task<IActionResult> AddToCart(int? id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(product == null)
            {
                return NotFound();
            }
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == id);
            if(cartitem != null)
            {
                cartitem.Quantity++;
            }
            else
            {
                cart.Add(new Cart() { Quantity = 1, Product = product });
            }
            SaveCartSession(cart);
            return Ok();
        }
        public IActionResult UpdateCart(int productid, int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                // Đã tồn tại, tăng thêm 1
                cartitem.Quantity = quantity;
            }
            SaveCartSession(cart);
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return Ok();
        }
        public IActionResult RemoveItemCart(int? id)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.Product.Id == id);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }
            SaveCartSession(cart);
            ViewModel model = new ViewModel();
            model.Carts = GetCartItems();

            return View("Update-List-Cart",model);
        }
    }
}
