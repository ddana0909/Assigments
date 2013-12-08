using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly nwndEntities db;

        public HomeController()
        {
            db = new nwndEntities();
        }

        public ActionResult Index(int id = 0)
        {
            if (id != 0)
            {
                var ord = db.Orders.Where(o => o.EmployeeID == id);
                var orders = ord.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
              
                return View(orders.ToList());
            }
            return View(db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper).ToList());
        }

        public ActionResult EmployeeDetails(int id = 0)
        {
            Employee emp = db.Employees.Find(id);
            ViewBag.empName = db.Employees.Find(emp.ReportsTo).FirstName + " " + db.Employees.Find(emp.ReportsTo).LastName; //must be changed
            return PartialView("_EmployeeDetails", emp);
        }

        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName");
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        public ActionResult Delete(int id = 0)
        {
            var order = db.Orders.Where(o => o.OrderID == id);
            order.Include(o => o.Customer);
            return PartialView("_DeleteDetails", order.ToList());
        }

        public ActionResult DeleteConfirmed(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null)
            {
                var orderDetails = db.Order_Details.Where(o => o.OrderID == id);
                foreach (var orderDetail in orderDetails)
                {
                    db.Order_Details.Remove(orderDetail);
                }
                db.Orders.Remove(order);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}