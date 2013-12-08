using System.Data;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        const int PageSize = 5;

        private readonly NorthWindDataContext _db;

        public HomeController()
        {
            _db = new NorthWindDataContext();
        }

        public ActionResult Index(int pageNumber = 1, int employeeId = 0)
        {
            var orders = _db.Orders.Where(o => o.EmployeeID == employeeId || employeeId == 0).OrderBy(o => o.OrderID);

            return View(orders.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult EmployeeDetails(int employeeId = 0)
        {
            Employee emp = _db.Employees.Find(employeeId);

            ViewBag.empName = _db.Employees.Find(emp.ReportsTo).FirstName + " " + _db.Employees.Find(emp.ReportsTo).LastName; //must be changed
            return PartialView("_EmployeeDetails", emp);
        }

        public ActionResult Details(int orderId = 0)
        {
            var order = _db.Orders.Find(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        public ActionResult Edit(int orderId = 0)
        {
            var order = _db.Orders.Find(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }

            CreateSelectListItems(order);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(order).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            CreateSelectListItems(order);

            return View(order);
        }

        public ActionResult Delete(int orderId)
        {
            var order = _db.Orders.Find(orderId);

            if (order == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteDetails", order);
        }

        public ActionResult DeleteConfirmed(int orderId)
        {
            var order = _db.Orders.Find(orderId);

            if (order != null)
            {
                var orderDetails = _db.Order_Details.Where(o => o.OrderID == orderId);

                foreach (var orderDetail in orderDetails)
                {
                    _db.Order_Details.Remove(orderDetail);
                }

                _db.Orders.Remove(order);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        private void CreateSelectListItems(Order order)
        {
            ViewBag.Customers = new SelectList(_db.Customers.ToList(), "CustomerID", "CompanyName", order.CustomerID);
            ViewBag.Employees = new SelectList(_db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVias = new SelectList(_db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
        }
    }
}